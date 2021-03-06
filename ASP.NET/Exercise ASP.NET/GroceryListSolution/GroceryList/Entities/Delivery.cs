// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GroceryList.Entities
{
    internal partial class Delivery
    {
        [Key]
        public int DeliveryID { get; set; }
        public int OrderID { get; set; }
        [Required (ErrorMessage ="Name is Required")]
        [StringLength(50, ErrorMessage ="Name is limited to 50 characters")]
        public string Name { get; set; }
        [Required (ErrorMessage ="Phone is Required")]
        [StringLength(12, ErrorMessage ="Phone is limited to 12 characters")]
        public string Phone { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DeliveredOn { get; set; }
        [StringLength(30, ErrorMessage ="Address is limited to 30 characters")]
        public string Address { get; set; }
        [StringLength(10, ErrorMessage = "Unit is limited to 10 characters")]
        public string Unit { get; set; }
        [StringLength(30, ErrorMessage = "City is limited to 30 characters")]
        public string City { get; set; }
        [StringLength(2, ErrorMessage = "Provices must be on their code with 2 characters")]
        public string Province { get; set; }
    }
}