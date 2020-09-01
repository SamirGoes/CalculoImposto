using Imposto.Core.Service;
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

            _container.Verify();
        }

        public static T GetInstance<T>() where T: class
            => _container.GetInstance<T>();
    }
}
