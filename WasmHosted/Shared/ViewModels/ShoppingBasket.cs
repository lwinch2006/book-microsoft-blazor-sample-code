namespace WasmHosted.Shared.ViewModels;

public class ShoppingBasket
{
    public Customer Customer { get; set; } = new Customer();
    public ICollection<int> Orders { get; } = new List<int>();
    public bool HasPaid { get; set; }
}