using System;
using MediatR;

namespace FoodOrder.Application.Soups.Commands.DeleteSoup
{
    public class DeleteSoupCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}