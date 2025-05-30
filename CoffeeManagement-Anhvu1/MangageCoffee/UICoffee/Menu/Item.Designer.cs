namespace MangageCoffee.UICoffee.Menu
{
    partial class Item
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
            this.components = new System.ComponentModel.Container();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.btnHome = new Guna.UI2.WinForms.Guna2Button();
            this.ptbImage = new Guna.UI2.WinForms.Guna2PictureBox();
            this.Item_cost = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.name_Item = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.numeric = new Guna.UI2.WinForms.Guna2NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImage)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 10;
            this.guna2Elipse1.TargetControl = this;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHome.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHome.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHome.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHome.FillColor = System.Drawing.Color.Transparent;
            this.btnHome.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Image = global::MangageCoffee.Properties.Resources.item_icon;
            this.btnHome.ImageSize = new System.Drawing.Size(30, 30);
            this.btnHome.Location = new System.Drawing.Point(202, 222);
            this.btnHome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(56, 51);
            this.btnHome.TabIndex = 87;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // ptbImage
            // 
            this.ptbImage.BackColor = System.Drawing.Color.Transparent;
            this.ptbImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.ptbImage.FillColor = System.Drawing.Color.LightGray;
            this.ptbImage.ImageRotate = 0F;
            this.ptbImage.Location = new System.Drawing.Point(0, 0);
            this.ptbImage.Margin = new System.Windows.Forms.Padding(3, 38, 3, 38);
            this.ptbImage.Name = "ptbImage";
            this.ptbImage.Size = new System.Drawing.Size(272, 214);
            this.ptbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbImage.TabIndex = 84;
            this.ptbImage.TabStop = false;
            this.ptbImage.Click += new System.EventHandler(this.guna2PictureBox1_Click);
            // 
            // Item_cost
            // 
            this.Item_cost.AutoSize = true;
            this.Item_cost.BackColor = System.Drawing.Color.Transparent;
            this.Item_cost.Dock = System.Windows.Forms.DockStyle.Left;
            this.Item_cost.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Item_cost.ForeColor = System.Drawing.Color.Red;
            this.Item_cost.Location = new System.Drawing.Point(0, 0);
            this.Item_cost.Name = "Item_cost";
            this.Item_cost.Size = new System.Drawing.Size(55, 30);
            this.Item_cost.TabIndex = 78;
            this.Item_cost.Text = "10 $";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.Item_cost);
            this.guna2Panel2.Location = new System.Drawing.Point(14, 266);
            this.guna2Panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(172, 35);
            this.guna2Panel2.TabIndex = 89;
            // 
            // name_Item
            // 
            this.name_Item.AutoSize = true;
            this.name_Item.BackColor = System.Drawing.Color.White;
            this.name_Item.Dock = System.Windows.Forms.DockStyle.Left;
            this.name_Item.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_Item.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.name_Item.Location = new System.Drawing.Point(0, 0);
            this.name_Item.Name = "name_Item";
            this.name_Item.Size = new System.Drawing.Size(79, 30);
            this.name_Item.TabIndex = 77;
            this.name_Item.Text = "Burger";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.name_Item);
            this.guna2Panel1.Location = new System.Drawing.Point(14, 231);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(172, 35);
            this.guna2Panel1.TabIndex = 88;
            // 
            // numeric
            // 
            this.numeric.BackColor = System.Drawing.Color.Transparent;
            this.numeric.BorderColor = System.Drawing.Color.White;
            this.numeric.BorderRadius = 15;
            this.numeric.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numeric.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.numeric.Location = new System.Drawing.Point(193, 266);
            this.numeric.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric.Name = "numeric";
            this.numeric.Size = new System.Drawing.Size(75, 40);
            this.numeric.TabIndex = 90;
            this.numeric.UpDownButtonFillColor = System.Drawing.Color.Black;
            this.numeric.UpDownButtonForeColor = System.Drawing.Color.White;
            this.numeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.numeric);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.ptbImage);
            this.Controls.Add(this.btnHome);
            this.Margin = new System.Windows.Forms.Padding(34, 21, 34, 21);
            this.Name = "Item";
            this.Size = new System.Drawing.Size(272, 311);
            ((System.ComponentModel.ISupportInitialize)(this.ptbImage)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label name_Item;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label Item_cost;
        private Guna.UI2.WinForms.Guna2PictureBox ptbImage;
        private Guna.UI2.WinForms.Guna2Button btnHome;
        private Guna.UI2.WinForms.Guna2NumericUpDown numeric;
    }
}
