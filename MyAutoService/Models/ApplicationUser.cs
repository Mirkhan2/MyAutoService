using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MyAutoService.Models
{
	public class ApplicationUser : IdentityUser
	{
		[Display(Name = " CustomerName")]
		[MaxLength(200)]
		public string Name { get; set; }
		public string Address { get; set; }
		[MaxLength(200)]
		[Display(Name = "CiTy ")]
		public string City { get; set; }

		[Display(Name = " PoStalCode")]
		[MaxLength(200)]
		public string PostalCode { get; set; }

		[Display(Name = "Email ")]
		public override string Email
		{
			get => base.Email
				; set => base.Email = value;
		}

		[Display(Name = " PhoneNumber")]
		public override string PhoneNumber
		{
			get
			{
				return base.PhoneNumber	;
			}
			set
			{
				base.PhoneNumber = value;
				
			}
		}
	}
}
