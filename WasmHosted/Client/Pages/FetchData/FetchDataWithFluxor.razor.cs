using Fluxor;
using Microsoft.AspNetCore.Components;
using WasmHosted.Shared.Redux.Actions;
using WasmHosted.Shared.Redux.Stores;

namespace WasmHosted.Client.Pages.FetchData;

public partial class FetchDataWithFluxor
{
	[Inject]
	private IState<AppStore> State { get; set; } = default!;

	[Inject]
	private IDispatcher Dispatcher { get; set; } = default!;
	
	private AppStore AppStore => State.Value;
	
	protected override void OnInitialized()
	{
		var action = new FetchDataAction();
		Dispatcher.Dispatch(action);
		
		base.OnInitialized();
	}
}