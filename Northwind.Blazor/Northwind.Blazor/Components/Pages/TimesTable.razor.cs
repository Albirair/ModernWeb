using Microsoft.AspNetCore.Components;
namespace Northwind.Blazor.Components.Pages;
public partial class TimesTable : ComponentBase
{
	[Parameter]
	public int Number { get; set; }
	[Parameter]
	public int? Size { get; set; } = 12;
	public int TableSize { get; set; }
	protected override void OnParametersSet()
	{
		TableSize = Size ?? 12;
	}
}