using AutoMapper;
using SafetyBP.EntityMapper.Profiles;

namespace SafetyBP.EntityMapper.Base
{
    public class BaseMapper : IBaseMapper
    {
        public IMapper Mapper { get; private set; }

        public BaseMapper()
        {
            Mapper = CreateMapper();
        }

        public static IMapper CreateMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingDtoProfile>();
            });

            return mapperConfiguration.CreateMapper();
        }
    }
}
