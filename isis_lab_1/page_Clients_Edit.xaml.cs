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
    /// Логика взаимодействия для page_Clients_Edit.xaml
    /// </summary>
    public partial class page_Clients_Edit : Page
    {
        private Client _currentClient = new Client();

        public page_Clients_Edit(Client selectedClient)
        {
            InitializeComponent();

            if (selectedClient != null)
            {
                _currentClient = selectedClient;
            }

            DataContext = _currentClient;
            combo_gender.ItemsSource = poday_na_43Entities1.GetContext().Genders.Select(column => column.Code).ToList();

            if (string.IsNullOrEmpty(_currentClient.RegistrationDate))
            {
                _currentClient.RegistrationDate = Convert.ToString(DateTime.Now);
            }
            if (string.IsNullOrEmpty(_currentClient.ID.ToString()) || _currentClient.ID == 0)
            {
                textBlock_ID.Visibility = Visibility.Hidden;
                textblock_ID_value.Visibility = Visibility.Hidden;
            }

            textbox_phone.MaxLength = 20;
        }

        private void submit_btn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(_currentClient.FirstName))
            {
                errors.AppendLine("FirstName can not be empty");
            }
            if (string.IsNullOrEmpty(_currentClient.LastName))
            {
                errors.AppendLine("LastName can not be empty");
            }
            if (string.IsNullOrEmpty(_currentClient.Patronymic))
            {
                errors.AppendLine("Patronymic can not be empty");
            }
            if (string.IsNullOrEmpty(_currentClient.Birthday))
            {
                errors.AppendLine("Birthday can not be empty");
            }
            if (string.IsNullOrEmpty(_currentClient.Email))
            {
                errors.AppendLine("Email can not be empty");
            }
            if (string.IsNullOrEmpty(_currentClient.Phone))
            {
                errors.AppendLine("Phone can not be empty");
            }
            if (string.IsNullOrEmpty(_currentClient.GenderCode))
            {
                errors.AppendLine("GenderCode can not be empty");
            }

            if (errors.Length != 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {

                if (_currentClient.ID == 0)
                {
                    poday_na_43Entities1.GetContext().Clients.Add(_currentClient);
                }
                try
                {
                    poday_na_43Entities1.GetContext().SaveChanges();
                    Manager.MainFrame.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }
    }
}
