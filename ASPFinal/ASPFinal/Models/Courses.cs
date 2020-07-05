using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPFinal.Models
{
    public class Courses
    {
        public int Id { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImgFile { get; set; }

        public string TextTitle { get; set; }
        public string Text { get; set; }

        [Column(TypeName = "ntext")]
        public string DetailText { get; set; }
        public int CategoriesId { get; set; }
        public Categories Categories { get; set; }
        public List<Tags> Tags { get; set; }
    }
}