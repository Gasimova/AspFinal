using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPFinal.Models
{
    public class Tags
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public int CoursesId { get; set; }
        public Courses Courses { get; set; }
    }
}