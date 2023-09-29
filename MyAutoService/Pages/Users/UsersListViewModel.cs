using System.Collections.Generic;
using MyAutoService.Models;

namespace MyAutoService.Pages.Users
{
	public class UsersListViewModel
	{
		public List<ApplicationUser> ApplicationUserList { get; set; }
		public PagingInfo PagingInfo { get; set; }

	}
}