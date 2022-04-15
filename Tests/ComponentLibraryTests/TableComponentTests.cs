using System.Linq;
using Bunit;
using ComponentsLibrary;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Xunit;

namespace ComponentLibraryTests;

public class TableComponentTests : TestContext
{
    [Fact]
    public void Test_InitialSetup_ShouldPass()
    {
        var component = RenderComponent<TableComponent<string>>();
        component.Find("p").MarkupMatches("<p>Loading...</p>");
    }

    [Fact]
    public void Test_ItemsNotEmpty_ShouldPass()
    {
        var items = new[] { "Hello", "World", "!!!" };

        var expectedRowsContent = new[]
        {
            "<span>Hello</span>",
            "<span>World</span>",
            "<span>!!!</span>",
        };
        
        var component = RenderComponent<TableComponent<string>>(parameters => 
            parameters
                .Add(p => p.Items, items)
                .Add(p => p.Row, (context) => $"<span>{context}</span>"));

        var rowsContent = component.FindAll("span");
        
        Assert.Equal(3, rowsContent.Count);

        foreach (var rowContent in rowsContent)
        {
            Assert.Contains(expectedRowsContent, t => rowContent.ToMarkup().Contains(t));
        }
    }
    
    [Fact]
    public void Test_ItemsNotEmpty2_ShouldPass()
    {
        var items = new[] { "100", "200", "300" };

        var expectedRowsContent = new[]
        {
            "<p>Current count: 100</p>",
            "<p>Current count: 200</p>",
            "<p>Current count: 300</p>",
        };
        
        var component = RenderComponent<TableComponent<string>>(parameters => 
            parameters
                .Add(p => p.Items, items)
                .Add<TwoWayCounter, string>(p => p.Row, (context) => itemsParam => itemsParam.Add(p => p.CurrentCount, int.Parse(context))));

        var rowsContent = component.FindAll("p");
        
        Assert.Equal(3, rowsContent.Count);

        var index = 0;
        
        foreach (var rowContent in rowsContent)
        {
            rowContent.MarkupMatches(expectedRowsContent[index++]);
        }
    }
    
    
}