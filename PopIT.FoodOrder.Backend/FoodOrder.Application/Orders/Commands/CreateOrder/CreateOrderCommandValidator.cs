using FluentValidation;
using System;

namespace FoodOrder.Application.Orders.Commands.CreateOrder
{
	public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
	{
		public CreateOrderCommandValidator()
		{
			// TODO: Auth
			// RuleFor(c => c.UserId)
			//	.NotEqual(Guid.Empty).WithMessage("Идентификатор пользователя обязателен");
		}
	}
}
