using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AngularAndAsp.NetCoreWebApiEcommerce.Models
{
    public class OrderDetails
    {
        public int ID { get; set; }
        [ForeignKey("ProductID")]
        public int ProductID { get; set; }
        [ForeignKey("OrderID")]
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}
