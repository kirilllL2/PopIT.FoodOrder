using System;
using MediatR;

namespace FoodOrder.Application.Meats.Commands.DeleteMeat
{
    public class DeleteMeatCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}