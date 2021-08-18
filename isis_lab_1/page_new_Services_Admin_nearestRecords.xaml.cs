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
    /// Логика взаимодействия для page_new_Services_Admin_nearestRecords.xaml
    /// </summary>
    public partial class page_new_Services_Admin_nearestRecords : Page
    {
        ListView lstView_records;

        public page_new_Services_Admin_nearestRecords()
        {
            InitializeComponent();

            var records = poday_na_43Entities1.GetContext().ClientServices.ToList();
            records = records.OrderByDescending(p => p.StartTime).ToList();
            lstView_records = listView_records;
            listView_records.ItemsSource = records;

            ButtonAutomationPeer peer = new ButtonAutomationPeer(btn_start);
            IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            invokeProv.Invoke();

            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0,0,30);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            poday_na_43Entities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            lstView_records.ItemsSource = poday_na_43Entities1.GetContext().ClientServices.ToList();

            ButtonAutomationPeer peer = new ButtonAutomationPeer(btn_start);
            IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            invokeProv.Invoke();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            Manager.isVisibleAdminPage = true;
            Manager.MainFrame.GoBack();
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

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < listView_records.Items.Count; i++)
            {
                ListViewItem myListViewItem = listView_records.ItemContainerGenerator.ContainerFromIndex(i) as ListViewItem;
                ContentPresenter myTemplateParent = GetFrameworkElementByName<ContentPresenter>(myListViewItem);
                DataTemplate myDataTemplate = listView_records.ItemTemplate;

                Grid grid_infoBlock = myDataTemplate.FindName("grid_infoBlock", myTemplateParent) as Grid;
                TextBlock textBlock_serviceName = myDataTemplate.FindName("textBlock_serviceName", myTemplateParent) as TextBlock;
                TextBlock textBlock_fio = myDataTemplate.FindName("textBlock_fio", myTemplateParent) as TextBlock;
                TextBlock textBlock_email = myDataTemplate.FindName("textBlock_email", myTemplateParent) as TextBlock;
                TextBlock textBlock_phone = myDataTemplate.FindName("textBlock_phone", myTemplateParent) as TextBlock;
                TextBlock textBlock_startTime = myDataTemplate.FindName("textBlock_startTime", myTemplateParent) as TextBlock;
                TextBlock textBlock_timeLeft = myDataTemplate.FindName("textBlock_timeLeft", myTemplateParent) as TextBlock;
                TextBlock textBlock_clientId = myDataTemplate.FindName("textBlock_clientId", myTemplateParent) as TextBlock;
                TextBlock textBlock_serviceId = myDataTemplate.FindName("textBlock_serviceId", myTemplateParent) as TextBlock;

                //  grid_infoBlock
                //  textBlock_serviceName
                //  textBlock_fio
                //  textBlock_email
                //  textBlock_phone
                //  textBlock_startTime
                //  textBlock_timeLeft
                //  textBlock_clientId
                //  textBlock_serviceId

                int findServiceId = Convert.ToInt32(textBlock_serviceId.Text);
                textBlock_serviceName.Text = poday_na_43Entities1.GetContext().Services.Where(p => p.ID == findServiceId).Select(p => p.Title).FirstOrDefault().ToString();

                int findClientId = Convert.ToInt32(textBlock_clientId.Text);
                string fio = poday_na_43Entities1.GetContext().Clients.Where(p => p.ID == findClientId).Select(p => p.FirstName).FirstOrDefault().ToString();
                fio += " " + poday_na_43Entities1.GetContext().Clients.Where(p => p.ID == findClientId).Select(p => p.LastName).FirstOrDefault().ToString();
                fio += " " + poday_na_43Entities1.GetContext().Clients.Where(p => p.ID == findClientId).Select(p => p.Patronymic).FirstOrDefault().ToString();
                textBlock_fio.Text = fio;
                textBlock_email.Text = poday_na_43Entities1.GetContext().Clients.Where(p => p.ID == findClientId).Select(p => p.Email).FirstOrDefault().ToString();
                textBlock_phone.Text = poday_na_43Entities1.GetContext().Clients.Where(p => p.ID == findClientId).Select(p => p.Phone).FirstOrDefault().ToString();

                DateTime dt = DateTime.ParseExact(textBlock_startTime.Text, "yyyy-MM-dd HH:mm:ss.000", System.Globalization.CultureInfo.InvariantCulture);
                if (dt.Date == DateTime.Today || dt.Date == DateTime.Today.AddDays(1))
                {
                    grid_infoBlock.Background = Brushes.LightGreen;

                    TimeSpan interval = dt - DateTime.Now;
                    textBlock_timeLeft.Text = interval.Hours.ToString() + " час(ов/а) " + interval.Minutes.ToString() + " минут(ы).";

                    if (interval.TotalHours <= 1)
                    {
                        grid_infoBlock.Background = Brushes.IndianRed;
                    }
                } else
                {
                    if (dt.Date < DateTime.Today)
                    {
                        grid_infoBlock.Background = Brushes.Gray;
                    }
                }
            }
        }
    }
}
