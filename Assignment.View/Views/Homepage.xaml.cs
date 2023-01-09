using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Assignment.View
{
    /// <summary>
    /// Interaction logic for Homepage.xaml
    /// </summary>
    public partial class Homepage : Window
    {
        public Homepage()
        {
            InitializeComponent();
        }


        private void logout(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(localdb)\Local;Initial Catalog=Assignments;Integrated Security=True;");
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                string query = "select FirstName,LastName,Gender,Email,DOB from users";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.ExecuteNonQuery();

                SqlDataAdapter dataadp = new SqlDataAdapter(sqlcmd);
                DataTable dt = new DataTable("users");
                dataadp.Fill(dt);
                datagrid.ItemsSource = dt.DefaultView;
                dataadp.Update(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlcon.Close();
            }
        }

        private void searchclick(object sender, RoutedEventArgs e)
        {
            string sitem = searchbox.Text;

            SqlConnection sqlcon = new SqlConnection(@"Data Source=(localdb)\Local;Initial Catalog=Assignments;Integrated Security=True;");
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();

                string query = String.Format("select * from users where Firstname like '%{0}%' or LastName like '%{0}%'" +
                    "  or Gender like '%{0}%'  or Email like '%{0}%'  or DOB like '%{0}%'", sitem);

                //string query = "select * from Users where Firstname like '%@sitem%' or LastName like '%@sitem%'" +
                // "  or Gender like '%@sitem%'  or Email like '%@sitem%'  or DOB like '%@sitem%' ";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.CommandType = CommandType.Text;

                sqlcmd.ExecuteNonQuery();


                SqlDataAdapter dataadp = new SqlDataAdapter(sqlcmd);
                DataTable dt = new DataTable("users");
                dataadp.Fill(dt);
                datagrid.ItemsSource = dt.DefaultView;
                dataadp.Update(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlcon.Close();
            }
        }
    }
}
