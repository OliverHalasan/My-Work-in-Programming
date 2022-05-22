using SalesSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesSystem.ViewModels;
using SalesSystem.Entities;

namespace SalesSystem.BLL
{
    public class SalesSystemServices
    {
        private readonly SalesDbContext _context;
        public List<SaleDetailsViewModel> cart;
        internal SalesSystemServices(SalesDbContext context)
        {
            _context = context ?? throw new ArgumentNullException();
            cart = new List<SaleDetailsViewModel>();
        }

        public List<CategoryViewModel> ListCategories()
        {
            Console.WriteLine($"SalesSystemServices: ListCategories();");
            List<CategoryViewModel> categories = _context.Categories
                .Select(c => new CategoryViewModel
                {
                    CategoryID = c.CategoryID,
                    Description = c.Description
                }).OrderBy(x => x.Description).ToList();

            return categories;
        }

        public List<PartViewModel> ListParts()
        {
            Console.WriteLine($"SalesSystemServices: ListParts();");
            List<PartViewModel> parts = _context.Parts
                .Select(c => new PartViewModel
                {
                    PartID = c.PartID,
                    Description = c.Description,
                    CategoryID = c.CategoryID,
                    QuantityOnHand = c.QuantityOnHand
                }).OrderBy(x => x.Description).ToList();

            return parts;
        }

        public List<PartViewModel> ListPartsByCategory(int categoryID)
        {
            Console.WriteLine($"SalesSystemServices: ListPartsByCategory();");
            List<PartViewModel> parts = _context.Parts
                .Where(c => c.CategoryID == categoryID)
                .Select(c => new PartViewModel
                {
                    PartID = c.PartID,
                    Description = c.Description,
                    CategoryID = c.CategoryID,
                    QuantityOnHand = c.QuantityOnHand
                }).OrderBy(x => x.Description).ToList();

            return parts;
        }

        public PartViewModel ListPartByPartID(int partID)
        {
            Console.WriteLine($"SalesSystemServices: ListPartsByPartID();");
            PartViewModel part = _context.Parts
                .Where(c => c.PartID == partID)
                .Select(c => new PartViewModel
                {
                    PartID = c.PartID,
                    Description = c.Description,
                    CategoryID = c.CategoryID,
                    QuantityOnHand = c.QuantityOnHand
                }).OrderBy(x => x.Description).FirstOrDefault();

            return part;
        }

        public void StageSaleDetail(SaleDetailsViewModel detail)
        {
            SaleDetail newdetail = new SaleDetail
            {
                Part = _context.Parts.Where(x => x.PartID == detail.PartID).FirstOrDefault(),
                PartID = detail.PartID,
                Quantity = detail.Quantity,
                SellingPrice = detail.Price,
                SaleID = 123
            };

            _context.SaleDetails.Add(newdetail);
        }

        public List<SaleDetailsViewModel> Test()
        {
            List<SaleDetailsViewModel> temp = new List<SaleDetailsViewModel>();


            //var addedEntities = dbContext.ChangeTracker.Entries()
            //          .Where(x => x.State == EntityState.Added && x.Entity is Mytable)
            //          .Select(x => x.Entity as MyTable)
            //          .Where(t => --criteria--);

            var addedEntities = _context.ChangeTracker.Entries()
                                .Where(x => x.State == Microsoft.EntityFrameworkCore.EntityState.Added && x.Entity is SaleDetail)
                                .Select(x => x.Entity as SaleDetail).ToList();

            foreach (var item in addedEntities)
            {
                SaleDetailsViewModel saleItem = new SaleDetailsViewModel();
                //saleItem.PartDescription = item.Part.Description;
                saleItem.Price = item.SellingPrice;
                saleItem.Quantity = item.Quantity;
                saleItem.Total = item.SellingPrice * item.Quantity;

                temp.Add(saleItem);
            }

            return temp;
        }
    }
}
