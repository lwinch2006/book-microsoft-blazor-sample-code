namespace WasmHosted.Shared.ViewModels;

public class State
{
    public UI UI { get; } = new UI();
    public ShoppingBasket Basket { get; } = new ShoppingBasket();
    public Menu Menu { get; } = new Menu();
}