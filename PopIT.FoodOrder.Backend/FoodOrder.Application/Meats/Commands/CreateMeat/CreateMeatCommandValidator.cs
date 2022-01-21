using FluentValidation;

namespace FoodOrder.Application.Meats.Commands.CreateMeat
{
	public class CreateMeatCommandValidator : AbstractValidator<CreateMeatCommand>
	{
		public CreateMeatCommandValidator()
		{
			RuleFor(c => c.Name)
				.NotNull().WithMessage("Мясо не может быть null.")
				.Length(2, 30).WithMessage("Название мяса должно быть от 2 до 30 символов.");

			RuleFor(c => c.Price)
				.GreaterThan(0).WithMessage("Цена должна быть больше нуля.");
		}
	}
}
