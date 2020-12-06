using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularAndAsp.NetCoreWebApiEcommerce.Models
{
    public class ProductType
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name ="Product Type")]
        public string ProductTypeName { get; set; }
    }
}
