using Sitecore.Mvc.ExperienceEditor.Presentation;

namespace TamingEE.Cms.Custom.RenderingWrapper.Markers
{
    public class EditorComponentRenderingMarker : IMarker
   {
      private string _componentName;
      public EditorComponentRenderingMarker(string componentName)
      {
         _componentName = componentName;
      }
      public string GetStart()
      {
         string formatstring = "<div class=\"component-wrapper {0}\"><span class=\"wrapper-header\">{1} - <em>Rendering</em></span><div class=\"component-content clearfix\">";
         return string.Format(formatstring, _componentName.Replace(" ", string.Empty), _componentName);
      }
      public string GetEnd()
      {
         return "</div></div>";
      }
   }
}
