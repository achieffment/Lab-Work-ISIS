using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для page_users.xaml
    /// </summary>
    public partial class page_users : Page
    {
        //SqlDataAdapter adapter;

        public page_users()
        {
            InitializeComponent();

            db_connection("SELECT * FROM users");
        }

        public void db_connection(string query)
        {
            string connStr = "data source=DESKTOP-8HUTIFE;Initial Catalog=poday_na_43_users;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                DataTable usersTable = new DataTable();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(usersTable);
                usersGrid.ItemsSource = usersTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        private void btn_find_Click(object sender, RoutedEventArgs e)
        {
            string find_text = textBox_find.Text.ToString();
            db_connection("SELECT * FROM users WHERE username='" + find_text + "'");
        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            db_connection("SELECT * FROM users");
        }
    }
}
