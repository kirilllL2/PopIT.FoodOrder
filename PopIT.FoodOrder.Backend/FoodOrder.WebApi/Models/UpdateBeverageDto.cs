using AutoMapper;
using FoodOrder.Application.Beverages.Commands.UpdateBeverage;
using FoodOrder.Application.Common.Mappings;
using System.ComponentModel.DataAnnotations;

namespace FoodOrder.WebApi.Models
{
	public class UpdateBeverageDto : IMapWith<UpdateBeverageCommand>
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public decimal Price { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<UpdateBeverageDto, UpdateBeverageCommand>();
		}
	}
}
