﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentCodeFirstCheckbox.Models
{
    public class Color
    {
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public virtual List<ProductColor> ProductColors { get; set; }
    }
}