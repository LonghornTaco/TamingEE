using Sitecore.Mvc.Pipelines.Response.RenderRendering;
using System;
using System.Linq;

namespace TamingEE.Cms.Custom.RenderingWrapper
{
    public class EndEditorRenderingWrapper : RenderRenderingProcessor
    {
        public override void Process(RenderRenderingArgs args)
        {
            foreach (IDisposable wrapper in args.Disposables.OfType<EditorRenderingWrapper>())
            {
                wrapper.Dispose();
            }
        }
    }
}
