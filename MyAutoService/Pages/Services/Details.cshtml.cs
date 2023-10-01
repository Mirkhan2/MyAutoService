using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyAutoService.Data;
using MyAutoService.Models;

namespace MyAutoService.Pages.Services
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private ApplicationDbContext _context;
        public DetailsModel(ApplicationDbContext context)
        {
			_context = context;

		}
        [BindProperty]
        public ServiceHeader ServiceHeader { get; set; }
        public List<ServiceDetails> ServiceDetails { get; set; }
        public IActionResult OnGet(int serviceid)
        {
            ServiceHeader = _context.ServiceHeaders
                .Include(s => s.Car)
                .Include(s => s.Car.ApplicationUser)
                .FirstOrDefault(s => s.Id == serviceid);


            if (ServiceHeader == null)
            
                return NotFound();

                ServiceDetails = _context.ServiceDetails.Where(d => d.ServiceHeaderId == serviceid).ToList();

                return Page();

            
        }
    }
}
