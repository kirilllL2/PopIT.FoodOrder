using FoodOrder.Persistence;
using System;

namespace FoodOrder.Tests.Common
{
	public class TestCommandBase : IDisposable
	{
		protected readonly FoodOrderDbContext Context;

		public TestCommandBase()
		{
			Context = FoodOrderContextFactory.Create();
		}

		public void Dispose()
		{
			FoodOrderContextFactory.Destroy(Context);
		}
	}
}
