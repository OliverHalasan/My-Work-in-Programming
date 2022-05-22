using AppSecurity.BLL;
using BikesRUs.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PurchasingSystem.BLL;
using PurchasingSystem.ViewModels;



namespace BikesRUs.Pages.PurchasingPages
{
    public class PurchasingModel : PageModel
    {
       private readonly UserManager<ApplicationUser> _UserManager;
       private readonly SecurityService _Security;
       private readonly VendorService _vendorService;
       private readonly PurchaseOrderService _purchaseOrderService;

        public PurchasingModel(UserManager<ApplicationUser> userManager, SecurityService security, VendorService vendorservice, PurchaseOrderService purchaseOrderService)
        {
            _UserManager = userManager;
            _Security = security;
            _vendorService = vendorservice;
            _purchaseOrderService = purchaseOrderService;
        }

        public ApplicationUser AppUser { get; set; }
        public string EmployeeName { get; set; }
      

        [TempData]
        public string FeedBack { get; set; }
        public bool HasFeedBack => !string.IsNullOrWhiteSpace(FeedBack);
        [TempData]
        public string ErrorMsg { get; set; }
        public bool HasErrorMsg => !string.IsNullOrWhiteSpace(ErrorMsg);
        //
        [BindProperty]
        public List<VendorSelection> VendorList { get; set; }
        [BindProperty]
        public VendorsInfo Vendorsinfo { get; set; }
        [BindProperty]
        public PurchaseInfo PurchaseOrderinfo { get; set; }

        [BindProperty]
        public PurchaseInfo PurchaseInfo { get; set; }

        [BindProperty]
        public List<PartsInfo> PurchaseOrderDetails { get; set; }
        [BindProperty]
        public List<PartsInfo> recommendedParts { get; set; }
        [BindProperty]
        public string SelectedPart { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? vendorid { get; set; }
      
        public async Task OnGet()
        {
            AppUser = await _UserManager.FindByNameAsync(User.Identity.Name);
            EmployeeName = _Security.GetEmployeeName(AppUser.EmployeeId.Value);
            VendorList = _vendorService.GetAllVendors();

           if (vendorid.HasValue && vendorid != 0)
            {
                Vendorsinfo = _vendorService.GetVendorsInfo((int)vendorid);
                PurchaseOrderinfo = _purchaseOrderService.GetAllPurchaseOrder((int)vendorid);

                if (PurchaseOrderinfo == null)
                {
                    PurchaseOrderinfo = new PurchaseInfo()
                    {
                        PurchaseOrderID = 0,
                        PurchaseOrderNumber = 0,
                        SubTotal = (decimal)0.00

                    };
                    PurchaseOrderDetails = _purchaseOrderService.GetAllRecommendedParts((int)vendorid, 0);
                    recommendedParts = new List<PartsInfo>();

                }
                else
                {
                    PurchaseOrderDetails = _purchaseOrderService.GetAllOrderParts(PurchaseOrderinfo.PurchaseOrderID);
                    recommendedParts = _purchaseOrderService.GetAllRecommendedParts((int)vendorid, PurchaseOrderinfo.PurchaseOrderID);
                }
            }

        }
        public IActionResult OnPost()
        {
            if (!vendorid.HasValue || vendorid == 0)
            {
                FeedBack = "You did not select a Vendor";
            }
            return RedirectToPage(new { vendorid = vendorid });
        }

        public IActionResult OnPostClear()
        {
            vendorid = null;
            return RedirectToPage(new{ vendorid = vendorid });
        }

        public IActionResult OnPostDelete()
        {
            vendorid = null;
            return RedirectToPage(new { vendorid = vendorid });
        }

        public void OnPostAddPart()
        {
            var found = recommendedParts.SingleOrDefault(x => x.Name == SelectedPart);
            if (found != null)
            {
                found.QuantityToOrder = 1;

                PurchaseOrderDetails.Add(found);
                recommendedParts.Remove(found);
            }
        }
        public void OnPostRemovePart()
        {
            var found = PurchaseOrderDetails.SingleOrDefault(x => x.Name == SelectedPart);
            if ( found != null)
            {
                PurchaseOrderDetails.Remove(found);
                recommendedParts.Add(found);
            }
        }

        public PurchaseInfo updatePrices(PurchaseInfo oldInfo, List<PartsInfo> orderinfo)
        {
            decimal newSubTotal = (decimal)0.0;

            foreach (var part in orderinfo)
            {
                newSubTotal += part.PurchasePrice;
            }

            PurchaseInfo NewInfo = new PurchaseInfo()
            {
                PurchaseOrderID = oldInfo.PurchaseOrderID,
                PurchaseOrderNumber = oldInfo.PurchaseOrderNumber,
                SubTotal = newSubTotal,
            };
            return NewInfo;
        }
    }
}
