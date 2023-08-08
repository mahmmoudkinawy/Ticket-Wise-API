namespace TicketWise.Application.Mappers;
public sealed class CategoriesMapperProfile : Profile
{
    public CategoriesMapperProfile()
    {
        CreateMap<CategoryEntity, Features.Events.Queries.GetEventDetail.CategoryResponse>();
        CreateMap<CategoryEntity, Features.Categories.Queries.GetCategories.CategoryResponse>();
    }
}
