using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi.Framework.DataAccess.Entities;
using WebApi.Framework.DataAccess.Repositories.EntityFramework;

namespace WebApi.Framework.DataAccess.Repositories
{
    public abstract class MixedORMRepositoryBase<T> : EntityFrameworkRepositoryBase<T> where T : EntityBaseIncrementalId
    {
        public readonly IDbConnection Connection;

        protected MixedORMRepositoryBase(DbContext context) : base(context)
        {
            Connection = context.Database.GetDbConnection();
        }



        // execute, query, querylist, find
    }
}
