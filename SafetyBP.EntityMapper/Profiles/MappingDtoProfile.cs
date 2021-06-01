using AutoMapper;
using SafetyBP.Domain.Helpers;
using SafetyBP.Domain.Models;
using SafetyBP.Domain.Models.Modules.ControlObjects;
using SafetyBP.Domain.Models.Modules.CorrectiveAction;
using SafetyBP.Dtos;
using SafetyBP.Dtos.Requests;

namespace SafetyBP.EntityMapper.Profiles
{
    public class MappingDtoProfile : Profile
    {
        public MappingDtoProfile()
        {
            CreateMap<TaskCheckListDto, SafetyTaskCheckList>()
                .ForMember(dest => dest.IsPendingToSync, opt => opt.Ignore());

            CreateMap<TaskDetailsDto, SafetyTaskDetails>()
            .ForMember(dest => dest.StartDateTime, opt => opt.MapFrom(src => DatetimeHelper.ConvertFromString(src.StartDateTime)))
            .ForMember(dest => dest.EndDateTime, opt => opt.MapFrom(src => DatetimeHelper.ConvertFromString(src.EndDateTime)))
            .ForMember(dest => dest.Files, opt => opt.MapFrom(src => StringHelper.ConcatenateString(src.Files)))
            .ForMember(dest => dest.IsComplete, opt => opt.Ignore());

            CreateMap<TaskDto, SafetyTask>();

            CreateMap<ControlObjectsQuestionDto, ControlObjectsQuestion>();
            CreateMap<ControlObjectsCheckListDto, ControlObjectsCheckList>()
                .ForMember(dest => dest.NegativeValues, opt => opt.MapFrom(src => SafetyHelper.ConvertIntToControlObjectsNegativeValues(src.NegativeValues)));
            CreateMap<ControlObjectsSurveyDto, ControlObjectsSurvey>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.IsFinalize, opt => opt.MapFrom(src => false));

            CreateMap<ControlObjectsSectorsDto, ControlObjectsSector>();
            CreateMap<ControlObjectsHardwareDto, ControlObjectsHardware>();

            CreateMap<CheckListDto, SafetyCheckList>();
            CreateMap<CheckListDetailDto, SafetyCheckListDetail>()
                .ForMember(dest => dest.DueDateTime, opt => opt.MapFrom(src => DatetimeHelper.ConvertFromString(src.Date)));

            CreateMap<CheckListQuestionDto, SafetyCheckListQuestion>()
                .ForMember(dest => dest.NegativeValues, opt => opt.MapFrom(src => SafetyHelper.ConvertIntToNegativeValues(src.NegativeValues)));

            CreateMap<SectorDto, SafetySector>();
            CreateMap<SafetySpontaneousDiversion, SafetySpontaneousDiversionDetailRequestDto>()
                .ForMember(dest => dest.Risk, opt => opt.MapFrom(src => (byte)src.Risk));

            CreateMap<CorrectiveActionTaskDto, CorrectiveActionTask>();
            CreateMap<CorrectiveActionTopicDto, CorrectiveActionTopic>()
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => DatetimeHelper.ConvertDatetimeFromString(src.DueDate)));
            CreateMap<CorrectiveActionSectorDto, CorrectiveActionSector>();
            
        }
    }
}
