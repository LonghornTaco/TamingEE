using Sitecore.Mvc.ExperienceEditor.Presentation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamingEE.Cms.Custom.RenderingWrapper
{
   public class RenderingWrapper : Wrapper
   {
      public RenderingWrapper(TextWriter writer, IMarker marker)
          : base(writer, marker)
      {
      }
   }
}
