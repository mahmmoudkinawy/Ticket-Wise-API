namespace TicketWise.Persistence.Repositories;
public class BaseRepository<T> : IAsyncRepository<T> where T : AuditableEntity
{
    protected readonly TicketWiseDbContext _context;

    public BaseRepository(TicketWiseDbContext context)
    {
        _context = context ??
            throw new ArgumentNullException(nameof(context));
    }

    public async Task<T> AddAsync(T entity)
    {
        ArgumentNullException.ThrowIfNull(nameof(entity));

        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        ArgumentNullException.ThrowIfNull(nameof(entity));

        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        ArgumentNullException.ThrowIfNull(nameof(id));

        if (id == Guid.Empty)
        {
            throw new Exception("Can not parse id");
        }

        return await _context.Set<T>().FindAsync(id);
    }

    public async Task UpdateAsync(T entity)
    {
        ArgumentNullException.ThrowIfNull(nameof(entity));

        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
