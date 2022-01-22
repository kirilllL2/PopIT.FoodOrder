using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Application.Meats.Commands.UpdateMeat;

namespace FoodOrder.WebApi.Models
{
    public class UpdateMeatDto : IMapWith<UpdateMeatCommand>
    {
		[Required]
        public string Name { get; set; }
		[Required]
        public decimal Price { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<UpdateMeatDto, UpdateMeatCommand>();
		}
	}
}