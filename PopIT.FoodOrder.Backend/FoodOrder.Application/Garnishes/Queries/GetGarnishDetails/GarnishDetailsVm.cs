using FoodOrder.Application.Common.Mappings;
using FoodOrder.Domain.Entities;
using System;

namespace FoodOrder.Application.Garnishes.Queries.GetGarnishDetails
{
	public class GarnishDetailsVm : IMapFrom<Garnish>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
	}
}