using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Mvc.Controllers;
using Sitecore.Mvc.Presentation;

namespace TamingEE.Web.Controllers
{
   public class LayoutsController : SitecoreController
   {
      public ViewResult OneColumnSection()
      {
         return View();
      }

      public ViewResult TwoColumnSection()
      {
         return View();
      }

      public ViewResult ThreeColumnSection()
      {
         return View();
      }

      public ViewResult TextItem()
      {
         Item item = null;
         if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
         {
            item = Sitecore.Context.Database.GetItem(new ID(RenderingContext.Current.Rendering.DataSource));
         }
         return View(item);
      }
   }
}