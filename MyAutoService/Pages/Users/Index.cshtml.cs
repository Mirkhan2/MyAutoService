using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyAutoService.Data;
using MyAutoService.Models;

namespace MyAutoService.Pages.Users
{
	public class IndexModel : PageModel
	{
		private readonly ApplicationDbContext _db;
		public IndexModel(ApplicationDbContext db)
		{
			_db = db;
		}
	//	[BindProperty]
//		public UsersListViewModel UsersListViewModel { get; set; }



		//public async Task<IActionResult> OnGet()
		//{
		//	UsersListViewModel = new UsersListViewModel()
		//	{

		//		applicationUsersList = await _db.ApplicationUser.ToListAsync(),
		//	};
		//	StringBuilder param = new StringBuilder();
		//	param.Append("/Users?productPage :");
		//	var count = UsersListViewModel.ApplicationUser.Count;
		//	UsersListViewModel.PagingInfo = new Paginginfo()
		//	{
		//		CurrentPage = pageId,
		//		ItemPerPage = 2,
		//		TotalItems = count,
		//		urlParam = param.ToString()
		//	};
		//	UsersListViewModel.ApplicatonViewModel = UsersListViewModel.ApplicatopnUserList.OrderBy(uint => uint.Name)
		//		.Skip(pageId - 1)* 2).Take(2).ToList;
		//	return Page();
		//}
	}
}
