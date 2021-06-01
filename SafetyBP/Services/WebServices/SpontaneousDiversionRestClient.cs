using AutoMapper;
using SafetyBP.Domain.Constants;
using SafetyBP.Domain.Models;
using SafetyBP.Domain.OperationsResult;
using SafetyBP.Dtos.Requests;
using SafetyBP.EntityMapper.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SafetyBP.Services.WebServices
{
    public class SpontaneousDiversionRestClient : BaseRestClient, ISpontaneousDiversionRestClient
    {
        private readonly IMapper _mapper;
        private const string URL = "https://safetybp.com/admin/api/desvios.php";
        public SpontaneousDiversionRestClient():base()
        {
            var mapperbase = DependencyService.Get<IBaseMapper>();
            _mapper = mapperbase.Mapper;
        }

        public async Task<BooleanOperationResult> SaveAsync(List<SafetySpontaneousDiversion> value, Action<BooleanOperationResult> callback)
        {
            var request = new SafetySpontaneousDiversionRequestDto
            {
                Action = "saveDesviation",
                Token = await TokenHelper.GetTokenAsync(),
                Diversion = _mapper.Map<IEnumerable<SafetySpontaneousDiversionDetailRequestDto>>(value)

            };
            
            return await ExecutePostCommand(request, GetHashCode(request), URL, ModuleNameConstants.SPONTANEOUSDIVERSION, callback);
        }
    }

}
