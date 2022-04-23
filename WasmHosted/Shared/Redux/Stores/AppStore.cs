namespace WasmHosted.Shared.Redux.Stores;

public record AppStore(int Counter, bool IsLoading, WeatherForecast[] Forecasts);
