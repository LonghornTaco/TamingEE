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

namespace TamingEE.Cms.Custom.RenderingWrapper
{
   public class AddRenderingWrapper : RenderRenderingProcessor
   {
      public override void Process(RenderRenderingArgs args)
      {
         var marker = GetMarker();
         if (marker == null) return;
         args.Disposables.Add(new RenderingWrapper(args.Writer, marker));
      }

      public IMarker GetMarker()
      {
         var renderingContext = RenderingContext.CurrentOrNull;
         IMarker marker = null;

         if (renderingContext != null)
         {
            //if (renderingContext.Rendering.Placeholder.Contains(CmsPlaceholders.HorizontalSlider))
            //   marker = new SlideItemRenderingMarker();
            //else if (renderingContext.Rendering.Placeholder.Contains(CmsPlaceholders.Accordion) && renderingContext.Rendering.RenderingItem.ID == ID.Parse(CmsRenderings.Atomic.Image) && !Context.PageMode.IsPageEditorEditing)
            //   marker = new AccordionImageRenderingMarker();
            //else if (renderingContext.Rendering.Placeholder.Contains(CmsPlaceholders.Accordion))
            //   marker = new ListItemRenderingMarker();
         }

         return marker;
      }
   }
}
