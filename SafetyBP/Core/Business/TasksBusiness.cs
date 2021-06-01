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
    public class TasksBusiness : BaseContextBusiness<SafetyTask>, ITasksBusiness
    {
        public TasksBusiness() : base(TableNamesConstants.TASKS2)
        {
        }

        public override async Task<IEnumerable<SafetyTask>> GetListAsync()
        {
            using (var blogContext = new SafetyContext())
            {
                var data = await blogContext
                                .Tasks
                                .Include(inc => inc.Details)
                                .ThenInclude(inc => inc.CheckList)
                                .AsNoTracking()
                                .ToListAsync();

                return data;
            }
        }


        public async Task SyncDatabaseAsync(List<SafetyTask> tasks)
        {
            if (tasks.Count > 0) {
                using (var blogContext = new SafetyContext())
                {
                    if (!ForcedUpdateRecords)
                    {
                        foreach (var task in tasks)
                        {
                            var iTask = blogContext
                                        .Tasks
                                        .Include(inc => inc.Details)
                                        .ThenInclude(inc => inc.CheckList)
                                        .Include(inc => inc.AdditionalData)
                                        .FirstOrDefault(fo => fo.Id == task.Id);

                            if ((iTask == null) || (iTask.Details.Count() != task.Details.Count()))
                            {
                                blogContext.Add(task);
                            } else {
                                iTask.Id = task.Id;
                                iTask.Sector = task.Sector;

                                foreach (var tdetail in task.Details) {
                                    var taskDetail = iTask.Details.FirstOrDefault(fo => fo.Id == tdetail.Id);
                                    if (taskDetail != null) taskDetail.UpdateValues(tdetail);
                                    else task.Details.Add(tdetail);
                                }
                            }
                        }

                        await blogContext.SaveChangesAsync();
                    }
                }
            }
        }

        public async Task UpdateCheckListAsync(SafetyTaskCheckList checkList, System.Action callback) {
            using (var blogContext = new SafetyContext())
            {
                var chkInternal = blogContext.TaskDetailsCheckLists.FirstOrDefault(fo => fo.Id == checkList.Id);
                if (chkInternal != null) {
                    chkInternal.UpdateValues(checkList);
                    await blogContext.SaveChangesAsync();
                }

                callback?.Invoke();
            }
        }

        public async Task UpdateTaskDetailAsync(SafetyTaskDetails checkList)
        {
            using (var blogContext = new SafetyContext())
            {
                var chkInternal = blogContext
                                    .TaskDetails
                                    .Include(inc => inc.CheckList)
                                    .FirstOrDefault(fo => fo.Id == checkList.Id);
                if (chkInternal != null)
                {
                    chkInternal.UpdateValues(checkList);
                    await blogContext.SaveChangesAsync();
                }
            }
        }

        public async Task<int> GetCountAsync()
        {
            int result = 0;

            using (var blogContext = new SafetyContext())
            {
                result = await blogContext.Tasks.CountAsync();
            }

            return result;
        }
    }
}
