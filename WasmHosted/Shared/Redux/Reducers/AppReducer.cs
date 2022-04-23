using Fluxor;
using WasmHosted.Shared.Redux.Actions;
using WasmHosted.Shared.Redux.Stores;

namespace WasmHosted.Shared.Redux.Reducers;

public static class AppReducer
{
	[ReducerMethod]
	public static AppStore ReduceIncrementCounterAction(AppStore appStore, IncrementCounterAction action)
	{
		return appStore with { Counter = appStore.Counter + 1 };
	}

	[ReducerMethod(typeof(FetchDataAction))]
	public static AppStore ReduceFetchDataAction(AppStore appStore)
	{
		return appStore with { IsLoading = true };
	}

	[ReducerMethod]
	public static AppStore ReduceFetchDataResultAction(AppStore appStore, FetchDataResultAction action)
	{
		return appStore with { IsLoading = false, Forecasts = action.Forecasts };
	}
}