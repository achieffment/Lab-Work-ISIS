using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
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
    /// Логика взаимодействия для page_new_Services_Edit.xaml
    /// </summary>
    public partial class page_new_Services_Admin : Page
    {
        public page_new_Services_Admin()
        {
            InitializeComponent();
            listView_service.ItemsSource = poday_na_43Entities1.GetContext().Services.ToList();
            comboBox_findType.Items.Add("None");
            comboBox_findType.Items.Add("Title");
            comboBox_findType.Items.Add("Cost inc");
            comboBox_findType.Items.Add("Cost desc");
            comboBox_findType.Items.Add("DurationInSeconds");
            comboBox_findType.Items.Add("Discount");
            comboBox_findType.Items.Add("Discount 0-5%");
            comboBox_findType.Items.Add("Discount 5-15%");
            comboBox_findType.Items.Add("Discount 15-30%");
            comboBox_findType.Items.Add("Discount 30-70%");
            comboBox_findType.Items.Add("Discount 70-100%");
        }

        private static T GetFrameworkElementByName<T>(FrameworkElement referenceElement) where T : FrameworkElement
        {
            FrameworkElement child = null;
            for (Int32 i = 0; i < VisualTreeHelper.GetChildrenCount(referenceElement); i++)
            {
                child = VisualTreeHelper.GetChild(referenceElement, i) as FrameworkElement;
                System.Diagnostics.Debug.WriteLine(child);
                if (child != null && child.GetType() == typeof(T))
                { break; }
                else if (child != null)
                {
                    child = GetFrameworkElementByName<T>(child);
                    if (child != null && child.GetType() == typeof(T))
                    {
                        break;
                    }
                }
            }
            return child as T;
        }

        private void btn_Start_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < listView_service.Items.Count; i++)
            {
                ListViewItem myListViewItem = listView_service.ItemContainerGenerator.ContainerFromIndex(i) as ListViewItem;
                ContentPresenter myTemplateParent = GetFrameworkElementByName<ContentPresenter>(myListViewItem);
                DataTemplate myDataTemplate = listView_service.ItemTemplate;
                TextBlock textBlock_cost = myDataTemplate.FindName("textBlock_cost", myTemplateParent) as TextBlock;
                TextBlock textBlock_discountCost = myDataTemplate.FindName("textBlock_discountCost", myTemplateParent) as TextBlock;
                TextBlock textBlock_discount = myDataTemplate.FindName("textBlock_discount", myTemplateParent) as TextBlock;
                TextBlock textBlock_duration = myDataTemplate.FindName("textBlock_duration", myTemplateParent) as TextBlock;
                Grid grid_element = myDataTemplate.FindName("grid_element", myTemplateParent) as Grid;

                if (double.Parse(textBlock_discount.Text, System.Globalization.CultureInfo.InvariantCulture) > 0)
                {
                    grid_element.Background = Brushes.LightGreen;

                    double cost = double.Parse(textBlock_cost.Text, System.Globalization.CultureInfo.InvariantCulture);
                    textBlock_cost.Text = "Стоимость: ";
                    Run strikedText = new Run(cost.ToString());
                    strikedText.TextDecorations = TextDecorations.Strikethrough;
                    textBlock_cost.Inlines.Add(strikedText);

                    textBlock_discountCost.Text = "= " + (cost - ((cost / 100) * double.Parse(textBlock_discount.Text, System.Globalization.CultureInfo.InvariantCulture) * 100)).ToString() + " Рублей";
                }
                else
                {
                    textBlock_cost.Text = "Стоимость: " + textBlock_cost.Text;
                    textBlock_discountCost.Text = "Рублей";
                }
                textBlock_duration.Text = (Convert.ToInt32(textBlock_duration.Text) / 60).ToString() + " минут";
            }
        }

        private void textBox_findText_TextChanged(object sender, TextChangedEventArgs e)
        {
            comboBox_findType.SelectedIndex = -1;
            UpdateService(true);
        }

        private void comboBox_findType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textBox_findText.Text = "";
            UpdateService(false);
        }

        private void UpdateService(bool findFilter)
        {
            var currentService = poday_na_43Entities1.GetContext().Services.ToList();
            if (findFilter && !string.IsNullOrEmpty(textBox_findText.Text))
            {
                currentService = currentService.Where(p => p.Title.ToLower().Contains(textBox_findText.Text.ToLower())).ToList();
                listView_service.ItemsSource = currentService;
            }
            else
            {
                if (comboBox_findType.SelectedIndex == 0)
                {
                    currentService = poday_na_43Entities1.GetContext().Services.ToList();
                }
                if (comboBox_findType.SelectedIndex == 1)
                {
                    currentService = currentService.OrderBy(p => p.Title).ToList();
                }
                if (comboBox_findType.SelectedIndex == 2)
                {
                    currentService = currentService.OrderBy(p => p.Cost).ToList();
                }
                if (comboBox_findType.SelectedIndex == 3)
                {
                    currentService = currentService.OrderByDescending(p => p.Cost).ToList();
                }
                if (comboBox_findType.SelectedIndex == 4)
                {
                    currentService = currentService.OrderBy(p => p.DurationInSeconds).ToList();
                }
                if (comboBox_findType.SelectedIndex == 5)
                {
                    currentService = currentService.OrderBy(p => p.Discount).ToList();
                }
                if (comboBox_findType.SelectedIndex == 6)
                {
                    currentService = currentService.Where(p => p.Discount.Value >= 0.0 && p.Discount.Value < 0.05).ToList();
                }
                if (comboBox_findType.SelectedIndex == 7)
                {
                    currentService = currentService.Where(p => p.Discount.Value >= 0.05 && p.Discount.Value < 0.15).ToList();
                }
                if (comboBox_findType.SelectedIndex == 8)
                {
                    currentService = currentService.Where(p => p.Discount.Value >= 0.15 && p.Discount.Value < 0.3).ToList();
                }
                if (comboBox_findType.SelectedIndex == 9)
                {
                    currentService = currentService.Where(p => p.Discount.Value >= 0.3 && p.Discount.Value < 0.7).ToList();
                }
                if (comboBox_findType.SelectedIndex == 10)
                {
                    currentService = currentService.Where(p => p.Discount.Value >= 0.7 && p.Discount.Value < 1.0).ToList();
                }
                listView_service.ItemsSource = currentService;
                ButtonAutomationPeer peer = new ButtonAutomationPeer(btn_Start);
                IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
                invokeProv.Invoke();
            }
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            Manager.isVisibleAdminPage = false;
            Manager.MainFrame.Navigate(new page_new_Services_Admin_Edit(null));
        }

        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {
            Manager.isVisibleAdminPage = false;
            Manager.MainFrame.Navigate(new page_new_Services_Admin_Edit((sender as Button).DataContext as Service));
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            Service serviceToDelete = (sender as Button).DataContext as Service;
            if (MessageBox.Show($"Do you really want to delete this position?", "Attention!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    poday_na_43Entities1.GetContext().Services.Remove(serviceToDelete);
                    poday_na_43Entities1.GetContext().SaveChanges();
                    MessageBox.Show("Removed successfully!");
                    poday_na_43Entities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                    listView_service.ItemsSource = poday_na_43Entities1.GetContext().Services.ToList();
                    UpdateService(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void btn_goBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.isVisibleAdminPage = false;
            Manager.MainFrame.GoBack();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Manager.isVisibleAdminPage)
            {
                poday_na_43Entities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                listView_service.ItemsSource = poday_na_43Entities1.GetContext().Services.ToList();
                UpdateService(false);
            }
        }
    }
}
