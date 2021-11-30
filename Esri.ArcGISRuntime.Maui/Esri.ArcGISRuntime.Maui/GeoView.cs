using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.UI;
using Microsoft.Maui.Controls;

namespace Esri.ArcGISRuntime.Maui
{
    public abstract class GeoView : View, IGeoView
    {
        private protected GeoView() : base()
        {
            GraphicsOverlays = new GraphicsOverlayCollection();
        }

        public static readonly BindableProperty GraphicsOverlaysProperty =
            BindableProperty.Create(nameof(GraphicsOverlays), typeof(GraphicsOverlayCollection), typeof(GeoView), null,
                BindingMode.OneWay, null);

        public GraphicsOverlayCollection? GraphicsOverlays
        {
            get { return GetValue(GraphicsOverlaysProperty) as GraphicsOverlayCollection; }
            set { SetValue(GraphicsOverlaysProperty, value); }
        }

#if WINDOWS || IOS || ANDROID
        private UI.Controls.GeoView? NativeGeoView => Handler?.NativeView as UI.Controls.GeoView;
        private UI.Controls.GeoView NativeGeoViewOrThrow => Handler?.NativeView as UI.Controls.GeoView ?? throw new InvalidOperationException("Operation not supported until view handler is initialized");

#endif

        public void SetViewpoint(Viewpoint viewpoint)
        {
#if WINDOWS || IOS || ANDROID
            NativeGeoViewOrThrow.SetViewpoint(viewpoint);
#else
            throw new NotSupportedException();
#endif
        }

        public Task<bool> SetViewpointAsync(Viewpoint viewpoint)
        {
#if WINDOWS || IOS || ANDROID
            return NativeGeoViewOrThrow.SetViewpointAsync(viewpoint);
#else
            throw new NotSupportedException();
#endif
        }

        public Task<IReadOnlyList<IdentifyLayerResult>> IdentifyLayersAsync(Microsoft.Maui.Graphics.Point screenPoint, double tolerance, bool returnPopupsOnly, long maximumResultsPerLayer, CancellationToken cancellationToken)
        {
#if WINDOWS || IOS || ANDROID
            return NativeGeoViewOrThrow.IdentifyLayersAsync(screenPoint.ToNativePoint(), tolerance, returnPopupsOnly, maximumResultsPerLayer, cancellationToken);
#else
            throw new NotSupportedException();
#endif
        }

        public event EventHandler? ViewpointChanged;

        void IGeoView.ViewpointChanged(EventArgs e) => ViewpointChanged?.Invoke(this, e);
    }
}