using FoodOrder.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodOrder.Persistence.EntityTypeConfigurations
{
	public class GarnishConfiguration : IEntityTypeConfiguration<Garnish>
	{
		public void Configure(EntityTypeBuilder<Garnish> builder)
		{
			builder.ToTable("Garnishes");

			builder.HasKey(g => g.Id);
			builder.HasIndex(g => g.Id).IsUnique();

			builder.Property(g => g.Name)
				.IsRequired();
		}
	}
}
