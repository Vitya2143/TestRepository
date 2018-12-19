using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Library
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<LBook> lbooks = new List<LBook>();
        public class MyDbContext : DbContext
        {
            public MyDbContext() : base("MyConnection") { }

            public DbSet<Book> books { get; set; }

        }
        public MainWindow()
        {
            InitializeComponent();
            Refresh();

        }
        public void Refresh()
        {
            delBtn.IsEnabled = false;
            loadBtn.IsEnabled = false;
            lbooks.Clear();

            bookLB.Items.Clear();
            using (MyDbContext ctx = new MyDbContext())
            {

                var a = ctx.books.ToList();

                foreach (var item in a)
                {
                    lbooks.Add(new LBook(item.Id,item.ImageFile, item.Textfile, item.Title, item.Author));
                }
                foreach (var item in lbooks)
                {
                    bookLB.Items.Add(item);
                }
            }


        }

        private void Add_click(object sender, RoutedEventArgs e)
        {
            Add dlg = new Add();
            dlg.ShowDialog();
            Refresh();
        }


        private void lb_Selection(object sender, SelectionChangedEventArgs e)
        {
            delBtn.IsEnabled = true;
            loadBtn.IsEnabled = true;
        }

        private void Del_click(object sender, RoutedEventArgs e)
        {
            var item = lbooks[bookLB.SelectedIndex];           
            BookRepository bookRepository = new BookRepository();
            bookRepository.Delete(item.Id);
            Refresh();
        }

        private void Load_click(object sender, RoutedEventArgs e)
        {
            var txt = lbooks[bookLB.SelectedIndex].Textfile;
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Text Files |*.txt;";
            if (dlg.ShowDialog() == true)
            {
                using (FileStream fs = new FileStream(dlg.FileName, FileMode.Create))
                {
                    fs.Write(txt, 0, txt.Length);
                }
            }
        }
    }
}
