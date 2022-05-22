#nullable disable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


#region Additional Namespaces
using Microsoft.AspNetCore.Identity;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using BikesRUs.Data;
using AppSecurity.BLL;
using ReceivingSystem.BLL;
using ReceivingSystem.Models;

#endregion

namespace BikesRUs.Pages.ReceivingPages
{
    public class ReceivingModel : PageModel
    {

        #region Private variables and DI constructor
        private readonly ReceivingServices _receivingservices;
        private readonly UserManager<ApplicationUser> _UserManager;
        private readonly SecurityService _Security;

        public ReceivingModel(ReceivingServices receivingServices, UserManager<ApplicationUser> userManager,
                                           SecurityService security)
        {
            _UserManager = userManager;
            _Security = security;
            _receivingservices = receivingServices;
        }
        #endregion

        #region Messaging and Error Handling
        [TempData]
        public string FeedBackMessage { get; set; }

        public string ErrorMessage { get; set; }

        //a get property that returns the result of the lamda action
        public bool HasError => !string.IsNullOrWhiteSpace(ErrorMessage);
        public bool HasFeedBack => !string.IsNullOrWhiteSpace(FeedBackMessage);

        //used to display any collection of errors on web page
        public List<string> ErrorDetails { get; set; } = new();

        //PageModel local error list for collection 
        public List<Exception> Errors { get; set; } = new();

        #endregion

        #region Security
        public ApplicationUser AppUser { get; set; }
        public string EmployeeName { get; set; }
        #endregion

        [BindProperty]
        public OutstandingOrdersQuery OutstandingOrderInfo { get; set; }

        [BindProperty]
        public List<OutstandingOrdersQuery> OutstandingOrders { get; set; }

        [BindProperty]
        public List<ReceivedItem> ReceivedItems { get; set; }

        [BindProperty]
        public UnorderedItem UnorderedItems { get; set; }

