namespace TMC.Web.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using CloudinaryDotNet.Actions;
    using TMC.Data.DT;
    using TMC.Models;
    using TMC.Web.Areas.Admin.Models.DT.Theatre;
    using TMC.Data;

    public class TheatreController : BaseController
    {
        //
        // GET: /Admin/Theatre/History

        public ActionResult History()
        {
            HistoryViewModel model = new HistoryViewModel();
            History history = new TmcDAL(this.tmcContext).GetHistoryByBranch(Branch.DT);

            if (history == null)
            {
                history = new History();
            }

            if(history.HasImage)
            {
                model.Images = history.Images.ToList();
            }

            model.Content = history.Content;
            model.Cloudinary = this.cloudinary;

            return View(model);
        }

        //
        // POST: /Admin/Theatre/History

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]

        public ActionResult History(HistoryViewModel model)
        {
            History history = new TmcDAL(this.tmcContext).GetHistoryByBranch(Branch.DT);

            if (history == null)
            {
                history = new History()
                {
                    Branch = Branch.DT,
                    Content = model.Content
                };

                this.tmcContext.Histories.Add(history);
            }
            else
            {
                history.Content = model.Content;
            }

            this.tmcContext.SaveChanges();

            if (history.HasImage)
            {
                model.Images = history.Images.ToList();
            }

            model.Cloudinary = this.cloudinary;

            return View(model);
        }

        //
        // POST: /Admin/Theatre/HistoryImage

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult HistoryImage(HttpPostedFileBase Image)
        {
            if (Image != null)
            {
                var fileName = Guid.NewGuid().ToString();

                // uplad image to cloudinary
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(fileName, Image.InputStream)
                };

                var uploadResult = this.cloudinary.Upload(uploadParams);

                // insert information in database
                if (uploadResult != null)
                {
                    History history = new TmcDAL(this.tmcContext).GetHistoryByBranch(Branch.DT);
                    Image image = new Image() 
                    { 
                        Url = uploadResult.PublicId + "." + uploadResult.Format
                    };

                    if (history == null)
                    {
                        // insert history for first time and add the image
                        history = new History()
                        {
                            Images = new List<Image>(),
                            Branch = Branch.DT,
                            HasImage = true
                        };
                        history.Images.Add(image);

                        this.tmcContext.Histories.Add(history);
                    }
                    else
                    {
                        // update images in history
                        if (!history.HasImage)
                        {
                            history.HasImage = true;
                            history.Images = new List<Image>();
                        }

                        history.Images.Add(image);
                    }

                    this.tmcContext.SaveChanges();
                }
            }

            return RedirectToAction("History");
        }

        //
        // Ajax GET: /Admin/Theatre/UpdateDescription/id

        public void UpdateDescription(string imageUrl, string description)
        {
            var matchedImage = new TmcDAL(this.tmcContext).GetImageByUrl(imageUrl);
            if (matchedImage != null)
            {
                matchedImage.Description = description;
                this.tmcContext.SaveChanges();
            }
        }

        //
        // Ajax GET: /Admin/Theatre/Delete/id

        public JsonResult Delete(string imageUrl)
        {
            var tmcDal = new TmcDAL(this.tmcContext);

            //get imageId before delete it
            int imgId = tmcDal.GetImageId(imageUrl);

            // delete picture from cloudinary
            string publicId = imageUrl.Split(new char[] { '.' })[0];
            this.cloudinary.DeleteResources(new string[] { publicId });

            // delete picture information from database and return historyId
            int historyId = tmcDal.DeleteImageByUrl(imageUrl);

            // check if has image
            if (!tmcDal.HasImage(historyId))
            {
                var history = tmcDal.GetHistoryByBranch(Branch.DT);
                history.HasImage = false;

                this.tmcContext.SaveChanges();
            }

            return Json(new { imageId = imgId }, JsonRequestBehavior.AllowGet);
        }

    }
}
