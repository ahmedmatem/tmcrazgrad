namespace TMC.Web.Models.DT.Theatre
{
    using System.Web;
    using System.Collections.Generic;

    using CloudinaryDotNet;
    using TMC.Models;

    public class HistoryViewModel
    {
        public int HistoryId { get; set; }

        public int Title { get; set; }

        public string Content { get; set; }

        public List<Image> Images { get; set; }

        public Cloudinary Cloudinary { get; set; }
    }
}