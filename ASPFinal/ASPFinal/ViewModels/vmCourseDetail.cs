﻿using ASPFinal.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;

namespace ASPFinal.ViewModels
{
    public class vmCourseDetail
    {
        public Courses Courses { get; set; }
        public Features Features { get; set; }
        public List<Categories> Categories { get; set; }
        public List<Tags> Tags { get; set; }
        public List<Events> Events { get; set; }
        public List<Messages> Messages { get; set; }
    }
}