using NoriuValgyti.Core.Interfaces;
using NoriuValgyti.Core.Requests.Recipe;
using Microsoft.AspNetCore.Mvc;
using NoriuValgyti.Core.Requests.Place;

namespace NoriuValgyti.API.Controllers;

public class RecipeController : BaseController 
{
    private readonly IRecipeService _recipeService;
    
    public RecipeController(IRecipeService placeService)
    {
        _recipeService = placeService;
    }

    [HttpGet]
    public IActionResult GetAll([FromQuery] RecipesParameters recipesParameters)
    {
        return Ok(_recipeService.GetAll(recipesParameters));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRecipeRequest request)
    {
        return Ok(await _recipeService.Create(request));
    }

    [HttpPut("{id:guid}")]
    public IActionResult Update(Guid id, UpdateRecipeRequest request)
    {
        return Ok(_recipeService.Update(id, request));
    }

    [HttpGet]
    public IActionResult GetSuggestions([FromQuery] SearchSuggestionsRequest searchSuggestionsRequest)
    {
        return Ok(_recipeService.GetSuggestions(searchSuggestionsRequest));
    }
}