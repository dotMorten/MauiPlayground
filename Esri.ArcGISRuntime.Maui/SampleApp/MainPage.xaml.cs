using System;
using System.Threading.Tasks;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.UI;
using Microsoft.Maui.Controls;

namespace SampleApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			mapView.Map = new Map(Basemap.CreateStreetsNightVector());

			// Add a dot
			var go = new GraphicsOverlay();
			go.Graphics.Add(new Graphic(new MapPoint(-117, 34, SpatialReferences.Wgs84), new SimpleMarkerSymbol() { Color = System.Drawing.Color.Red, Size = 14 }));
			mapView.GraphicsOverlays.Add(go);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

			// Wait then zoom in on red dot
			await Task.Delay(5000);
			await mapView.SetViewpointAsync(new Viewpoint(new MapPoint(-117, 34, SpatialReferences.Wgs84), 1000000));
        }
    }
}
