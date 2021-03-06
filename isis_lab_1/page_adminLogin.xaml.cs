using System;
using System.Collections.Generic;
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

namespace isis_lab_1
{
    /// <summary>
    /// Логика взаимодействия для page_adminLogin.xaml
    /// </summary>
    public partial class page_adminLogin : Page
    {
        public page_adminLogin()
        {
            InitializeComponent();
        }

        private void btn_accept_Click(object sender, RoutedEventArgs e)
        {
            if (passwordBox_input.Password.Contains("0000"))
            {
                Manager.isVisibleAdminPage = true;
                Manager.MainFrame.Navigate(new page_new_Services_Admin());
            } else
            {
                MessageBox.Show("Incorrect password. Try again!");
            }
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            Manager.isVisibleServicesPage = true;
            Manager.MainFrame.GoBack();
        }
    }
}
