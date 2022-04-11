using System.Text.Json;

namespace WasmHosted.Shared.Extensions;

public static class DebuggerExtensions
{
    private static JsonSerializerOptions _options = new() { WriteIndented = true };

    public static string ToJson(this object obj)
    {
        return JsonSerializer.Serialize(obj, _options);
    }

    public static bool IsDebug()
    {
#if DEBUG
        return true;
#else
        return false;
#endif
    }
}