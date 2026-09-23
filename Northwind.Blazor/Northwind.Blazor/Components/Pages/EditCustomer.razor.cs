using Microsoft.AspNetCore.Components;
namespace Northwind.Blazor.Components.Pages;
public partial class EditCustomer : ComponentBase
{
	[Parameter]
	public string CustomerId { get; set; } = null!;
	private Customer? customer = new();
	protected override async Task OnParametersSetAsync()
	{
		customer = await _service.GetCustomerAsync(CustomerId);
	}
	private async Task Update()
	{
		if (customer is not null)
		{
			await _service.UpdateCustomerAsync(customer);
		}
		_navigation.NavigateTo("customers");
	}
}