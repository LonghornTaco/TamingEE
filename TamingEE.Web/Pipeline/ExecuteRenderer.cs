using System;
using System.IO;
using System.Web.Mvc;
using Sitecore.Diagnostics;
using Sitecore.Mvc.Pipelines;
using Sitecore.Mvc.Pipelines.Response.RenderRendering;
using System.Web;
using TamingEE.Web.ViewModels;
using TamingEE.Web.Controllers;
using TamingEE.Cms.Custom.Exceptions;

namespace TamingEE.Web.Pipeline
{
   public class ExecuteRenderer : Sitecore.Mvc.Pipelines.Response.RenderRendering.ExecuteRenderer
   {
      /// <summary>
      /// Processes the specified arguments.
      /// </summary>
      /// <param name="args">The arguments.</param>
      public override void Process(RenderRenderingArgs args)
      {
         try
         {
            base.Process(args);
         }
         catch (Exception ex)
         {
            //ICommonLog log = DependencyResolver.Current.GetService<ICommonLog>();
            //args.Cacheable = false;

            //var parametersException = GetRenderingParametersException(ex);

            //if (parametersException != null)
            //{
            //   this.RenderParametersError(args, parametersException);
            //   log.Error(parametersException.Message, parametersException);
            //}
            //else
            //{
            //   this.RenderError(args, ex);
            //   log.Error(ex.Message, ex);
            //}
         }
      }

      /// <summary>
      /// Renders the view to string.
      /// </summary>
      /// <param name="viewName">Name of the view.</param>
      /// <param name="model">The model.</param>
      /// <param name="controllerContext">The controller context.</param>
      /// <returns></returns>
      public string RenderViewToString(string viewName, object model, ControllerContext controllerContext)
      {
         if (string.IsNullOrEmpty(viewName))
         {
            viewName = controllerContext.RouteData.GetRequiredString("action");
         }

         controllerContext.Controller.ViewData.Model = model;

         using (var stringWriter = new StringWriter())
         {
            var viewEngineResult = ViewEngines.Engines.FindView(controllerContext, viewName, null);

            var viewContext = new ViewContext(
                controllerContext,
                viewEngineResult.View,
                controllerContext.Controller.ViewData,
                controllerContext.Controller.TempData,
                stringWriter);

            viewEngineResult.View.Render(viewContext, stringWriter);

            return stringWriter.GetStringBuilder().ToString();
         }
      }

      /// <summary>
      /// Gets the rendering error model.
      /// </summary>
      /// <param name="args">The arguments.</param>
      /// <param name="ex">The ex.</param>
      /// <returns></returns>
      private static RenderingErrorViewModel GetRenderingErrorViewModel(RenderRenderingArgs args, Exception ex)
      {
         string renderingName = args.Rendering.RenderingItem != null ? args.Rendering.RenderingItem.Name : string.Empty;
         return new RenderingErrorViewModel(renderingName, ex, Sitecore.Context.PageMode.IsExperienceEditor, HttpContext.Current.IsCustomErrorEnabled);
      }

      /// <summary>
      /// Gets the controller context.
      /// </summary>
      /// <param name="args">The arguments.</param>
      /// <returns></returns>
      private static ControllerContext GetControllerContext(MvcPipelineArgs args)
      {
         return new ControllerContext(
             args.PageContext.RequestContext,
             DependencyResolver.Current.GetService<ErrorController>());
      }

      /// <summary>
      /// Gets the rendering parameters exception.
      /// </summary>
      /// <param name="ex">The ex.</param>
      /// <returns></returns>
      private static Exception GetRenderingParametersException(Exception ex)
      {
         while (true)
         {
            if (ex is RenderingParametersException)
            {
               return ex;
            }

            if (ex.InnerException != null)
            {
               ex = ex.InnerException;
               continue;
            }

            return null;
         }
      }

      /// <summary>
      /// Renders the error.
      /// </summary>
      /// <param name="args">The arguments.</param>
      /// <param name="ex">The ex.</param>
      private void RenderError(RenderRenderingArgs args, Exception ex)
      {
         args.Writer.Write(this.RenderViewToString("Error/RenderingError", GetRenderingErrorViewModel(args, ex), GetControllerContext(args)));
      }

      /// <summary>
      /// Renders the parameters error.
      /// </summary>
      /// <param name="args">The arguments.</param>
      /// <param name="ex">The ex.</param>
      private void RenderParametersError(RenderRenderingArgs args, Exception ex)
      {
         args.Writer.Write(this.RenderViewToString("Error/RenderingParametersError", GetRenderingErrorViewModel(args, ex), GetControllerContext(args)));
      }
   }
}