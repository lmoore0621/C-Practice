using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.Models.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public int Copyright { get; set; }
    }
}