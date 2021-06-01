using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafetyBP.Domain.Interfaces
{
    public interface ICommonBusiness<TModel>
    {
        Task<IEnumerable<TModel>> GetListAsync();
    }
}