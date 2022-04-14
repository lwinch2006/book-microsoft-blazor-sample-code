using WasmHosted.Client.Extensions;
using WasmHosted.Client.Models;
using WasmHosted.Shared.Models;

namespace WasmHosted.Client.Components.Animals;

public partial class AnimalSelectorComponent
{
    private ComponentMetadata? _metadata;
    
    private void AnimalSelected(object? value)
    {
        var valueAsString = value?.ToString();
        if (Enum.TryParse<AnimalTypes>(valueAsString, out var animalType))
        {
            _metadata = animalType.ToMetadata();
        }
    }
}