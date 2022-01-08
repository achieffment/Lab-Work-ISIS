using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для page_new_Services_Admin_Record.xaml
    /// </summary>
    public partial class page_new_Services_Admin_Record : Page
    {
        ClientService _currentRecord = new ClientService();

        int duration;

        public page_new_Services_Admin_Record(Service selectedService)
        {
            InitializeComponent();

            DataContext = selectedService;

            duration = selectedService.DurationInSeconds / 60;

            _currentRecord.ServiceID = selectedService.ID;

            textBox_durationInMinutes.Text = (selectedService.DurationInSeconds / 60).ToString();

            comboBox_name.ItemsSource = poday_na_43Entities2.GetContext().Clients.Select(column => column.ID + " " + column.FirstName + " " + column.LastName + " " + column.Patronymic).ToList();

            textBox_endTimeHours.MaxLength = 2;
            textBox_endTimeMinutes.MaxLength = 2;
        }

        private void btn_goBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.isVisibleAdminPage = true;
            Manager.MainFrame.GoBack();
        }

        public bool new_service_admin_record_check_errors(StringBuilder errors)
        {
            if (errors.Length != 0)
                return true;
            else
                return false;
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (comboBox_name.SelectedIndex == -1)
            {
                errors.AppendLine("You must choose a person!");
            }

            if (datePicker_date.SelectedDate == null)
            {
                errors.AppendLine("You must choose a date!");
            } else
            {
                if (datePicker_date.SelectedDate < DateTime.Today)
                {
                    errors.AppendLine("You can not record a person on past date!");
                } else { 
                    if (string.IsNullOrEmpty(textBox_endTimeHours.Text))
                    {
                        errors.AppendLine("You must choose time!");
                    } else {
                        if (string.IsNullOrEmpty(textBox_endTimeMinutes.Text))
                        {
                            textBox_endTimeMinutes.Text = "00";
                        }
                        if (datePicker_date.SelectedDate == DateTime.Today)
                        {
                            if (Convert.ToInt32(textBox_endTimeHours.Text) < Convert.ToInt32(DateTime.Now.Hour))
                            {
                                errors.AppendLine("You can not record a person on past time!");
                            } else
                            {
                                if (Convert.ToInt32(textBox_endTimeHours.Text) == Convert.ToInt32(DateTime.Now.Hour))
                                {
                                    if (Convert.ToInt32(textBox_endTimeMinutes.Text) < Convert.ToInt32(DateTime.Now.Minute))
                                    {
                                        errors.AppendLine("You can not record a person on past minutes!");
                                    }
                                }
                            }
                        }
                    }

                }
            }
            
            if (new_service_admin_record_check_errors(errors))
            {
                MessageBox.Show(errors.ToString());
                return;
            } else
            {
                //_currentRecord.ClientID = poday_na_43Entities1.GetContext().Clients.Select(p => p.)
                string comboText = comboBox_name.SelectedItem.ToString();
                string[] comboTextSplit = comboText.Split(' ');
                int clientId = Convert.ToInt32(comboTextSplit[0]);

                _currentRecord.ClientID = clientId;

                string month = datePicker_date.SelectedDate.Value.Month.ToString();
                if (month.Length == 1)
                {
                    month = "0" + month;
                }
                string day = datePicker_date.SelectedDate.Value.Day.ToString();
                if (day.Length == 1)
                {
                    day = "0" + day;
                }
                string time_hour = textBox_endTimeHours.Text;
                if (time_hour.Length == 1)
                {
                    time_hour = "0" + time_hour;
                }
                string time_min = textBox_endTimeMinutes.Text;
                if (time_min.Length == 1)
                {
                    time_min = "0" + time_min;
                }

                _currentRecord.StartTime = datePicker_date.SelectedDate.Value.Year.ToString() + "-" + month + "-" + day + " " + time_hour + ":" + time_min + ":00.000";
                _currentRecord.Comment = textBox_comment.Text;

                poday_na_43Entities2.GetContext().ClientServices.Add(_currentRecord);
                try
                {
                    poday_na_43Entities2.GetContext().SaveChanges();
                    Manager.isVisibleAdminPage = true;
                    Manager.MainFrame.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void textBox_endTimeHours_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void textBox_endTimeHours_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_endTimeHours.Text)) {
                if (Convert.ToInt32(textBox_endTimeHours.Text) > 23)
                {
                    textBox_endTimeHours.Text = "23";
                }
            }
            string durHour = DateTime.Now.Hour.ToString();
            if (!string.IsNullOrEmpty(textBox_endTimeHours.Text))
            {
                durHour = textBox_endTimeHours.Text;
            }
            string durMin = "0";
            if (!string.IsNullOrEmpty(textBox_endTimeMinutes.Text))
            {
                durMin = textBox_endTimeMinutes.Text;
            }

            double endTime = Convert.ToInt32(durHour) * 60 + Convert.ToInt32(durMin) + duration;
            endTime = endTime / 60;

            if (Math.Truncate(endTime) >= 24)
            {
                endTime -= 24;
            }

            textBlock_endTimeTime.Text = Math.Truncate(endTime).ToString() + ":" + (Math.Round(((endTime - Math.Truncate(endTime)) * 60))).ToString();
        }

        private void textBox_endTimeMinutes_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void textBox_endTimeMinutes_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_endTimeMinutes.Text))
            {
                if (Convert.ToInt32(textBox_endTimeMinutes.Text) > 59)
                {
                    textBox_endTimeMinutes.Text = "59";
                }
            }

            string durHour = DateTime.Now.Hour.ToString();
            if (!string.IsNullOrEmpty(textBox_endTimeHours.Text))
            {
                durHour = textBox_endTimeHours.Text;
            }
            string durMin = "0";
            if (!string.IsNullOrEmpty(textBox_endTimeMinutes.Text))
            {
                durMin = textBox_endTimeMinutes.Text;
            }

            double endTime = Convert.ToInt32(durHour) * 60 + Convert.ToInt32(durMin) + duration;
            endTime = endTime / 60;

            if (Math.Truncate(endTime) >= 24)
            {
                endTime -= 24;
            }

            textBlock_endTimeTime.Text = Math.Truncate(endTime).ToString() + ":" + (Math.Round(((endTime - Math.Truncate(endTime)) * 60))).ToString();
        }
    }
}
