﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagCloud
{
    public interface IFontGenerator
    {
        Font GetFont(Counter word);
    }
}
