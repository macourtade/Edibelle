using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
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
        private Button printButton = new Button();

        public InventoryForm(DataTable CurrentUser)
        {
            //syncing inventory form & datagrid with buttons & event handlers
            InitializeComponent();

            cUser = CurrentUser;

            dataGridView1.Dock = DockStyle.Top;
            dataGridView1.Height = 1000;
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
            
            Text = "Inventory";
        }


        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Sorry, there is an issue with the data you are trying to save.  Please check the formatting");
            //e.Cancel = true;

        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            //loading inventory form
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
                GetData("select PLU, [Name], Decription, Organic,[Out of Stock], Inventory.Loc_ID, Location.Loc_Name  from Inventory LEFT JOIN Location ON Inventory.Loc_ID = Location.Loc_ID");
                
                
                //dataGridView1.Columns["Loc_ID"].Visible = false;
                //dataGridView1.Columns["Loc_Name"].Visible = false;
                //AddComboboxColumn();
            }
            catch (Exception ex) //when error occurs, show in message box
            {
                MessageBox.Show(ex.Message);
            }




        }

        private void ReloadButton_Click(object sender, EventArgs e)
        {
            //reload button, reset any newly added data and adds it to database
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
            //if exception is caught, should display in message box
            catch (Exception ex)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
        }

        private void AddComboboxColumn()
        {
            DataGridViewComboBoxColumn ColComboBox = new DataGridViewComboBoxColumn();
            dataGridView1.Columns.Add(ColComboBox);
            
            ColComboBox.HeaderText = "Location";
            ColComboBox.ValueType = typeof(string);
            ColComboBox.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
            ColComboBox.DisplayIndex = 5;
            ColComboBox.Width = 150;
            ColComboBox.DataSource = bindingSource1;
            ColComboBox.DisplayMember = "Loc_Name";
            ColComboBox.ValueMember = "Loc_ID";
            ColComboBox.Name = "Loc_ID";
            ColComboBox.DataPropertyName = "Loc_ID";
        }

    private void InventoryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //closing inventory form

        }

        private void tsmDepartments_Click(object sender, EventArgs e)
        {
            //when department is pressed from maintain drop down, should show up
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

        private void PrintButton_Click(object sender, EventArgs e)
        {
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



            //exporting iventory form to csv file
            using (StreamWriter sw = new StreamWriter("All_Inventory.csv")) //make a streamwriter
            {
                sw.WriteLine(s); //write this one big ass strign to the file 
                sw.Flush();
            }
        }
    }
}
