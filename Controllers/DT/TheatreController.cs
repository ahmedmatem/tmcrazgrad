namespace TMC.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using TMC.Models;
    using TMC.Web.Models.DT.Theatre;
    using TMC.Data;

    public class TheatreController : BaseController
    {
        //
        // GET: /Theatre/DTHistory

        public ActionResult DTHistory()
        {
            HistoryViewModel model = new HistoryViewModel();
            History history = new TmcDAL(this.tmcContext).GetHistoryByBranch(Branch.DT);

            if (history == null)
            {
                history = new History();
            }

            if (history.HasImage)
            {
                model.Images = history.Images.ToList();
            }

            model.Content = history.Content;
            model.Cloudinary = this.cloudinary;

            return View(model);
        }

    }
}
