using Microsoft.EntityFrameworkCore;
using SafetyBP.Core.Base;
using SafetyBP.Domain.Constants;
using SafetyBP.Domain.Extensions;
using SafetyBP.Domain.Interfaces;
using SafetyBP.Domain.Models;
using SafetyBP.Persistance;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafetyBP.Core.Business
{
    public class ModuleCheckListsBusiness : BaseContextBusiness<SafetyCheckList>, IModuleCheckListsBusiness
    {
        public ModuleCheckListsBusiness() : base(TableNamesConstants.CHECKLISTS2)
        {
        }

        public override async Task<IEnumerable<SafetyCheckList>> GetListAsync()
        {
            using (var blogContext = new SafetyContext())
            {
                var data = await blogContext
                                .CheckLists
                                .Include(inc => inc.Details)
                                .ThenInclude(inc => inc.Questions)
                                .AsNoTracking()
                                .ToListAsync();

                return data;
            }
        }

        public async Task SyncDatabaseAsync(List<SafetyCheckList> checkLists)
        {
            if (checkLists.Count > 0)
            {
                using (var blogContext = new SafetyContext())
                {
                    foreach (var check in checkLists)
                    {
                        var iCheckList = blogContext
                                    .CheckLists
                                    .Include(inc => inc.Details)
                                    .ThenInclude(inc => inc.Questions)
                                    .FirstOrDefault(fo => fo.Id == check.Id);

                        if ((iCheckList == null) || (iCheckList.Details.Count() != check.Details.Count())) 
                        {
                            blogContext.Add(check);
                        }
                        else
                        {
                            iCheckList.Id = check.Id;
                            iCheckList.Sector = check.Sector;

                            foreach (var cdetail in check.Details)
                            {
                                var taskDetail = iCheckList.Details.FirstOrDefault(fo => fo.Id == cdetail.Id);
                                if (taskDetail != null) taskDetail.UpdateValues(cdetail);
                                else check.Details.Add(cdetail);
                            }
                        }
                    }

                    await blogContext.SaveChangesAsync();
                }
            }
        }

        public async Task<int> GetCountAsync()
        {
            int result = 0;
            using (var blogContext = new SafetyContext())
            {
                result = await blogContext.CheckLists.CountAsync();
            }
            return result;
        }

        public async Task UpdateCheckListQuestionValue(SafetyCheckListQuestion value)
        {
            using (var blogContext = new SafetyContext())
            {
                var result = await blogContext.CheckListQuestions.Where(wh => wh.Id == value.Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    result.IsPendingToSyncronize = true;
                    result.Value = value.Value;
                    await blogContext.SaveChangesAsync();
                }
                
            }
        }

        public async Task SetNAStatusCheckListQuestion(int checkListId, bool status) {
            using (var blogContext = new SafetyContext())
            {
                var result = await blogContext.CheckListQuestions.Where(wh => wh.Id == checkListId).FirstOrDefaultAsync();
                if (result != null) {
                    result.Value = "2";
                    result.DoesNotApply = status;
                    result.IsPendingToSyncronize = true;
                    await blogContext.SaveChangesAsync();
                }
            }
        }

        public async Task SettleUpdateCheckListQuestionOperation(SafetyCheckListQuestion value)
        {
            using (var blogContext = new SafetyContext())
            {
                var result = await blogContext.CheckListQuestions.Where(wh => wh.Id == value.Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    result.IsPendingToSyncronize = false;
                    await blogContext.SaveChangesAsync();
                }
            }
        }

        public async Task FinalizeCheckList(SafetyCheckListDetail value) {

            using (var blogContext = new SafetyContext())
            {
                var result = await blogContext.CheckListDetails.Where(wh => wh.Id == value.Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    result.IsPendingToSyncronize = false;
                    result.Complete = true;
                    await blogContext.SaveChangesAsync();
                }
            }
        }
    }
}
