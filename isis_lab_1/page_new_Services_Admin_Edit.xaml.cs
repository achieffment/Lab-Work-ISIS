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
    /// Логика взаимодействия для page_new_Services_Edit_Edit.xaml
    /// </summary>
    public partial class page_new_Services_Admin_Edit : Page
    {
        private Service _currentService = new Service();

        public page_new_Services_Admin_Edit(Service selectedService)
        {
            InitializeComponent();

            if (selectedService != null)
            {
                _currentService = selectedService;
            }

            DataContext = _currentService;

            if (_currentService.ID == 0)
            {
                textBlock_idId.Visibility = Visibility.Hidden;
                textBlock_idText.Visibility = Visibility.Hidden;
            }

            _currentService.Cost = Convert.ToInt32(_currentService.Cost);
        }

        private void btn_goBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.isVisibleAdminPage = true;
            Manager.MainFrame.GoBack();
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(_currentService.Title))
            {
                errors.AppendLine("Title can not be empty");
            }

            if (!int.TryParse(textBox_cost.Text, out _) || _currentService.Cost <= 0)
            {
                errors.AppendLine("Cost can not be zero or less and must be numeric");
            }

            if (!int.TryParse(textBox_durationInSeconds.Text, out _) || _currentService.DurationInSeconds == 0)
            {
                errors.AppendLine("DurationInSeconds can not be zero and must be numeric");
            }

            if (!double.TryParse(textBox_discount.Text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out _) || _currentService.Discount < 0 || _currentService.Discount > 1)
            {
                errors.AppendLine("Discount can not be less than zero and must be numeric. Also discount must be less or 1. Use dot instead of ','");
            }

            if (errors.Length != 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {
                if (_currentService.ID == 0)
                {
                    poday_na_43Entities1.GetContext().Services.Add(_currentService);
                }
                try
                {
                    poday_na_43Entities1.GetContext().SaveChanges();
                    Manager.isVisibleAdminPage = true;
                    Manager.MainFrame.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
