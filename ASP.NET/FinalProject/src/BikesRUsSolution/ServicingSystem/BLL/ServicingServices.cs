#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespace
using ServicingSystem.BLL;
using ServicingSystem.DAL;
using ServicingSystem.Entities;
using ServicingSystem.ViewModels;
using Microsoft.EntityFrameworkCore.ChangeTracking;
#endregion

namespace ServicingSystem.BLL
{
    public class ServicingServices
    {
        #region Constructor and DI variable setup
        private readonly ServicingDbContext _context;

        internal ServicingServices(ServicingDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Queries
        public List<CustomerInfo> Customer_Fetch_Customer(string lastname)
        {
            if (string.IsNullOrWhiteSpace(lastname))
            {
                throw new ArgumentNullException("No lastname has been entered.");
            }

            IEnumerable<CustomerInfo> info = _context.Customers
                                    .Where(x => x.LastName.Contains(lastname))
                                    .Select(x => new CustomerInfo
                                    {
                                        CustomerId = x.CustomerID,
                                        Name = x.FirstName + " " + x.LastName,
                                        Phone = x.ContactPhone,
                                        Address = x.Address + " " + x.City
                                    })
                                    .OrderBy(x => x.Name);
            
            return info.ToList(); 
        }

        public List<CustomerVehicleInfo> GetCustomerVehicleInfo(int selectedcustomerid)
        {
            IEnumerable<CustomerVehicleInfo> info = _context.CustomerVehicles
                                            .Where(x => x.CustomerID.Equals(selectedcustomerid))
                                            .Select(x => new CustomerVehicleInfo
                                            {
                                                CustomerId = x.CustomerID,
                                                VehicleIdentification = x.VehicleIdentification,
                                                Vehicle = x.Make + " " + x.Model,
                                                CustomerName = x.Customer.FirstName + " " + x.Customer.LastName
                                            })
                                            .OrderByDescending(x => x.VehicleIdentification);
            return info.ToList();
        }

        public JobInfo GetJobDetailsInfo(string selectedvehicleidentification)
        {
            JobInfo info = _context.Jobs
                        .Where(x => x.VehicleIdentification.Contains(selectedvehicleidentification))
                        .Select(x => new JobInfo
                        {
                            JobDetailItems = x.JobDetails
                                        .Select(a => new JobDetailInfo
                                        {
                                            JobDetailId = a.JobDetailID,
                                            Description = a.Description,
                                            Hrs = a.JobHours,
                                            Comment = a.Comments
                                        })
                                        .ToList()
                        })
                        .FirstOrDefault();
            return info;
        }

        #endregion

    }
}
