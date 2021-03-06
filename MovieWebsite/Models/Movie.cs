using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebsite.Models
{
	public class Movie
	{
		[Key]
		public int Id { get; set; }
		public bool Rented { get; set; } = false;

		[Required]
		public string Name{ get; set; }
		public int Year { get; set; }

	}
}
