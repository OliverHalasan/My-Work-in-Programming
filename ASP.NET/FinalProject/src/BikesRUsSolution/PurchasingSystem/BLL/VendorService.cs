using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PurchasingSystem.ViewModels;
using PurchasingSystem.DAL;
//using PurchasingSystem.BLL;
//using PurchasingSystem.Entities;


namespace PurchasingSystem.BLL
{
    public class VendorService
    {
        #region Constructor and Context Dependency
        private readonly PurchasingDbContext _context;
        internal VendorService(PurchasingDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Services : Queries


        public List<VendorSelection> GetAllVendors()
        {
            IEnumerable<VendorSelection> info = _context.Vendors
                                            .Select(x => new VendorSelection
                                            {
                                                ValueId = x.VendorID,
                                                DisplayText = x.VendorName,
                                            })
                                            .OrderBy(x => x.DisplayText);
            return info.ToList();
        }
        #endregion
        public VendorsInfo GetVendorsInfo(int vendorsid)
        {
            VendorsInfo info = _context.Vendors
                                        .Where(x => x.VendorID == vendorsid)
                                        .Select(x => new VendorsInfo
                                        {
                                            VendorID = x.VendorID,
                                            Phone = x.Phone,
                                            City = x.City

                                        })
                                        .FirstOrDefault();
            return info;
        }
        //test

    }
}
