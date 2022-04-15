using Bunit;
using WasmHosted.Client.Pages;
using Xunit;

namespace WasmHosted.ClientTests.Pages;

public class CounterTests : TestContext
{
    [Fact]
    public void Test_RenderInitialyWithZero_ShouldPass()
    {
        var component = RenderComponent<Counter>();
        Assert.Contains("Current count: 0", component.Markup);
    }
    
    [Fact]
    public void Test_RenderInitialyWithZero_FindUsingCssSelector_ShouldPass()
    {
        var component = RenderComponent<Counter>();
        component.Find("p").MarkupMatches("<p role:ignore>Current count: 0</p>");
    }

    [Fact]
    public void Test_ButtonClicked_TotalIncremeted_ShouldPass()
    {
        var component = RenderComponent<Counter>();
        component.Find("p").MarkupMatches("<p role:ignore>Current count: 0</p>");
        
        component.FindAll("button")[0].Click();
        component.Find("p").MarkupMatches("<p role:ignore>Current count: 1</p>");
    }
}