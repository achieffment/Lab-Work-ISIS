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
    /// Логика взаимодействия для page_service.xaml
    /// </summary>
    public partial class page_Service : Page
    {
        public page_Service()
        {
            InitializeComponent();

            var currentService = poday_na_43Entities1.GetContext().Services.ToList();

            listview_service.ItemsSource = currentService;

            comboBox_type.Items.Add("None");
            comboBox_type.Items.Add("Title");
            comboBox_type.Items.Add("Cost");
            comboBox_type.Items.Add("DurationInSeconds");
            comboBox_type.Items.Add("Discount");

            UpdateService();
        }

        private void UpdateService()
        {
            var currentService = poday_na_43Entities1.GetContext().Services.ToList();

            currentService = currentService.Where(p => p.Title.ToLower().Contains(textBox_find.Text.ToLower())).ToList();

            if (comboBox_type.SelectedIndex == 0)
            {
                currentService = poday_na_43Entities1.GetContext().Services.ToList();
            }
            if (comboBox_type.SelectedIndex == 1)
            {
                currentService = currentService.OrderBy(p => p.Title).ToList();
            }
            if (comboBox_type.SelectedIndex == 2)
            {
                currentService = currentService.OrderBy(p => p.Cost).ToList();
            }
            if (comboBox_type.SelectedIndex == 3)
            {
                currentService = currentService.OrderBy(p => p.DurationInSeconds).ToList();
            }
            if (comboBox_type.SelectedIndex == 4)
            {
                currentService = currentService.OrderBy(p => p.Discount).ToList();
            }

            listview_service.ItemsSource = currentService;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateService();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateService();
        }
    }
}
