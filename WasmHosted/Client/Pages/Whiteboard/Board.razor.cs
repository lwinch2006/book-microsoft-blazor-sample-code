using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using WasmHosted.Shared.ViewModels.Whiteboard;

namespace WasmHosted.Client.Pages.Whiteboard;

public partial class Board : ComponentBase, IAsyncDisposable
{
	private readonly List<LineSegment> _lineSegments = new();
	private HubConnection _hubConnection = default!;
	
	[Inject] 
	private NavigationManager NavigationManager { get; set; } = default!;
	
	private async Task AddLineSegment(LineSegment lineSegment)
	{
		await _hubConnection.SendAsync("SendNewLineSegmentsToClients", new[] { lineSegment });
		_lineSegments.Add(lineSegment);
	}

	protected override async Task OnInitializedAsync()
	{
		_hubConnection = new HubConnectionBuilder()
			.WithUrl(NavigationManager.ToAbsoluteUri("/whiteboard"))
			.Build();

		_hubConnection.On<IEnumerable<LineSegment>>("AddLineSegments", lineSegments =>
		{
			_lineSegments.AddRange(lineSegments);
			StateHasChanged();
		});

		_hubConnection.On<List<LineSegment>>("InitLineSegments", lineSegments =>
		{
			_lineSegments.Clear();
			_lineSegments.AddRange(lineSegments);
			StateHasChanged();
		});

		await _hubConnection.StartAsync();
		await _hubConnection.SendAsync("InitLineSegmentsOnClient");
	}

	public async ValueTask DisposeAsync()
	{
		await _hubConnection.DisposeAsync();
	}
}