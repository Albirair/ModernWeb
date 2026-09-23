using Microsoft.AspNetCore.Components;
namespace Northwind.Web.Components.Pages;
public partial class Index : ComponentBase
{
	public string DayName { get; set; } = DateTime.Today.ToString("dddd");
}