using ASPFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPFinal.ViewModels
{
    public class vmEventRight
    {
        public List<Events> Events { get; set; }
        public Events Event { get; set; }
        public List<Categories> Categories { get; set; }
        public List<Messages> Messages { get; set; }
        public List<Tags> Tags { get; set; }
        public List<Speakers> Speakers { get; set; }
    }
}