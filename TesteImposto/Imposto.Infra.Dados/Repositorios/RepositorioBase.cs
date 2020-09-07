using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Imposto.Infra.Dados.Repositorios
{
    public abstract class RepositorioBase
    {
        protected string ConnectionString => ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    }
}
