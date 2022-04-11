namespace WasmHosted.Client.Components;

public class CounterData
{
    private int _count;

    public int Count
    {
        get => _count;
        set
        {
            if (_count != value)
            {
                _count = value;
                CountChanged?.Invoke(_count);
            }
        }
    }
    
    public Action<int>? CountChanged { get; set; }




}