using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.UI;
using Microsoft.Maui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esri.ArcGISRuntime.Maui
{
    public interface ISceneView : IGeoView
    {
        Scene? Scene { get; set; }
    }
}
