using FluentValidation;
using System;

namespace FoodOrder.Application.Beverages.Commands.DeleteBeverage
{
	public class DeleteBeverageCommandValidator : AbstractValidator<DeleteBeverageCommand>
	{
		public DeleteBeverageCommandValidator()
		{
			RuleFor(c => c.Id)
				.NotEqual(Guid.Empty).WithMessage("Идентификатор обязателен");
		}
	}
}
