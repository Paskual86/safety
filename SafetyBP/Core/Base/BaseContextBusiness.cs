using AutoMapper;
using SafetyBP.Domain.Interfaces;
using SafetyBP.EntityMapper.Base;
using SafetyBP.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SafetyBP.Core.Base
{
    public abstract class BaseContextBusiness<TModel> : ICommonBusiness<TModel>
        where TModel: class
    {
        protected readonly bool ForcedUpdateRecords;
        protected readonly string _tableName;
        protected readonly IWebService _webService;
        protected readonly IMapper _mapper;
        protected string _token;

        public BaseContextBusiness(string tableName)
        {
            _tableName = tableName;
            _webService = DependencyService.Get<IWebService>();
            var mapperbase = DependencyService.Get<IBaseMapper>();
            _mapper = mapperbase.Mapper;
            ForcedUpdateRecords = false;
        }

        public virtual Task<IEnumerable<TModel>> GetListAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<string> GetTokenAsync() { 
            return _token = await SecureStorage.GetAsync("token");
        }

        
    }
}
