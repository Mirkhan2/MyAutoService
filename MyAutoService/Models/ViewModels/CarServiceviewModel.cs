using System.Collections.Generic;

namespace MyAutoService.Models.ViewModels
{
	public class CarServiceviewModel
	{
        public Car car { get; set; }
        public ServiceHeader ServiceHeader { get; set; }
        public ServiceDetails ServiceDetails { get; set; }
        public List<ServiceType> ServiceTypesList { get; set; }
        public List<ServicesShoppingCart> ServicesShoppingCart { get; set; }
    }
}
