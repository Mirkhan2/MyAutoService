using System;

namespace MyAutoService.Models
{
	public class Paginginfo
	{
        public int TotalItems { get; set; }
		public int ItemPerPage { get; set; }
		public int CurrentPage { get; set; }
		public int TotalPage => (int)Math.Ceiling((decimal) TotalItems / ItemPerPage );

			public string urlParam { get; set; }
	}
}
