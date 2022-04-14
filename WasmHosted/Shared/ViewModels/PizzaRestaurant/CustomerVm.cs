using System.ComponentModel.DataAnnotations;

namespace WasmHosted.Shared.ViewModels.PizzaRestaurant;

public class CustomerVm
{
    public Guid Id { get; set; }
    
    [Required (ErrorMessage = "Please provide a name")]
    public string? Name { get; set; }
    
    [Required (ErrorMessage = "Please provide a street with house number")]
    public string? Street { get; set; }
    
    [Required (ErrorMessage = "Please provide a city")]
    public string? City { get; set; }
}