#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using ReceivingSystem.Models;
using ReceivingSystem.DAL;
using ReceivingSystem.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
#endregion

namespace ReceivingSystem.BLL
{
    public class ReceivingServices
    {
        #region Constructor and DI variable setup
        private readonly ReceivingDbContext _context;

        internal ReceivingServices(ReceivingDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Query
        public List<OutstandingOrdersQuery> GetOutstandingOrders()
        {
            IEnumerable<OutstandingOrdersQuery> info = _context.PurchaseOrders
                                .Where(x => x.Closed == false && x.OrderDate != null)
                                .Select(x => new OutstandingOrdersQuery
                                {
                                    PurchaseOrderNumber = x.PurchaseOrderNumber,
                                    OrderDate = x.OrderDate,
                                    VendorName = x.Vendor.VendorName,
                                    Phone = x.Vendor.Phone,
                                    PurchaseOrderID = x.PurchaseOrderID,
                                });
            return info.ToList();
        }

        public OutstandingOrdersQuery GetOutstandingOrderInfo(int PurchaseOrderID)
        {
            OutstandingOrdersQuery info = _context.PurchaseOrders
                                .Where(x => x.PurchaseOrderID == PurchaseOrderID)
                                .OrderBy(x => x.PurchaseOrderID)
                                .Select(x => new OutstandingOrdersQuery
                                {
                                    PurchaseOrderNumber = x.PurchaseOrderNumber,
                                    OrderDate = x.OrderDate,
                                    VendorName = x.Vendor.VendorName,
                                    Phone = x.Vendor.Phone,
                                    OutstandingOrderDetails = x.PurchaseOrderDetails
                                            .Select(o => new OrderInfo
                                            {
                                                PurchaseOrderDetailId = o.PurchaseOrderDetailID,
                                                PartID = o.Part.PartID,
                                                Description = o.Part.Description,
                                                OriginalQty = o.Quantity,
                                                OutstandingQty = o.Quantity - o.ReceiveOrderDetails.Sum(x => x.QuantityReceived)
                                            })
                                            .OrderBy(o => o.PartID)
                                             .ToList()
                                }).FirstOrDefault();
            return info;

        }
        #endregion

        #region Process - Record Receiving Order
        public void ReceivingRecord(int purchaseorderID, List<ReceivedItem> receivedItems, List<UnorderedItem> unorderedItems, int employeeID)
        {

            ReceiveOrder newReceiveOrder = null;
            ReceiveOrderDetail newReceiveOrderDetail = null;
            ReturnedOrderDetail newReturnedOrderDetail = null;
            UnorderedPurchaseItemCart newUnorderedPurchaseItemCart = null;
            PurchaseOrder purchaseOrderExists = null;
            PurchaseOrderDetail purchaseOrderDetailExists = null;
            Employee employeeExists = null;

            int receivedItemsSum = 0;
            int canBeClosed = 0;
            bool isQunatityReceived = false;
            Part partExists = null;

            List<Exception> errorlist = new List<Exception>();

            newReceiveOrder = new ReceiveOrder
            {
                PurchaseOrderID = purchaseorderID,
                ReceiveDate = DateTime.Now,
                EmployeeID = employeeID,
            };

            _context.Add(newReceiveOrder);

            if (purchaseorderID <= 0)
            {
                throw new ArgumentNullException($"PurchaseOrderID of {purchaseorderID} is invalid");
            }
            if (receivedItems == null)
            {
                throw new ArgumentNullException($"There are no items on order receiving list");
            }
            else
            {
                if (!receivedItems.Any())
                {
                    throw new ArgumentNullException($"There are no items on order receiving list");
                }
            }

            if (receivedItems == null && unorderedItems.Count == 0)
            {
                throw new ArgumentNullException($"There are no items on order receiving AND unordered list");
            }

            if (employeeID <= 0)
            {
                throw new ArgumentNullException($"Employee information is missing");
            }

            purchaseOrderExists = _context.PurchaseOrders
                        .Where(p => p.PurchaseOrderID == purchaseorderID)
                        .FirstOrDefault();

            employeeExists = _context.Employees
                            .Where(x => x.EmployeeID == employeeID)
                            .FirstOrDefault();


            if (purchaseOrderExists == null)
            {
                throw new ArgumentException($"PurchaseOrder {purchaseorderID} doesn't exists");
            }
            else
            {
                if (purchaseOrderExists.Closed == true)
                {
                    throw new ArgumentException($"PurchaseOrder {purchaseorderID} is already closed");
                }
            }

            if (employeeExists == null)
            {
                throw new ArgumentException($"Employee {employeeID} doesn't exists");
            }

            if (unorderedItems.Count != 0)
            {
                if (!unorderedItems.Any())
                {
                    throw new ArgumentNullException($"There are no items on order unorderedItems list");
                }
                else
                {
                    foreach (var item in unorderedItems)
                    {
                        if (item.Qunatity < 0)
                        {
                            errorlist.Add(new Exception($"Unordered item {item.Description} recieved quantity ({item.Qunatity}) must be positive"));
                        }

                        if (errorlist.Count > 0)
                        {
                            throw new AggregateException("Unable to process your request", errorlist);
                        }
                        else
                        {
                            _context.SaveChanges();
                        }

                        if (item.Qunatity > 0)
                        {
                            newUnorderedPurchaseItemCart = new UnorderedPurchaseItemCart
                            {
                                Description = item.Description,
                                VendorPartNumber = item.VendorPartNumber,
                                Quantity = item.Qunatity
                            };

                            _context.Add(newUnorderedPurchaseItemCart);

                            newReturnedOrderDetail = new ReturnedOrderDetail
                            {
                                ReceiveOrderID = newReceiveOrder.ReceiveOrderID,
                                ItemDescription = item.Description,
                                Quantity = item.Qunatity,
                                Reason = "Not Ordered",
                                VendorPartNumber = item.VendorPartNumber
                            };

                            _context.Add(newReturnedOrderDetail);

                        }
                    }

                }

            }

            foreach (var item in receivedItems)
            {
                if (item.ReceivedQty >= 0 || item.ReceivedQty < 0)
                    isQunatityReceived = true;
            }

            if (isQunatityReceived == true)
            {
                if (!receivedItems.Any())
                {
                    throw new ArgumentNullException($"There are no items on order receiving list");
                }
                else
                {
                    foreach (var item in receivedItems)
                    {
                        purchaseOrderDetailExists = _context.PurchaseOrderDetails
                                            .Where(x => x.PurchaseOrderDetailID == item.PurchaseOrderDetailId)
                                            .FirstOrDefault();
                        partExists = _context.Parts
                                    .Where(x => x.PartID == item.PartID)
                                    .FirstOrDefault();

                        if (purchaseOrderDetailExists == null)
                        {
                            errorlist.Add(new Exception($"PurchaseOrderDetails item {partExists.Description} no longer on the purchaseOrder"));
                        }
                        else
                        {
                            if (item.ReceivedQty < 0)
                            {
                                errorlist.Add(new Exception($"PurchaseOrderDetails item {partExists.Description} recieved quantity ({item.ReceivedQty}) must be positive"));
                            }

                            else
                            {
                                receivedItemsSum = _context.ReceiveOrderDetails
                                            .Where(x => x.PurchaseOrderDetail.PurchaseOrderDetailID == purchaseOrderDetailExists.PurchaseOrderDetailID)
                                             .Sum(x => x.QuantityReceived);

                                if (item.ReceivedQty > (purchaseOrderDetailExists.Quantity - receivedItemsSum))
                                {
                                    errorlist.Add(new Exception($"PurchaseOrderDetails item  {partExists.Description} picked quantity ({item.ReceivedQty}) cannot be greater than the Outstanding"));
                                }

                                if (item.ReceivedQty == (purchaseOrderDetailExists.Quantity - receivedItemsSum))
                                {
                                    canBeClosed++;
                                }
                            }

                            if (item.Return > 0 && string.IsNullOrWhiteSpace(item.Reason))
                            {
                                errorlist.Add(new Exception($"PurchaseOrderDetails item  {partExists.Description} returned quantity ({item.Return}) must have a reason"));
                            }

                            if (errorlist.Count > 0)
                            {
                                throw new AggregateException("Unable to process your request", errorlist);
                            }
                            else
                            {
                                _context.SaveChanges();
                            }
                            partExists.QuantityOnHand = partExists.QuantityOnHand + item.ReceivedQty;
                            partExists.QuantityOnOrder = partExists.QuantityOnOrder - item.ReceivedQty;

                            EntityEntry<Part> updatingPart = _context.Entry(partExists);
                            updatingPart.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                            if (item.ReceivedQty > 0)
                            {

                                newReceiveOrderDetail = new ReceiveOrderDetail
                                {
                                    ReceiveOrderID = newReceiveOrder.ReceiveOrderID,
                                    PurchaseOrderDetailID = item.PurchaseOrderDetailId,
                                    QuantityReceived = item.ReceivedQty

                                };

                                _context.Add(newReceiveOrderDetail);
                                //_context.SaveChanges();

                            }

                            if (item.Return > 0 && !string.IsNullOrWhiteSpace(item.Reason))
                            {
                                newReturnedOrderDetail = new ReturnedOrderDetail
                                {
                                    ReceiveOrderID = newReceiveOrder.ReceiveOrderID,
                                    PurchaseOrderDetailID = item.PurchaseOrderDetailId,
                                    ItemDescription = partExists.Description,
                                    Quantity = item.Return,
                                    Reason = item.Reason,
                                    VendorPartNumber = purchaseOrderDetailExists.VendorPartNumber
                                };

                                _context.Add(newReturnedOrderDetail);
                                //_context.SaveChanges();

                            }

                            if (canBeClosed == receivedItems.Count())
                            {
                                purchaseOrderExists.Closed = true;
                            }
                        }
                    }
                }
            }

            if (errorlist.Count > 0)
            {
                throw new AggregateException("Unable to process your request", errorlist);
            }
            else
            {
                _context.SaveChanges();
            }

            //throw new NotImplementedException("OnPostSave() Not Implemented");
        }

        #endregion

        #region Process - Force Close Outstanding Order
        public void ForceOutstandingOrder(int purchaseorderID, string closeReason, List<ReceivedItem> receivedItems)
        {
            PurchaseOrder purchaseOrderExists = null;
            PurchaseOrderDetail purchaseOrderDetailExists = null;
            Part partExists = null;


            List<Exception> errorlist = new List<Exception>();

            if (purchaseorderID <= 0)
            {
                throw new ArgumentNullException($"PurchaseOrderID of {purchaseorderID} is invlaid");
            }

            if (string.IsNullOrWhiteSpace(closeReason))
            {
                throw new ArgumentNullException($"Close Reason is required");
            }

            if (receivedItems == null)
            {
                throw new ArgumentNullException($"There are no items on order receiving list");
            }
            else
            {
                if (!receivedItems.Any())
                {
                    throw new ArgumentNullException($"There are no items on order receiving list");
                }
            }

            purchaseOrderExists = _context.PurchaseOrders
            .Where(p => p.PurchaseOrderID == purchaseorderID)
            .FirstOrDefault();


            if (purchaseOrderExists == null)
            {
                throw new ArgumentException($"PurchaseOrder {purchaseorderID} doesn't exists");
            }
            else
            {
                purchaseOrderExists.Closed = true;
                purchaseOrderExists.Notes = closeReason;
            }
            foreach (var item in receivedItems)
            {
                purchaseOrderDetailExists = _context.PurchaseOrderDetails
                                            .Where(x => x.PurchaseOrderDetailID == item.PurchaseOrderDetailId)
                                            .FirstOrDefault();

                partExists = _context.Parts
                            .Where(x => x.PartID == item.PartID)
                            .FirstOrDefault();

                if (purchaseOrderDetailExists == null)
                {
                    errorlist.Add(new Exception($"PurchaseOrderDetails item {partExists.Description} no longer on the purchaseOrder"));
                }
                else
                {
                    partExists.QuantityOnOrder = partExists.QuantityOnOrder - (partExists.QuantityOnOrder - purchaseOrderDetailExists.ReceiveOrderDetails.Sum(x => x.QuantityReceived));
                }
            }

            if (errorlist.Count > 0)
            {
                throw new AggregateException("Unable to process your request", errorlist);
            }
            else
            {
                _context.SaveChanges();
            }
        }
        #endregion
    }
}
