using AutoMapper;
using FoodOrder.Application.Beverages.Commands.CreateBeverage;
using FoodOrder.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
