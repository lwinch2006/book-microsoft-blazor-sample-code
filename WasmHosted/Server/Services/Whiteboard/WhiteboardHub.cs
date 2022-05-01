using Microsoft.AspNetCore.SignalR;
using WasmHosted.Shared.ViewModels.Whiteboard;

namespace WasmHosted.Server.Services.Whiteboard;

public interface IWhiteboardHub
{
	Task InitLineSegmentsOnClient();
	Task SendNewLineSegmentsToClients(IEnumerable<LineSegment> lineSegments);
}

public class WhiteboardHub : Hub, IWhiteboardHub
{
	private static readonly List<LineSegment> LineSegments = new();
	private readonly ILogger<WhiteboardHub> _logger;

	public WhiteboardHub(ILogger<WhiteboardHub> logger)
	{
		_logger = logger;
	}

	public async Task InitLineSegmentsOnClient()
	{
		_logger.LogInformation("{FunctionName} - {Count}", nameof(InitLineSegmentsOnClient), LineSegments.Count);
		await Clients.Caller.SendAsync("InitLineSegments", LineSegments);
	}

	public async Task SendNewLineSegmentsToClients(IEnumerable<LineSegment> lineSegments)
	{
		_logger.LogInformation("{FunctionName} - {Count}", nameof(SendNewLineSegmentsToClients), LineSegments.Count);
		LineSegments.AddRange(lineSegments);
		await Clients.Others.SendAsync("AddLineSegments", lineSegments);
	}
}