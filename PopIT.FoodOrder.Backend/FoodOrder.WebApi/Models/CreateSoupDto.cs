using AutoMapper;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Application.Soups.Commands.CreateSoup;

namespace FoodOrder.WebApi.Models
{
	public class CreateSoupDto : IMapWith<CreateSoupCommand>
	{
		public string Name { get; set; }
		public decimal Price { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<CreateSoupDto, CreateSoupCommand>();
		}
	}
}
