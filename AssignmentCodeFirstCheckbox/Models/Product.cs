using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentCodeFirstCheckbox.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string MfgName{ get; set; }
        public decimal Price { get; set; }

        public virtual List<ProductColor> ProductColors { get; set; }
    }
}