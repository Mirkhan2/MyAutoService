using System.Collections.Generic;

namespace MyAutoService.Models.ViewModels
{
	public class LoggedInUserViewModel
	{
        public string Name { get; set; }
		public List<ServicesShoppingCart> shoppingCart{ get; set; }


	}
}
