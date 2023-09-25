using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyAutoService.Data;
using MyAutoService.Models;

namespace MyAutoService.Pages.ServiceTypes
{
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
