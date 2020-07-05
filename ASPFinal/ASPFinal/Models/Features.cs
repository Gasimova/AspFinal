using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPFinal.Models
{
    public class Features
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Starts { get; set; }

        [MaxLength(100)]
        public string Duration { get; set; }

        [MaxLength(100)]
        public string ClassDuration { get; set; }

        [MaxLength(100)]
        public string SkillLevel { get; set; }

        [MaxLength(100)]
        public string Language { get; set; }

        [MaxLength(100)]
        public string Students { get; set; }

        [MaxLength(100)]
        public string Assetsments { get; set; }

        [MaxLength(100)]
        public string CourseFee { get; set; }
    }
}