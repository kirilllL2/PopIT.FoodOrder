using AutoMapper;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Application.Soups.Commands.CreateSoup;
using System.ComponentModel.DataAnnotations;

namespace FoodOrder.WebApi.Models
{
	public class CreateSoupDto : IMapWith<CreateSoupCommand>
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public decimal Price { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<CreateSoupDto, CreateSoupCommand>();
		}
	}
}
