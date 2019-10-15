﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UmbrellaShop.Core.Entity
{
    public class FilteredList<T>
    {
        public IEnumerable<T> List { get; set; }
        public int Count { get; set; }
    }
}
