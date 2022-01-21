using System;
using AutoMapper;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Domain.Entities;

namespace FoodOrder.Application.Meats.Queries.GetMeatDetails
{
    public class MeatDetailsVm : IMapWith<Meat>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

		public void Mapping(Profile profile)
		{
            profile.CreateMap<Meat, MeatDetailsVm>();
		}
	}
}