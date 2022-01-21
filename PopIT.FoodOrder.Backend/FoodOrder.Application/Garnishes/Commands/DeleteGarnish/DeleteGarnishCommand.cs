using MediatR;
using System;

namespace FoodOrder.Application.Garnishes.Commands.DeleteGarnish
{
	public class DeleteGarnishCommand : IRequest
	{
		public Guid Id { get; set; }
	}
}
