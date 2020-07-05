using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPFinal.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [MaxLength(300)]
        public string Address { get; set; }

        [MaxLength(100)]
        public string Phone { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Website { get; set; }
    }
}