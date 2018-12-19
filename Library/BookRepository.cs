using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Library.MainWindow;

namespace Library
{
    class BookRepository : IRepository<Book>
    {
        MyDbContext db = new MyDbContext();
        public void Create(Book item)
        {
            db.books.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var books = db.books.FirstOrDefault(b=>b.Id==id);
            if (books != null)
            {
                db.Entry(books).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public Book Get(int id)
        {
            return db.books.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return db.books.ToList();
        }

        public IEnumerable<Book> GetAll(Func<Book, bool> predicate)
        {
            return db.books.Where(predicate).ToList();
        }

        public void Update(Book item)
        {
            var books = db.books.FirstOrDefault(b=>b.Id==item.Id);
            if (books != null)
            {
                books.ImageFile = item.ImageFile;
                books.Textfile = item.Textfile;
                books.Title = item.Title;
                books.Author = item.Author;
                db.Entry(books).State = EntityState.Modified;
                db.SaveChanges();
            }

        }
    }
}
