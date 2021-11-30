using Esri.ArcGISRuntime.Mapping;
using Microsoft.Maui.Controls;

namespace Esri.ArcGISRuntime.Maui
{
    [ContentProperty(nameof(Scene))]
    public sealed class SceneView : GeoView, ISceneView
    {
        public SceneView() : base()
        {
        }

        public static readonly BindableProperty SceneProperty = BindableProperty.Create(nameof(Scene), typeof(Scene), typeof(SceneView));

        public Scene? Scene
        {
            get { return GetValue(SceneProperty) as Scene; }
            set { SetValue(SceneProperty, value); }
        }
    }
}