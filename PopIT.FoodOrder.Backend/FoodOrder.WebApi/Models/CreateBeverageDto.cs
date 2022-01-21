using AutoMapper;
using FoodOrder.Application.Beverages.Commands.CreateBeverage;
using FoodOrder.Application.Common.Mappings;

namespace FoodOrder.WebApi.Models
{
	public class CreateBeverageDto : IMapWith<CreateBeverageCommand>
	{
		public string Name { get; set; }
		public decimal Price { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<CreateBeverageDto, CreateBeverageCommand>();
		}
	}
}
