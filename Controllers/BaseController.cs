namespace TMC.Web.Controllers
{
    using CloudinaryDotNet;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using TMC.Data;
    using TMC.Models;

    public class BaseController : Controller
    {
        protected TmcContext dbContext;
        protected Cloudinary cloudinary;

        public BaseController()
        {
            this.dbContext = new TmcContext("DefaultConnection");
            this.cloudinary = ImageCloudinary.Instance.Cloudinary;
        }
    }
}
