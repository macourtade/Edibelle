using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Edibelle
{
    public partial class InventoryForm : Form
    {
        private DataTable cUser;
        private DataGridView dataGridView1 = new DataGridView();
        private BindingSource bindingSource1 = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private Button reloadButton = new Button();
        private Button submitButton = new Button();

        public InventoryForm(DataTable CurrentUser)
        {
            InitializeComponent();
            
            cUser = CurrentUser;
            
            dataGridView1.Dock = DockStyle.Fill;
            reloadButton.Text = "Reload";
            submitButton.Text = "Submit";
            reloadButton.Click += new EventHandler(ReloadButton_Click);
            submitButton.Click += new EventHandler(SubmitButton_Click);

            FlowLayoutPanel panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true
            };
            panel.Controls.AddRange(new Control[] { reloadButton, submitButton });

            Controls.AddRange(new Control[] { dataGridView1, panel });
            Load += new EventHandler(InventoryForm_Load);
            Text = "Inventory";
        }


        // MY Connection String
        /*
         * Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\Edibelle\DB\edibelle.mdf;Integrated Security = True; Connect Timeout = 30
        */

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            try
            {
                
                foreach (DataRow dr in cUser.Rows)
                {
                    if (dr["isAdmin"].Equals(false))
                    {
                        msMaintain.Enabled = false;
                    }
                    else
                    {
                        msMaintain.Enabled = true;
                        
                    }
                    
                }
                // Bind the DataGridView to the BindingSource
                // and load the data from the database.
                dataGridView1.DataSource = bindingSource1;
                GetData("select * from Inventory");

            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
           

           
        }

        private void ReloadButton_Click(object sender, EventArgs e)
        {
            // Reload the data from the database.
            GetData(dataAdapter.SelectCommand.CommandText);
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            // Update the database with changes.
            dataAdapter.Update((DataTable)bindingSource1.DataSource);
        }

        private void GetData(string selectCommand)
        {
            try
            {
                // Specify a connection string.
                // Replace <SQL Server> with the SQL Server for your Northwind sample database.
                // Replace "Integrated Security=True" with user login information if necessary.
                String connectionString =
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\Edibelle\DB\edibelle.mdf;Integrated Security=True;Connect Timeout=30";

                // Create a new data adapter based on the specified query.
                dataAdapter = new SqlDataAdapter(selectCommand, connectionString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand.
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable
                {
                    Locale = CultureInfo.InvariantCulture
                };
                dataAdapter.Fill(table);
                bindingSource1.DataSource = table;

                // Resize the DataGridView columns to fit the newly loaded content.
                dataGridView1.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
        }


        private void InventoryForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            
        }

        private void tsmDepartments_Click(object sender, EventArgs e)
        {
            DepartmentForm deptFrm = new DepartmentForm();
            deptFrm.ShowDialog();

            //should we refresh inventory grid if we close one of the  maintain forms
            reloadButton.PerformClick();
        }

        private void tsmEmployees_Click(object sender, EventArgs e)
        {
            EmployeeForm empFrm = new EmployeeForm();
            empFrm.ShowDialog();

            //should we refresh inventory grid if we close one of the  maintain forms
            reloadButton.PerformClick();
        }

        private void tsmLocations_Click(object sender, EventArgs e)
        {
            LocationForm locFrm = new LocationForm();
            locFrm.ShowDialog();

            //should we refresh inventory grid if we close one of the  maintain forms
            reloadButton.PerformClick();
        }
    }
}
