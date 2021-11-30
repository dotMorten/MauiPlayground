using Esri.ArcGISRuntime.Mapping;
using Microsoft.Maui.Controls;

namespace Esri.ArcGISRuntime.Maui
{
    [ContentProperty(nameof(Map))]
    public sealed class MapView : GeoView, IMapView
    {
        public MapView() : base()
        {
        }

        public static readonly BindableProperty MapProperty = BindableProperty.Create(nameof(Map), typeof(Map), typeof(MapView));

        public Map? Map
        {
            get { return GetValue(MapProperty) as Map; }
            set { SetValue(MapProperty, value); }
        }
    }
}