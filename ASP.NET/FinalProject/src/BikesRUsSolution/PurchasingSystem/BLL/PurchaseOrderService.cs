using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PurchasingSystem.ViewModels;
using PurchasingSystem.DAL;
using PurchasingSystem.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace PurchasingSystem.BLL
{
    public class PurchaseOrderService
    {
        #region Constructor and Context Dependency
        private readonly PurchasingDbContext _context;
        internal PurchaseOrderService(PurchasingDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Services : Queries
        public PurchaseInfo GetAllPurchaseOrder(int vendorid)
        {
            PurchaseInfo purchaseInfo = _context.PurchaseOrders
                                        .Where(x => x.VendorID == vendorid
                                                    && x.OrderDate == null
                                                    && x.Closed == false)
                                        .Select(x => new PurchaseInfo
                                        {
                                            PurchaseOrderID = x.PurchaseOrderID,
                                            PurchaseOrderNumber = x.PurchaseOrderNumber,
                                            SubTotal = x.SubTotal
                                        })
                                        .FirstOrDefault();
            return purchaseInfo;
        }

        public List<PartsInfo> GetAllOrderParts(int purchaseorderid)
        {
            List<PartsInfo> Orderparts = _context.PurchaseOrderDetails
                                    .Where(x => x.PurchaseOrderID == purchaseorderid)
                                    .Select(x => new PartsInfo
                                    {
                                        PartID = x.PartID,
                                        Description = x.Part.Description,
                                        QuantityOnHand = x.Part.QuantityOnHand,
                                        ReorderLevel = x.Part.ReorderLevel,
                                        QuantityOnOrder = x.Part.QuantityOnOrder,
                                        QuantityToOrder = x.Quantity,
                                        PurchasePrice = x.Part.PurchasePrice
                                    })
                                    .ToList();
            return Orderparts;
        }

        public List<PartsInfo> GetAllRecommendedParts(int vendorid, int purchaseorderid)
        {
            List<PartsInfo> AllVendorsParts = _context.Parts
                                              .Where(x => x.VendorID == vendorid)
                                              .Select(x => new PartsInfo
                                              {
                                                  PartID = x.PartID,
                                                  Description = x.Description,
                                                  QuantityOnHand = x.QuantityOnHand,
                                                  ReorderLevel = x.ReorderLevel,
                                                  QuantityOnOrder = x.QuantityOnOrder,
                                                  PurchasePrice = x.PurchasePrice
                                              })
                                              .ToList();
            List<PartsInfo> orderParts = GetAllOrderParts(purchaseorderid);
            List<PartsInfo> partsRecommended = new List<PartsInfo>();

            if (purchaseorderid != 0)
            {
                foreach (var part in AllVendorsParts)
                {
                    bool PartsInOrder = false;
                    foreach (var PartsOrder in orderParts)
                    {
                        if (part.PartID == PartsOrder.PartID)
                        {
                            PartsInOrder = true;
                        }
                    }

                    if (!PartsInOrder)
                    {
                        partsRecommended.Add(part);
                    }
                }
            }
            else
            {
                List<PartsInfo> vendorsParts = _context.Parts
                                                .Where(x => x.VendorID == vendorid)
                                                .Select(x => new PartsInfo
                                                {
                                                    PartID = x.PartID,
                                                    Description = x.Description,
                                                    QuantityOnHand = x.QuantityOnHand,
                                                    ReorderLevel = x.ReorderLevel,
                                                    QuantityOnOrder = x.QuantityOnOrder,
                                                    PurchasePrice = x.PurchasePrice
                                                })
                                                .ToList();
                List<PartsInfo> VendorsBuy = new List<PartsInfo>();

                foreach (var part in vendorsParts)
                {
                    if ((part.ReorderLevel - (part.QuantityOnOrder + part.QuantityOnOrder)) > 0)
                    {
                        VendorsBuy.Add(part);
                    }
                }

                partsRecommended = VendorsBuy;
            }
            return partsRecommended;


        }

        public PurchaseInfo SuggestedOrder(int vendorid)
        {
            int higestOrderNum = _context.PurchaseOrders
                                .Select(x => x.PurchaseOrderNumber)
                                .Max();
            PurchaseInfo SuggestedPurchaseOrder = new PurchaseInfo()
            {
                PurchaseOrderNumber = higestOrderNum + 1
            };

            return SuggestedPurchaseOrder;
        }

        public int DeletePurchaseOrder(int purchaseorderid)
        {
            PurchaseOrder PurchaseOrderInstance = _context.PurchaseOrders
                .Where(x => x.PurchaseOrderNumber == purchaseorderid)
                .Select(x =>x)
                .FirstOrDefault();

            if (PurchaseOrderInstance == null)
            {
                throw new Exception("Purchase Order do not exist");
            }  
            
            if (PurchaseOrderInstance.OrderDate.HasValue)
            {
                throw new Exception("It's not allowed to remove an order that has already been placed.");
            }

            EntityEntry<PurchaseOrder> PurchaseOrderDelete = _context.Entry(PurchaseOrderInstance);
            PurchaseOrderDelete.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return _context.SaveChanges();
        }

        public int PlacePurchaseOrder(PurchaseInfo purchaseInfo, List<PartsInfo> partsInfos, int vendorid)
        {
            decimal subtotal = (decimal)0.0;
            foreach (var part in partsInfos)
            {
                subtotal += part.PurchasePrice;
            }
            decimal tax = subtotal * (decimal)0.05;
            decimal total = subtotal + tax;

            if (purchaseInfo.PurchaseOrderID == 0)
            {
                int highestOrderNum = _context.PurchaseOrders
                            .Select(x => x.PurchaseOrderNumber)
                            .Max();

                PurchaseOrder NewPurchaseOrder = new PurchaseOrder()
                {
                    PurchaseOrderNumber = highestOrderNum + 1,
                    TaxAmount = tax,
                    SubTotal = subtotal,
                    VendorID = vendorid
                };

                foreach (var part in partsInfos)
                {
                    Part TempPart = _context.Parts
                                    .Where(x => x.PartID == part.PartID)
                                    .Select(x => x)
                                    .FirstOrDefault();
                }
                NewPurchaseOrder.OrderDate = DateTime.Now;
                NewPurchaseOrder.Closed = true;

                EntityEntry<PurchaseOrder> AddPurchaseOrder = _context.Entry(NewPurchaseOrder);
                AddPurchaseOrder.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {
                PurchaseOrder CurrentPurchaseOrder = _context.PurchaseOrders
                                                     .Where(x => x.PurchaseOrderID == purchaseInfo.PurchaseOrderID)
                                                     .Select(x => x)
                                                     .FirstOrDefault();
                foreach (var part in partsInfos)
                {
                    Part TempParts = _context.Parts
                                    .Where(x => x.PartID == part.PartID)
                                    .Select(x => x)
                                    .FirstOrDefault();
                };
                CurrentPurchaseOrder.SubTotal = subtotal;
                CurrentPurchaseOrder.TaxAmount = tax;
                CurrentPurchaseOrder.OrderDate = DateTime.Now;
                CurrentPurchaseOrder.Closed = true;

                EntityEntry<PurchaseOrder> AddPurchaseOrder = _context.Entry(CurrentPurchaseOrder);
                AddPurchaseOrder.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
           
            return _context.SaveChanges();
        }
        #endregion
    }
}
