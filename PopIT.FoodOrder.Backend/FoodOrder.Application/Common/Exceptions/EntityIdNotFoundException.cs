using System;

namespace FoodOrder.Application.Common.Exceptions
{
	public class EntityIdNotFoundException : FoodOrderException
	{
        public EntityIdNotFoundException(string modelName, Guid id) =>
            (ModelName, Id) = (modelName, id);
        
        public string ModelName { get; }
        public Guid Id { get; }
        public override string Message => $"Entity {ModelName} with id {Id} not found";
    }
}
