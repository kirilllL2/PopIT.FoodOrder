using AutoMapper;
using FoodOrder.Application.Beverages.Commands.CreateBeverage;
using FoodOrder.Application.Common.Mappings;
using System.ComponentModel.DataAnnotations;

namespace FoodOrder.WebApi.Models
{
	public class CreateBeverageDto : IMapWith<CreateBeverageCommand>
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public decimal Price { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<CreateBeverageDto, CreateBeverageCommand>();
		}
	}
}
