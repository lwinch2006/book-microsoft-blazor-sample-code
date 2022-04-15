using System;
using Bunit;
using ComponentsLibrary;
using Microsoft.AspNetCore.Components;
using Xunit;

namespace ComponentLibraryTests;

public class TwoWayCounterTests : TestContext
{
    [Fact]
    public void Test_InitialSetup_ShoulsPass()
    {
        var component = RenderComponent<TwoWayCounter>(parameters => 
            parameters
                .Add(p => p.CurrentCount, 100)
                .Add(p => p.Increment, 50));

        component.Find("button").Click();
        component.Find("p").MarkupMatches("<p>Current count: 150</p>");
    }

    [Fact]
    public void Test_EventCallbacks_ShouldPass()
    {
        var count = -1;
        var increment = -1;

        Action<int> counterChangeHandler = newValue =>
        {
            count = newValue;
        };

        Action<int> incrementChangeHandler = newValue =>
        {
            increment = newValue;
        };

        var component = RenderComponent<TwoWayCounter>(parameters => 
            parameters
                .Add(p => p.CurrentCount, 100)
                .Add(p => p.Increment, 50)
                .Add(p => p.CurrentCountChanged, counterChangeHandler)
                .Add(p => p.IncrementChanged, incrementChangeHandler)
            );
        
        component.Find("button").Click();

        Assert.Equal(150, count);

        component.Instance.Increment = 200;
        
        Assert.Equal(200, increment);
    }
    
}