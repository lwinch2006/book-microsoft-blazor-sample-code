using WasmHosted.Shared.ViewModels;

namespace WasmHosted.Server.Services;


public interface IMeasurementService
{
    IAsyncEnumerable<MeasurementVm> GetMeasurements(int start = 1, int count = 5000);
    Task<(ICollection<MeasurementVm> items, int maxCount)> GetMeasurementsPage(int from, int count, CancellationToken cancellationToken = default);
}

public class MeasurementService : IMeasurementService
{
    public async IAsyncEnumerable<MeasurementVm> GetMeasurements(int start = 1, int count = 5000)
    {
        var rnd = new Random();
        
        await foreach (var item in RangeAsync(start, count))
        {
            yield return new MeasurementVm
            {
                Guid = Guid.NewGuid(),
                Min = rnd.Next(0, 100),
                Max = rnd.Next(300, 400),
                Avg = rnd.Next(100, 300)
            };
        }
    }

    public async Task<(ICollection<MeasurementVm> items, int maxCount)> GetMeasurementsPage(int from, int count, CancellationToken cancellationToken = default)
    {
        const int maxCount = 5000;
        count = Math.Max(0, Math.Min(count, maxCount - from));

        var result = new List<MeasurementVm>(count);
        
        await foreach (var item in (GetMeasurements(1, count).WithCancellation(cancellationToken)))
        {
            //await Task.Delay(100, cancellationToken);
            result.Add(item);
        }

        return new ValueTuple<ICollection<MeasurementVm>, int>(result, maxCount);
    }
    
    private static async IAsyncEnumerable<int> RangeAsync(int start, int count)
    {
        for (var i = 0; i < count; i++)
        {
            yield return await Task.FromResult(start + i);
        }
    }
}