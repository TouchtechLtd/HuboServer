using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Hubo.EntityFramework.Repositories
{
    public abstract class HuboRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<HuboDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected HuboRepositoryBase(IDbContextProvider<HuboDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class HuboRepositoryBase<TEntity> : HuboRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected HuboRepositoryBase(IDbContextProvider<HuboDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
