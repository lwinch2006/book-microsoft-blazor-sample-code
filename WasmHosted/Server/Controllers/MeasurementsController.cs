using Microsoft.AspNetCore.Mvc;
using WasmHosted.Server.Services;
using WasmHosted.Shared.ViewModels;

namespace WasmHosted.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class MeasurementsController : ControllerBase
{
    private readonly IMeasurementService _measurementService;

    public MeasurementsController(IMeasurementService measurementService)
    {
        _measurementService = measurementService;
    }
    
    [HttpGet]
    public async IAsyncEnumerable<MeasurementVm> GetMeasurements()
    {
        await foreach (var measurement in _measurementService.GetMeasurements())
        {
            yield return measurement;
        }
    }

    [HttpGet("PagedResults")]
    public async Task<ActionResult> GetMeasurementsPage(int from, int count)
    {
        var results = await _measurementService.GetMeasurementsPage(from, count);

        var response = new GetMeasurementsPageVm
        {
            Items = results.items,
            MaxCount = results.maxCount
        };

        return new JsonResult(response);
    }
}