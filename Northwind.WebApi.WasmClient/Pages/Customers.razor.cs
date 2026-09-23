using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Northwind.EntityModels;
namespace Northwind.WebApi.WasmClient.Pages;
public partial class Customers : ComponentBase
{
	[Parameter]
	public string? Country { get; set; }
	private IEnumerable<Customer>? customers;
	protected override async Task OnParametersSetAsync()
	{
		if (string.IsNullOrWhiteSpace(Country))
		{
			customers = await Http.GetFromJsonAsync
			<Customer[]>("/customers");
		}
		else
		{
			customers = await Http.GetFromJsonAsync
			<Customer[]>($"/customers/in/{Country}");
		}
	}
}