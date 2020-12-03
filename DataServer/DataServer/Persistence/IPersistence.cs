﻿using DataServer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataServer.Persistence
{
	public interface IPersistence
	{
		//TODO some of these probably dont need to be async since some wait for data to be finished, and socket shouldnt do something else

		//PLACES CRUD
		Task<Place> AddPlace(Place place);

		Task<List<Place>> GetPlaces();

		Task<Place> GetPlace(long id);

		Task UpdatePlace(Place place);

		Task RemovePlace(long id);

		//REVIEW CRUD
		Task AddReview(ReviewItem review, long placeId);

		Task<List<ReviewItem>> GetReviews(long placeId);

		Task UpdateReview(ReviewItem reviewItem);

		Task RemoveReview(long reviewId);

		//USER CRUD
		Task CreateUser(User user);

		Task<User> GetUser(string username, string password);

		Task UpdateUser(User user);

		Task BanUser(long userId);

		Task UnbanUser(long userId);

		//REPORT CRUD
		Task CreatePlaceReport(Report<Place> placeReport);

		Task CreateReviewReport(Report<ReviewItem> reviewReport);

		Task CreateUserReport(Report<User> userReport);

		Task UpdatePlaceReport(Report<Place> placeReport);

		Task UpdateReviewReport(Report<ReviewItem> reviewReport);

		Task UpdateUserReport(Report<User> userReport);

		Task<Dictionary<long, Report<Place>>> GetPlaceReports();

		Task<Dictionary<long, Report<ReviewItem>>> GetReviewReports();

		Task<Dictionary<long, Report<User>>> GetUserReports();
		Task DismissPlaceReport(long reportId);
	}
}
