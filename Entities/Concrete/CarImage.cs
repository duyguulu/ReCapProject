﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
	public class CarImage : IEntity
	{
		public int CarImageId { get; set; }
		public int CarId { get; set; }
		public string ImagePath { get; set; }
		public string ImageName { get; set; }
		public DateTime DateT { get; set; }
	}
}
