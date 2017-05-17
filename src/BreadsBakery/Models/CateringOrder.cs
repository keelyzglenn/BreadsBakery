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

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateNeeded { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateTaken { get; set; }
        public string Address { get; set; }
        public string Time { get; set; }

        public string Delivery { get; set; }

        public int Price { get; set; }

        public string ServingRange { get; set; }

        public string PaymentMethod { get; set; }

        
        public virtual User User { get; set; }

        public User FindWorker(string UserName)
        {
            User thisUser = new BreadsBakeryDbContext().Users.FirstOrDefault(i => i.UserName == UserName);
            return thisUser;
        }

        public virtual ICollection<Order> Order { get; set; }


    }
}