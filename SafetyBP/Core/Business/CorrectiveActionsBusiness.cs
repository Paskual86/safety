using Microsoft.EntityFrameworkCore;
using SafetyBP.Core.Base;
using SafetyBP.Domain.Constants;
using SafetyBP.Domain.Interfaces;
using SafetyBP.Domain.Models.Modules.CorrectiveAction;
using SafetyBP.Persistance;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafetyBP.Core.Business
{
    public class CorrectiveActionsBusiness : BaseContextBusiness<CorrectiveActionSector>, ICorrectiveActionsBusiness
    {
        public CorrectiveActionsBusiness() : base(TableNamesConstants.CORRECTIVE_ACTIONS_SECTOR)
        {
        }

        public async Task SyncDatabaseAsync(IList<CorrectiveActionSector> correctiveActions) 
        {
            if (correctiveActions != null)
            {
                using (var blogContext = new SafetyContext())
                {
                    foreach (var controObject in correctiveActions) blogContext.CorrectiveActionSectors.Add(controObject);
                    await blogContext.SaveChangesAsync();
                }
            }
        }

        public async Task<IList<CorrectiveActionSector>> GetSectorsAsync() 
        {
            using (var blogContext = new SafetyContext())
            {
                return await blogContext.CorrectiveActionSectors.AsNoTracking().ToListAsync();
            }
        }

        public async Task<IList<CorrectiveActionTopic>> GetTopicsAsync(long sectorId) 
        {
            using (var blogContext = new SafetyContext())
            {
                return await blogContext.CorrectiveActionTopics
                    .Include(inc => inc.Sector)
                    .AsNoTracking()
                    .Where(wh => wh.SectorId == sectorId && wh.Tasks.Any(an => an.Status != 2/*Finalizado*/)).ToListAsync();
            }
        }

        public async Task<IList<CorrectiveActionTask>> GetTasksAsync(long topicId) 
        {
            using (var blogContext = new SafetyContext())
            {
                return await blogContext
                            .CorrectiveActionTasks
                            .Include(inc => inc.Topic)
                            .AsNoTracking()
                            .Where(wh => wh.TopicId == topicId).ToListAsync();
            }
        }

        public async Task UpdateTaskAsync(CorrectiveActionTask task, System.Action callback)
        {
            using (var blogContext = new SafetyContext())
            {
                var taskDb = await blogContext
                            .CorrectiveActionTasks
                            .FirstOrDefaultAsync(fo => fo.Id == task.Id);
                if (taskDb != null) 
                {
                    taskDb.Status = task.Status;
                    await blogContext.SaveChangesAsync();

                    callback?.Invoke();
                }
            }
        }
    }
}
