﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GrocerySystem.Entities
{
    internal partial class Delivery
    {
        [Key]
        public int DeliveryID { get; set; }
        public int OrderID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(12)]
        public string Phone { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DeliveredOn { get; set; }
        [StringLength(30)]
        public string Address { get; set; }
        [StringLength(10)]
        public string Unit { get; set; }
        [StringLength(30)]
        public string City { get; set; }
        [StringLength(2)]
        public string Province { get; set; }
    }
}