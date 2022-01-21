using FluentValidation;
using System;

namespace FoodOrder.Application.Soups.Commands.UpdateSoup
{
	public class UpdateSoupCommandValidator : AbstractValidator<UpdateSoupCommand>
	{
		public UpdateSoupCommandValidator()
		{
			RuleFor(c => c.Id)
				.NotEqual(Guid.Empty).WithMessage("Идентификатор обязателен");

			RuleFor(c => c.Name)
				.NotNull().WithMessage("Суп не может быть null.")
				.Length(2, 30).WithMessage("Название супа должно быть от 2 до 30 символов.");

			RuleFor(c => c.Price)
				.GreaterThan(0).WithMessage("Цена должна быть больше нуля.");
		}
	}
}
