namespace MangageCoffee.UICoffee.Untils
{
    partial class Bill_item
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
            this.guna2GradientPanel2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTotal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblQuantity = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblUnitprice = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2GradientPanel2.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2GradientPanel2
            // 
            this.guna2GradientPanel2.BorderColor = System.Drawing.Color.Black;
            this.guna2GradientPanel2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.guna2GradientPanel2.BorderThickness = 1;
            this.guna2GradientPanel2.Controls.Add(this.guna2Panel1);
            this.guna2GradientPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GradientPanel2.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2GradientPanel2.Name = "guna2GradientPanel2";
            this.guna2GradientPanel2.Size = new System.Drawing.Size(835, 56);
            this.guna2GradientPanel2.TabIndex = 1;
            this.guna2GradientPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2GradientPanel2_Paint);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.lblTotal);
            this.guna2Panel1.Controls.Add(this.lblQuantity);
            this.guna2Panel1.Controls.Add(this.lblUnitprice);
            this.guna2Panel1.Controls.Add(this.lblName);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 15);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(835, 25);
            this.guna2Panel1.TabIndex = 16;
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(711, 0);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(124, 25);
            this.lblTotal.TabIndex = 19;
            this.lblTotal.Text = "20000000000";
            // 
            // lblQuantity
            // 
            this.lblQuantity.BackColor = System.Drawing.Color.Transparent;
            this.lblQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(587, 0);
            this.lblQuantity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(14, 24);
            this.lblQuantity.TabIndex = 18;
            this.lblQuantity.Text = "3";
            // 
            // lblUnitprice
            // 
            this.lblUnitprice.BackColor = System.Drawing.Color.Transparent;
            this.lblUnitprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitprice.Location = new System.Drawing.Point(371, 0);
            this.lblUnitprice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblUnitprice.Name = "lblUnitprice";
            this.lblUnitprice.Size = new System.Drawing.Size(156, 24);
            this.lblUnitprice.TabIndex = 17;
            this.lblUnitprice.Text = "20000000000vnd";
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(64, 25);
            this.lblName.TabIndex = 16;
            this.lblName.Text = "Vu cac";
            // 
            // Bill_item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2GradientPanel2);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Bill_item";
            this.Size = new System.Drawing.Size(835, 55);
            this.guna2GradientPanel2.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotal;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblQuantity;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblUnitprice;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblName;
    }
}
