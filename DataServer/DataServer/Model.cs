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
        private IPersistence cache;
        Router router;

        public Model()
        {
            cache = new Cache();
            router = new Router();


            //for demo
            InitPlace();
        }

        private void InitPlace()
        {

            User user = new User()
            {
                id = 200,
                savedPlaces = new List<Place>()
            };
            router.CreateUser(user);
            Place reitan = new Place()
            {
                title = "Reitan",
                description = "Heaven",
                longitude = 9.795995847440167,
                latitude = 55.83663617092108,
                reviews = new List<Review>()
            };
            AddPlace(reitan);
            Report<Place> report = new Report<Place>()
            {
                category = "Blyatity",
                reportedItem = reitan
            };
            AddPlaceReport(report);
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

            AddPlaceReview(reitan.id, review);
            AddPlaceReview(reitan.id, newReview);
            Console.WriteLine(reitan.reviews.Count);
        }

        public void AddPlaceReport(Report<Place> report)
        {
            //cache.CreatePlaceReport(report);
            router.CreatePlaceReport(report);
        }

        //todo
        public void AddUserReport(Report<UserData> report)
        {
            Report<User> fullReport = new Report<User>()
            {
                reportId = report.reportId,
                reportedClass = report.reportedClass,
                reportedItem = router.GetUserById(report.reportedItem.userId),
                description = report.description,
                category = report.category,
                resolved = report.resolved
            };
            router.CreateUserReport(fullReport);
        }

        //todo
        public void AddReviewReport(Report<Review> report)
        {
            router.CreateReviewReport(report);
        }

        //todo
        public async Task AddSavedPlace(long userId, long placeId)
        {
            router.AddSavedPlace(userId, await router.GetPlace(placeId));
        }

        //todo
        public async Task RemoveSavedPlace(long userId, long placeId)
        {
            router.RemoveSavedPlace(userId, await router.GetPlace(placeId));
        }

        public async Task<List<Place>> GetAllPlacesAsync()
        {
            //return cache.GetPlaces().Result;
            return await router.GetPlaces();
        }

        public Place AddPlace(Place place)
        {
            //cache.AddPlace(place);
            router.AddPlace(place);
            Console.WriteLine("returned place id: " + place.id);
            return place;
        }

        public void UpdatePlace(Place place)
        {
            //cache.UpdatePlace(place);
            router.UpdatePlace(place);
        }

        public void RemovePlace(long id)
        {
            //cache.RemovePlace(id);
            router.RemovePlace(id);
        }

        public bool AuthroizeUser(User user)
        {
            //User check = cache.GetUser(user.username, user.password).Result;
            User check = router.GetUser(user.username, user.password).Result;
            return check.auth >= 2;
        }

        public Task<List<Report<Place>>> GetPlaceReports()
        {
            //return cache.GetPlaceReports().Result.Values.ToList();
            return router.GetPlaceReports();
        }
        /*
		public List<Report<Place>> GetPlaceReports()
		{
			return cache.GetPlaceReports().Result.Values.ToList();
		}*/

        //public Task<Dictionary<long, Report<Review>>> GetReviewReports()
        public Task<List<Report<Review>>> GetReviewReports()
        {
            //return cache.GetReviewReports();
            return router.GetReviewReports();
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

        public void RemoveReview(long id)
        {
            //cache.RemoveReview(id);
            router.RemoveReview(id);
        }

        public void BanUser(long id)
        {
            //cache.BanUser(id);
            router.BanUser(id);
        }

        public void UnbanUser(long id)
        {
            //cache.UnbanUser(id);
            router.UnbanUser(id);
        }


        public Task<Review> AddPlaceReview(long id, Review review)
        {
            //return cache.AddPlaceReview(id, review);
            return (Task<Review>)router.AddReview(review, id); //not sure if it's this method
        }

        public void DismissPlaceReport(long reportId)
        {
            //cache.DismissPlaceReport(reportId);
            router.DismissPlaceReport(reportId);
        }

        public void DismissReviewReport(long reportId)
        {
            //cache.DismissReviewReport(reportId);
            router.DismissReviewReport(reportId);
        }

        public void DismissUserReport(long reportId)
        {
            //cache.DismissUserReport(reportId);
            router.DismissUserReport(reportId);
        }

        public User GetUserById(long userId)
        {
            //return cache.GetUserById(userId);
            return router.GetUserById(userId);
        }


        //User CRUD

        public Task<User> Login(string username, string password)
        {
            //return cache.GetUser(username, password);
            return router.GetUser(username, password);
        }

        public void Register(User user)
        {
            //cache.Register(user);
            router.CreateUser(user);
        }
        public void CheckUsername(string username)
        {
            //cache.CheckUsername(username);
            router.CheckUsername(username);
        }

        public void CheckEmail(string email)
        {
            //cache.CheckEmail(email);
            router.CheckEmail(email);
        }

        public void UpdateFirstName(long id, string firstName)
        {
            //cache.UpdateFirstName(id, firstName);
            router.UpdateFirstName(id, firstName);
        }

        public void UpdateLastName(long id, string lastName)
        {
            //cache.UpdateLastName(id, lastName);
            router.UpdateLastName(id, lastName);
        }

        public void UpdateUsername(long id, string userName)
        {
            //cache.UpdateUsername(id, userName);
            router.UpdateUsername(id, userName);
        }

        public void UpdateEmail(long id, string email)
        {
            //cache.UpdateEmail(id, email);
            router.UpdateEmail(id, email);
        }

        public void UpdatePassword(long id, string password)
        {
            //cache.UpdatePassword(id, password);
            router.UpdatePassword(id, password);
        }

        public async Task<List<User>> GetBannedUsers()
        {
            return await router.GetBannedUsers();
        }
    }
}
