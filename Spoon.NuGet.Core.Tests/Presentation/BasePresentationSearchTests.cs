namespace Spoon.NuGet.Core.Tests.Presentation;

using Core.Presentation;
using Domain;

public class BasePresentationSearchTests
{
    [Fact]
    public void Constructor_InitializesProperties()
    {
        // Arrange
        var filters = new List<Filter>();
        var sortField = new List<Sorting>();
        var includeDeleted = true;
        var page = 1;
        var pageSize = 10;

        // Act
        var search = new BasePresentationSearch
        {
            Filters = filters,
            SortField = sortField,
            IncludeDeleted = includeDeleted,
            Page = page,
            PageSize = pageSize
        };

        // Assert
        Assert.Equal(filters, search.Filters);
        Assert.Equal(sortField, search.SortField);
        Assert.Equal(includeDeleted, search.IncludeDeleted);
        Assert.Equal(page, search.GetType().GetProperty("Page")?.GetValue(search, null));
        Assert.Equal(pageSize, search.GetType().GetProperty("PageSize")?.GetValue(search, null));
    }
}