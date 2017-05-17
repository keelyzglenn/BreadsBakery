using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BreadsBakery.ViewModels;

namespace BreadsBakery.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int CateringOrderId { get; set; }
        public virtual CateringOrder CateringOrder { get; set; }

        public int CateringProductId { get; set; }
        public virtual CateringProduct CateringProduct { get; set; }

        public int Quantity { get; set; }

        public static Order CreateOrder(PlaceOrderViewModel vm)
        {
            Order newOrder = new Order
            {
                CateringOrderId = vm.CateringOrderId,
                Quantity = vm.Quantity,
                CateringProductId = vm.CateringProductId,

            };

            return newOrder;
        }
    }
}