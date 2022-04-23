using Fluxor;
using Microsoft.AspNetCore.Components;
using WasmHosted.Shared.Redux.Actions;
using WasmHosted.Shared.Redux.Stores;

namespace WasmHosted.Client.Pages.Counter;

public partial class CounterWithFluxor
{
	[Inject] 
	private IState<AppStore> State { get; set; } = default!;

	[Inject]
	private IDispatcher Dispatcher { get; set; } = default!;

	private AppStore AppStore => State.Value;

	private void IncrementCounter()
	{
		var action = new IncrementCounterAction();
		Dispatcher.Dispatch(action);
	}
}