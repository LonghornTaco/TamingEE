using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Mvc.Pipelines.Response.RenderRendering;

namespace TamingEE.Cms.Custom.RenderingWrapper
{
   public class EndRenderingWrapper : RenderRenderingProcessor
   {
      public override void Process(RenderRenderingArgs args)
      {
         foreach (IDisposable wrapper in args.Disposables.OfType<RenderingWrapper>())
         {
            wrapper.Dispose();
         }
      }
   }
}
