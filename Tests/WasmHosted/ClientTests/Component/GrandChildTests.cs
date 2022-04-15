using Bunit;
using WasmHosted.Client.Components;
using Xunit;

namespace WasmHosted.ClientTests.Component;

public class GrandChildTests : TestContext
{
    [Fact]
    public void Test_InitialSetup_ShouldPass()
    {
        var component = RenderComponent<GrandChild>(parameters 
            => parameters.AddCascadingValue("gm", new CounterData { Count = 100}));

        component.MarkupMatches(@"
            <h3>GrandChild</h3>

            100

            <button type=""button"" class:ignore >Increment</button>
        ");
    }
    
}