using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPFinal.Models
{
    public class Testimonials
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImgFile { get; set; }

        [MaxLength(500)]
        public string Text { get; set; }
        [MaxLength(200)]
        public string Person { get; set; }
        [MaxLength(200)]
        public string Position { get; set; }
    }
}