using System.Collections.Generic;
using System.Threading.Tasks;

namespace Epicalsoft.Data.Common
{
    public interface IUnitOfWork
    {
        Task<int> ExecuteAsync(string storedProcedure, object param);

        Task<T> ExecuteScalarAsync<T>(string storedProcedure, object param);

        Task<IEnumerable<T>> QueryAsync<T>(string storedProcedure, object param);

        Task<T> QuerySingleOrDefaultAsync<T>(string storedProcedure, object param);

        void Commit();

        void Dispose();
    }
}