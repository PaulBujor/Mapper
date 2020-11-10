﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models
{
	[Serializable]
	public class PlaceTask
	{
		public string taskName { get; set; }
		public Place place { get; set; }
		public long placeID { get; set; }

		public PlaceTask(string taskName, Place place, long placeID)
		{
			this.taskName = taskName;
			this.place = place;
			this.placeID = placeID;
		}
	}
}