using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Novaetra.Backend.EntityFramework.Repositories
{
    public abstract class BackendRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<BackendDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected BackendRepositoryBase(IDbContextProvider<BackendDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    //a shortcut for entities that have integer Ids
    public abstract class BackendRepositoryBase<TEntity> : BackendRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected BackendRepositoryBase(IDbContextProvider<BackendDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
