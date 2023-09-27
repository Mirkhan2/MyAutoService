using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyAutoService.Data;
using MyAutoService.Models;
using MyAutoService.Utilities;

namespace MyAutoService.Pages.Users
{
	public class IndexModel : PageModel
	{
		private readonly ApplicationDbContext _db;

		//private UsersListViewModel usersListViewModel;

		public IndexModel(ApplicationDbContext db)
		{
			_db = db;
		}
		[BindProperty]
		public UsersListViewModel UsersListViewModel { get; set; }

		public async Task<IActionResult> OnGet(int pageId = 1, string searchName = null, string searchEmail = null ,string searchPhone = null)
		{
			UsersListViewModel = new UsersListViewModel()
			{


				ApplicationUsersList = await _db.ApplicationUser.ToListAsync(),
			};
			StringBuilder param = new StringBuilder();
			param.Append("/Users?pageId= :");
			param.Append("&searchName =");
			if (searchName != null)
				param.Append(searchName);

			param.Append("&searchEmail =");
			if (searchName != null)
				param.Append(searchEmail);

			param.Append("&searchPhone =");
			if (searchName != null)
				param.Append(searchPhone);
			
			if (searchName != null || searchEmail!=null || searchPhone != null)
			{
				UsersListViewModel.ApplicationUsersList = _db.ApplicationUser.Where(u => u.Name.Contains(searchName)||u.Email.Contains(searchEmail)||u.PhoneNumber.Contains(searchPhone)).ToList();
			}

			var count = UsersListViewModel.ApplicationUsersList.Count;
			
			UsersListViewModel.PagingInfo = new Paginginfo()
			{
				CurrentPage = pageId,
				ItemPerPage = 2,
				TotalItems = count,
				urlParam = param.ToString()
			};
			UsersListViewModel.ApplicationUsersList = UsersListViewModel.ApplicationUsersList.OrderBy(u => u.Name).ToList();
			//UsersListViewModel.ApplicationUsersList = UsersListViewModel.ApplicationUsersList.OrderBy(u =>u.Name).
			//	Skip(pageId -1) * 2) * SD.PagingUserCount).Take(SD.PagingUserCount).ToList();
	
			return Page();
		}
	}
}
