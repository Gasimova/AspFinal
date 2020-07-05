using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPFinal.Models
{
    public class Speakers
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Profession { get; set; }

        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImgFile { get; set; }

        public List<EventToSpeakers> EventToSpeakers;
    }
}