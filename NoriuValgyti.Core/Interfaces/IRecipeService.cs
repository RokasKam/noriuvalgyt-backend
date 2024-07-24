using NoriuValgyti.Core.Requests.Place;
using NoriuValgyti.Core.Requests.Recipe;
using NoriuValgyti.Core.Responses.Recipes;


namespace NoriuValgyti.Core.Interfaces;
    public interface IRecipeService
    {
        Task<RecipeResponse> Create(CreateRecipeRequest recipe);

        List<RecipeResponse> GetAll(RecipesParameters recipesParameters);
        RecipeResponse Update(Guid id, UpdateRecipeRequest recipe);
        RecipeResponse? GetById(Guid id);
        List<string> GetSuggestions(SearchSuggestionsRequest searchSuggestionsRequest);
}

