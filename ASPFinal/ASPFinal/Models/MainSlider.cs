using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPFinal.Models
{
    public class MainSlider
    {
        public int Id { get; set; }
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImgFile { get; set; }
        [MaxLength(500)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Subtitle { get; set; }
    }
}