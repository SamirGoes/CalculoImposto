﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Service
{
    public interface INotaFiscalService
    {
        bool GerarNotaFiscal(Domain.Pedido pedido);
    }
}
