using FluentValidation;

namespace FoodOrder.Application.Garnishes.Commands.CreateGarnish
{
	public class CreateGarnishCommandValidator : AbstractValidator<CreateGarnishCommand>
	{
		public CreateGarnishCommandValidator()
		{
			RuleFor(c => c.Name)
				.NotNull().WithMessage("Гарнир не может быть null.")
				.Length(2, 30).WithMessage("Название гарнира должно быть от 2 до 30 символов.");

			RuleFor(c => c.Price)
				.GreaterThan(0).WithMessage("Цена должна быть больше нуля.");
		}
	}
}
