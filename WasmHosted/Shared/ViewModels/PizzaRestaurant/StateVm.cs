using WasmHosted.Shared.Extensions;

namespace WasmHosted.Shared.ViewModels.PizzaRestaurant;

public class StateVm
{
    public UIVm UiVm { get; } = new();
    public ShoppingBasketVm BasketVm { get; } = new();
    public MenuVm MenuVm { get; set; } = new();
    public PizzaVm? CurrentPizza { get; set; }
    public decimal TotalPrice
    {
        get
        {
            return BasketVm.Pizzas.Sum(t => MenuVm.GetPizza(t)?.Price ?? 0.00M);
        }
    }
}