using ASPFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPFinal.ViewModels
{
    public class vmLayout
    {
        public List<Contact> Contacts { get; set; }
        public List<Settings> Settings { get; set; }
    }
}