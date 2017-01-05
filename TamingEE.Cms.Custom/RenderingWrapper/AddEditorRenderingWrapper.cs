using Sitecore;
using Sitecore.Mvc.ExperienceEditor.Presentation;
using Sitecore.Mvc.Pipelines.Response.RenderRendering;
using Sitecore.Mvc.Presentation;
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
