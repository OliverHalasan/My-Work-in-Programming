﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ReceivingSystem.Entities
{
    internal partial class ReturnedOrderDetail
    {
        [Key]
        public int ReturnedOrderDetailID { get; set; }
        public int ReceiveOrderID { get; set; }
        public int? PurchaseOrderDetailID { get; set; }
        [StringLength(50)]
        public string ItemDescription { get; set; }
        public int Quantity { get; set; }
        [Required]
        [StringLength(50)]
        public string Reason { get; set; }
        [StringLength(50)]
        public string VendorPartNumber { get; set; }

        [ForeignKey(nameof(PurchaseOrderDetailID))]
        [InverseProperty("ReturnedOrderDetails")]
        public virtual PurchaseOrderDetail PurchaseOrderDetail { get; set; }
        [ForeignKey(nameof(ReceiveOrderID))]
        [InverseProperty("ReturnedOrderDetails")]
        public virtual ReceiveOrder ReceiveOrder { get; set; }
    }
}