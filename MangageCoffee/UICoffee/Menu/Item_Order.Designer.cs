namespace MangageCoffee.UICoffee.Menu
{
    partial class Item_Order
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.name_item = new System.Windows.Forms.Label();
            this.SoLuong = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.price = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.name_item);
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(112, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(99, 28);
            this.panel1.TabIndex = 82;
            // 
            // name_item
            // 
            this.name_item.AutoSize = true;
            this.name_item.BackColor = System.Drawing.Color.White;
            this.name_item.Dock = System.Windows.Forms.DockStyle.Left;
            this.name_item.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_item.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.name_item.Location = new System.Drawing.Point(0, 0);
            this.name_item.Name = "name_item";
            this.name_item.Size = new System.Drawing.Size(57, 20);
            this.name_item.TabIndex = 78;
            this.name_item.Text = "Burger";
            this.name_item.Click += new System.EventHandler(this.name_item_Click);
            // 
            // SoLuong
            // 
            this.SoLuong.AutoSize = true;
            this.SoLuong.BackColor = System.Drawing.Color.White;
            this.SoLuong.Dock = System.Windows.Forms.DockStyle.Left;
            this.SoLuong.Font = new System.Drawing.Font("Segoe UI", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SoLuong.ForeColor = System.Drawing.Color.Black;
            this.SoLuong.Location = new System.Drawing.Point(0, 0);
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.Size = new System.Drawing.Size(19, 15);
            this.SoLuong.TabIndex = 78;
            this.SoLuong.Text = "x1";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.price);
            this.panel3.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(217, 22);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(86, 37);
            this.panel3.TabIndex = 84;
            // 
            // price
            // 
            this.price.AutoSize = true;
            this.price.BackColor = System.Drawing.Color.Transparent;
            this.price.Dock = System.Windows.Forms.DockStyle.Right;
            this.price.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price.ForeColor = System.Drawing.Color.Red;
            this.price.Location = new System.Drawing.Point(41, 0);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(45, 23);
            this.price.TabIndex = 79;
            this.price.Text = "10 $";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.SoLuong);
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(112, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(57, 28);
            this.panel2.TabIndex = 83;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDelete.FillColor = System.Drawing.Color.Transparent;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Image = global::MangageCoffee.Properties.Resources.minus;
            this.btnDelete.Location = new System.Drawing.Point(261, 56);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(42, 28);
            this.btnDelete.TabIndex = 85;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.BorderRadius = 10;
            this.guna2PictureBox1.FillColor = System.Drawing.Color.LightGray;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(17, 13);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(89, 76);
            this.guna2PictureBox1.TabIndex = 81;
            this.guna2PictureBox1.TabStop = false;
            // 
            // Item_Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.guna2PictureBox1);
            this.Name = "Item_Order";
            this.Size = new System.Drawing.Size(320, 103);
            this.Load += new System.EventHandler(this.Item_Order_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label name_item;
        private System.Windows.Forms.Label SoLuong;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label price;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}
