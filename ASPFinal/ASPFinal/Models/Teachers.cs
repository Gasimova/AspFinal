using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPFinal.Models
{
    public class Teachers
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Position { get; set; }

        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImgFile { get; set; }

        [MaxLength(300)]
        public string AboutMe { get; set; }

        [MaxLength(100)]
        public string Degree { get; set; }

        [MaxLength(300)]
        public string Experience { get; set; }

        [MaxLength(300)]
        public string Hobbies { get; set; }

        [MaxLength(300)]
        public string Faculty { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Phone { get; set; }

        [MaxLength(100)]
        public string Skype { get; set; }
        public string Language { get; set; }
        public string TeamLeader { get; set; }
        public string Development { get; set; }
        public string Design { get; set; }
        public string Innovation { get; set; }
        public string Communication { get; set; }
    }
}