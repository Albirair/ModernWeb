using Microsoft.AspNetCore.Components;
namespace Northwind.Web.Components.Pages;
public partial class Suppliers : ComponentBase
{
	private IQueryable? Companies { get; set; }
	protected override void OnInitialized()
	{
		Companies = _db.Suppliers
		.OrderBy(c => c.Country)
		.ThenBy(c => c.CompanyName)
		.Select((s) => new { s.CompanyName, s.Country, s.Phone });
	}
}