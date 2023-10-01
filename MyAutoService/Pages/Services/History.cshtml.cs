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
	public class HistoryModel : PageModel
	{
		private ApplicationDbContext _context;
		public HistoryModel(ApplicationDbContext context)
		{
			_context = context;
		}

        [BindProperty]
        public List<ServiceHeader> ServiceHeaders { get; set; }

        public string UserId { get; set; }

        public void OnGet(int carId)
		{
            ServiceHeaders = _context.ServiceHeaders
                .Include(c => c.Car)
                .Include(c => c.Car.ApplicationUser)
                .Where(c => c.CarId == carId).ToList();

            UserId = _context.Cars.Where(c => c.Id == carId).FirstOrDefault().UserId;
        }
	}
}
