using System.Collections.Generic;
using System.Threading.Tasks;
using DataServer.Models;

namespace DataServer.Persistence
{
    public interface IUserReport_Persistence
    {
        Task CreateUserReport(Report<User> userReport);
        Task UpdateUserReport(Report<User> userReport);
        Task<Dictionary<long, Report<User>>> GetUserReports();
        public Task DismissUserReport(long reportId);
    }
}