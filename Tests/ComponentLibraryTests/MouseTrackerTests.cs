using Bunit;
using ComponentsLibrary;
using Microsoft.AspNetCore.Components.Web;
using Xunit;

namespace ComponentLibraryTests;

public class MouseTrackerTests : TestContext
{
    [Fact]
    public void Test_MouseMove_PositionUpdated_ShouldPass()
    {
        var mouseEventArgs = new MouseEventArgs
        {
            ClientX = 100,
            ClientY = 200
        };
        
        var mouse = RenderComponent<MouseTracker>();
        mouse.Find("div").MouseMove(mouseEventArgs);
        mouse.MarkupMatches(@"
        <div style:ignore>
            Mouse at 100 x 200
        </div>");
    }
}