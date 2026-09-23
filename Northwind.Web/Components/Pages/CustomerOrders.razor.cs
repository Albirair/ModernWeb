using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Northwind.EntityModels;
namespace Northwind.Web.Components.Pages;
public partial class CustomerOrders : ComponentBase
{
	[Parameter]
	public string? CustomerId { get; set; }
	public Customer? Customer { get; set; }
	private static readonly string title = "Customer and their orders";
	protected override void OnInitialized()
	{
		Customer = _db.Customers.Include(c => c.Orders)
		  .SingleOrDefault(c => c.CustomerId == CustomerId);
	}
}