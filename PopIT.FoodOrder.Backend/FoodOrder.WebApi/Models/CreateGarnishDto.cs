using AutoMapper;
using FoodOrder.Application.Common.Mappings;
using FoodOrder.Application.Garnishes.Commands.CreateGarnish;
using System.ComponentModel.DataAnnotations;

namespace FoodOrder.WebApi.Models
{
	public class CreateGarnishDto : IMapWith<CreateGarnishCommand>
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public decimal Price { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<CreateGarnishDto, CreateGarnishCommand>();
		}
	}
}
