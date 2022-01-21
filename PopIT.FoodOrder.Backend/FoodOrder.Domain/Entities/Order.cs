using System;

namespace FoodOrder.Domain.Entities
{
	public class Order
	{
		public Guid UserId { get; set; }
		public Guid Id { get; set; }
		public DateTime OrderTime { get; set; }
		public bool IsCompleted { get; set; }

		public Guid BeverageId { get; set; }
		public Beverage Beverage { get; set; }

		public Guid GarnishId { get; set; }
		public Garnish Garnish { get; set; }

		public Guid MeatId { get; set; }
		public Meat Meat { get; set; }

		public Guid SoupId { get; set; }
		public Soup Soup { get; set; }
	}
}
