using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPFinal.Models
{
    public class EventToSpeakers
    {
        public int Id { get; set; }
        public int EventsId { get; set; }
        public int SpeakersId { get; set; }
    }
}