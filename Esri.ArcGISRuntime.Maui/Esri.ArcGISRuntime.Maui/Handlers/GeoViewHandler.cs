using System;
using Microsoft.Maui;
using Microsoft.Maui.Handlers;

namespace Esri.ArcGISRuntime.Maui.Handlers
{
    public abstract class GeoViewHandler<S, T>
#if WINDOWS || __IOS__ || __ANDROID__
        : ViewHandler<S,T>
        where S: class, IGeoView
        where T : Esri.ArcGISRuntime.UI.Controls.GeoView
#else
        : ViewHandler<IGeoView, object>
#endif
    {
        private protected GeoViewHandler(PropertyMapper mapper) : base(mapper)
        {
        }

        public static PropertyMapper<IGeoView, GeoViewHandler<S, T>> GeoViewMapper = new PropertyMapper<IGeoView, GeoViewHandler<S, T>>(ViewHandler.ViewMapper)
        {
            [nameof(IGeoView.GraphicsOverlays)] = MapGraphicsOverlays,
        };

#if WINDOWS || __IOS__ || __ANDROID__
        protected override void ConnectHandler(T nativeView)
        {
            nativeView.ViewpointChanged += OnViewpointChanged;
            base.ConnectHandler(nativeView);
        }

        protected override void DisconnectHandler(T nativeView)
        {
            nativeView.GraphicsOverlays = null;
            nativeView.ViewpointChanged -= OnViewpointChanged;
            base.DisconnectHandler(nativeView);
        }
#endif

        public static void MapGraphicsOverlays(GeoViewHandler<S, T> handler, IGeoView geoView)
        {
#if WINDOWS || __IOS__ || __ANDROID__
            if (handler.NativeView != null)
                handler.NativeView.GraphicsOverlays = geoView.GraphicsOverlays;
#endif
        }

        private void OnViewpointChanged(object? sender, EventArgs e) => VirtualView?.ViewpointChanged(e);
    }
}
