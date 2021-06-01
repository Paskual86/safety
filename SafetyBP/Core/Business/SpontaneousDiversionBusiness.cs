using Microsoft.EntityFrameworkCore;
using SafetyBP.Core.Base;
using SafetyBP.Domain.Constants;
using SafetyBP.Domain.Interfaces;
using SafetyBP.Domain.Models;
using SafetyBP.Persistance;
using SafetyBP.Services.WebServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SafetyBP.Core.Business
{
    public class SpontaneousDiversionBusiness : BaseContextBusiness<SafetySpontaneousDiversion>, ISpontaneousDiversionBusiness
    {
        private readonly ISpontaneousDiversionRestClient _restClient;
        public SpontaneousDiversionBusiness():base(TableNamesConstants.SPONTANEOUSDIVERSION)
        {
            _restClient = DependencyService.Get<ISpontaneousDiversionRestClient>();
        }

        public async Task AddSpontaneousDiversionAsync(SafetySpontaneousDiversion value)
        {
            using (var blogContext = new SafetyContext())
            {
                if (value.Sector != null) {
                    value.SectorId = value.Sector.Id;
                    value.Sector = null;
                    blogContext.SpontaneousDiversions.Add(value);
                    await blogContext.SaveChangesAsync();
                }
            }
        }

        public async Task<bool> AnyPendingToFinalizeAsync()
        {
            using (var blogContext = new SafetyContext())
            {
                return await blogContext.SpontaneousDiversions.AsNoTracking().Where(wh => !wh.Synchronized).AnyAsync();
            }
        }

        public async Task<IEnumerable<SafetySpontaneousDiversion>> GetPendingToFinalizeListAsync()
        {
            using (var blogContext = new SafetyContext())
            {
                return await blogContext
                    .SpontaneousDiversions
                    .Include(inc => inc.Sector)
                    .AsNoTracking()
                    .Where(wh => !wh.Synchronized).ToListAsync();
            }
        }

        public override async Task<IEnumerable<SafetySpontaneousDiversion>> GetListAsync()
        {
            using (var blogContext = new SafetyContext())
            {
                return await blogContext.SpontaneousDiversions.ToListAsync();
            }
        }
        
        public async Task SendToServer(string roundName, System.Action callbackSuccess) 
        {
            var itemsToSend = new List<SafetySpontaneousDiversion>();

            using (var blogContext = new SafetyContext())
            {
                var items = await blogContext.SpontaneousDiversions.Where(wh => !wh.Synchronized).ToListAsync();

                foreach (var item in items)
                {
                    item.Synchronized = true;
                    item.RoundName = roundName;
                    itemsToSend.Add(item);
                    
                }
                await blogContext.SaveChangesAsync();
                await _restClient.SaveAsync(itemsToSend, result => {
                    callbackSuccess.Invoke();
                    });
            }

        }

        public async Task Clear()
        {
            using (var blogContext = new SafetyContext())
            {
                blogContext.SpontaneousDiversions.RemoveRange(await blogContext
                    .SpontaneousDiversions
                    .Where(wh => !wh.Synchronized).ToArrayAsync());
                await blogContext.SaveChangesAsync();
            }
        }
    }
}
