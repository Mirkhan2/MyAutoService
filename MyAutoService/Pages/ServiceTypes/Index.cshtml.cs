using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyAutoService.Data;
using MyAutoService.Models;
using MyAutoService.Utilities;

namespace MyAutoService.Pages.ServiceTypes
{
    [Authorize(Roles =SD.AdminEndUser)]
    public class IndexModel : PageModel
    {
       private ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
       {
            _db = db;
        }

		public IList<ServiceType> ServiceTypes { get; set; }

        public async Task<IActionResult> OnGet()
        {
            ServiceTypes = await _db.ServiceTypes.ToListAsync(); 
            return Page();
        }
    }
}
