namespace TicketWise.Persistence.Repositories;
public sealed class CategoryRepository : BaseRepository<CategoryEntity>, ICategoryRepository
{
    public CategoryRepository(TicketWiseDbContext context) : base(context) { }

    public async Task<IReadOnlyList<CategoryEntity>> GetCategoriesWithEventsAsync(bool includeHistory)
    {
        var categories = await _context.Categories
            .Include(c => c.Events)
            .ToListAsync();

        if (includeHistory)
        {
            categories.ForEach(
                c => c.Events.ToList().RemoveAll(c => c.Date < DateTime.Now));
        }

        return categories;
    }
}