        //[BindProperty(SupportsGet = true)]
        public List<UnorderedItem> UnorderedItemsList { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int? PurchaseOrderId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Notes { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? employeeid { get; set; }

        [BindProperty]
        public int unorderedItemId { get; set; }

 
        public async Task OnGet()
        {
            AppUser = await _UserManager.FindByNameAsync(User.Identity.Name);
            employeeid = AppUser.EmployeeId;
            EmployeeName = _Security.GetEmployeeName(AppUser.EmployeeId.Value);

            GetOrderInfo();
        }

        public async Task GetActiveEmployee()
        {
            AppUser = await _UserManager.FindByNameAsync(User.Identity.Name);
            employeeid = AppUser.EmployeeId;
            EmployeeName = _Security.GetEmployeeName(AppUser.EmployeeId.Value);
        }

        public void GetOrderInfo()
        {

            if (PurchaseOrderId.HasValue && PurchaseOrderId > 0)
            {
                OutstandingOrderInfo = _receivingservices.GetOutstandingOrderInfo((int)PurchaseOrderId);

                GetTempCartItems();
            }
            else
            {
                OutstandingOrders = _receivingservices.GetOutstandingOrders();
            }
                
        }

        public void GetTempCartItems()
        {
            foreach (string key in HttpContext.Session.Keys)
            {
                UnorderedItems = JsonSerializer.Deserialize<UnorderedItem>(HttpContext.Session.GetString(key));
                if (key == $"{UnorderedItems.VendorPartNumber}")
                {
                    UnorderedItemsList.Add(new UnorderedItem()
                    {
                        Description = UnorderedItems.Description,
                        VendorPartNumber = UnorderedItems.VendorPartNumber,
                        Qunatity = UnorderedItems.Qunatity
                    });
                }
            }
            UnorderedItems = null;
            
        }
        public IActionResult OnPostReceive()
        {
            _ = GetActiveEmployee();
            Thread.Sleep(1000);

            try
            {
                if (PurchaseOrderId.HasValue)
                {
                    GetTempCartItems();
                    _receivingservices.ReceivingRecord((int)PurchaseOrderId, ReceivedItems, UnorderedItemsList, (int)employeeid);
                    HttpContext.Session.Clear();
                }

                else
                {
                    FeedBackMessage = "Record isn't successful";
                }

                PurchaseOrderId = null;
                return RedirectToPage(new { PurchaseOrderId = PurchaseOrderId });

            }
            catch (AggregateException ex)
            {
                ErrorMessage = "Unable to process your request:";
                foreach (var problem in ex.InnerExceptions)
                    ErrorDetails.Add(problem.Message);

                GetOrderInfo();
                return Page();
            }
            catch (Exception ex)
            {
                ErrorMessage = GetInnerException(ex).Message;

                GetOrderInfo();
                return Page();
            }
        }

        public IActionResult OnPostInsert()
        {
            _ = GetActiveEmployee();
            Thread.Sleep(1000);

            try
            {
                if (PurchaseOrderId.HasValue)
                {
                    if (UnorderedItems.Description == null)
                        ErrorMessage = "Insert: Item is missing description";
                    else if (UnorderedItems.VendorPartNumber == null)
                        ErrorMessage = "Insert: Item is missing Vendor Part ID ";
                    else if (UnorderedItems.Qunatity == 0)
                        ErrorMessage = "Insert: Item is missing Qunatity";
                    else
                    {
                        if(HttpContext.Session.Keys.Count() == 0)
                            HttpContext.Session.SetString($"{UnorderedItems.VendorPartNumber}", JsonSerializer.Serialize(UnorderedItems));
                        else
                        {
                            foreach (string key in HttpContext.Session.Keys)
                            {
                                if (key == $"{UnorderedItems.VendorPartNumber}")
                                    ErrorMessage = "Insert: Item already exists";
                                else
                                    HttpContext.Session.SetString($"{ UnorderedItems.VendorPartNumber}", JsonSerializer.Serialize(UnorderedItems));
                            }
                        }
                        
                    } 
                }

                else
                {
                    FeedBackMessage = "Record isn't successful";
                }

                return RedirectToPage(new { PurchaseOrderId = PurchaseOrderId});

            }
            catch (AggregateException ex)
            {
                ErrorMessage = "Unable to process your request:";
                foreach (var problem in ex.InnerExceptions)
                    ErrorDetails.Add(problem.Message);

                GetOrderInfo();
                return Page();
            }
            catch (Exception ex)
            {
                ErrorMessage = GetInnerException(ex).Message;

                GetOrderInfo();
                return Page();
            }
        }

        public IActionResult OnPostDelete()
        {
            _ = GetActiveEmployee();
            Thread.Sleep(1000);

            try
            {
                if (PurchaseOrderId.HasValue)
                {
                    HttpContext.Session.Remove($"{unorderedItemId}");
                }

                else
                {
                    FeedBackMessage = "Delete Record isn't successful";
                }


                return RedirectToPage(new { PurchaseOrderId = PurchaseOrderId});

            }
            catch (AggregateException ex)
            {
                ErrorMessage = "Unable to process your request:";
                foreach (var problem in ex.InnerExceptions)
                    ErrorDetails.Add(problem.Message);

                GetOrderInfo();
                return Page();
            }
            catch (Exception ex)
            {
                ErrorMessage = GetInnerException(ex).Message;

                GetOrderInfo();
                return Page();
            }
        }

        public IActionResult OnPostForceClose()
        {
            try
            {
                if (PurchaseOrderId.HasValue)
                {
                    _receivingservices.ForceOutstandingOrder((int)PurchaseOrderId,Notes, ReceivedItems);
                }

                else
                {
                    FeedBackMessage = "Record isn't successful";
                }

                HttpContext.Session.Clear();
                PurchaseOrderId = null;
                return RedirectToPage(new { PurchaseOrderId = PurchaseOrderId });
            }
            catch (AggregateException ex)
            {
                ErrorMessage = "Unable to process your request:";
                foreach (var problem in ex.InnerExceptions)
                    ErrorDetails.Add(problem.Message);

                GetOrderInfo();
                return Page();
            }
            catch (Exception ex)
            {
                ErrorMessage = GetInnerException(ex).Message;
                GetOrderInfo();
                return Page();
            }
        }

        public IActionResult OnPostClear()
        {
            PurchaseOrderId = null;
            HttpContext.Session.Clear();
            return RedirectToPage(new { PurchaseOrderId = PurchaseOrderId });
        }

        public IActionResult OnPostClearForm()
        {
            UnorderedItems = null;

            return RedirectToPage(new { PurchaseOrderId = PurchaseOrderId});
        }

        private Exception GetInnerException(Exception ex)
        {
            while (ex.InnerException != null)
                ex = ex.InnerException;
            return ex;
        }

    }
}
