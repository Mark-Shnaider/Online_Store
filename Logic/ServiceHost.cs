using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Contracts.Services;
using Common.Contracts.Services.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Logic
{
    public  class ServiceHost:IServiceHost
    {
        private readonly IServiceProvider _provider;
        private readonly Dictionary<Type, IService> _services;

        public ServiceHost(IServiceProvider provider)
        {
            _provider = provider;
            _services = new Dictionary<Type, IService>();
        }

        

        public void Register<T>(T service)
            where T : IService
        {
            if (!_services.ContainsKey(typeof(T)))
                _services.Add(typeof(T), service);
        }
        //public T GetService<T>() 
        //    where T : IService
        //{
        //    if (_services.ContainsKey(typeof(T)))
        //    {
        //        return (T)_services[typeof(T)];
        //    }

        //    //var service = _provider.Resolve<T>();
        //    //var service = _provider.GetService(T);
        //    //Register(service);

        //    return IService;
        //}

        public T GetService<T>() where T : IService
        {
            throw new NotImplementedException();
        }
    }
}
