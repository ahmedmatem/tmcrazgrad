namespace TMC.Web.Controllers
{
    using CloudinaryDotNet;
    using System.Data.Entity;
    using System.Web.Mvc;
    using TMC.Data;
    using TMC.Models;

    public class BaseController : Controller
    {
        protected Cloudinary cloudinary;
        protected TmcContext tmcContext;

        public BaseController()
        {
            this.cloudinary = ImageCloudinary.Instance.Cloudinary;
            this.tmcContext = new TmcContext("DefaultConnection");
        }
    }
}
