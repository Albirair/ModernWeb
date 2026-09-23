using Microsoft.AspNetCore.Components;
namespace Northwind.Blazor.Components;
public partial class CustomerDetail : ComponentBase
{
	[Parameter]
	public Customer Customer { get; set; } = null!;
	[Parameter]
	public string ButtonText { get; set; } = "Save Changes";
	[Parameter]
	public string ButtonStyle { get; set; } = "info";
	[Parameter]
	public EventCallback OnValidSubmit { get; set; }
}