﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExhibitGrid.ViewModel.v2
{
    public class ColumnHeaderVm
    {
        public string ColCode { get; set; }
        public bool HeaderIsVisible { get; set; }
        public string Width { get; set; }
        public string Text { get; set; }
        public int ColSpan { get; set; }
        public int Level { get; set; }
        public int Order { get; set; }
    }
}