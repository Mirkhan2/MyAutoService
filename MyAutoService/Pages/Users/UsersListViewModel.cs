using System.Collections.Generic;
using MyAutoService.Models;

namespace MyAutoService.Pages.Users
{
	public class UsersListViewModel
	{
		internal List<ApplicationUser> ApplicationUsersList;
		internal Paginginfo PagingInfo;
	}
}