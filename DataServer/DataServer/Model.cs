using DataServer.Models;
using DataServer.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServer
{
    class Model
    {
        PersistenceRouter router;

        public Model()
        {
            router = new PersistenceRouter();

            //for demo
            try
            {
                //InitPlace();
            } catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}
        }

        private async Task InitPlace()
        {
            User user = new User()
            {
                savedPlaces = new List<Place>(),
                auth = 1,
                password = "123",
                username = "mamamia",
                email = "bonjour@blyat.dk"
            };
            await router.CreateUser(user);
            
            PlaceLite reitan = new PlaceLite()
            {
                title = "Reitan",
                description = "Heaven",
                longitude = 9.795995847440167,
                latitude = 55.83663617092108,
                reviews = new List<Review>(),
                addedBy = new UserData(user)
            };
            await AddPlace(reitan);
            Report<PlaceLite> report = new Report<PlaceLite>()
            {
                category = "Blyatity",
                reportedItem = reitan
            };
            await AddPlaceReport(report);
            ReviewLite review = new ReviewLite()
            {
                rating = 1,
                comment = "very beautiful, but my back hurts",
                addedBy = new UserData(user)
            };
            ReviewLite newReview = new ReviewLite()
            {
                rating = 1,
                comment = "rema 1000 tak",
                addedBy = new UserData(user)
            };

            await AddPlaceReview(reitan.id, review);
            await AddPlaceReview(reitan.id, newReview);
        }

        //todo convert to placelite
        public async Task AddPlaceReport(Report<PlaceLite> report)
        {
            Report<Place> fullReport = new Report<Place>()
            {
                reportId = report.reportId,
                reportedClass = report.reportedClass,
                reportedItem = await router.GetPlace(report.reportedItem.id),
                description = report.description,
                category = report.category,
                resolved = report.resolved
            };
            await router.CreatePlaceReport(fullReport);
        }

        
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

        public async Task AddReviewReport(Report<ReviewLite> report)
        {
            Report<Review> fullReport = new Report<Review>()
            {
                reportId = report.reportId,
                reportedClass = report.reportedClass,
                reportedItem = await router.GetReview(report.reportedItem.id),
                description = report.description,
                category = report.category,
                resolved = report.resolved
            };
            await router.CreateReviewReport(fullReport);
        }

        public async Task AddSavedPlace(long userId, long placeId)
        {
            await router.AddSavedPlace(userId, await router.GetPlace(placeId));
        }

        public async Task RemoveSavedPlace(long userId, long placeId)
        {
            await router.RemoveSavedPlace(userId, await router.GetPlace(placeId));
        }

        public async Task<List<PlaceLite>> GetAllPlacesAsync()
        {
            List<Place> places = await router.GetPlaces();
            List<PlaceLite> newPlaces = new List<PlaceLite>();
            foreach(Place place in places)
			{
                newPlaces.Add(new PlaceLite(place));
			}
            return newPlaces;
        }

        public async Task AddPlace(PlaceLite place)
        {
            Place addedPlace = new Place(place, await GetUserById(place.addedBy.userId));
            await router.AddPlace(addedPlace);
            place.id = addedPlace.id;
        }

        public async Task UpdatePlace(PlaceLite place)
        {
            Place addedPlace = new Place(place, await GetUserById(place.addedBy.userId));
            await router.UpdatePlace(addedPlace);
            place.id = addedPlace.id;
        }

        public async Task RemovePlace(long id)
        {
            await router.RemovePlace(id);
        }

        public async Task<bool> AuthroizeUser(User user)
        {
            User check = await router.GetUser(user.username, user.password);
            return check.auth >= 2;
        }

        public async Task<List<Report<PlaceLite>>> GetPlaceReports()
        {
            List<Report<Place>> reports = await router.GetPlaceReports();
            List<Report<PlaceLite>> newReports = new List<Report<PlaceLite>>();
            foreach (Report<Place> report in reports)
            {
				Console.WriteLine(report.reportedItem.id);
                newReports.Add(new Report<PlaceLite>()
                {
                    reportId = report.reportId,
                    reportedClass = report.reportedClass,
                    reportedItem = new PlaceLite(report.reportedItem),
                    description = report.description,
                    category = report.category,
                    resolved = report.resolved
                });
            }
            return newReports;
        }

        public async Task<List<Report<ReviewLite>>> GetReviewReports()
        {
            List<Report<Review>> reports = await router.GetReviewReports();
            List<Report<ReviewLite>> newReports = new List<Report<ReviewLite>>();
            foreach (Report<Review> report in reports)
            {
                newReports.Add(new Report<ReviewLite>()
                {
                    reportId = report.reportId,
                    reportedClass = report.reportedClass,
                    reportedItem = new ReviewLite(report.reportedItem),
                    description = report.description,
                    category = report.category,
                    resolved = report.resolved
                });
            }
            return newReports;
        }

        public async Task<List<Report<UserData>>> GetUserReports()
        {
            List<Report<User>> reports = await router.GetUserReports(); ;
            List<Report<UserData>> newReports = new List<Report<UserData>>();
            foreach (Report<User> report in reports)
			{
                newReports.Add(new Report<UserData>()
                {
                    reportId = report.reportId,
                    reportedClass = report.reportedClass,
                    reportedItem = new UserData(report.reportedItem),
                    description = report.description,
                    category = report.category,
                    resolved = report.resolved
                });
			}
            return newReports;
        }

        public async Task RemoveReview(long id)
        {
            await router.RemoveReview(id);
        }

        public async Task BanUser(long id)
        {
            await router.BanUser(id);
        }

        public async Task UnbanUser(long id)
        {
            await router.UnbanUser(id);
        }


        //todo convert to reviewlite
        public async Task<Review> AddPlaceReview(long id, ReviewLite review)
        {
            Review fullReview = new Review(review, await GetUserById(review.addedBy.userId));
            return await router.AddReview(fullReview, id);
        }

        public async Task DismissPlaceReport(long reportId)
        {
            await router.DismissPlaceReport(reportId);
        }

        public async Task DismissReviewReport(long reportId)
        {
            await router.DismissReviewReport(reportId);
        }

        public async Task DismissUserReport(long reportId)
        {
            await router.DismissUserReport(reportId);
        }

        public async Task<User> GetUserById(long userId)
        {
            User user = await router.GetUserById(userId);
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

        public async Task<List<UserData>> GetBannedUsers()
        {
            List<User> users = await router.GetBannedUsers();
            List<UserData> strippedUsers = new List<UserData>();
            foreach (User user in users)
			{
                strippedUsers.Add(new UserData(user));
			}
            return strippedUsers;
        }
    }
}
