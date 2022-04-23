using System.Drawing;

namespace WasmHosted.Shared.ViewModels.Whiteboard;

public struct LineSegment
{
	public PointF Start { get; init; }
	public PointF End { get; init; }

	public LineSegment(PointF start, PointF end)
	{
		Start = start;
		End = end;
	}
}