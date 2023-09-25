using System.ComponentModel.DataAnnotations;

namespace MyAutoService.Models
{
	public class ServiceType
	{
        public int Id { get; set; }


		[Display(Name= " Name :")]
		[Required(ErrorMessage ="Please Add Your Name")]
		[MaxLength(555)]
		public string Name { get; set; }

		[Display(Name = "Price : ")]
		[Required(ErrorMessage = "Please Add Your Price")]
        public double Price { get; set; }
    }
}
