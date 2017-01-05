using Sitecore.Mvc.ExperienceEditor.Presentation;

namespace TamingEE.Cms.Custom.RenderingWrapper.Markers
{
    public class EditorComponentPlaceholderMarker : IMarker
    {
        private readonly string _placeholderName;
        public EditorComponentPlaceholderMarker(string placeholderName)
        {
            _placeholderName = placeholderName;
        }
        public string GetStart()
        {
            const string formatstring = "<div class=\"component-wrapper {0}\"><span class=\"wrapper-header\">{1} - <em>Placeholder</em></span><div class=\"component-content clearfix\">";
            return string.Format(formatstring, _placeholderName.Replace(" ", string.Empty), _placeholderName);
        }

        public string GetEnd()
        {
            return "</div></div>";
        }
    }
}
