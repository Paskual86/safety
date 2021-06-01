using AutoMapper;
using SafetyBP.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SafetyBP.Core.Base
{
    public abstract class BaseContextBusiness<TModel> : ICommonBusiness<TModel>
        where TModel : class
    {
        protected readonly bool ForcedUpdateRecords;
        protected readonly string _tableName;
        protected readonly IPersistanceProvider _persistanceProvider;
        protected readonly IMapper _mapper;
        protected string _token;

        public BaseContextBusiness(string tableName)
        {
            _persistanceProvider = DependencyService.Get<IPersistanceProvider>();
            _mapper = DependencyService.Get<IBaseMapper>().Mapper;
            _tableName = tableName;
            ForcedUpdateRecords = false;
        }

        public BaseContextBusiness(string tableName, IPersistanceProvider persistanceProvider, IBaseMapper baseMapper)
        {
            _persistanceProvider = persistanceProvider;
            _tableName = tableName;
            _mapper = baseMapper.Mapper;
            ForcedUpdateRecords = false;
        }

        public async Task ClearTableAsync()
        {
            await _persistanceProvider.DropTableAsync(_tableName);
        }

        public async Task CreateTableAsync()
        {
            await _persistanceProvider.CreateTableAsync(_tableName);
        }

        public virtual async Task InitializateAsync()
        {
            await ClearTableAsync();
            await CreateTableAsync();
        }

        public virtual async Task CleanTableAsync()
        {
            await _persistanceProvider.CleanTableAsync(_tableName);
        }

        public virtual async Task<IEnumerable<TModel>> GetListAsync()
        {
            var result = await _persistanceProvider.GetListAsync(_tableName);
            if ((result != null) && (result.Count() > 0))
            {
                return ((IEnumerable<TModel>)result);
            }
            else return null;
        }

        public async Task<string> GetTokenAsync()
        {
            return await Task.FromResult(string.Empty);
        }
    }
}
