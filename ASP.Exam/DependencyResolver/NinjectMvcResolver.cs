using ASP.Exam.BL;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ASP.Exam.DependencyResolver
{
    public class NinjectMvcResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectMvcResolver(IKernel kernel)
        {
            _kernel = kernel;
            _kernel.Bind<IUserService>().To<UserService>();
            //_kernel.Bind<IRepository>().To<UserRepository>();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _kernel.GetAll(serviceType);
            }
            catch
            {
                return null;
            }
        }
    }
}