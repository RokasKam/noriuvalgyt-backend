using NoriuValgyti.Core.Interfaces;
using NoriuValgyti.Core.Requests.Recipe;
using NoriuValgyti.Domain.Entities;
using NoriuValgyti.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using NoriuValgyti.Core.Requests.Place;

namespace NoriuValgyti.Infrastructure.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly NoriuValgytiDataContext _dbContext;
        public RecipeRepository(NoriuValgytiDataContext dbContext) { _dbContext = dbContext; }
        public Recipe? GetById(Guid id)
        {
            var recipe = _dbContext.Recipes.FirstOrDefault(x => x.Id == id);

            return recipe;
        }
        public Recipe? GetByName(string name)
        {
            var recipe = _dbContext.Recipes.FirstOrDefault(x => x.Name == name);

            return recipe;        
        }
        public IEnumerable<Recipe> GetAll(RecipesParameters recipesParameters)
        {


            IQueryable<Recipe> entities = _dbContext.Recipes;

            if (recipesParameters.FilteringCategory != Domain.Entities.Type.All)
            {
                entities = entities
                    .Where(i => i.Type == recipesParameters.FilteringCategory);
            }
            if (recipesParameters.SearchPhrase != "")
            {
                entities = entities
                    .Where(x => x.Name.ToLower().Contains(recipesParameters.SearchPhrase.ToLower()));
            }

            entities = entities
                .OrderByDescending(x => x.Rating)
                .Skip((recipesParameters.PageNumber - 1) * recipesParameters.PageSize)
                .Take(recipesParameters.PageSize);

            return entities.ToList();
        }
        public Recipe? Create(Recipe recipe)
        {
           recipe.Id = Guid.NewGuid();
           _dbContext.Recipes.Add(recipe);
           _dbContext.SaveChanges();
           return recipe;
        }

        public Recipe? Update(Recipe recipe)
        {
            var local = _dbContext.Recipes
                .Local
                .FirstOrDefault(oldEntity => oldEntity.Id == recipe.Id);

            if (local != null)
            {
                _dbContext.Entry(local).State = EntityState.Detached;
            }

            _dbContext.Entry(recipe).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return recipe;
        }
        public IEnumerable<string> GetSuggestions(SearchSuggestionsRequest searchSuggestionsRequest)
        {
            var searchPhrase = searchSuggestionsRequest.SearchPhrase.ToLower();
            var suggestions = _dbContext.Recipes
                .Where(x => x.Name.ToLower().Contains(searchPhrase))
                .Select(x => x.Name)
                .ToList();
            return suggestions;
        }
    }
}
