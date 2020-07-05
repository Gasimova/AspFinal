using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPFinal.Models
{
    public class Events
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImgFile { get; set; }

        [MaxLength(200)]
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        [MaxLength(200)]
        public string Venue { get; set; }
        [MaxLength(100)]
        public string Time { get; set; }

        public List<EventToSpeakers> EventToSpeakers;
    }
}