using MediatR;
using System;

namespace FoodOrder.Application.Beverages.Commands.DeleteBeverage
{
	public class DeleteBeverageCommand : IRequest
	{
		public Guid Id { get; set; }
	}
}
