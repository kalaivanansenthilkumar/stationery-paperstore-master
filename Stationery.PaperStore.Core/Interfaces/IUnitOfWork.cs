using System;
using System.Threading.Tasks;
using Stationery.PaperStore.Core.Entities;

namespace Stationery.PaperStore.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
       IEcommerceRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
       Task<int> Complete();
    }
}