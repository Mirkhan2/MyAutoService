using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyAutoService.Data;
using MyAutoService.Models;
using MyAutoService.Models.ViewModels;

namespace MyAutoService.Pages.Services
{
	public class CreateModel : PageModel
	{
		private ApplicationDbContext _db;
		public CreateModel(ApplicationDbContext db)
		{
			_db = db;
		}
		[BindProperty]
		public CarServiceviewModel CarServiceVM { get; set; }
		public async Task<IActionResult> OnGet(int carId)
		{
			CarServiceVM = new CarServiceviewModel()
			{
				car = await _db.Cars.Include(c => c.ApplicationUser)
				.FirstOrDefaultAsync(c => c.Id == carId),
				ServiceHeader = new ServiceHeader()

			};
			List<string> lstServiceTypeInShoppingCart = _db.ServicesShoppingCarts
				.Include(c => c.ServiceType)
				.Where(c => c.CarId == carId)
				.Select(c => c.ServiceType.Name)
				.ToList();

			IQueryable<ServiceType> lstServices = from s in _db.ServiceTypes
												  where !(lstServiceTypeInShoppingCart.Contains(s.Name))
												  select s;

			CarServiceVM.ServiceTypesList = lstServices.ToList();
			CarServiceVM.ServicesShoppingCart = _db.ServicesShoppingCarts.Include(c => c.ServiceType)
				.Where(c => c.CarId == carId)
				.ToList();
			CarServiceVM.ServiceHeader.TotalPrice = 0;
			foreach (var item in CarServiceVM.ServicesShoppingCart)
			{
				CarServiceVM.ServiceHeader.TotalPrice = item.ServiceType.Price;
			}
			return Page();
		}


		public async Task<IActionResult> OnPost()
		{
			if(ModelState.IsValid)
			{
				CarServiceVM.ServiceHeader.Dateadded = DateTime.Now;
				CarServiceVM.ServicesShoppingCart = _db.ServicesShoppingCarts.Include(c => c.ServiceType)
					.Where(c => c.CarId == CarServiceVM.car.Id) .ToList();
				foreach (var shop in CarServiceVM.ServicesShoppingCart)
				{
					CarServiceVM.ServiceHeader.TotalPrice += shop.ServiceType.Price;
				}
				CarServiceVM.ServiceHeader.CarId = CarServiceVM.car.Id;
				_db.ServiceHeaders.Add(CarServiceVM.ServiceHeader);
				await _db.SaveChangesAsync();

				foreach (var shop in CarServiceVM.ServicesShoppingCart)
				{
					ServiceDetails details = new ServiceDetails()
					{
						ServiceHeaderId = CarServiceVM.ServiceHeader.Id,
						ServiceName = shop.ServiceType.Name,
						ServicePrice = shop.ServiceType.Price,
						ServiceTypeId = shop.ServiceTypeId
					};
					_db.ServiceDetails.Add(details);
				}
				_db.ServicesShoppingCarts.RemoveRange(CarServiceVM.ServicesShoppingCart);
				await _db.SaveChangesAsync();
				return RedirectToPage("/Cars/Index", new { userId = CarServiceVM.car.UserId });
			}
			return Page();
		}

		public async Task<IActionResult> OnPostAddToCart()
		{
			ServicesShoppingCart shopping = new ServicesShoppingCart()
			{
				CarId = CarServiceVM.car.Id,
				ServiceTypeId = CarServiceVM.ServiceDetails.ServiceTypeId
			};
			_db.ServicesShoppingCarts.Add(shopping);
			await _db.SaveChangesAsync();
			return RedirectToPage("Create", new {carId = CarServiceVM.car.Id});
		}
		public async Task<IActionResult> OnPostRemoveFromCart(int serviceTypeId)
		{
			ServicesShoppingCart shopping = _db.ServicesShoppingCarts
				.First(u => u.CarId == CarServiceVM.car.Id && u.ServiceTypeId == serviceTypeId);
			_db.Remove(shopping);
			await _db.SaveChangesAsync();
			return RedirectToPage("Create", new { carId = CarServiceVM.car.Id });
		}
	}
}
