using NoriuValgyti.Core.Interfaces;
using NoriuValgyti.Core.Requests.Recipe;
using NoriuValgyti.Core.Responses.Recipes;
using NoriuValgyti.Domain.Entities;
using AutoMapper;
using NoriuValgyti.Core.Requests.Place;

namespace NoriuValgyti.Core.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;


        public RecipeService(IRecipeRepository recipeRepository, IMapper mapper, IImageService imageService)
        { 
            _recipeRepository = recipeRepository;
            _mapper = mapper;
            _imageService = imageService;
        }
        public List<RecipeResponse> GetAll(RecipesParameters recipesParameters)
        {
            var recipes = _recipeRepository.GetAll(recipesParameters);
            var recipesResponseList = recipes.Select(x => _mapper.Map<RecipeResponse>(x)).ToList();

            return recipesResponseList;
        }
        public async Task<RecipeResponse> Create(CreateRecipeRequest recipe)
        {
            var requestRecipe = _mapper.Map<Recipe>(recipe);
            if (_recipeRepository.GetByName(recipe.Name) != null)
            {
                throw new Exception("Place with this name exist");
            }
            Stream imageStream = _imageService.ConvertBase64ToStream(recipe.PhotoBase64);
            string imageFromFirebase = await _imageService.UploadImage(imageStream, recipe.Name);
            requestRecipe.PhotoURL = imageFromFirebase;
            var createdRecipe = _recipeRepository.Create(requestRecipe);
            var response = _mapper.Map<RecipeResponse>(createdRecipe);
            return response;
        }

        public RecipeResponse Update(Guid id, UpdateRecipeRequest recipe)
        {
            var recipeToUpdate = _recipeRepository.GetById(id);

            if (recipeToUpdate.RatingAmount == 0)
            {
                recipeToUpdate.Rating = recipe.UserRating;
                recipeToUpdate.RatingAmount = 1;
            }
            else
            {
                recipeToUpdate.Rating = (recipeToUpdate.Rating * recipeToUpdate.RatingAmount + recipe.UserRating)
                                       / (recipeToUpdate.RatingAmount + 1);
                recipeToUpdate.RatingAmount += 1;
            }

            var updatedRecipe = _recipeRepository.Update(recipeToUpdate);
            var updateRecipeResponse = _mapper.Map<RecipeResponse>(updatedRecipe);
            return updateRecipeResponse;

        }
        public RecipeResponse? GetById(Guid id)
        {
            var recipe = _recipeRepository.GetById(id);
            var recipeResponse = _mapper.Map<RecipeResponse>(recipe);

            return recipeResponse;
        }
        public List<string> GetSuggestions(SearchSuggestionsRequest searchSuggestionsRequest)
        {
            var suggestions = _recipeRepository.GetSuggestions(searchSuggestionsRequest).ToList();
            return suggestions;
        }
    }
}
