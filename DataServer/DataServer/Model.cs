﻿using DataServer.Models;
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
			Place reitan = new Place()
			{
				title = "Reitan",
				description = "Heaven",
				longitude = 9.795995847440167,
				latitude = 55.83663617092108
			};
			AddPlace(reitan);
			Report<Place> report = new Report<Place>()
			{
				category = "Blyatity",
				reportedItem = reitan
			};
			AddPlaceReport(report);
		}

		public void AddPlaceReport(Report<Place> report)
		{
			cache.CreatePlaceReport(report);
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

		public bool AuthroizeUser(User user)
		{
			User check = cache.GetUser(user.username, user.password).Result;
			return check.auth >= 2;
		}

		public List<Report<Place>> GetPlaceReports()
		{
			return cache.GetPlaceReports().Result.Values.ToList();
		}

		public Task<Dictionary<long, Report<ReviewItem>>> GetReviewReports()
		{
			return cache.GetReviewReports();
		}

		public Task<Dictionary<long, Report<User>>> GetUserReports()
		{
			return cache.GetUserReports();
		}

		internal void RemoveReview(long id)
		{
			cache.RemoveReview(id);
		}

		internal void BanUser(long id)
		{
			cache.BanUser(id);
		}

		internal void UnbanUser(long id)
		{
			cache.UnbanUser(id);
		}

		internal void DismissReport(long reportId)
		{
			if (GetPlaceReports().FirstOrDefault(report => report.reportId == reportId) != null)
				cache.DismissPlaceReport(reportId);
			//todo remaining dismiss or better/ more efficient solution
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
			cache.UpdateFirstName(id,firstName);
		}

		public void UpdateLastName(long id, string lastName)
		{
			cache.UpdateLastName(id,lastName);
		}

		public void UpdateUsername(long id, string userName)
		{
			cache.UpdateUsername(id,userName);
		}

		public void UpdateEmail(long id, string email)
		{
			cache.UpdateEmail(id,email);
		}

		public void UpdatePassword(long id, string password)
		{
			cache.UpdatePassword(id,password);
		}
	}
}
