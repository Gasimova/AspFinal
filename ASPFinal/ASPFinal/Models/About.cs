using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPFinal.Models
{
    public class About
    {
        public int Id { get; set; }

        [MaxLength(500)]
        public string ContentTitle { get; set; }

        [MaxLength(1000)]
        public string Text { get; set; }
        public string Video { get; set; }
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImgFile { get; set; }
    }
}