using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TamingEE.Web.ViewModels
{
   public class RenderingErrorViewModel : ViewModelBase
   {
      public RenderingErrorViewModel(string renderingName, Exception exception, bool isEditor = false, bool customErrorsEnabled = true)
      {
         this.Exception = exception;
         this.RenderingName = renderingName;
         this.IsEditor = isEditor;
         this.ShowErrors = !customErrorsEnabled || isEditor;
      }

      public string RenderingName { get; private set; }
      public Exception Exception { get; private set; }
      public bool ShowErrors { get; private set; }
   }
}