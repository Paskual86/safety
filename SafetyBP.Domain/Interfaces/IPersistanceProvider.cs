using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafetyBP.Domain.Interfaces
{
    public interface IPersistanceProvider
    {
        Task DropTableAsync(string TableName);
        Task CreateTableAsync(string TableName);
        Task CleanTableAsync(string TableName);
        Task<IEnumerable<object>> GetListAsync(string TableName);
    }
}
