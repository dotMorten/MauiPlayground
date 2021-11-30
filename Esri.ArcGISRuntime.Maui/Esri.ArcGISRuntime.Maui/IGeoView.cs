using System;
using Esri.ArcGISRuntime.UI;
using Microsoft.Maui;

namespace Esri.ArcGISRuntime.Maui
{
    public interface IGeoView : IView
    {
        GraphicsOverlayCollection? GraphicsOverlays { get; set; }

        void ViewpointChanged(EventArgs e);
    }
}
