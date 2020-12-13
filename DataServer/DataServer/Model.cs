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

		public Model()
		{
			cache = new Cache();

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
			cache.Register(user);
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
			cache.CreatePlaceReport(report);
		}

		public void AddUserReport(Report<UserData> report)
		{
			Report<User> fullReport = new Report<User>()
			{
				reportId = report.reportId,
				reportedClass = report.reportedClass,
				reportedItem = cache.GetUserById(report.reportedItem.userId),
				description = report.description,
				category = report.category,
				resolved = report.resolved
			};
			cache.CreateUserReport(fullReport);
		}

		public void AddReviewReport(Report<Review> report)
		{
			cache.CreateReviewReport(report);
		}

		public List<Place> GetAllPlaces()
		{
			return cache.GetPlaces().Result;
		}

		public Place AddPlace(Place place)
		{
			cache.AddPlace(place);
			Console.WriteLine("returned place id: " + place.id);
			return place;
		}

		public void UpdatePlace(Place place)
		{
			cache.UpdatePlace(place);
		}

		public void RemovePlace(long id)
		{
			cache.RemovePlace(id);
		}

		public void AddSavedPlace(long userId, long placeId)
		{
			cache.AddSavedPlace(userId, placeId);
		}

		public void RemoveSavedPlace(long userId, long placeId)
		{
			cache.RemoveSavedPlace(userId, placeId);
		}

		internal List<UserData> GetBannedUsers()
		{
			List<User> users = cache.GetBannedUsers().Result.Values.ToList();
			List<UserData> userData = new List<UserData>();
			foreach (User user in users)
			{
				userData.Add(new UserData() { userId = user.id, username = user.username });
			}
			return userData;
		}

		public bool AuthroizeUser(User user)
		{
			User check = cache.GetUser(user.username, user.password).Result;
			return check.auth >= 2;
		}

		public List<Report<Place>> GetPlaceReports()
		{
			return cache.GetPlaceReports().Result.Values.ToList();
		}

		public List<Report<Review>> GetReviewReports()
		{
			return cache.GetReviewReports().Result.Values.ToList();
		}

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

		public void RemoveReview(long id)
		{
			cache.RemoveReview(id);
		}

		public void BanUser(long id)
		{
			cache.BanUser(id);
		}

		public void UnbanUser(long id)
		{
			cache.UnbanUser(id);
		}


		public Task<Review> AddPlaceReview(long id, Review review)
		{
			return cache.AddPlaceReview(id, review);
		}

		public void DismissPlaceReport(long reportId)
		{
			cache.DismissPlaceReport(reportId);
		}

		public void DismissReviewReport(long reportId)
		{
			cache.DismissReviewReport(reportId);
		}

		public void DismissUserReport(long reportId)
		{
			cache.DismissUserReport(reportId);
		}

		public User GetUserById(long userId)
		{
			return cache.GetUserById(userId);
		}


		//User CRUD

		public Task<User> Login(string username, string password)
		{
			return cache.GetUser(username, password);
		}

		public void Register(User user)
		{
			cache.Register(user);
		}
		public void CheckUsername(string username)
		{
			cache.CheckUsername(username);
		}

		public void CheckEmail(string email)
		{
			cache.CheckEmail(email);
		}

		public void UpdateFirstName(long id, string firstName)
		{
			cache.UpdateFirstName(id, firstName);
		}

		public void UpdateLastName(long id, string lastName)
		{
			cache.UpdateLastName(id, lastName);
		}

		public void UpdateUsername(long id, string userName)
		{
			cache.UpdateUsername(id, userName);
		}

		public void UpdateEmail(long id, string email)
		{
			cache.UpdateEmail(id, email);
		}

		public void UpdatePassword(long id, string password)
		{
			cache.UpdatePassword(id, password);
		}
	}
}
