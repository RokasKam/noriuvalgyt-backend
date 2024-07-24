using NoriuValgyti.Core.Requests.Recipe;
using NoriuValgyti.Domain.Entities;
using AutoMapper;
using NoriuValgyti.Core.Responses.Recipes;

namespace Academy.Core.Mappings;

public class RecipeMappingProfile : Profile
{
    public RecipeMappingProfile()
    {
        CreateMap<CreateRecipeRequest, Recipe>();
        CreateMap<Recipe, RecipeResponse>();
    }
}