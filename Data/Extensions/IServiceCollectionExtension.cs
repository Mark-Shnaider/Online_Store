using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Common.Models.Entities.Base;
using Data.Repos.Base;
using Common.Contracts.Repos.Base;

namespace Common.Extensions
{
    public static class IServiceCollectionExtension
    {
        //public static IServiceCollection AddRepository<TEntity, TKey, TRepository>(this IServiceCollection services)
        //    where TEntity:BaseEntity<TKey>
        //    where TKey: IEquatable<TKey>
        //    where TRepository:IBaseRepository<TKey, TEntity>
        //{
        //    services.AddScoped(IBaseRepository<TKey, TEntity>,);
        //}
    }
}
