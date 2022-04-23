using System.Drawing;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using WasmHosted.Client.Models.Whiteboard;
using WasmHosted.Shared.ViewModels.Whiteboard;

namespace WasmHosted.Client.Components.Whiteboard;

public partial class BoardComponent : ComponentBase
{
	private PointF _lastPosition = new(0, 0);
	private bool _trackMouse;
	private DateTime _lastDateTime;
	
	private ElementReference _board;
	private IJSObjectReference? _canvas;
	
	[Inject]
	private IJSRuntime JsRuntime { get; set; } = default!;
	
	[Parameter] 
	public List<LineSegment> LineSegmets { get; set; } = new();

	[Parameter] 
	public Func<LineSegment, Task> AddLineSegment { get; set; } = default!;
	
	public void MouseDown(MouseEventArgs e)
	{
		if (e.Button == (int)MouseButtonTypes.Left)
		{
			_trackMouse = true;
			_lastDateTime = DateTime.Now;
			_lastPosition = new PointF((float)e.OffsetX, (float)e.OffsetY);
		}
		
	}

	public void MouseUp(MouseEventArgs e)
	{
		_trackMouse = false;
	}

	public void MouseMove(MouseEventArgs e)
	{
		var currentPos = new PointF((float)e.OffsetX, (float)e.OffsetY);
		
		var currentDateTime = DateTime.Now;

		if (_trackMouse && currentDateTime - _lastDateTime > TimeSpan.FromMilliseconds(200))
		{
			AddLineSegment.Invoke(new LineSegment(_lastPosition, currentPos));
			_lastPosition = currentPos;
			_lastDateTime = DateTime.Now;
		}
	}

	protected override async Task OnInitializedAsync()
	{
		_canvas = await JsRuntime.InvokeAsync<IJSObjectReference>("import", "./scripts/whiteboard/canvas.js");
		await base.OnInitializedAsync();
	}

	protected override async Task OnAfterRenderAsync(bool firstRender)
	{
		if (_canvas is not null)
		{
			await _canvas.InvokeVoidAsync("drawLines", _board, LineSegmets);
		}
		
		await base.OnAfterRenderAsync(firstRender);
	}
}