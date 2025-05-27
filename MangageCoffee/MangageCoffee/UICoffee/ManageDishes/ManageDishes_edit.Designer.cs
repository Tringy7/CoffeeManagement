namespace MangageCoffee.UICoffee.ManageDishes
{
    partial class ManageDishes_edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageDishes_edit));
            this.exit = new Guna.UI2.WinForms.Guna2Button();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.ptbImage = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.TxtQuantity = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Txtcost = new Guna.UI2.WinForms.Guna2TextBox();
            this.TxtType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.save = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Txtname = new Guna.UI2.WinForms.Guna2TextBox();
            this.TxtId = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // exit
            // 
            this.exit.BorderRadius = 20;
            this.exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.exit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.exit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.exit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.exit.FillColor = System.Drawing.Color.Red;
            this.exit.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.ForeColor = System.Drawing.Color.White;
            this.exit.Location = new System.Drawing.Point(272, 636);
            this.exit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(208, 54);
            this.exit.TabIndex = 127;
            this.exit.Text = "Exit";
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdd.FillColor = System.Drawing.Color.Transparent;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAdd.ForeColor = System.Drawing.Color.Transparent;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageSize = new System.Drawing.Size(27, 27);
            this.btnAdd.Location = new System.Drawing.Point(422, 168);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(33, 34);
            this.btnAdd.TabIndex = 126;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ptbImage
            // 
            this.ptbImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ptbImage.BackColor = System.Drawing.Color.Transparent;
            this.ptbImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbImage.FillColor = System.Drawing.Color.LightGray;
            this.ptbImage.ImageRotate = 0F;
            this.ptbImage.Location = new System.Drawing.Point(280, 36);
            this.ptbImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ptbImage.Name = "ptbImage";
            this.ptbImage.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.ptbImage.Size = new System.Drawing.Size(159, 165);
            this.ptbImage.TabIndex = 125;
            this.ptbImage.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(362, 495);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 32);
            this.label3.TabIndex = 124;
            this.label3.Text = "Quantity";
            // 
            // TxtStatus
            // 
            this.TxtStatus.BackColor = System.Drawing.Color.Transparent;
            this.TxtStatus.BorderColor = System.Drawing.Color.Black;
            this.TxtStatus.BorderRadius = 15;
            this.TxtStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.TxtStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TxtStatus.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtStatus.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.TxtStatus.ForeColor = System.Drawing.Color.Black;
            this.TxtStatus.ItemHeight = 30;
            this.TxtStatus.Items.AddRange(new object[] {
            "True ",
            "False"});
            this.TxtStatus.Location = new System.Drawing.Point(71, 546);
            this.TxtStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtStatus.Name = "TxtStatus";
            this.TxtStatus.Size = new System.Drawing.Size(257, 36);
            this.TxtStatus.TabIndex = 123;
            // 
            // TxtQuantity
            // 
            this.TxtQuantity.BorderColor = System.Drawing.Color.Black;
            this.TxtQuantity.BorderRadius = 15;
            this.TxtQuantity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtQuantity.DefaultText = "";
            this.TxtQuantity.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtQuantity.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtQuantity.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtQuantity.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtQuantity.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtQuantity.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtQuantity.ForeColor = System.Drawing.Color.Black;
            this.TxtQuantity.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtQuantity.Location = new System.Drawing.Point(368, 536);
            this.TxtQuantity.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.TxtQuantity.Name = "TxtQuantity";
            this.TxtQuantity.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.TxtQuantity.PlaceholderText = "3";
            this.TxtQuantity.SelectedText = "";
            this.TxtQuantity.Size = new System.Drawing.Size(327, 54);
            this.TxtQuantity.TabIndex = 122;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 495);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 32);
            this.label2.TabIndex = 121;
            this.label2.Text = "Status";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(362, 351);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 32);
            this.label8.TabIndex = 120;
            this.label8.Text = "Cost (Vnd)";
            // 
            // Txtcost
            // 
            this.Txtcost.BorderColor = System.Drawing.Color.Black;
            this.Txtcost.BorderRadius = 15;
            this.Txtcost.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Txtcost.DefaultText = "";
            this.Txtcost.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Txtcost.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Txtcost.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Txtcost.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Txtcost.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Txtcost.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtcost.ForeColor = System.Drawing.Color.Black;
            this.Txtcost.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Txtcost.Location = new System.Drawing.Point(368, 392);
            this.Txtcost.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Txtcost.Name = "Txtcost";
            this.Txtcost.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.Txtcost.PlaceholderText = "10000";
            this.Txtcost.SelectedText = "";
            this.Txtcost.Size = new System.Drawing.Size(327, 54);
            this.Txtcost.TabIndex = 119;
            // 
            // TxtType
            // 
            this.TxtType.BackColor = System.Drawing.Color.Transparent;
            this.TxtType.BorderColor = System.Drawing.Color.Black;
            this.TxtType.BorderRadius = 15;
            this.TxtType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.TxtType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TxtType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtType.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.TxtType.ForeColor = System.Drawing.Color.Black;
            this.TxtType.ItemHeight = 30;
            this.TxtType.Items.AddRange(new object[] {
            "FastFood",
            "Bakery",
            "Hot Drink",
            "Cold Drink"});
            this.TxtType.Location = new System.Drawing.Point(71, 401);
            this.TxtType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtType.Name = "TxtType";
            this.TxtType.Size = new System.Drawing.Size(257, 36);
            this.TxtType.TabIndex = 118;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(65, 351);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 32);
            this.label7.TabIndex = 117;
            this.label7.Text = "Type";
            // 
            // save
            // 
            this.save.BorderRadius = 20;
            this.save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.save.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.save.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.save.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.save.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.save.FillColor = System.Drawing.Color.Teal;
            this.save.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save.ForeColor = System.Drawing.Color.White;
            this.save.Location = new System.Drawing.Point(487, 636);
            this.save.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(208, 54);
            this.save.TabIndex = 116;
            this.save.Text = "Save Changes";
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(362, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 32);
            this.label1.TabIndex = 115;
            this.label1.Text = "Name Product";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(65, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 32);
            this.label5.TabIndex = 114;
            this.label5.Text = "Original price";
            // 
            // Txtname
            // 
            this.Txtname.BorderColor = System.Drawing.Color.Black;
            this.Txtname.BorderRadius = 15;
            this.Txtname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Txtname.DefaultText = "";
            this.Txtname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Txtname.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Txtname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Txtname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Txtname.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Txtname.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtname.ForeColor = System.Drawing.Color.Black;
            this.Txtname.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Txtname.Location = new System.Drawing.Point(368, 268);
            this.Txtname.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Txtname.Name = "Txtname";
            this.Txtname.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.Txtname.PlaceholderText = "Burger";
            this.Txtname.SelectedText = "";
            this.Txtname.Size = new System.Drawing.Size(327, 54);
            this.Txtname.TabIndex = 113;
            // 
            // TxtId
            // 
            this.TxtId.BorderColor = System.Drawing.Color.Black;
            this.TxtId.BorderRadius = 15;
            this.TxtId.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtId.DefaultText = "";
            this.TxtId.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtId.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtId.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtId.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtId.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtId.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtId.ForeColor = System.Drawing.Color.Black;
            this.TxtId.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtId.Location = new System.Drawing.Point(71, 268);
            this.TxtId.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.TxtId.Name = "TxtId";
            this.TxtId.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.TxtId.PlaceholderText = "10000";
            this.TxtId.SelectedText = "";
            this.TxtId.Size = new System.Drawing.Size(258, 54);
            this.TxtId.TabIndex = 112;
            // 
            // ManageDishes_edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(760, 725);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.ptbImage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtStatus);
            this.Controls.Add(this.TxtQuantity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Txtcost);
            this.Controls.Add(this.TxtType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.save);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Txtname);
            this.Controls.Add(this.TxtId);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ManageDishes_edit";
            this.Text = "ManageDishes_edit";
            this.Load += new System.EventHandler(this.ManageDishes_edit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button exit;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2CirclePictureBox ptbImage;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox TxtStatus;
        private Guna.UI2.WinForms.Guna2TextBox TxtQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2TextBox Txtcost;
        private Guna.UI2.WinForms.Guna2ComboBox TxtType;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2Button save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox Txtname;
        private Guna.UI2.WinForms.Guna2TextBox TxtId;
    }
}