using System.Collections.Generic;
using System.Threading.Tasks;
using DataServer.Models;

namespace DataServer.Persistence
{
    public interface IPlacesReport_Persistence
    {
         Task CreatePlaceReport(Report<Place> placeReport);
         Task UpdatePlaceReport(Report<Place> placeReport);
         Task<Dictionary<long, Report<Place>>> GetPlaceReports();
         Task DismissPlaceReport(long reportId);
    }
}