namespace TMC.Web.Areas.Admin.Models.DT.Theatre
{
    using System.Web;
    using TMC.Models;

    public class HistoryViewModel
    {
        public Article History { get; set; }

        public HttpPostedFileBase Image { get; set; }
    }
}