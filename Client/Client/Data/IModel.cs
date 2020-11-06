﻿using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Data
{
	public interface IModel
	{
		Task AddPlaceAsync(Place place);

		IList<Place> GetPlaces();
	}
}