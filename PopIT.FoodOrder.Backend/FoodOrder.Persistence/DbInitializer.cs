namespace FoodOrder.Persistence
{
	public class DbInitializer
	{
		public static void Initialize(FoodOrderDbContext context)
		{
			context.Database.EnsureCreated();
		}
	}
}
