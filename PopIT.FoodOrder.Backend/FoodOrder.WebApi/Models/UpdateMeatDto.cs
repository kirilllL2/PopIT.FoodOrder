using System;
using AutoMapper;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Application.Meats.Commands.UpdateMeat;

namespace FoodOrder.WebApi.Models
{
    public class UpdateMeatDto : IMapWith<UpdateMeatCommand>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<UpdateMeatDto, UpdateMeatCommand>();
		}
	}
}