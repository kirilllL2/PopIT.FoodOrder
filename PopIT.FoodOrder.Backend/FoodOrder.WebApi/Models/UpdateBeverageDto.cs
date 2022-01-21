using AutoMapper;
using FoodOrder.Application.Beverages.Commands.UpdateBeverage;
using FoodOrder.Application.Common.Mappings;

namespace FoodOrder.WebApi.Models
{
	public class UpdateBeverageDto : IMapWith<UpdateBeverageCommand>
	{
		public string Name { get; set; }
		public decimal Price { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<UpdateBeverageDto, UpdateBeverageCommand>();
		}
	}
}
