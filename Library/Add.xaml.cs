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
using System.Windows.Shapes;
using static Library.MainWindow;

namespace Library
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        byte[] img;
        byte[] txt;
        public Add()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (ImgTb.Text != "" && TxtTb.Text != "")
            {
                if (titleTb.Text != "" && authorTb.Text != "")
                {

                    BookRepository bookRepository = new BookRepository();
                        bookRepository.Create(new Book
                        {
                            ImageFile = img,
                            Textfile = txt,
                            Title = $"Название: {titleTb.Text}",
                            Author = $"Автор: {authorTb.Text}"
                        });
                        MessageBox.Show("Книга успешно добавлена!");
                       this.Close();
                    
                }
                else
                    MessageBox.Show("Заполните поля!");
            }
            else
                MessageBox.Show("Файлы не выбраны!");
        }

        private void OpenImg_click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image files |*.png;*.jpeg;*.jfif";
            if (dlg.ShowDialog() == true)
            {
                ImgTb.Text = dlg.FileName;
                string path = dlg.FileName;

                FileInfo fi = new FileInfo(path);
                using (FileStream fs = new FileStream(fi.FullName, FileMode.Open))
                {
                    img = new byte[fs.Length];
                    fs.Read(img, 0, img.Length);
                }
            }
        }

        private void OpenTextFile_click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Text files |*.txt;*text";
            if (dlg.ShowDialog() == true)
            {
                TxtTb.Text = dlg.FileName;
                string path = dlg.FileName;

                FileInfo fi = new FileInfo(path);
                using (FileStream fs = new FileStream(fi.FullName, FileMode.Open))
                {
                    txt = new byte[fs.Length];
                    fs.Read(txt, 0, txt.Length);
                }
            }
        }
    }
}
