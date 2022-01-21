using FluentValidation;
using System;

namespace FoodOrder.Application.Garnishes.Commands.UpdateGarnish
{
	public class UpdateGarnishCommandValidator : AbstractValidator<UpdateGarnishCommand>
	{
		public UpdateGarnishCommandValidator()
		{
			RuleFor(c => c.Id)
				.NotEqual(Guid.Empty).WithMessage("Идентификатор обязателен");

			RuleFor(c => c.Name)
				.NotNull().WithMessage("Гарнир не может быть null.")
				.Length(2, 30).WithMessage("Название гарнира должно быть от 2 до 30 символов.");

			RuleFor(c => c.Price)
				.GreaterThan(0).WithMessage("Цена должна быть больше нуля.");
		}
	}
}
