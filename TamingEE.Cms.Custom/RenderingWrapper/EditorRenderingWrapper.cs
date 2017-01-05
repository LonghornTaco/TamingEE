using Sitecore.Mvc.ExperienceEditor.Presentation;
using System.IO;

namespace TamingEE.Cms.Custom.RenderingWrapper
{
    public class EditorRenderingWrapper : Wrapper
    {
        public EditorRenderingWrapper(TextWriter writer, IMarker marker)
            : base(writer, marker)
        {
        }
    }
}
