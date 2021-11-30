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

        /// <inheritdoc />
        protected override void DisconnectHandler(ViewType nativeView)
        {
#if WINDOWS || __IOS__ || __ANDROID__
            nativeView.Scene = null;
#endif
            base.DisconnectHandler(nativeView);
        }
        public static void MapScene(SceneViewHandler handler, ISceneView sceneView)
        {
#if WINDOWS || __IOS__ || __ANDROID__
            if (handler.NativeView != null)
                handler.NativeView.Scene = sceneView.Scene;
#endif
        }

#if WINDOWS || __IOS__ || __ANDROID__
        protected override UI.Controls.SceneView CreateNativeView()
        {
#if __ANDROID__
             return new UI.Controls.SceneView(Context);
#else
            return new UI.Controls.SceneView();
#endif
        }
#else
        protected override object CreateNativeView() => throw new System.NotSupportedException();
#endif
    }
}