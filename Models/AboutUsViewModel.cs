namespace TMC.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AboutUsViewModel
    {
        [Display(Name = "Съдържание")]
        public string Content { get; set; }
    }
}