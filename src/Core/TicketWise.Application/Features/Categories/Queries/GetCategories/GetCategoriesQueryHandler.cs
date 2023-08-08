namespace TicketWise.Application.Features.Categories.Queries.GetCategories;
public sealed class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IReadOnlyList<CategoryResponse>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetCategoriesQueryHandler(
        ICategoryRepository categoryRepository,
        IMapper mapper)
    {
        _categoryRepository = categoryRepository ??
            throw new ArgumentNullException(nameof(categoryRepository));
        _mapper = mapper ??
            throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IReadOnlyList<CategoryResponse>> Handle(
        GetCategoriesQuery request, 
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(request));

        var categories = (await _categoryRepository.GetAllAsync()).OrderBy(c => c.Name);

        return _mapper.Map<IReadOnlyList<CategoryResponse>>(categories);
    }
}
