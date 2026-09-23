using Microsoft.AspNetCore.Components;
namespace Northwind.Blazor.Components.Pages;
public partial class Customers : ComponentBase
{
	[Parameter]
	public string? Country { get; set; }
	private IEnumerable<Customer>? customers;
	protected override async Task OnParametersSetAsync()
	{
		/* await Task.Delay(1000);*@ @* to see "loading" */
		if (string.IsNullOrWhiteSpace(Country))
		{
			customers = await _service.GetCustomersAsync();
		}
		else
		{
			customers = await _service.GetCustomersAsync(Country);
		}
	}
}