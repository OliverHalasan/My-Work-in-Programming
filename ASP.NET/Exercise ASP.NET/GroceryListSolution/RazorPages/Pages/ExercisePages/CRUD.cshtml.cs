using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using GroceryList.BLL;
using GroceryList.ViewModels;

namespace RazorPages.Pages.ExercisePages
{
    public class CRUDModel : PageModel
    {
        private readonly ProductServices _productservices;
        private readonly CategoryServices _categoryservices;

        [TempData]
        public string FeedBackMessage { get; set; }
        public string ErrorMessage { get; set; }

        public CRUDModel(ProductServices productservices, CategoryServices categoryservices)
        {
            _productservices = productservices;
            _categoryservices = categoryservices;
        }

        [BindProperty(SupportsGet = true)]
        public int? productid { get; set; }
        [BindProperty]
        public ProductList Product { get; set; }
        [BindProperty]
        public List<SelectionList> Categories { get; set; }

        public void OnGet()
        {
            Categories = _categoryservices.GetAllCategories();

            if (productid.HasValue && productid > 0)
            {
                Product = _productservices.Product_getProductById((int)productid);
            }
        }
        public IActionResult OnPostNew()
        {
            try
            {
                productid = _productservices.AddProduct(Product);
                FeedBackMessage = $"Product ({productid}) has been added";
                //the response to the browser  is a Post Redirect Get pattern 
                return RedirectToPage(new { productid = productid });
            }
            catch (Exception ex)
            {
                ErrorMessage = GetInnerException(ex).Message;
                Categories = _categoryservices.GetAllCategories();
                //the response to the browser is the result of Post processing
                //this means the OnGet() will not be executed
                return Page();
            }

        }
        public IActionResult OnPostUpdate()
        {
            try
            {
                if (productid.HasValue)
                {
                    int rowaffected = _productservices.UpdateProduct(Product);
                    if (rowaffected > 0)
                    {
                        FeedBackMessage = "Product has been updated";
                    }
                    else
                    {
                        FeedBackMessage = "No Product update. Product does not exist";
                    }
                }
                else
                {
                    FeedBackMessage = "Find an Product to maintain before attempting the update";
                }
                //the response to the browser  is a Post Redirect Get pattern 
                return RedirectToPage(new { productid = productid });
            }
            catch (Exception ex)
            {
                ErrorMessage = GetInnerException(ex).Message;
                Categories = _categoryservices.GetAllCategories();
                //the response to the browser is the result of Post processing
                //this means the OnGet() will not be executed
                return Page();
            }

        }

        private Exception GetInnerException(Exception ex)
        {
            while (ex.InnerException != null)
            {
                //promote the InnerException to be the Exception
                //this loop will continue until to get to the most InnerException
                //      which is your actual error you wish to see
                ex = ex.InnerException;
            }
            return ex;
        }
        public IActionResult OnPostDelete()
        {
            try
            {
                if (productid.HasValue)
                {
                    int rowaffected = _productservices.DeleteProduct(Product);
                    if (rowaffected > 0)
                    {
                        FeedBackMessage = "Product has been removed";
                    }
                    else
                    {
                        FeedBackMessage = "No Product remove. Product does not exist";
                    }
                    //remove your pkey value you are hanging on to for Post Get Redirect
                    productid = null;
                }
                else
                {
                    FeedBackMessage = "Find an Product to review before attempting the delete";
                }
                return RedirectToPage(new { productid = productid });
            }
            catch (Exception ex)
            {
                ErrorMessage = GetInnerException(ex).Message;
                Categories = _categoryservices.GetAllCategories();
                return Page();
            }

        }
        public IActionResult OnPostSearch()
        {
            return RedirectToPage("/ExercisePages/Query");
        }
    }
}
