using System;
using AutoMapper;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Domain.Entities;

namespace FoodOrder.Application.Meats.Queries.GetMeatList
{
    public class MeatLookupDto : IMapWith<Meat>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Meat, MeatLookupDto>();
		}
	}
}