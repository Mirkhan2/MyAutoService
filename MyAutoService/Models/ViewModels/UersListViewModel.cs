using System.Collections.Generic;

namespace MyAutoService.Models.ViewModels
{
	public class UersListViewModel
	{
		public List<ApplicationUser> applicationUsersList { get; set; }
		public Paginginfo paginginfo { get; set; }
	}
}
