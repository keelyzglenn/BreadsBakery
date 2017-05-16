using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    }
}