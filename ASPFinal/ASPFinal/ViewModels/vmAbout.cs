using ASPFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPFinal.ViewModels
{
    public class vmAbout
    {
        public About About { get; set; }
        public List<Teachers> Teachers { get; set; }
        public List<Testimonials> Testimonials { get; set; }
        public List<Board> Boards { get; set; }
    }
}