using Microsoft.AspNetCore.Components;
using WasmHosted.Shared.ViewModels.Whiteboard;

namespace WasmHosted.Client.Pages.Whiteboard;

public partial class Board : ComponentBase
{
	private readonly List<LineSegment> _lineSegments = new();
	
	private Task AddLineSegment(LineSegment lineSegment)
	{
		_lineSegments.Add(lineSegment);
		return Task.CompletedTask;
	}
}