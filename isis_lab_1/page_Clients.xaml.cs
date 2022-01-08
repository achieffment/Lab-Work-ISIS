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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class page_Clients : Page
    {
        public page_Clients()
        {
            InitializeComponent();
            dataGrid.ItemsSource = poday_na_43Entities2.GetContext().Clients.ToList();
        }

        public bool is_page_visible(Visibility vis)
        {
            if (vis == Visibility.Visible) 
                return true;
            else
                return false;
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (is_page_visible(Visibility))
            {
                poday_na_43Entities2.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dataGrid.ItemsSource = poday_na_43Entities2.GetContext().Clients.ToList();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new page_Clients_Edit((sender as Button).DataContext as Client));
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new page_Clients_Edit(null));
        }

        private void rmvBtn_Click(object sender, RoutedEventArgs e)
        {
            var clientsForRemove = dataGrid.SelectedItems.Cast<Client>().ToList();

            if (MessageBox.Show( $"Do you want to remove this {clientsForRemove.Count()} positions?", "Attention!", MessageBoxButton.YesNo, MessageBoxImage.Warning ) == MessageBoxResult.Yes) 
            {
                try
                {
                    poday_na_43Entities2.GetContext().Clients.RemoveRange(clientsForRemove);
                    poday_na_43Entities2.GetContext().SaveChanges();
                    MessageBox.Show("Positions successefully removed.");
                    dataGrid.ItemsSource = poday_na_43Entities2.GetContext().Clients.ToList();
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
