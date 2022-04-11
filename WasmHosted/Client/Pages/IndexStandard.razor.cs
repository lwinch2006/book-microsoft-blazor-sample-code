using WasmHosted.Client.Components;

namespace WasmHosted.Client.Pages;

public partial class IndexStandard
{
    private bool ShowAlert { get; set; }

    private Alert? _alert;
    
    private void ToggleAlert()
    {
        ShowAlert = !ShowAlert;
    }    
}