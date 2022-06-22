﻿using System;
using System.ComponentModel.DataAnnotations;
namespace Dishes.Models;

	public class Dish
	{
		[Key]
		public int Dishid { get; set; }

		[Required]
		public string Chef { get; set; }

		[Required]
		[Range(1,5)]
		public int Tastiness { get; set; }

		[Required]
		[Range(0,int.MaxValue)]
		public int Calories { get; set; }

		[Required]
		public string Description { get; set; }

		public DateTime CreatedAt { get; set; } = DateTime.Now;
		public DateTime UpdatedAt { get; set; } = DateTime.Now;


	}


