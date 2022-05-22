using AppSecurity.BLL;
using BikesRUs.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalesSystem.BLL;
using SalesSystem.ViewModels;

namespace BikesRUs.Pages.SalesPages
{
    public class IndexModel : PageModel
    {
        private readonly SalesSystemServices _service;
        public IndexModel(SalesSystemServices service)
        {
            _service = service;
        }
        [BindProperty]
        public int CategoryID { get; set; }

        public List<SelectionList> Categories { get; set; }
        [BindProperty]
        public int SelectedCategoryID { get; set; }

        [BindProperty]
        public int PartID { get; set; }

        public List<SelectionList> Parts { get; set; }
        [BindProperty]
        public int SelectedPartID { get; set; }
        [BindProperty]
        public int AddQuantity { get; set; }
        public List<SaleDetailsViewModel> SaleDetails { get; set; } = new List<SaleDetailsViewModel>();

        public void OnGet()
        {
            PopulateCategoryList();
            PopulatePartList(SelectedCategoryID);
        }

        public void OnPostCategory()
        {
            PopulateCategoryList();
            PopulatePartList(SelectedCategoryID);
            SaleDetails = _service.Test();
            //return RedirectToPage(new { SaleDetails = SaleDetails });
            //SaleDetails = SaleDetails;
        }

        public void OnPostAdd()
        {
            PopulateCategoryList();
            PopulatePartList(SelectedCategoryID);

            SaleDetailsViewModel detail = new SaleDetailsViewModel();
            detail.PartID = SelectedPartID;
            detail.PartDescription = _service.ListPartByPartID(SelectedPartID).Description;
            detail.Quantity = AddQuantity;
            detail.Price = 25.00M;
            detail.Total = detail.Price * detail.Quantity;

            //SaleDetails.Add(detail);

            _service.StageSaleDetail(detail);
            SaleDetails = _service.Test();
        }
        public void PopulateCategoryList()
        {
            Categories = new List<SelectionList>();
            List<CategoryViewModel> categoryList = new List<CategoryViewModel>();
            categoryList = _service.ListCategories();
            foreach (var category in categoryList)
            {
                Categories.Add(new SelectionList
                {
                    valueId = category.CategoryID,
                    DisplayText = category.Description
                });
            }
        }

        public void PopulatePartList(int categoryID)
        {
            Parts = new List<SelectionList>();
            List<PartViewModel> partList = new List<PartViewModel>();
            partList = categoryID != 0 ? _service.ListPartsByCategory(categoryID) : _service.ListParts();
            foreach (var part in partList)
            {
                Parts.Add(new SelectionList
                {
                    valueId = part.PartID,
                    DisplayText = part.Description + " (" + part.QuantityOnHand + ")"
                });
            }
        }


        public class SelectionList
        {
            public int valueId { get; set; }
            public string DisplayText { get; set; }
        }
    }
}
