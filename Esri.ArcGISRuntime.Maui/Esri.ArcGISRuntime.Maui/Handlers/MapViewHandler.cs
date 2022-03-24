using Microsoft.Maui;
#if WINDOWS || __IOS__ || __ANDROID__
using ViewType = Esri.ArcGISRuntime.UI.Controls.MapView;
#else
using ViewType = System.Object;
#endif

namespace Esri.ArcGISRuntime.Maui.Handlers
{
    public partial class MapViewHandler : GeoViewHandler<IMapView, ViewType>
    {
        public static PropertyMapper<IMapView, MapViewHandler> MapViewMapper = new PropertyMapper<IMapView, MapViewHandler>(GeoViewMapper)
        {
            [nameof(IMapView.Map)] = MapMap,
        };

        public MapViewHandler() : base(MapViewMapper)
        {
        }

        protected override void DisconnectHandler(ViewType PlatformView)
        {
            base.DisconnectHandler(PlatformView);
#if WINDOWS || __IOS__ || __ANDROID__
            PlatformView.Map = null;
#endif
        }

        public static void MapMap(MapViewHandler handler, IMapView mapView)
        {
#if WINDOWS || __IOS__ || __ANDROID__
            if (handler.PlatformView != null)
                handler.PlatformView.Map = mapView.Map;
#endif
        }

#if WINDOWS || __IOS__ || __ANDROID__
        protected override ViewType CreatePlatformView()
        {
#if __ANDROID__
            return new ViewType(Context);
#else
            return new ViewType();
#endif
        }
#else
        protected override object CreatePlatformView() => throw new System.NotSupportedException();
#endif

    }
}