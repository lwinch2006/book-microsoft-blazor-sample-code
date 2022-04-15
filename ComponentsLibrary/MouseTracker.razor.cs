using Microsoft.AspNetCore.Components.Web;

namespace ComponentsLibrary;

public partial class MouseTracker
{
    private string _mousePosition = string.Empty;

    public void MouseMove(MouseEventArgs e)
    {
        _mousePosition = $"Mouse at {e.ClientX} x {e.ClientY}";
    }
}