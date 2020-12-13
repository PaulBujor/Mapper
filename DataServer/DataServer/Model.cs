using DataServer.Models;
using DataServer.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServer
{
    //todo store places here, evt. will connect to database
    class Model
    {
        PersistenceRouter router;

        public Model()
        {
            router = new PersistenceRouter();

            //for demo
            InitPlace();
        }

        private async void InitPlace()
        {

            User user = new User()
            {
                id = 200,
                savedPlaces = new List<Place>()
            };
            await router.CreateUser(user);
            Place reitan = new Place()
            {
                title = "Reitan",
                description = "Heaven",
                longitude = 9.795995847440167,
                latitude = 55.83663617092108,
                reviews = new List<Review>()
            };
            await AddPlace(reitan);
            Report<Place> report = new Report<Place>()
            {
                category = "Blyatity",
                reportedItem = reitan
            };
            await AddPlaceReport(report);
            Review review = new Review()
            {
                id = 1,
                rating = 1,
                comment = "very beautiful, but my back hurts",
                addedBy = new UserData()
                {
                    userId = 1,
                    username = "admin"
                }
            };
            Review newReview = new Review()
            {
                id = 2,
                rating = 1,
                comment = "rema 1000 tak",
                addedBy = new UserData()
                {
                    userId = 2,
                    username = "adminomnom"
                }
            };

            await AddPlaceReview(reitan.id, review);
            await AddPlaceReview(reitan.id, newReview);
            Console.WriteLine(reitan.reviews.Count);
        }

        public async Task AddPlaceReport(Report<Place> report)
        {
            //cache.CreatePlaceReport(report);
            await router.CreatePlaceReport(report);
        }

        //todo
        public async Task AddUserReport(Report<UserData> report)
        {
            Report<User> fullReport = new Report<User>()
            {
                reportId = report.reportId,
                reportedClass = report.reportedClass,
                reportedItem = await router.GetUserById(report.reportedItem.userId),
                description = report.description,
                category = report.category,
                resolved = report.resolved
            };
            await router.CreateUserReport(fullReport);
        }

        //todo
        public async Task AddReviewReport(Report<Review> report)
        {
            await router.CreateReviewReport(report);
        }

        //todo
        public async Task AddSavedPlace(long userId, long placeId)
        {
            await router.AddSavedPlace(userId, await router.GetPlace(placeId));
        }

        //todo
        public async Task RemoveSavedPlace(long userId, long placeId)
        {
            await router.RemoveSavedPlace(userId, await router.GetPlace(placeId));
        }

        public async Task<List<Place>> GetAllPlacesAsync()
        {
            //return cache.GetPlaces().Result;
            return await router.GetPlaces();
        }

        public async Task<Place> AddPlace(Place place)
        {
            //cache.AddPlace(place);

            Console.WriteLine("returned place id: " + place.id);
            return await router.AddPlace(place); ;
        }

        public async Task UpdatePlace(Place place)
        {
            //cache.UpdatePlace(place);
            await router.UpdatePlace(place);
        }

        public async Task RemovePlace(long id)
        {
            //cache.RemovePlace(id);
            await router.RemovePlace(id);
        }

        public async Task<bool> AuthroizeUser(User user)
        {
            //User check = cache.GetUser(user.username, user.password).Result;
            User check = await router.GetUser(user.username, user.password);
            return check.auth >= 2;
        }

        public async Task<List<Report<Place>>> GetPlaceReports()
        {
            //return cache.GetPlaceReports().Result.Values.ToList();
            return await router.GetPlaceReports();
        }
        /*
		public List<Report<Place>> GetPlaceReports()
		{
			return cache.GetPlaceReports().Result.Values.ToList();
		}*/

        //public Task<Dictionary<long, Report<Review>>> GetReviewReports()
        public async Task<List<Report<Review>>> GetReviewReports()
        {
            //return cache.GetReviewReports();
            return await router.GetReviewReports();
        }
        /*
		public List<Report<Review>> GetReviewReports()
		{
			return cache.GetReviewReports().Result.Values.ToList();
		}*/

        //public Task<Dictionary<long, Report<User>>> GetUserReports()
        public async Task<List<Report<User>>> GetUserReports()
        {
            //return cache.GetUserReports();
            return await router.GetUserReports();
        }

        /*
		public List<Report<UserData>> GetUserReports()
		{
			List<Report<User>> fullReports = cache.GetUserReports().Result.Values.ToList();
			List<Report<UserData>> reports = new List<Report<UserData>>();
			foreach (Report<User> report in fullReports)
			{
				reports.Add(new Report<UserData>()
				{
					reportId = report.reportId,
					category = report.category,
					description = report.description,
					reportedClass = "UserData",
					reportedItem = new UserData()
					{
						userId = report.reportedItem.id,
						username = report.reportedItem.username
					},
					resolved = report.resolved
				});
			}
			return reports;
		}
         */

        public async Task RemoveReview(long id)
        {
            //cache.RemoveReview(id);
            await router.RemoveReview(id);
        }

        public async Task BanUser(long id)
        {
            //cache.BanUser(id);
            await router.BanUser(id);
        }

        public async Task UnbanUser(long id)
        {
            //cache.UnbanUser(id);
            await router.UnbanUser(id);
        }


        public async Task<Review> AddPlaceReview(long id, Review review)
        {
            //return cache.AddPlaceReview(id, review);
            return await router.AddReview(review, id); //not sure if it's this method
        }

        public async Task DismissPlaceReport(long reportId)
        {
            //cache.DismissPlaceReport(reportId);
            await router.DismissPlaceReport(reportId);
        }

        public async Task DismissReviewReport(long reportId)
        {
            //cache.DismissReviewReport(reportId);
            await router.DismissReviewReport(reportId);
        }

        public async Task DismissUserReport(long reportId)
        {
            //cache.DismissUserReport(reportId);
            await router.DismissUserReport(reportId);
        }

        public async Task<User> GetUserById(long userId)
        {
            //return cache.GetUserById(userId);
            return await router.GetUserById(userId);
        }


        //User CRUD

        public async Task<User> Login(string username, string password)
        {
            //return cache.GetUser(username, password);
            return await router.GetUser(username, password);
        }

        public async Task Register(User user)
        {
            //cache.Register(user);
            await router.CreateUser(user);
        }
        public async Task CheckUsername(string username)
        {
            //cache.CheckUsername(username);
            await router.CheckUsername(username);
        }

        public async Task CheckEmail(string email)
        {
            //cache.CheckEmail(email);
            await router.CheckEmail(email);
        }

        public async Task UpdateFirstName(long id, string firstName)
        {
            //cache.UpdateFirstName(id, firstName);
            await router.UpdateFirstName(id, firstName);
        }

        public async Task UpdateLastName(long id, string lastName)
        {
            //cache.UpdateLastName(id, lastName);
            await router.UpdateLastName(id, lastName);
        }

        public async Task UpdateUsername(long id, string userName)
        {
            //cache.UpdateUsername(id, userName);
            await router.UpdateUsername(id, userName);
        }

        public async Task UpdateEmail(long id, string email)
        {
            //cache.UpdateEmail(id, email);
            await router.UpdateEmail(id, email);
        }

        public async Task UpdatePassword(long id, string password)
        {
            //cache.UpdatePassword(id, password);
            await router.UpdatePassword(id, password);
        }

        public async Task<List<User>> GetBannedUsers()
        {
            return await router.GetBannedUsers();
        }
    }
}
