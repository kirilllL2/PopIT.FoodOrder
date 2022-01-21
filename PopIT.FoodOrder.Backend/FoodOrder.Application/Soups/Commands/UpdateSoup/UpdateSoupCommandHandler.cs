using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FoodOrder.Application.Common.Exceptions;
using FoodOrder.Application.Interfaces;
using FoodOrder.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FoodOrder.Application.Soups.Commands.UpdateSoup
{
    public class UpdateSoupCommandHandler : IRequestHandler<UpdateSoupCommand>
    {
        private readonly IFoodOrderDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateSoupCommandHandler(IFoodOrderDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<Unit> Handle(UpdateSoupCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Soups.FirstOrDefaultAsync(soup =>
                soup.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new EntityIdNotFoundException(nameof(Soup), request.Id);
            }

            _mapper.Map(request, entity);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}