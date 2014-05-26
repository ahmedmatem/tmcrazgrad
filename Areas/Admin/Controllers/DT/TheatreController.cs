using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TMC.Web.Areas.Admin.Controllers
{
    public class TheatreController : BaseController
    {
        //
        // GET: /Admin/Theatre/History

        public ActionResult History()
        {
            return View();
        }

        //
        // POST: /Admin/Theatre/HistoryImage

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult HistoryImage(HttpPostedFileBase Image)
        {
            return RedirectToAction("History");
        }

    }
}
