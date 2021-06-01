using Microsoft.EntityFrameworkCore;
using SafetyBP.Core.Base;
using SafetyBP.Domain.Constants;
using SafetyBP.Domain.Interfaces;
using SafetyBP.Domain.Models.Modules.ControlObjects;
using SafetyBP.Persistance;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafetyBP.Core.Business
{
    public class HardwareBusiness : BaseContextBusiness<ControlObjectsHardware>, IHardwareBusiness
    {
        public HardwareBusiness() : base(TableNamesConstants.CONTROL_OBJECT_HARDWARE) {

        }
        public async Task SyncDatabase(List<ControlObjectsHardware> controlDeObjetos)
        {
            if (controlDeObjetos != null) 
            {
                using (var blogContext = new SafetyContext())
                {
                    foreach (var controObject in controlDeObjetos) blogContext.Hardwares.Add(controObject);
                    await blogContext.SaveChangesAsync();
                }
            }
        }

        public override async Task<IEnumerable<ControlObjectsHardware>> GetListAsync()
        {
            using (var blogContext = new SafetyContext()) return await blogContext.Hardwares.ToListAsync();
        }

        public async Task<IEnumerable<ControlObjectsSector>> GetSectorsAsync(int hardwareId)
        {
            using (var blogContext = new SafetyContext()) return await blogContext.ControlObjectsSectors.Where(wh => wh.HardwareId == hardwareId).ToArrayAsync();
        }

        public async Task<IEnumerable<ControlObjectsSurvey>> GetSurveysAsync(int hardwareId, int sectorId)
        {
            using (var blogContext = new SafetyContext()) 
                return await blogContext
                    .ControlObjectsSurveys
                    .Include(inc => inc.Sector)
                    .Where(wh => wh.HardwareId == hardwareId && wh.SectorId == sectorId && !wh.IsFinalize && wh.IsActive)
                    .ToArrayAsync();
        }

        public async Task<ControlObjectsSurvey> GetSurveyByObjectIdAsync(int objectId) 
        {
            using (var blogContext = new SafetyContext())
                return await blogContext
                                .ControlObjectsSurveys
                                .Include(inc => inc.Sector)
                                .FirstOrDefaultAsync(fo => fo.ObjectId == objectId && !fo.IsFinalize && fo.IsActive);
        }

        public async Task<IEnumerable<ControlObjectsQuestion>> GetQuestionsAsync(int surveyId)
        {
            using (var blogContext = new SafetyContext()) return await blogContext.ControlObjectsQuestions.Where(wh => wh.SurveyId == surveyId).ToArrayAsync();
        }

        public async Task MarkSurveyAsInactiveAsync(int surveyId) 
        {
            using (var blogContext = new SafetyContext()) 
            {
                var survey = await blogContext.ControlObjectsSurveys.FirstOrDefaultAsync(fo => fo.Id == surveyId);
                if (survey != null) 
                {
                    survey.IsActive = false;
                    await blogContext.SaveChangesAsync();
                }
            }
        }

        public async Task<IEnumerable<ControlObjectsCheckList>> GetCheckListsAsync(int surveyId) 
        {
            using (var blogContext = new SafetyContext()) return await blogContext.ControlObjectsCheckLists.Where(wh => wh.SurveyId == surveyId).ToArrayAsync();
        }

        public async Task SaveCheckListAnswer(ControlObjectsCheckList value) 
        {
            using (var blogContext = new SafetyContext())
            {
                var check = await blogContext.ControlObjectsCheckLists.FirstOrDefaultAsync(fo => fo.Id == value.Id && fo.SurveyId == value.SurveyId);
                if (check != null) 
                {
                    check.Answer = value.Answer;
                    check.SkipCheck = value.SkipCheck;
                    await blogContext.SaveChangesAsync();
                }
            }
        }

        public async Task MarkSurveyAsFinalizeAsync(ControlObjectsSurvey survey) 
        {
            using (var blogContext = new SafetyContext())
            {
                var surveyObject = await blogContext.ControlObjectsSurveys.FirstOrDefaultAsync(fo => fo.Id == survey.Id);
                if (surveyObject != null)
                {
                    surveyObject.IsFinalize = true;
                    surveyObject.Result = survey.Result;
                    await blogContext.SaveChangesAsync();
                }
            }
        }

        public async Task SaveQuestionAnswerAsync(ControlObjectsQuestion value) 
        {
            using (var blogContext = new SafetyContext())
            {
                var check = await blogContext.ControlObjectsQuestions.FirstOrDefaultAsync(fo => fo.Id == value.Id && fo.SurveyId == value.SurveyId);
                if (check != null)
                {
                    check.Answer = value.Answer;
                    await blogContext.SaveChangesAsync();
                }
            }
        }
    }
}
