#nullable disable
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Additional Namespace
using AppSecurity.BLL;
using BikesRUs.Data;
using ServicingSystem.BLL;
using ServicingSystem.DAL;
using ServicingSystem.ViewModels;
using Microsoft.EntityFrameworkCore.ChangeTracking;
#endregion

namespace BikesRUs.Pages.ServicingPages
{
    public class ServicingModel : PageModel
    {
        #region Private variables and DI constructor
        private readonly ServicingServices _servicingservices;
        private readonly UserManager<ApplicationUser> _UserManager;
        private readonly SecurityService _Security;

        public ServicingModel(ServicingServices servicingServices, UserManager<ApplicationUser> userManager,
                                           SecurityService security)
        {
            _UserManager = userManager;
            _Security = security;
            _servicingservices = servicingServices;
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

        [BindProperty(SupportsGet = true)]
        public string lastname { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<CustomerInfo> CustomerInfo { get; set; }

        [BindProperty(SupportsGet = true)]
        public CustomerInfo CustomerId { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<CustomerVehicleInfo> CustomerVehicleInfo { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int selectedcustomerid { get; set; }

        [BindProperty(SupportsGet = true)]
        public string selectedvehicleidentification { get; set; }

        [BindProperty(SupportsGet = true)]
        public JobInfo JobInfo { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? employeeid { get; set; }

        public int? count = 1;
        public async Task OnGet()
        {
            AppUser = await _UserManager.FindByNameAsync(User.Identity.Name);
            employeeid = AppUser.EmployeeId;
            EmployeeName = _Security.GetEmployeeName(AppUser.EmployeeId.Value);

            GetCustomerInfo();
        }

        public async Task GetActiveEmployee()
        {
            AppUser = await _UserManager.FindByNameAsync(User.Identity.Name);
            employeeid = AppUser.EmployeeId;
            EmployeeName = _Security.GetEmployeeName(AppUser.EmployeeId.Value);
        }


        public void GetCustomerInfo()
        {
            if (!string.IsNullOrWhiteSpace(lastname))
            {
                CustomerInfo = _servicingservices.Customer_Fetch_Customer(lastname);
            }

        }

        public IActionResult OnPostCustomerSearch()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(lastname))
                {
                    Errors.Add(new Exception("Customer Search not entered"));
                }
                if (Errors.Any())
                {
                    throw new AggregateException(Errors);
                }
                return RedirectToPage(new
                {
                    lastname = lastname.Trim()

                });
            }
            catch (AggregateException ex)
            {
                ErrorMessage = "Unable to process search";
                foreach (var error in ex.InnerExceptions)
                {
                    ErrorDetails.Add(error.Message);
                }
                return Page();
            }
            catch (Exception ex)
            {
                ErrorMessage = GetInnerException(ex).Message;
                return Page();
            }
        }

        private void GetCustomerVehicleInfo()
        {
            if (selectedcustomerid != 0)
            {
                CustomerVehicleInfo = _servicingservices.GetCustomerVehicleInfo((int)selectedcustomerid);
            }
        }

        public IActionResult OnPostCustomerVehicleSearch()
        {
            GetCustomerInfo();

            try
            {
                if (selectedcustomerid == 0)
                {
                    Errors.Add(new Exception("Customer not selected"));
                }
                if (Errors.Any())
                {
                    throw new AggregateException(Errors);
                }
                GetCustomerVehicleInfo();
                return Page();
            }
            catch (AggregateException ex)
            {
                ErrorMessage = "Unable to process search";
                foreach (var error in ex.InnerExceptions)
                {
                    ErrorDetails.Add(error.Message);
                }
                return Page();
            }
            catch (Exception ex)
            {
                ErrorMessage = GetInnerException(ex).Message;
                return Page();
            }
        }

        public void GetJobSearch()
        {
            if (!string.IsNullOrWhiteSpace(selectedvehicleidentification))
            {
                JobInfo = _servicingservices.GetJobDetailsInfo(selectedvehicleidentification);
            }

        }

        public IActionResult OnPostJobSearch()
        {
            GetCustomerInfo();
            GetCustomerVehicleInfo();

            try
            {
                if (selectedcustomerid == 0)
                {
                    Errors.Add(new Exception("Customer not selected"));
                }
                if (Errors.Any())
                {
                    throw new AggregateException(Errors);
                }
                return Page();
            }
            catch (AggregateException ex)
            {
                ErrorMessage = "Unable to process search";
                foreach (var error in ex.InnerExceptions)
                {
                    ErrorDetails.Add(error.Message);
                }
                return Page();
            }
            catch (Exception ex)
            {
                ErrorMessage = GetInnerException(ex).Message;
                return Page();
            }
        }


        private Exception GetInnerException(Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }
    }
}
