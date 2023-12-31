﻿namespace TicketWise.Application.Features.Categories.Queries.GetCategoriesWithEvents;
public sealed class GetCategoriesWithEventsQueryHandler :
    IRequestHandler<GetCategoriesWithEventsQuery, IReadOnlyList<CategoryEventResponse>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetCategoriesWithEventsQueryHandler(
        ICategoryRepository categoryRepository,
        IMapper mapper)
    {
        _categoryRepository = categoryRepository ??
            throw new ArgumentNullException(nameof(categoryRepository));
        _mapper = mapper ??
            throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IReadOnlyList<CategoryEventResponse>> Handle(GetCategoriesWithEventsQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(request));

        var categoriesWithEvents = await _categoryRepository.GetCategoriesWithEventsAsync(request.IncludeHistory);

        return _mapper.Map<IReadOnlyList<CategoryEventResponse>>(categoriesWithEvents);
    }
}
