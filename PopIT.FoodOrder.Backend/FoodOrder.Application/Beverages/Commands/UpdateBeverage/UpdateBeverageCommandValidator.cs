using FluentValidation;
using System;

namespace FoodOrder.Application.Beverages.Commands.UpdateBeverage
{
	public class UpdateBeverageCommandValidator : AbstractValidator<UpdateBeverageCommand>
	{
		public UpdateBeverageCommandValidator()
		{
			RuleFor(c => c.Id)
				.NotEqual(Guid.Empty).WithMessage("Идентификатор обязателен");

			RuleFor(c => c.Name)
				.NotNull().WithMessage("Напиток не может быть null.")
				.Length(2, 30).WithMessage("Название напитка должно быть от 2 до 30 символов.");

			RuleFor(c => c.Price)
				.GreaterThan(0).WithMessage("Цена должна быть больше нуля.");
		}
	}
}
