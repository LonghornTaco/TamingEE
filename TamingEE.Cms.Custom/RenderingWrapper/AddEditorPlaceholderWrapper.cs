using Sitecore;
using Sitecore.Mvc.ExperienceEditor.Presentation;
using Sitecore.Mvc.Pipelines.Response.RenderPlaceholder;
using Sitecore.Mvc.Presentation;
using TamingEE.Cms.Custom.RenderingWrapper.Markers;

namespace TamingEE.Cms.Custom.RenderingWrapper
{
    public class AddEditorPlaceholderWrapper : RenderPlaceholderProcessor
    {
        public override void Process(RenderPlaceholderArgs args)
        {
            if (Context.Site == null || !Context.PageMode.IsExperienceEditorEditing)
            {
                return;
            }

            var marker = GetMarker(args);
            if (marker == null)
            {
                return;
            }

            args.Disposables.Add(new EditorPlaceholderWrapper(args.Writer, marker));
        }

        public IMarker GetMarker(RenderPlaceholderArgs args)
        {
            var currentOrNull = PlaceholderContext.CurrentOrNull;
            if (currentOrNull == null)
                return null;
            var placeholderName = args.PlaceholderName;
            return new EditorComponentPlaceholderMarker(placeholderName);
        }
    }
}
