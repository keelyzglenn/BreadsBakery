using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BreadsBakery.Models
{
    [Table("Departments")]
    public class Department
    {

        [Key]
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<StoreProduct> StoreProducts { get; set; }
        public virtual ICollection<CateringProduct> CateringProduct { get; set; }


    }
}