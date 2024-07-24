using NoriuValgyti.Domain.Entities;

namespace NoriuValgyti.Core.Requests.Recipe;

public class RecipesParameters
{
    const int maxPageSize = 50;

    public string? SearchPhrase { get; set; } = "";
    public NoriuValgyti.Domain.Entities.Type FilteringCategory { get; set; } = Domain.Entities.Type.All;

    public int PageNumber { get; set; } = 1;
    private int _pageSize = 10;
    public int PageSize
    {
        get
        {
            return _pageSize;
        }
        set
        {
            _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
    }
}