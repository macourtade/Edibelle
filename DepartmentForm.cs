using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Edibelle
{

    //forming department form + attributes
    public partial class DepartmentForm : Form
    {

        private DataGridView dataGridView1 = new DataGridView();
        private BindingSource bindingSource1 = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private Button reloadButton = new Button();
        private Button submitButton = new Button();
        private Button printButton = new Button();

        public DepartmentForm()

        //syncing ddepartment form & datagrid with buttons & event handlers
        {
            try
            {
                InitializeComponent();


                dataGridView1.Dock = DockStyle.Fill;


                reloadButton.Text = "Reload";
                submitButton.Text = "Submit";
                printButton.Text = "Print";
                reloadButton.Click += new EventHandler(ReloadButton_Click);
                submitButton.Click += new EventHandler(SubmitButton_Click);
                printButton.Click += new EventHandler(PrintButton_Click);


                FlowLayoutPanel panel = new FlowLayoutPanel
                {
                    Dock = DockStyle.Top,
                    AutoSize = true
                };


                panel.Controls.AddRange(new Control[] { reloadButton, submitButton, printButton });

                Controls.AddRange(new Control[] { dataGridView1, panel });
                Load += new EventHandler(DepartmentForm_Load);
                Text = "Departments";
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        // MY Connection String
        /*
         * Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\Edibelle\DB\edibelle.mdf;Integrated Security = True; Connect Timeout = 30
        */
        private void DepartmentForm_Load(object sender, EventArgs e)
        {
            // Bind the DataGridView to the BindingSource
            // and load the data from the database.
            dataGridView1.DataSource = bindingSource1;
            GetData("select * from Department");

        }
        private void ReloadButton_Click(object sender, EventArgs e)
        {
            // Reload the data from the database.
            GetData(dataAdapter.SelectCommand.CommandText);
        }

        private void SubmitButton_Click(object sender, EventArgs e)

        {
            // Update the database with changes.
            try
            {

                dataAdapter.Update((DataTable)bindingSource1.DataSource);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Sorry you entered the wrong thing \n\n" + ex.Message);


            }
        }


        private void PrintButton_Click(object sender, EventArgs e)
        {
            // printInventory.Print();


            string s = "";

            //TODO: here is accessing row by col  

            for (int i = 0; i < dataGridView1.Rows.Count; i++) //for each row index in the data grid view 
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++) //for each col index in the data grid view 
                {
                    s += dataGridView1[j, i].Value; //acess the col and row index then select the value 
                    if (j < dataGridView1.Rows.Count - 1) //if this is not the last col
                    {
                        s += ",";  //add a comma before the next value 
                    }
                }
                s += "\n"; //at the end of processing one row, add a newline char 
            }

            MessageBox.Show(s); //visually verify 

            //string s needs to be printed to a file --<> will result in a "csv" file that excel should be able to open 


            using (StreamWriter sw = new StreamWriter("All_Inventory.csv")) //make a streamwriter
            {
                sw.WriteLine(s); //write this one big ass strign to the file 
                sw.Flush();
            }

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
            catch (SqlException)

            //if an exception occurs, message box should show error
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }


        }

    }

}
