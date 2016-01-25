using Sitecore;
using Sitecore.Data;
using Sitecore.Mvc.ExperienceEditor.Presentation;
using Sitecore.Mvc.Pipelines.Response.RenderRendering;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamingEE.Cms.Custom.RenderingWrapper.Markers;

namespace TamingEE.Cms.Custom.RenderingWrapper
{
   public class AddEditorRenderingWrapper : RenderRenderingProcessor
   {
      public override void Process(RenderRenderingArgs args)
      {
         if (args.Rendered || Context.Site == null || !Context.PageMode.IsExperienceEditorEditing || args.Rendering.RenderingType == "Layout")
         {
            return;
         }

         var marker = GetMarker(args);
         if (marker == null)
         {
            return;
         }

         args.Disposables.Add(new EditorRenderingWrapper(args.Writer, marker));
      }

      public IMarker GetMarker(RenderRenderingArgs args)
      {
         var renderingContext = RenderingContext.CurrentOrNull;
         IMarker marker = null;
         var renderingItem = args.Rendering.RenderingItem;

         if (renderingItem != null)
         {
            marker = new EditorComponentRenderingMarker(renderingItem.Name);
         }

         return marker;
      }
   }
}
