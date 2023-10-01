using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAutoService.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name OF car")]
        [Required(ErrorMessage ="Please Fill in{0}")]
        public string Name { get; set; }

        [Display(Name = "Model")]
        [Required(ErrorMessage = "Please Fill in{0}")]
        public string Model {  get; set; }

        [Display(Name = "Color")]
        public string Color { get; set; }

        [Display(Name = "Year")]
        public string Year { get; set; }
        [Display(Name = "Image")]

        public string ImageName  { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser  ApplicationUser{ get; set; }

        public List<ServicesShoppingCart> ServicesShoppingCarts { get; set; }


    }
}
