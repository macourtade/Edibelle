namespace Edibelle
{
    partial class InventoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.msMaintain = new System.Windows.Forms.MenuStrip();
            this.maintainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDepartments = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEmployees = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLocations = new System.Windows.Forms.ToolStripMenuItem();
            this.msMaintain.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMaintain
            // 
            this.msMaintain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.msMaintain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maintainToolStripMenuItem});
            this.msMaintain.Location = new System.Drawing.Point(0, 530);
            this.msMaintain.Name = "msMaintain";
            this.msMaintain.Size = new System.Drawing.Size(606, 24);
            this.msMaintain.TabIndex = 0;
            this.msMaintain.Text = "menuStrip1";
            // 
            // maintainToolStripMenuItem
            // 
            this.maintainToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDepartments,
            this.tsmEmployees,
            this.tsmLocations});
            this.maintainToolStripMenuItem.Name = "maintainToolStripMenuItem";
            this.maintainToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.maintainToolStripMenuItem.Text = "Maintain";
            // 
            // tsmDepartments
            // 
            this.tsmDepartments.Name = "tsmDepartments";
            this.tsmDepartments.Size = new System.Drawing.Size(142, 22);
            this.tsmDepartments.Text = "Departments";
            this.tsmDepartments.Click += new System.EventHandler(this.tsmDepartments_Click);
            // 
            // tsmEmployees
            // 
            this.tsmEmployees.Name = "tsmEmployees";
            this.tsmEmployees.Size = new System.Drawing.Size(142, 22);
            this.tsmEmployees.Text = "Employees";
            this.tsmEmployees.Click += new System.EventHandler(this.tsmEmployees_Click);
            // 
            // tsmLocations
            // 
            this.tsmLocations.Name = "tsmLocations";
            this.tsmLocations.Size = new System.Drawing.Size(142, 22);
            this.tsmLocations.Text = "Locations";
            this.tsmLocations.Click += new System.EventHandler(this.tsmLocations_Click);
            // 
            // InventoryForm
            // 
            this.ClientSize = new System.Drawing.Size(606, 554);
            this.Controls.Add(this.msMaintain);
            this.MainMenuStrip = this.msMaintain;
            this.Name = "InventoryForm";
            this.Text = "Inventory";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InventoryForm_FormClosing);
            this.Load += new System.EventHandler(this.InventoryForm_Load);
            this.msMaintain.ResumeLayout(false);
            this.msMaintain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.MenuStrip msMaintain;
        private System.Windows.Forms.ToolStripMenuItem maintainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmDepartments;
        private System.Windows.Forms.ToolStripMenuItem tsmEmployees;
        private System.Windows.Forms.ToolStripMenuItem tsmLocations;
    }
}

