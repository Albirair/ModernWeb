using Microsoft.AspNetCore.Components;
namespace Northwind.Blazor.Components.Pages;
public partial class CreateCustomer : ComponentBase
{
	private Customer customer = new();
	private async Task Create()
	{
		await _service.CreateCustomerAsync(customer);
		_navigation.NavigateTo("customers");
	}
}