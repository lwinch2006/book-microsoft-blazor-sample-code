using WasmHosted.Client.Components.Animals;
using WasmHosted.Client.Models;
using WasmHosted.Shared.Models;
using WasmHosted.Shared.ViewModels;
using WasmHosted.Shared.ViewModels.Animals;

namespace WasmHosted.Client.Extensions;

public static class ComponentMetadataExtensions
{
    public static ComponentMetadata? ToMetadata(this AnimalTypes animalType)
    {
        return animalType switch
        {
            AnimalTypes.Cat => new ComponentMetadata()
            {
                Type = typeof(CatComponent),
                Parameters = new Dictionary<string, object> { { "Instance", new CatVm() } }
            },
            AnimalTypes.Dog => new ComponentMetadata()
            {
                Type = typeof(DogComponent),
                Parameters = new Dictionary<string, object> { { "Instance", new DogVm() } }
            },
            _ => null
        };
    }
}