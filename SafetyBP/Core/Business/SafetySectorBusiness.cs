using Microsoft.EntityFrameworkCore;
using SafetyBP.Core.Base;
using SafetyBP.Domain.Constants;
using SafetyBP.Domain.Interfaces;
using SafetyBP.Domain.Models;
using SafetyBP.Persistance;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafetyBP.Core.Business
{
    public class SafetySectorBusiness : BaseContextBusiness<SafetySector>, ISafetySectorBusiness
    {

        public SafetySectorBusiness() : base(TableNamesConstants.SECTORS)
        {

        }

        public async Task SyncDatabaseAsync(List<SafetySector> sectors)
        {
            if (sectors.Count > 0)
            {
                using (var blogContext = new SafetyContext())
                {
                    foreach (var sector in sectors)
                    {
                        var sectorDB = blogContext
                                    .Sectors
                                    .FirstOrDefault(fo => fo.Id == sector.Id);

                        if (sectorDB == null)
                        {
                            blogContext.Sectors.Add(sector);
                        }
                        else
                        {
                            sectorDB.Id = sector.Id;
                            sectorDB.Sector = sector.Sector;
                        }
                    }

                    await blogContext.SaveChangesAsync();
                }
            }
        }

        public async Task<List<SafetySector>> GetAllSectorsAsync() 
        {
            using (var blogContext = new SafetyContext())
            {
                var result = await blogContext.Sectors.AsNoTracking().ToListAsync();
                return result;
            }
        }

    }
}
