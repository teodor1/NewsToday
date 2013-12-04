using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NEWS
{
    public class NewsBSL
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Texts { get; set; }
        public string CreateDate { get; set; }
        public int Status { get; set; } //0 - Insert; 1 - Update;

        public NewsBSL()
        {
        }
    }
}