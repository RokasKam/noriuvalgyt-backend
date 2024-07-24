using NoriuValgyti.Domain.Entities;
using NoriuValgyti.Core.Requests.Recipe;
using NoriuValgyti.Core.Requests.Place;

namespace NoriuValgyti.Core.Interfaces
{
    public interface IRecipeRepository
    {
        Recipe? GetById(Guid id);
        Recipe? GetByName(string name);
        Recipe? Create(Recipe recipe);
        IEnumerable<Recipe> GetAll(RecipesParameters recipesParameters);
        Recipe? Update(Recipe recipe);
        IEnumerable<string> GetSuggestions(SearchSuggestionsRequest searchSuggestionsRequest);

    }
}
