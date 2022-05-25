namespace BlazorServer.Extensions;

public static class HelperFunctionExtensions
{
	public static T As<T>(this object source)
	{
		return (T)source;
	}

	public static WebApplication Use<T>(this T app, Action action)
		where T: class
	{
		action();
		return (app as WebApplication)!;
	}
}