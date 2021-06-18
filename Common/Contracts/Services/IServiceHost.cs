using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Contracts.Services.Base;

namespace Common.Contracts.Services
{
    interface IServiceHost
    {
        void Register<T>(T service) where T : IService;
        T GetService<T>() where T : IService;
    }
}
