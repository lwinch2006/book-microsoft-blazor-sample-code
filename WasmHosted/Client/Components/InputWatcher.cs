using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace WasmHosted.Client.Components;

public class InputWatcher : ComponentBase
{
    private EditContext? _editContext;

    [CascadingParameter]
    public EditContext? EditContext
    {
        get => _editContext;
        set
        {
            _editContext = value;
            _editContext!.OnFieldChanged += async (sender, e) =>
            {
                await FieldChanged.InvokeAsync(e.FieldIdentifier.FieldName);
            };
        }
    }
    
    [Parameter]
    public EventCallback<string> FieldChanged { get; set; }

    public bool Validate()
    {
        return EditContext?.Validate() ?? false;
    }
}