using System.ComponentModel.DataAnnotations.Schema;

namespace MyAutoService.Models
{
	public class ServicesShoppingCart
	{
		public int Id { get; set; }
		public int CarId { get; set; }
        public int ServiceTypeId { get; set; }

		[ForeignKey("CarId")]
        public virtual Car Car { get; set; }

		[ForeignKey("CarId")]
		public virtual ServiceType ServiceType { get; set; }
    }
}
