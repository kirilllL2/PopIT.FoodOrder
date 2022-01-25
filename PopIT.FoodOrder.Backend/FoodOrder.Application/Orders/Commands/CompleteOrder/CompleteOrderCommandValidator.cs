using FluentValidation;
using System;

namespace FoodOrder.Application.Orders.Commands.CompleteOrder
{
	public class CompleteOrderCommandValidator : AbstractValidator<CompleteOrderCommand>
	{
		public CompleteOrderCommandValidator()
		{
			RuleFor(c => c.Id)
				.NotEqual(Guid.Empty).WithMessage("Идентификатор обязателен");
		}
	}
}
