using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataServer.Persistence.Impl
{
    public class PlacesReportImpl : IPlacesReport_Persistence
    {
        private MapDbContext dbContext;

        public PlacesReportImpl(MapDbContext context)
        {
            dbContext = context;
        }
        public async Task CreatePlaceReport(Report<Place> placeReport)
        {
            /*EntityEntry<Report<Place>> newlyAdded = */
            await dbContext.PlaceReports.AddAsync(placeReport);
            await dbContext.SaveChangesAsync();
        }

        public async Task DismissPlaceReport(long reportId)
        {
            Report<Place> toDismiss = await dbContext.PlaceReports.FirstOrDefaultAsync(pr => pr.reportId == reportId);
            toDismiss.resolved = true;
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Report<Place>>> GetPlaceReports()
        {
            return await dbContext.PlaceReports
                .Where(r => !r.resolved)
                .Include(r => r.reportedItem)
                .ThenInclude(r => r.addedBy)
                .ToListAsync();
        }

        public async Task UpdatePlaceReport(Report<Place> placeReport)
        {
            dbContext.PlaceReports.Update(placeReport);
            await dbContext.SaveChangesAsync();
        }
    }
}