using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularAndAsp.NetCoreWebApiEcommerce.Models
{
    public class QuantityType
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Special Tag")]
        public string QuantityTypeName { get; set; }
    }
}
