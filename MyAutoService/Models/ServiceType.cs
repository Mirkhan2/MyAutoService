﻿using System.ComponentModel.DataAnnotations;

namespace MyAutoService.Models
{
	public class ServiceType
	{
        public int Id { get; set; }

		[Required]
		[MaxLength(555)]
		public string Name { get; set; }

        [Required]
        public double Price { get; set; }
    }
}