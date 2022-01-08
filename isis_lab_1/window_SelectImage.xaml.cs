using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace isis_lab_1
{
    /// <summary>
    /// Логика взаимодействия для window_SelectImage.xaml
    /// </summary>
    public partial class window_SelectImage : Window
    {
        private static page_new_Services_Admin_Edit pageWin;

        public window_SelectImage(page_new_Services_Admin_Edit win)
        {
            InitializeComponent();
            pageWin = win;
            listView_images.ItemsSource = poday_na_43Entities2.GetContext().ServicePhotoes.ToList();
        }

        private readonly ImageSourceConverter imageSourceConverter = new ImageSourceConverter();

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            string findRec = poday_na_43Entities2.GetContext().ServicePhotoes.Where(p => p.ServiceID == listView_images.SelectedIndex+1).Select(p => p.PhotoPath).FirstOrDefault().ToString();

            pageWin.textBox_mainImagePath.Text = findRec;
            pageWin.image.Source = (ImageSource)imageSourceConverter.ConvertFrom(findRec);

            this.Close();
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Load_Click(object sender, RoutedEventArgs e)
        {
            ServicePhoto service_photo = new ServicePhoto();

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var fileName = ofd.FileName;
                service_photo.PhotoPath = System.IO.Path.Combine("Resources\\", System.IO.Path.GetFileName(fileName));
                service_photo.ServiceID = poday_na_43Entities2.GetContext().ServicePhotoes.Count() + 1;
                System.IO.File.Copy(fileName, service_photo.PhotoPath);
                System.IO.File.Copy(fileName, System.IO.Path.Combine("..\\..\\Resources\\", System.IO.Path.GetFileName(fileName)));
                poday_na_43Entities2.GetContext().ServicePhotoes.Add(service_photo);
                try
                {
                    poday_na_43Entities2.GetContext().SaveChanges();
                    poday_na_43Entities2.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                    listView_images.ItemsSource = poday_na_43Entities2.GetContext().ServicePhotoes.ToList();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
