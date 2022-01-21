using System;
using System.Collections.Generic;

namespace FoodOrder.Domain.Entities
{
	public class Beverage
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }

		public IEnumerable<Order> Orders { get; set; }
	}
}
