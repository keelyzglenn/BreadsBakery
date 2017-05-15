using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BreadsBakery.Models
{
    [Table("CateringOrders")]
    public class CateringOrder
    {

        [Key]
        public int CateringOrderId { get; set; }
        public string DateNeeded { get; set; }
        public string DateTaken { get; set; }
        public string Address { get; set; }
        public string Time { get; set; }

        public string Delivery { get; set; }

        public int Price { get; set; }

        public string ServingRange { get; set; }

        public string PaymentMethod { get; set; }

        public virtual ICollection<Order> Order { get; set; }


    }
}