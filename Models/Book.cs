using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bookly.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string store { get; set; }
        public int Pages { get; set; }

        public string CoverPath { get; set; }

        [NotMapped] //Very important
        public HttpPostedFileBase CoverFile { get; set; }
    }
}