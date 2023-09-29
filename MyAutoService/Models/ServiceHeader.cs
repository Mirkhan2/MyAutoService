using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAutoService.Models
{
	public class ServiceHeader
	{
        public int Id { get; set; }
        [Display(Name  = "Kilometer")]
        public double Miles { get; set; }

        [Required]
        public double  TotalPrice { get; set; }
		[Display(Name = "DesCription")]
		public string Description { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "yyyy/MM/dd")]
        public DateTime Dateadded { get; set; }

        public int CarId { get; set; }

        [ForeignKey("CarId")]
        public virtual Car Car { get; set; }
    }
}
