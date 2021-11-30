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

        protected override void DisconnectHandler(ViewType nativeView)
        {
#if WINDOWS || __IOS__ || __ANDROID__
            nativeView.Map = null;
#endif
            base.DisconnectHandler(nativeView);
        }

        public static void MapMap(MapViewHandler handler, IMapView mapView)
        {
#if WINDOWS || __IOS__ || __ANDROID__
            if (handler.NativeView != null)
                handler.NativeView.Map = mapView.Map;
#endif
        }

#if WINDOWS || __IOS__ || __ANDROID__
        protected override UI.Controls.MapView CreateNativeView()
        {
#if __ANDROID__
            return new UI.Controls.MapView(Context);
#else
            return new UI.Controls.MapView();
#endif
        }
#else
        protected override object CreateNativeView() => throw new System.NotSupportedException();
#endif

    }
}