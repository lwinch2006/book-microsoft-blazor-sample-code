namespace WasmHosted.Shared.ViewModels;

public class GetMeasurementsPageVm
{
    public ICollection<MeasurementVm> Items { get; init; } = Array.Empty<MeasurementVm>();
    public int MaxCount { get; init; }
}