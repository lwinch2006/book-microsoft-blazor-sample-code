using Bunit;
using ComponentsLibrary;
using WasmHosted.Client.Components;
using WasmHosted.Client.Pages;
using Xunit;

namespace WasmHosted.ClientTests.Component;

public class AlertTests : TestContext
{
    [Fact]
    public void Test_Alert_CreationMethodOne_ShowTrue_Visible_ShouldPass()
    {
        var component = RenderComponent<Alert>(ComponentParameter.CreateParameter("Show", true));
        
        Assert.Contains("<button type=\"button\"", component.Markup);
        component.MarkupMatches(@"
    <div class=""alert alert-danger alert-dismissible mt-4"" role=""alert"">

            <button type=""button"" class=""btn-close"" data-bs-dismiss=""alert"" aria-label=""Close"" >
            </button>
            </div>

            <p>
            Show property is True
            </p>

        ");
    }
    
    [Fact]
    public void Test_Alert_CreationMethodTwo_ShowTrue_Visible_ShouldPass()
    {
        var component = RenderComponent<Alert>(("Show", true));
        
        Assert.Contains("<button type=\"button\"", component.Markup);
        component.MarkupMatches(@"
    <div class=""alert alert-danger alert-dismissible mt-4"" role=""alert"">

            <button type=""button"" class=""btn-close"" data-bs-dismiss=""alert"" aria-label=""Close"" >
            </button>
            </div>

            <p>
            Show property is True
            </p>

        ");
    }
    
    [Fact]
    public void Test_Alert_CreationMethodThree_CssIgnored_ShowTrue_Visible_ShouldPass()
    {
        var component = RenderComponent<Alert>(parameters =>
        {
            parameters
                .Add(alert => alert.Show, true)
                .Add(alert => alert.ChildContent, "<span>Test</span>");
        });
        
        
        Assert.Contains("<button type=\"button\"", component.Markup);
        component.MarkupMatches(@"
    <div class:ignore role=""alert"">
            <span>Test</span>
            <button type=""button"" class=""btn-close"" data-bs-dismiss=""alert"" aria-label=""Close"" >
            </button>
            </div>

            <p>
            Show property is True
            </p>

        ");
    }

    [Fact]
    public void Test_Alert_AddingChildContent_ShowTrue_Visible_ShouldPass()
    {
        var component = RenderComponent<Alert>(parameters =>
        {
            parameters
                .Add(alert => alert.Show, true)
                .AddChildContent("<span>Test</span>");
        });
        
        Assert.Contains("<button type=\"button\"", component.Markup);
        component.MarkupMatches(@"
    <div class:ignore role=""alert"">
            <span>Test</span>
            <button type=""button"" class=""btn-close"" data-bs-dismiss=""alert"" aria-label=""Close"" >
            </button>
            </div>

            <p>
            Show property is True
            </p>

        ");
    }
    
    [Fact]
    public void Test_Alert_AddingChildContent2_ShowTrue_Visible_ShouldPass()
    {
        var component = RenderComponent<Alert>(parameters =>
        {
            parameters
                .Add(alert => alert.Show, true)
                .AddChildContent("<span>Test</span>")
                .AddChildContent<TwoWayCounter>(parameters =>
                    parameters.Add(p => p.CurrentCount, 100));
        });
        
        Assert.Contains("<button type=\"button\"", component.Markup);
        component.Find("span").MarkupMatches("<span>Test</span>");
        component.Find("p").MarkupMatches("<p>Current count: 100</p>");
    }
    
    [Fact]
    public void Test_Alert_Visible_ButtonClicked_Hidden_ShouldPass()
    {
        var component = RenderComponent<Alert>(parameters =>
        {
            parameters
                .Add(alert => alert.Show, true)
                .Add(alert => alert.ChildContent, "<span>Test</span>");
        });
        
        component.Find("button").Click();
        
        component.MarkupMatches(@"
            <p>
            Show property is False
            </p>
        ");
    }
}