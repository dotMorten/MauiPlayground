using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace Esri.ArcGISRuntime.Maui
{
    public static class AppHostBuilderExtensions
    {
        public static MauiAppBuilder UseArcGISRuntime(this MauiAppBuilder builder)
        {
            builder.ConfigureMauiHandlers((a) => { a.AddHandler(typeof(MapView), typeof(Handlers.MapViewHandler)); });
            builder.ConfigureMauiHandlers((a) => { a.AddHandler(typeof(SceneView), typeof(Handlers.SceneViewHandler)); });
            ArcGISRuntimeEnvironment.Initialize();
            return builder;
        }
    }
}
