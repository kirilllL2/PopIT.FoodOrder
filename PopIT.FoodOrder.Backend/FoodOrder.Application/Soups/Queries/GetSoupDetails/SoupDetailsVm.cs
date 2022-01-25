using AutoMapper;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Domain.Entities;
using System;

namespace FoodOrder.Application.Soups.Queries.GetSoupDetails
{
    public class SoupDetailsVm : IMapWith<Soup>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Soup, SoupDetailsVm>();
		}
	}
}