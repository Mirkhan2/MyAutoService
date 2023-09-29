using System.Collections.Generic;

namespace MyAutoService.Models.ViewModels
{
	public class UsersListViewModel
	{
		public List<ApplicationUser> ApplicationUsersList { get; set; }
		public PagingInfo Paginginfo { get; set; }
	}
}
