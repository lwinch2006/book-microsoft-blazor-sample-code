using Fluxor;
using WasmHosted.Shared.Redux.Stores;

namespace WasmHosted.Shared.Redux.Features;

public class AppFeature : Feature<AppStore>
{
	public override string GetName() => nameof(AppStore);

	protected override AppStore GetInitialState()
	{
		return new AppStore(Counter: 0, IsLoading: false, Forecasts: Array.Empty<WeatherForecast>());
	}
}