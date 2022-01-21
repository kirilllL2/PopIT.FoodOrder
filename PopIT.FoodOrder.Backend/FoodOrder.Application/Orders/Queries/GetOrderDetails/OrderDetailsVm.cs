using System;
using AutoMapper;
using FoodOrder.Application.Beverages.Queries.GetBeverageDetails;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Application.Garnishes.Queries.GetGarnishDetails;
using FoodOrder.Application.Meats.Queries.GetMeatDetails;
using FoodOrder.Application.Soups.Queries.GetSoupDetails;
using FoodOrder.Domain.Entities;

namespace FoodOrder.Application.Orders.Queries.GetOrderDetails
{
    public class OrderDetailsVm : IMapWith<Order>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime OrderTime { get; set; }
        public decimal TotalPrice { get; set; }
        public BeverageDetailsVm Beverage { get; set; }
        public GarnishDetailsVm Garnish { get; set; }
        public MeatDetailsVm Meat { get; set; }
        public SoupDetailsVm Soup { get; set; }

		public void Mapping(Profile profile)
		{
            profile.CreateMap<Order, OrderDetailsVm>()
                .ForMember(r => r.TotalPrice,
                    opt => opt.MapFrom(o => o.Meat.Price + o.Soup.Price + o.Garnish.Price + o.Beverage.Price));
        }
	}
}