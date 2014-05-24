namespace TMC.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using TMC.Data;

    public class BaseController : Controller
    {
        protected TmcContext dbContext;

        public BaseController()
        {
            this.dbContext = new TmcContext("DefaultConnection");
        }
    }
}
