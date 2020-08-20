﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncLoadBase
{
   public abstract class AsyncLoad:IAsyncLoad
    {
        public abstract void Worker(object sender, DoWorkEventArgs e);
    }
}
