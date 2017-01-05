using Sitecore.Mvc.Pipelines.Response.RenderPlaceholder;
using System;
using System.Linq;

namespace TamingEE.Cms.Custom.RenderingWrapper
{
    public class EndEditorPlaceholderWrapper : RenderPlaceholderProcessor
    {
        public override void Process(RenderPlaceholderArgs args)
        {
            foreach (IDisposable wrapper in args.Disposables.OfType<EditorPlaceholderWrapper>())
            {
                wrapper.Dispose();
            }
        }
    }
}
