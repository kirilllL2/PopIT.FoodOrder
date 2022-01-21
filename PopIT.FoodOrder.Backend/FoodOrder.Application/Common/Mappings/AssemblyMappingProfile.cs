using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace FoodOrder.Application.Common.Mappings
{
	public class AssemblyMappingProfile : Profile
	{
		public AssemblyMappingProfile(Assembly assembly) =>
			ApplyMappingsFromAssembly(assembly);

		private void ApplyMappingsFromAssembly(Assembly assembly)
		{
			var typesTo = assembly.GetExportedTypes()
				.Where(type => type.GetInterfaces()
				.Any(i => i.IsGenericType
						&& i.GetGenericTypeDefinition() == typeof(IMapTo<>)))
				.ToList();

			foreach (var type in typesTo)
			{
				var instance = Activator.CreateInstance(type);
				var methodInfo = type.GetMethod("MapTo");
				methodInfo?.Invoke(instance, new object[] { this });
			}
			
			var typesFrom = assembly.GetExportedTypes()
							.Where(type => type.GetInterfaces()
							.Any(i => i.IsGenericType
									&& i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
							.ToList();

			foreach (var type in typesFrom)
			{
				var instance = Activator.CreateInstance(type);
				var methodInfo = type.GetMethod("MapFrom");
				methodInfo?.Invoke(instance, new object[] { this });
			}
		}
	}
}
