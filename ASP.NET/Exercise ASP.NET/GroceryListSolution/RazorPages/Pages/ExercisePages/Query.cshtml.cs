using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using GroceryList.BLL;
using GroceryList.ViewModels;
using WebApp.Helpers;

namespace RazorPages.Pages.ExercisePages
{
    public class QueryModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly CategoryServices _categoryServices;
        private readonly ProductServices _productServices;

        public QueryModel(ILogger<IndexModel> logger, CategoryServices categoryServices, ProductServices productServices)
        {
            _logger = logger;
            _categoryServices = categoryServices;
            _productServices = productServices;
        }
        [TempData]
        public string FeedBack { get; set; }
        public bool HasFeedBack => !string.IsNullOrWhiteSpace(FeedBack);
        [TempData]
        public string ErrorMsg { get; set; }
        public bool HasErrorMsg => !string.IsNullOrWhiteSpace(ErrorMsg);

        [BindProperty]
        public List<SelectionList> Categories { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? categoryid { get; set; }
        [BindProperty]
        public List<ProductList> Products { get; set; }

        private const int PAGE_SIZE = 10;
        //instance for Paginator
        public Paginator Pager { get; set; }
        public void OnGet(int? currentPage)
        {
            Categories = _categoryServices.GetAllCategories();
            //Categories.Sort((x, y) => x.DisplayText.CompareTo(y.DisplayText));
            
            if (categoryid.HasValue && categoryid.Value > 0)
            {
                int pageNumber = currentPage.HasValue ? currentPage.Value : 1;
                PageState current = new(pageNumber, PAGE_SIZE);
                int totalrows = 0;
                Products = _productServices.Product_getProductsByCategory((int)categoryid,
                                                                        pageNumber, PAGE_SIZE, out totalrows);
                Pager = new Paginator(totalrows, current);
            }
        }

        public IActionResult OnPost()
        {
            if(categoryid == 0)
            {
                FeedBack = "You did not select a Category";
            }
            return RedirectToPage(new { categoryid = categoryid });
        }
        public IActionResult OnPostNew()
        {

            return RedirectToPage("/ExercisePages/CRUD");
        }
    }
}
