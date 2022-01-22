using AutoMapper;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Application.Meats.Commands.CreateMeat;
using System.ComponentModel.DataAnnotations;

namespace FoodOrder.WebApi.Models
{
    public class CreateMeatDto : IMapWith<CreateMeatCommand>
    {
		[Required]
        public string Name { get; set; }
		[Required]
        public decimal Price { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<CreateMeatDto, CreateMeatCommand>();
		}
	}
}