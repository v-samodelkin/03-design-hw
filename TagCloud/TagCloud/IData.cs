﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagCloud
{
    interface IData
    {
        IEnumerable<Counter> Data { get; } 
    }
}
