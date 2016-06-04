using ASP.Exam.BL;
using Ninject;
using Ninject.Modules;
using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace ASP.Exam.DependencyResolver
{
    public class NinjectHttpResolver : NinjectScope, IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectHttpResolver(IKernel kernel) : base(kernel)
        {
            _kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectScope(_kernel.BeginBlock());
        }
    }

    public class NinjectScope : IDependencyScope
    {
        protected IResolutionRoot _resolver;

        public NinjectScope(IResolutionRoot resolver)
        {
            _resolver = resolver;
        }

        public void Dispose()
        {
            IDisposable disposable = (IDisposable)_resolver;
            if (disposable != null)
                disposable.Dispose();
            _resolver = null;
        }

        public object GetService(Type serviceType)
        {
            if (_resolver == null)
                throw new ObjectDisposedException("this", "This scope has been disposed");

            return _resolver.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (_resolver == null)
                throw new ObjectDisposedException("this", "This scope has been disposed");

            return _resolver.GetAll(serviceType);
        }
    }
}