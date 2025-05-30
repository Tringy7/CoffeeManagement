namespace MangageCoffee.UICoffee.Customer
{
    partial class Customer1
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
            this.components = new System.ComponentModel.Container();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.menu_add1 = new MangageCoffee.UICoffee.Menu.Menu_add();
            this.deleteOderHistory = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 50;
            this.guna2Elipse1.TargetControl = this;
            // 
            // menu_add1
            // 
            this.menu_add1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.menu_add1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.menu_add1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menu_add1.Location = new System.Drawing.Point(0, 0);
            this.menu_add1.Name = "menu_add1";
            this.menu_add1.Size = new System.Drawing.Size(1381, 892);
            this.menu_add1.TabIndex = 0;
            this.menu_add1.Load += new System.EventHandler(this.menu_add1_Load);
            // 
            // deleteOderHistory
            // 
            this.deleteOderHistory.BackColor = System.Drawing.Color.Transparent;
            this.deleteOderHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteOderHistory.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.deleteOderHistory.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.deleteOderHistory.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.deleteOderHistory.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.deleteOderHistory.FillColor = System.Drawing.Color.Transparent;
            this.deleteOderHistory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.deleteOderHistory.ForeColor = System.Drawing.Color.Transparent;
            this.deleteOderHistory.Image = global::MangageCoffee.Properties.Resources.close;
            this.deleteOderHistory.ImageSize = new System.Drawing.Size(24, 24);
            this.deleteOderHistory.Location = new System.Drawing.Point(1318, 12);
            this.deleteOderHistory.Name = "deleteOderHistory";
            this.deleteOderHistory.Size = new System.Drawing.Size(29, 27);
            this.deleteOderHistory.TabIndex = 116;
            this.deleteOderHistory.Click += new System.EventHandler(this.deleteOderHistory_Click);
            // 
            // Customer1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1381, 892);
            this.Controls.Add(this.deleteOderHistory);
            this.Controls.Add(this.menu_add1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Customer1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Menu.Menu_add menu_add1;
        private Guna.UI2.WinForms.Guna2Button deleteOderHistory;
    }
}