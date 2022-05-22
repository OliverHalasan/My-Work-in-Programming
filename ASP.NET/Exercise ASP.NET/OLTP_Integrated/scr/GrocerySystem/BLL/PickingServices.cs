#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using GrocerySystem.Models;
using GrocerySystem.DAL;
using GrocerySystem.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
#endregion


namespace GrocerySystem.BLL
{
    public class PickingServices
    {
        #region Constructor and DI variable setup
        private readonly GrocerylistContext _context;

        internal PickingServices(GrocerylistContext context)
        {
            _context = context;
        }
        #endregion

        #region Query
        public QueryOrderList Picking_GetPickingOrder(int orderid,
                                             int pickerid)
        {
            QueryOrderList info = _context.Orders
                                 .Where(x => x.OrderID == orderid)
                                 .Select(x => new QueryOrderList
                                 {
                                     PickerName = _context.Pickers
                                                    .Where(y => y.PickerID == pickerid)
                                                    .Select(x => x.FirstName + " " + x.LastName)
                                                    .FirstOrDefault(),
                                     CustomerName = x.Customer.FirstName + " " + x.Customer.LastName,
                                     CustomerPhone = x.Customer.Phone,
                                     OrderedItems = x.OrderLists
                                                    .Select(o => new QueryOrderListItem
                                                    {
                                                        OrderListId = o.OrderListID,
                                                        ProductId = o.ProductID,
                                                        Description = o.Product.Description,
                                                        OrderQty = o.QtyOrdered,
                                                        OrderComment = o.CustomerComment
                                                    })
                                                    .ToList()
                                 }).FirstOrDefault();
            return info;

        }
        #endregion

        #region Command
        public void Picking_RecordPicking(int orderid, int pickerid, List<PickedItem> orderitems)
        {
            #region TODO: Student Code Here
            // TODO: Student Code Here
            Picker pickers = null;
            Order orders = null;


            if (orderid == 0)
            {
                throw new Exception("Order does not exist");
            }

            if (pickerid == 0)
            {
                throw new Exception("Picker does not exist");
            }

            pickers = _context.Pickers
                               .Where(x => x.PickerID == pickerid)
                               .Select(x => x)
                               .FirstOrDefault();

            orders = _context.Orders
                            .Where(x => x.OrderID == orderid)
                            .Select(x => x)
                            .FirstOrDefault();
            if (pickers == null)
            {
                throw new Exception("there is no pickers assigend");    
            }
            if (orders == null)
            {
                throw new Exception("orders is null");
            }

            if (pickers.StoreID != orders.StoreID)
            {
                throw new Exception("Picker is not been assigned to the store where the order has been placed. ");
            }

            if (orders.OrderLists.Count() < 1)
            {
                throw new Exception("Order list cannot be empty");
            }

            foreach (var orderItem in orders.OrderLists)
            {
                Product productExists = null;

                productExists = _context.Products
                                .Where(x => x.ProductID == orderItem.ProductID)
                                .Select(x => x)
                                .FirstOrDefault()
                                ;

                if (productExists == null)
                {
                    throw new Exception("Order item does not exist ");
                }
            }

            foreach (var orderItem in orders.OrderLists)
            {
                if (orderItem.QtyPicked < 0)
                {
                    throw new Exception("One or more items have a negative quantity picked. ");
                }
            }

            foreach (var orderItem in orders.OrderLists)
            {
                if (orderItem.QtyOrdered != orderItem.QtyPicked)
                {
                    if (string.IsNullOrWhiteSpace(orderItem.PickIssue))
                    {
                        throw new Exception("One or more items are missing a pick issue. ");
                    }
                }
            }


            //Rules:
            //Order exists
            //Picker exists
            //Picker assigned to store where order is placed.
            //List has at least one item picked
            //Each Order item exists
            //Every item picked quantity is positive (greater or equal to zero)
            //Any item that is picked that has a picked quanity not equal to the ordered qty must have a picked concern  
            //Update OrderList items quantity picked, product price, product discount, Pick issue
            //Update Order picker, last date updated (today), subtotal, gst, status (R)

            #endregion
        }
        #endregion


    }
}
