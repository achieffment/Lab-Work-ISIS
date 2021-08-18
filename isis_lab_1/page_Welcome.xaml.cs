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
    /// Логика взаимодействия для page_welcome.xaml
    /// </summary>
    public partial class page_Welcome : Page
    {
        public page_Welcome()
        {
            InitializeComponent();
        }

        private void btn_Enter_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new page_new_Services());
        }
    }
}
