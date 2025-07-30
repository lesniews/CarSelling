using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace CarSelling.Web.Components;

/// <summary>
/// Render modes for Blazor components
/// </summary>
public static class RenderModes
{
    public static readonly InteractiveServerRenderMode InteractiveServer = new();
    public static readonly InteractiveWebAssemblyRenderMode InteractiveWebAssembly = new();
    public static readonly InteractiveAutoRenderMode InteractiveAuto = new();
}