using Demo.DAL.Models.Shared;

namespace Demo.DAL.Data.Configurations
{
    public class BaseConfigurations<T> : IEntityTypeConfiguration<T> where T : BaseEntity // thank you Generics
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(d => d.CreatedOn).HasDefaultValueSql("GETDATE()");
            builder.Property(d => d.LastModifiedOn).HasComputedColumnSql("GETDATE()");
        }
    }
}
