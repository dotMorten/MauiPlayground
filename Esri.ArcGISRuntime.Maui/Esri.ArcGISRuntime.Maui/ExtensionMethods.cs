// COPYRIGHT © 2016 ESRI
//
// TRADE SECRETS: ESRI PROPRIETARY AND CONFIDENTIAL
// Unpublished material - all rights reserved under the
// Copyright Laws of the United States and applicable international
// laws, treaties, and conventions.
//
// For additional information, contact:
// Environmental Systems Research Institute, Inc.
// Attn: Contracts and Legal Services Department
// 380 New York Street
// Redlands, California, 92373
// USA
//
// email: contracts@esri.com

using Microsoft.Maui.Graphics;
#if __ANDROID__
using NativePoint = Android.Graphics.PointF;
#elif __IOS__
using NativePoint = CoreGraphics.CGPoint;
#elif WINDOWS
using NativePoint = Windows.Foundation.Point;
using Microsoft.Maui.Controls;
#else
using NativePoint = Microsoft.Maui.Graphics.Point;
#endif
#if WINDOWS
using NativeColor = Windows.UI.Color;
#else
using NativeColor = System.Drawing.Color;
#endif

namespace Esri.ArcGISRuntime.Maui
{
    internal static class ExtensionMethods
    {
#if __ANDROID__
        // Screen coordinates for native Android is in physical pixels, but XF works in DIPs so apply the factor on conversion
        private static Android.Views.IWindowManager? s_windowManager;
        internal static float SystemPixelToDipsFactor
        {
            get
            {
                var displayMetrics = new Android.Util.DisplayMetrics();
                if (s_windowManager == null)
                {
                    var windowService = Android.App.Application.Context?.GetSystemService(Android.Content.Context.WindowService);
                    if (windowService != null)
                        s_windowManager = Android.Runtime.Extensions.JavaCast<Android.Views.IWindowManager>(windowService);
                }
                if (s_windowManager == null)
                    return 1f;
                s_windowManager.DefaultDisplay.GetMetrics(displayMetrics);
                return displayMetrics?.Density ?? 1f;
            }
        }
#endif

        internal static NativePoint ToNativePoint(this Point xfPoint)
        {
#if __ANDROID__
            return new NativePoint((float)(xfPoint.X * SystemPixelToDipsFactor), (float)(xfPoint.Y * SystemPixelToDipsFactor));
#else
            return new NativePoint(xfPoint.X, xfPoint.Y);
#endif
        }
    }
}
