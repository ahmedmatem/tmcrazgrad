namespace TMC.Web.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using TMC.Data;
    using TMC.Models;
    using TMC.Web.Areas.Admin.Models;

    public class AboutUsController : BaseController
    {
        //
        // GET: /Admin/AboutUs/

        public ActionResult Index()
        {
            AboutUs aboutUs = this.dbContext.AboutUs.FirstOrDefault();
            AboutUsViewModel model = new AboutUsViewModel();

            if (aboutUs != null)
            {
                model.Content = aboutUs.Content;
            }

            return View(model);
        }

        //
        // POST: /Admin/AboutUs/

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(AboutUsViewModel model)
        {
            AboutUs aboutUs = this.dbContext.AboutUs.FirstOrDefault();

            if (aboutUs == null)
            {
                // add
                aboutUs = new AboutUs();
                aboutUs.Content = model.Content;

                dbContext.AboutUs.Add(aboutUs);
            }
            else
            {
                // update
                aboutUs.Content = model.Content;
            }

            this.dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
