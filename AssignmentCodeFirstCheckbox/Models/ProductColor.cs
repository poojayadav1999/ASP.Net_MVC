using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentCodeFirstCheckbox.Models
{
    public class ProductColor
    {
        public int ProductColorId { get; set; }
        public int ProductId { get; set; }
        public int ColorId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Color Color { get; set; }
    }
}