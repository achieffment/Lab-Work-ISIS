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
    /// Логика взаимодействия для page_Test.xaml
    /// </summary>
    public partial class page_Test : Page
    {
        public page_Test()
        {
            InitializeComponent();
            listView_test.ItemsSource = poday_na_43Entities1.GetContext().Services.ToList();

            //listView_test.ItemContainerGenerator.StatusChanged += (sender, e) =>
            //{
            //    listView_test.Dispatcher.Invoke(() =>
            //    {
            //        var TheOne = listView_test.ItemContainerGenerator.ContainerFromIndex(0) as ListBoxItem;
            //        if (TheOne != null)
            //            TheOne.IsSelected = true;
            //    });
            //};

            //ButtonAutomationPeer peer = new ButtonAutomationPeer(btn_Test);
            //IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            //invokeProv.Invoke();
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

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void btn_Test_Click(object sender, RoutedEventArgs e)
        {
            //ListViewItem myListViewItem = listView_test.ItemContainerGenerator.ContainerFromIndex(listView_test.SelectedIndex) as ListViewItem;
            //ContentPresenter myTemplateParent = GetFrameworkElementByName<ContentPresenter>(myListViewItem);

            //DataTemplate myDataTemplate = listView_test.ItemTemplate;
            //TextBlock myTextBlock = myDataTemplate.FindName("textBlock_item", myTemplateParent) as TextBlock;
            //MessageBox.Show(myTextBlock.Text);
        }

        private void btn_Test2_Click(object sender, RoutedEventArgs e)
        {
            //StringBuilder str = new StringBuilder();

            //double a = double.Parse("0.1", System.Globalization.CultureInfo.InvariantCulture);
            //double b = double.Parse("0.2", System.Globalization.CultureInfo.InvariantCulture);

            //double c = a + b;

            //str.AppendLine(c.ToString());

            //MessageBox.Show(str.ToString());
        }
    }
}
