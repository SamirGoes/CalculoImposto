﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Factory
{
    public interface IFactory<T>
    {
        T ObterInstancia();
    }
}
