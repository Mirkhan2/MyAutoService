using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyAutoService.Data;
using MyAutoService.Models.ViewModels;

namespace MyAutoService.Pages.Cars
{
    public class IndexModel : PageModel
    {
        ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public CarAndCustomerViewModel CarAndCustomerViewModel { get; set; }

        public async Task<IActionResult> OnGet(string userId=null)
        {
            if (userId == null )
            {
                var claimsIdentity = (ClaimsIdentity) User.Identity;
                var claim = claimsIdentity.FindFirst( ClaimTypes.NameIdentifier);
                userId = claim.Value;
            }
            CarAndCustomerViewModel = new CarAndCustomerViewModel()
            {
                Cars = await _db.Cars.Where(c => c.UserId == userId).ToListAsync(),
                User = await _db.ApplicationUser.FirstOrDefaultAsync(u => u.Id == userId)
            };
            return Page();
        }
    }
}
