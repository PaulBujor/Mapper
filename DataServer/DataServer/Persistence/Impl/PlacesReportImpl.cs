using System.Collections.Generic;
using System.Threading.Tasks;
using DataServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataServer.Persistence.Impl
{
    public class PlacesReportImpl : IPlacesReport_Persistence
    {
        MapDbContext dbContext;

        public PlacesReportImpl()
        {
            dbContext = new MapDbContext();
        }
        public async Task CreatePlaceReport(Report<Place> placeReport)
        {
            /*EntityEntry<Report<Place>> newlyAdded = */await dbContext.PlaceReports.AddAsync(placeReport);
            await dbContext.SaveChangesAsync();
        }

        public async Task DismissPlaceReport(long reportId)
        {
            Report<Place> toDismiss = await dbContext.PlaceReports.FirstOrDefaultAsync(pr => pr.reportId == reportId);
            toDismiss.resolved = true;
        }

        public async Task<Dictionary<long, Report<Place>>> GetPlaceReports()
        {
            List<Report<Place>> myList = await dbContext.PlaceReports.ToListAsync();
            Dictionary<long, Report<Place>> myDic = new Dictionary<long, Report<Place>>();
            foreach (Report<Place> item in myList)
            {
                myDic.Add(item.reportId, item);
            }
            return myDic;
        }

        public async Task UpdatePlaceReport(Report<Place> placeReport)
        {
            dbContext.PlaceReports.Update(placeReport);
        }
    }
}