using Microsoft.Maui;
#if WINDOWS || __IOS__ || __ANDROID__
using ViewType = Esri.ArcGISRuntime.UI.Controls.SceneView;
#else
using ViewType = System.Object;
#endif

namespace Esri.ArcGISRuntime.Maui.Handlers
{
    public partial class SceneViewHandler : GeoViewHandler<ISceneView, ViewType>
    {
        public static PropertyMapper<ISceneView, SceneViewHandler> SceneViewMapper = new PropertyMapper<ISceneView, SceneViewHandler>(GeoViewMapper)
        {
            [nameof(ISceneView.Scene)] = MapScene,
        };

        public SceneViewHandler() : base(SceneViewMapper)
        {
        }

        public SceneViewHandler(PropertyMapper? mapper = null) : base(mapper ?? SceneViewMapper)
        {
        }

        protected override void DisconnectHandler(ViewType platformView)
        {
            base.DisconnectHandler(platformView);
#if WINDOWS || __IOS__ || __ANDROID__
            platformView.Scene = null;
#endif
        }
        public static void MapScene(SceneViewHandler handler, ISceneView sceneView)
        {
#if WINDOWS || __IOS__ || __ANDROID__
            if (handler.PlatformView != null)
                handler.PlatformView.Scene = sceneView.Scene;
#endif
        }

#if WINDOWS || __IOS__ || __ANDROID__
        protected override ViewType CreatePlatformView()
        {
#if __ANDROID__
             return new UI.Controls.SceneView(Context);
#else
            return new UI.Controls.SceneView();
#endif
        }
#else
        protected override object CreatePlatformView() => throw new System.NotSupportedException();
#endif
    }
}