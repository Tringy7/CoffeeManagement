namespace MangageCoffee.UICoffee.History
{
    partial class History_add
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
            this.label4 = new System.Windows.Forms.Label();
            this.btnInvoice = new Guna.UI2.WinForms.Guna2Button();
            this.btnHistory = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanelHistory = new System.Windows.Forms.FlowLayoutPanel();
            this.history_order1 = new MangageCoffee.UICoffee.History.History_order();
            this.history_historyform2 = new MangageCoffee.UICoffee.History.History_historyform();
            this.history_historyform3 = new MangageCoffee.UICoffee.History.History_historyform();
            this.history_historyform1 = new MangageCoffee.UICoffee.History.History_historyform();
            this.text_search = new Guna.UI2.WinForms.Guna2TextBox();
            this.panel1.SuspendLayout();
            this.flowLayoutPanelHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 50;
            this.guna2Elipse1.TargetControl = this;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(43, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 54);
            this.label4.TabIndex = 98;
            this.label4.Text = "Customer";
            // 
            // btnInvoice
            // 
            this.btnInvoice.BorderRadius = 10;
            this.btnInvoice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInvoice.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnInvoice.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnInvoice.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnInvoice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnInvoice.FillColor = System.Drawing.Color.Teal;
            this.btnInvoice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvoice.ForeColor = System.Drawing.Color.White;
            this.btnInvoice.Location = new System.Drawing.Point(51, 109);
            this.btnInvoice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(181, 52);
            this.btnInvoice.TabIndex = 100;
            this.btnInvoice.Text = "Invoice";
            this.btnInvoice.Click += new System.EventHandler(this.guna2Button6_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.BorderRadius = 10;
            this.btnHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistory.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHistory.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHistory.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHistory.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHistory.FillColor = System.Drawing.Color.Teal;
            this.btnHistory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistory.ForeColor = System.Drawing.Color.White;
            this.btnHistory.Location = new System.Drawing.Point(251, 109);
            this.btnHistory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(181, 52);
            this.btnHistory.TabIndex = 101;
            this.btnHistory.Text = "History";
            this.btnHistory.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanelHistory);
            this.panel1.Controls.Add(this.history_historyform1);
            this.panel1.Location = new System.Drawing.Point(51, 180);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1447, 891);
            this.panel1.TabIndex = 102;
            // 
            // flowLayoutPanelHistory
            // 
            this.flowLayoutPanelHistory.AutoScroll = true;
            this.flowLayoutPanelHistory.Controls.Add(this.history_order1);
            this.flowLayoutPanelHistory.Controls.Add(this.history_historyform2);
            this.flowLayoutPanelHistory.Controls.Add(this.history_historyform3);
            this.flowLayoutPanelHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelHistory.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelHistory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanelHistory.Name = "flowLayoutPanelHistory";
            this.flowLayoutPanelHistory.Size = new System.Drawing.Size(1447, 891);
            this.flowLayoutPanelHistory.TabIndex = 2;
            this.flowLayoutPanelHistory.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelHistory_Paint);
            // 
            // history_order1
            // 
            this.history_order1.BackColor = System.Drawing.Color.White;
            this.history_order1.Location = new System.Drawing.Point(11, 12);
            this.history_order1.Margin = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.history_order1.Name = "history_order1";
            this.history_order1.Size = new System.Drawing.Size(459, 519);
            this.history_order1.TabIndex = 0;
            // 
            // history_historyform2
            // 
            this.history_historyform2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(235)))), ((int)(((byte)(229)))));
            this.history_historyform2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.history_historyform2.Location = new System.Drawing.Point(3, 548);
            this.history_historyform2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.history_historyform2.Name = "history_historyform2";
            this.history_historyform2.Size = new System.Drawing.Size(1447, 0);
            this.history_historyform2.TabIndex = 9;
            // 
            // history_historyform3
            // 
            this.history_historyform3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(235)))), ((int)(((byte)(229)))));
            this.history_historyform3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.history_historyform3.Location = new System.Drawing.Point(3, 558);
            this.history_historyform3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.history_historyform3.Name = "history_historyform3";
            this.history_historyform3.Size = new System.Drawing.Size(1447, 0);
            this.history_historyform3.TabIndex = 10;
            // 
            // history_historyform1
            // 
            this.history_historyform1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(235)))), ((int)(((byte)(229)))));
            this.history_historyform1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.history_historyform1.Location = new System.Drawing.Point(0, 0);
            this.history_historyform1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.history_historyform1.Name = "history_historyform1";
            this.history_historyform1.Size = new System.Drawing.Size(1447, 891);
            this.history_historyform1.TabIndex = 0;
            // 
            // text_search
            // 
            this.text_search.BorderColor = System.Drawing.Color.Black;
            this.text_search.BorderRadius = 10;
            this.text_search.BorderThickness = 2;
            this.text_search.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.text_search.DefaultText = "";
            this.text_search.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.text_search.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.text_search.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.text_search.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.text_search.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.text_search.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_search.ForeColor = System.Drawing.Color.Black;
            this.text_search.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.text_search.IconLeft = global::MangageCoffee.Properties.Resources.search_interface_symbol;
            this.text_search.Location = new System.Drawing.Point(943, 114);
            this.text_search.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.text_search.Name = "text_search";
            this.text_search.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.text_search.PlaceholderText = "Search";
            this.text_search.SelectedText = "";
            this.text_search.Size = new System.Drawing.Size(555, 48);
            this.text_search.TabIndex = 99;
            this.text_search.TextChanged += new System.EventHandler(this.text_search_TextChanged);
            // 
            // History_add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.btnInvoice);
            this.Controls.Add(this.text_search);
            this.Controls.Add(this.label4);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "History_add";
            this.Size = new System.Drawing.Size(1554, 1115);
            this.Load += new System.EventHandler(this.History_add_Load);
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanelHistory.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2TextBox text_search;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Button btnInvoice;
        private Guna.UI2.WinForms.Guna2Button btnHistory;
        private System.Windows.Forms.Panel panel1;
        private History_historyform history_historyform1;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanelHistory;
        private History_order history_order1;
        private History_historyform history_historyform2;
        private History_historyform history_historyform3;
    }
}
