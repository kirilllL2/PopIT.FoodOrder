using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FoodOrder.Application.Interfaces;
using FoodOrder.Domain.Entities;
using MediatR;

namespace FoodOrder.Application.Soups.Commands.CreateSoup
{
    public class CreateSoupCommandHandler : IRequestHandler<CreateSoupCommand, Guid>
    {
        private readonly IFoodOrderDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateSoupCommandHandler(IFoodOrderDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);
        
        public async Task<Guid> Handle(CreateSoupCommand request, CancellationToken cancellationToken)
        {
            var soup = _mapper.Map<Soup>(request);

            await _dbContext.Soups.AddAsync(soup, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return soup.Id;
        }
    }
}