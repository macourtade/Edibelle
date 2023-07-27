namespace Edibelle
{
    partial class InventoryTest
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
            this.printInventory = new System.Drawing.Printing.PrintDocument();
            this.SuspendLayout();
            // 
            // msMaintain
            // 
            this.msMaintain.Location = new System.Drawing.Point(0, 0);
            this.msMaintain.Name = "msMaintain";
            this.msMaintain.Size = new System.Drawing.Size(800, 24);
            this.msMaintain.TabIndex = 0;
            this.msMaintain.Text = "menuStrip1";
            // 
            // printInventory
            // 
            this.printInventory.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printInventory_PrintPage);
            // 
            // InventoryTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.msMaintain);
            this.MainMenuStrip = this.msMaintain;
            this.Name = "InventoryTest";
            this.Text = "InventoryTest";
            this.Load += new System.EventHandler(this.InventoryTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMaintain;
        private System.Drawing.Printing.PrintDocument printInventory;
    }
}