using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;
using System.Globalization;

namespace Edibelle
{
    public partial class Login : Form
    {


        SqlDataAdapter dataAdapter;        

        public Login()
        {
            InitializeComponent();
        }

        

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Specify a connection string.
                // Replace <SQL Server> with the SQL Server for your Northwind sample database.
                // Replace "Integrated Security=True" with user login information if necessary.
                String connectionString =
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\Edibelle\DB\edibelle.mdf;Integrated Security=True;Connect Timeout=30";

                String getUserCommand = "SELECT * FROM EMPLOYEE WHERE Emp_ID='" + txtUsername.Text + "' AND password='" + txtPassword.Text + "' AND isActive=1";
                // Create a new data adapter based on the specified query.
                dataAdapter = new SqlDataAdapter(getUserCommand, connectionString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand.
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.asdfasfa
                DataTable table = new DataTable
                {
                    Locale = CultureInfo.InvariantCulture
                };
                dataAdapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    //they are logged in
                    //we need to save the user to a variable so they can check later

                    
                    InventoryForm inventoryForm = new InventoryForm();
                    this.Hide();
                    inventoryForm.ShowDialog();
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    this.Show();

                    
                }
                else
                {
                    //there is a problem 
                    //redirect back to the login for retry
                    MessageBox.Show("");
                }
            }
            catch (Exception ex) { 
                MessageBox.Show(ex.Message);
            }



        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
