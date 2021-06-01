using SafetyBP.Domain.Models.Modules.ControlObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafetyBP.Domain.Interfaces
{
    public interface IHardwareBusiness : ICommonBusiness<ControlObjectsHardware>
    {
        Task SyncDatabase(List<ControlObjectsHardware> controlDeObjetos);
        Task<IEnumerable<ControlObjectsSector>> GetSectorsAsync(int hardwareId);
        Task<IEnumerable<ControlObjectsSurvey>> GetSurveysAsync(int hardwareId, int sectorId);
        Task<ControlObjectsSurvey> GetSurveyByObjectIdAsync(int objectId);
        Task<IEnumerable<ControlObjectsQuestion>> GetQuestionsAsync(int surveyId);
        Task<IEnumerable<ControlObjectsCheckList>> GetCheckListsAsync(int surveyId);
        Task MarkSurveyAsInactiveAsync(int surveyId);
        Task SaveCheckListAnswer(ControlObjectsCheckList value);
        Task MarkSurveyAsFinalizeAsync(ControlObjectsSurvey survey);
        Task SaveQuestionAnswerAsync(ControlObjectsQuestion value);
    }
}
