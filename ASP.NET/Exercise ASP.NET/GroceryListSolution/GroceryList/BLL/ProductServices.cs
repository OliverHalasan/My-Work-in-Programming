using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryList.DAL;
using GroceryList.Entities;
using GroceryList.ViewModels;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GroceryList.BLL
{
    public class ProductServices
    {
        private readonly GrocerylistContext _context;

        internal ProductServices(GrocerylistContext context)
        {
            _context = context;
        }

        public List<ProductList> Product_getProductsByCategory(int categoryid,
                                                   int pageNumber,
                                                   int pagesize,
                                                   out int totalrows)
        {
            IEnumerable<ProductList> info = _context.Products
                                            .Where(x => x.CategoryID == categoryid)
                                            .Select(x => new ProductList
                                            {
                                                ProductID = x.ProductID,
                                                Description = x.Description,
                                                Price = x.Price,
                                                Discount = x.Price * (1 - x.Discount),
                                                UnitSize = x.UnitSize,
                                                Taxable = x.Taxable


                                            })
                                            .Distinct()
                                            .OrderBy(x => x.Description);
            totalrows = info.Count();
            int skipRows = (pageNumber - 1) * pagesize;
            return info.Skip(skipRows).Take(pagesize).ToList();
        }

        public ProductList Product_getProductById(int productid)
        {
            ProductList info = _context.Products
                            .Where(x => x.ProductID == productid)
                            .Select(x => new ProductList
                            {
                                ProductID = x.ProductID,
                                Description = x.Description,
                                Price = x.Price,
                                Discount = x.Discount,
                                UnitSize = x.UnitSize,
                                CategoryID = x.CategoryID,
                                Taxable = x.Taxable
                            })
                            .FirstOrDefault();

            return info;
        }
        public int AddProduct(ProductList item)
        {
           
            Product exist = _context.Products
                            .Where(x => x.ProductID.Equals(item.ProductID)
                                     && x.ProductID == item.ProductID
                                     && x.Description == item.Description
                                     && x.Price == item.Price
                                     && x.Discount == item.Discount
                                     && x.UnitSize == item.UnitSize
                                     && x.CategoryID == item.CategoryID
                                     && x.Taxable == item.Taxable)
                            .FirstOrDefault();
            if (exist != null)
            {
                throw new Exception("Product already exists on file");
            }

            exist = new Product
            {
                ProductID = item.ProductID,
                Description = item.Description,
                Price = item.Price,
                Discount = item.Discount,
                UnitSize = item.UnitSize,
                CategoryID = item.CategoryID,
                Taxable = item.Taxable,
            };
            _context.Add(exist);            
            _context.SaveChanges();
            return exist.ProductID;
        }
        public int UpdateProduct(ProductList item)
        {
            Product exist = _context.Products
                            .Where(x => x.ProductID == item.ProductID)
                            .FirstOrDefault();
            if (exist == null)
            {
                throw new Exception("Product does not exist on file");
            }

            exist.Description = item.Description;
            exist.Price = item.Price;
            exist.Discount = item.Discount;
            exist.UnitSize = item.UnitSize;
            exist.CategoryID = item.CategoryID;
            exist.Taxable = item.Taxable;

            //stage add in local memory
            EntityEntry<Product> updating = _context.Entry(exist);
            updating.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return _context.SaveChanges();

        }
        public int DeleteProduct(ProductList item)
        {
            Product exist = _context.Products
                           .Where(x => x.ProductID == item.ProductID)
                           .FirstOrDefault();
            if (exist == null)
            {
                throw new Exception("Product does not exist on file");
            }

            exist.Description = item.Description;
            exist.Price = item.Price;
            exist.Discount = item.Discount;
            exist.UnitSize = item.UnitSize;
            exist.CategoryID = item.CategoryID;
            exist.Taxable = item.Taxable;

            EntityEntry<Product> deleting = _context.Entry(exist);
            deleting.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

            return _context.SaveChanges();
        }
    }
}
