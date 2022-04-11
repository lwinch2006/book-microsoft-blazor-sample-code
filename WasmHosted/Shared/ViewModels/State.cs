using WasmHosted.Shared.Extensions;

namespace WasmHosted.Shared.ViewModels;

public class State
{
    public UI UI { get; } = new UI();
    public ShoppingBasket Basket { get; } = new ShoppingBasket();
    public Menu Menu { get; } = new Menu();
    public decimal TotalPrice
    {
        get
        {
            return Basket.Orders.Sum(t => Menu.GetPizza(t)?.Price ?? 0.00M);
        }
    }
}