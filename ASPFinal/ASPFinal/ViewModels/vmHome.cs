using ASPFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPFinal.ViewModels
{
    public class vmHome
    {
        public About About { get; set; }
        public List<Courses> Courses { get; set; }
        public List<Board> Boards { get; set; }
        public List<Events> Events { get; set; }
        public List<Testimonials> Testimonials { get; set; }
        public List<Blogs> Blogs { get; set; }
        public List<MainSlider> MainSliders { get; set; }
    }
}