﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExhibitGrid.ViewModel.v2
{
    public class TextCellVm : BaseCellVm
    {
        public string Text { get; set; }
        public int Indent { get; set; }
    }
}