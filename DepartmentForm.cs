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
using static System.Net.Mime.MediaTypeNames;

namespace Edibelle
{
    public partial class DepartmentForm : Form
    { 

    private DataGridView dataGridView1 = new DataGridView();
    private BindingSource bindingSource1 = new BindingSource();
    private SqlDataAdapter dataAdapter = new SqlDataAdapter();
    private Button reloadButton = new Button();
    private Button submitButton = new Button();
        
    
        public DepartmentForm()
        {
            InitializeComponent();

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
        Load += new EventHandler(Form1_Load);
        Text = "Departments";

        }

    // MY Connection String
    /*
     * Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\Edibelle\DB\edibelle.mdf;Integrated Security = True; Connect Timeout = 30
    */

    private void Form1_Load(object sender, EventArgs e)
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
        catch (SqlException)
        {
            MessageBox.Show("To run this example, replace the value of the " +
                "connectionString variable with a connection string that is " +
                "valid for your system.");
        }
    }

        private void DepartmentForm_Load(object sender, EventArgs e)
        {

        }
    }
}

