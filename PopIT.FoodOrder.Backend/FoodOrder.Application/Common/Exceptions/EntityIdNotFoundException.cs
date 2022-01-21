using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Application.Common.Exceptions
{
	public class EntityIdNotFoundException : FoodOrderException
	{
        public EntityIdNotFoundException(string modelName, int id) =>
            (ModelName, Id) = (modelName, id);
        
        public string ModelName { get; }
        public int Id { get; }
        public override string Message => $"Entity {ModelName} with id {Id} not found";
    }
}
