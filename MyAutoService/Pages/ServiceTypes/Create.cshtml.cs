using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyAutoService.Data;
using MyAutoService.Models;

namespace MyAutoService.Pages.ServiceTypes
{
    public class CreateModel : PageModel
    {
        ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public ServiceType ServiceType { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }

		public async Task<IActionResult> OnPost(ServiceType serviceType)
		{
			if (!ModelState.IsValid)
			{
				return Page();

			}

			_db.ServiceTypes.Add(serviceType);
			await _db.SaveChangesAsync();
			return RedirectToPage("Index");
		}
		//      public IActionResult OnPost(ServiceType serviceType)
		//      {
		//          if(!ModelState.IsValid)
		//          {
		//		return Page();

		//          }

		//         _db.ServiceTypes.Add(serviceType);
		//          _db.SaveChanges();
		//	return RedirectToPage("Index");
		//}
	}
}
