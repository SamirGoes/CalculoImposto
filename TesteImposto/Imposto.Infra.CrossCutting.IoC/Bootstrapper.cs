using Imposto.Core.Repositorios;
using Imposto.Core.Service;
using Imposto.Infra.Dados.Repositorios;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Infra.CrossCutting.IoC
{
    public static class Bootstrapper
    {
        static Container _container;
        public static void Configure()
        {
            _container = new Container();

            _container.Register<INotaFiscalService, NotaFiscalService>();
            _container.Register<ICfopService, CfopService>();
            _container.Register<IIpiService, IpiService>();
            _container.Register<IIcmsService, IcmsService>();
            _container.Register<INotaFiscalRepositorio, NotaFiscalRepositorio>();
            
            _container.Verify();
        }

        public static T GetInstance<T>() where T: class
            => _container.GetInstance<T>();
    }
}
