using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularAndAsp.NetCoreWebApiEcommerce.Models
{
    public class SpecialTag
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name ="Special Tag")]
        public string SpecialTagName { get; set; }
    }
}
