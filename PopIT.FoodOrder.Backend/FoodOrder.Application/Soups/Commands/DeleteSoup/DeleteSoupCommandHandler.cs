using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FoodOrder.Application.Common.Exceptions;
using FoodOrder.Application.Interfaces;
using FoodOrder.Domain.Entities;
using MediatR;

namespace FoodOrder.Application.Soups.Commands.DeleteSoup
{
    public class DeleteSoupCommandHandler : IRequestHandler<DeleteSoupCommand>
    {
        private readonly IFoodOrderDbContext _dbContext;
        
        public DeleteSoupCommandHandler(IFoodOrderDbContext dbContext) =>
            _dbContext = dbContext;
        
        public async Task<Unit> Handle(DeleteSoupCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Soups
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new EntityIdNotFoundException(nameof(Soup), request.Id);
            }

            _dbContext.Soups.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}