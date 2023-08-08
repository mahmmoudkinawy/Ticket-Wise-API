namespace TicketWise.Persistence.Configurations;
public sealed class EventConfiguration : IEntityTypeConfiguration<EventEntity>
{
    public void Configure(EntityTypeBuilder<EventEntity> builder)
    {
        builder
            .HasOne(e => e.Category)
            .WithMany(e => e.Events)
            .HasForeignKey(k => k.CategoryId)
            .IsRequired();
    }
}
