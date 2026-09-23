using Microsoft.AspNetCore.Components;
using Northwind.EntityModels;
namespace Northwind.Web.Components.Pages;
public partial class Customers : ComponentBase
{
	public ILookup<string?, Customer>? CustomersByCountry;
	private static readonly string title = "Customers by Country";
	protected override void OnInitialized()
	{
		CustomersByCountry = _db.Customers.ToLookup(c => c.Country);
	}
}