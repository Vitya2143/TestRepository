using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Library
{ 
    public class Book
    {
        public int Id { get; set; }   
        [Column(TypeName = "image")]
        public byte[] ImageFile { get; set; }
        public byte[]Textfile { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }
}
