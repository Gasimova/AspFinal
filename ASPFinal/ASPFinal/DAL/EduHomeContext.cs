using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ASPFinal.Models;

namespace ASPFinal.DAL
{
    public class EduHomeContext:DbContext
    {
        
        public EduHomeContext() : base("ConnectEdu")
        {

        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Blogs> Blogs { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<EventToSpeakers> EventToSpeakers { get; set; }
        public DbSet<Features> Features { get; set; }
        public DbSet<MainSlider> MainSliders { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Speakers> Speakers { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<Testimonials> Testimonials { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Admins> Admins { get; set; }
    }
}