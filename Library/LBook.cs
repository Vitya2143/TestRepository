using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class LBook
    {
        public int Id { get; set; }
        public Object Imagefile { get; set; }
        public byte[] Textfile { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public LBook(int id, Object img, byte[] txt, string title, string author)
        {
            Id = id;
            Imagefile = img;
            Textfile = txt;
            Title = title;
            Author = author;
        }
    }
}
