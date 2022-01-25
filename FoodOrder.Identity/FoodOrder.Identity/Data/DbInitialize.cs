namespace FoodOrder.Identity.Data
{
    public class DbInitialize
    {
        public static void Initialize(AuthDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}