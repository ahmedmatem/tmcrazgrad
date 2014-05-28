namespace TMC.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using TMC.Models;
    using TMC.Web.Models;

    public class AboutUsController : BaseController
    {
        //
        // GET: /AboutUs/

        public ActionResult Index()
        {
            AboutUs aboutUs = this.tmcContext.AboutUs.FirstOrDefault();
            var model = new AboutUsViewModel();

            if (aboutUs != null)
            {
                model.Content = aboutUs.Content;
            }

            return View(model);
        }

    }
}
