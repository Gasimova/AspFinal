using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPFinal.Models
{
    public class Blogs
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImgFile { get; set; }

        [MaxLength(200)]
        public string Title { get; set; }

        [Column(TypeName ="ntext")]
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ReadCount { get; set; }

        public int UsersId { get; set; }

        public Users Users { get; set; }
    }
}