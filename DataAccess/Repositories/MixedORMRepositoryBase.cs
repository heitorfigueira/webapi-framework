using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi.Framework.DataAccess.Entities;
using WebApi.Framework.DataAccess.Repositories.EntityFramework;
using Dapper;

namespace WebApi.Framework.DataAccess.Repositories
{
    public abstract class MixedORMRepositoryBase<TEntity> : 
        EntityFrameworkRepositoryBase<TEntity> 
        where TEntity : EntityBaseIncrementalId
    {
        public readonly IDbConnection Connection;

        protected MixedORMRepositoryBase(DbContext context) : base(context)
        {
            Connection = context.Database.GetDbConnection();
        }

        public bool Execute(string sql, object param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Connection.Execute(sql, param, transaction, commandTimeout, commandType) > 0;
        }

        public T Execute<T>(string sql, object param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Connection.ExecuteScalar<T>(sql, param, transaction, commandTimeout, commandType);
        }

        public IEnumerable<T> Query<T>(string sql, object param = null, IDbTransaction? transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Connection.Query<T>(sql, param, transaction, buffered, commandTimeout, commandType);
        }

        public IEnumerable<TEntity> QueryEntity(TEntity entity, IDbTransaction? transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            // TODO: Create query for entities passed through this
            throw new NotImplementedException();
        }
    }
}
