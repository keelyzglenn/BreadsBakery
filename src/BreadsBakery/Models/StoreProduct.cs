using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BreadsBakery.Models
{
    [Table("StoreProducts")]
    public class StoreProduct
    {
  
        [Key]
        public int StoreProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Price { get; set; }

        public string Category { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }


    }
}