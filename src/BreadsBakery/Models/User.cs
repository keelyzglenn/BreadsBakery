using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BreadsBakery.Models
{
    [Table("Users")]
    public class User
    {

        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string CompanyName { get; set; }

        public virtual ICollection<CateringOrder> CateringOrder { get; set; }

    }
}