using BreadsBakery.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BreadsBakery.ViewModels
{
    public class PlaceOrderViewModel
    {
       [Required]
       public int CateringOrderId { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        public IEnumerable<CateringProduct> CateringProduct { get; set; }

        public int CateringProductId { get; set; }
    }
}
