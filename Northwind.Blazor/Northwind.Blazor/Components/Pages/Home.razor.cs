using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
namespace Northwind.Blazor.Components.Pages;
public partial class Home : ComponentBase
{
	[Inject]
	public IJSRuntime JSRuntime { get; set; } = null!;
	public async Task AlertBrowser()
	{
		await JSRuntime.InvokeVoidAsync(
		  "messageBox", "Blazor poking the browser");
	}
	public async Task SetColor()
	{
		await JSRuntime.InvokeVoidAsync("setColorInStorage");
	}
	public async Task GetColor()
	{
		await JSRuntime.InvokeVoidAsync("getColorFromStorage");
	}
}