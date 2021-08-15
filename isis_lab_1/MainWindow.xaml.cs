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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            mainFrame.Navigate(new page_Welcome());
            Manager.MainFrame = mainFrame;

            //mainFrame.Navigate(new page_Service());
            ////mainFrame.Navigate(new page_Clients());
            //Manager.MainFrame = mainFrame;
        }

        //private void addBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    Manager.MainFrame.Navigate(new page_Clients_Edit(null));
        //}

        //private void rmvBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    // rmvBtn.Visibility = Visibility.Hidden;
        //}
    }
}
