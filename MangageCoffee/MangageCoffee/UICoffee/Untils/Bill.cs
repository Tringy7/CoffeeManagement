using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MangageCoffee.ADO.NET.DAL;
using MangageCoffee.DTO;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Globalization;


namespace MangageCoffee.UICoffee.Untils
{
    public partial class Bill : Form
    {
        private List<OrderItemDTO> _orderItems;

        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public int OrderID { get; set; }

        public Bill()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public Bill(List<OrderItemDTO> orderItems, string customerName, string customerPhoneNumber) : this()
        {
            Console.WriteLine("Bill Constructor:");
            Console.WriteLine("Customer Name: " + customerName);
            Console.WriteLine("Customer Phone: " + customerPhoneNumber);
            Console.WriteLine("Order Items Null? " + (orderItems == null));

            _orderItems = orderItems;
            CustomerName = customerName;
            CustomerPhoneNumber = customerPhoneNumber;
            InitializeBill();
        }

        private void InitializeBill()
        {
            lblTen.Text = CustomerName;
            lblSDT.Text = CustomerPhoneNumber;

            lblDate.Text = DateTime.Now.ToString();

            lblID.Text = OrderID.ToString();

            flowLayoutPanel1.Controls.Clear();
            if (_orderItems != null)
            {
                foreach (OrderItemDTO item in _orderItems)
                {
                    Bill_item billItemControl = new Bill_item();
                    billItemControl.SetItemData(item.Name, item.Quantity, item.UnitPrice);
                    flowLayoutPanel1.Controls.Add(billItemControl);
                }
                CalculateAndDisplayTotal(_orderItems);
            }
        }

        private void CalculateAndDisplayTotal(List<OrderItemDTO> orderItems)
        {
            if (orderItems != null)
            {
                double total = orderItems.Sum(item => item.TotalPrice);
                lblSubtotal.Text = total.ToString("C0", CultureInfo.GetCultureInfo("vi-VN"));
                double vat = total * 0.1;
                lblVAT.Text = "10%";
                total = total + vat;
                lblTotal.Text = total.ToString("C0", CultureInfo.GetCultureInfo("vi-VN"));
            }
        }
        private void deleteOderHistory_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ShowSaveDialogAndExport();
        }

        private void ShowSaveDialogAndExport()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveDialog.Title = "Save Bill As";
            saveDialog.DefaultExt = "pdf";  // Default to PDF
            saveDialog.Filter = "PDF files (*.pdf)|*.pdf|PNG Image (*.png)|*.png";
            saveDialog.FilterIndex = 1; // Start with PDF selected

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveDialog.FileName;
                string fileExtension = Path.GetExtension(filePath).ToLower();

                if (fileExtension == ".pdf")
                {
                    ExportToPdf(filePath);
                }
                else if (fileExtension == ".png")
                {
                    ExportToPng(filePath);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Invalid file format selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExportToPdf(string filePath)
        {
            btnPrint.Visible = false;
            btnClose.Visible = false;

            Bitmap formBitmap = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(formBitmap, new System.Drawing.Rectangle(0, 0, this.Width, this.Height));

            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    using (Document pdfDoc = new Document(PageSize.A4, 25, 25, 30, 30))
                    {
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, fs);
                        pdfDoc.Open();

                        using (MemoryStream imageStream = new MemoryStream())
                        {
                            formBitmap.Save(imageStream, ImageFormat.Png);
                            iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(imageStream.ToArray());

                            pdfImage.ScaleToFit(pdfDoc.PageSize.Width - 50, pdfDoc.PageSize.Height - 50);
                            pdfImage.Alignment = Element.ALIGN_CENTER;

                            pdfDoc.Add(pdfImage);
                        }

                        pdfDoc.Close();
                    }
                }

                System.Windows.Forms.MessageBox.Show("Bill saved as PDF successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error saving Bill as PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                formBitmap.Dispose();
                btnPrint.Visible = true; 
                btnClose.Visible = true; 
            }
        }

        private void ExportToPng(string filePath)
        {
            btnPrint.Visible = false;
            btnClose.Visible = false;

            Bitmap formBitmap = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(formBitmap, new System.Drawing.Rectangle(0, 0, this.Width, this.Height));

            try
            {
                formBitmap.Save(filePath, ImageFormat.Png);
                System.Windows.Forms.MessageBox.Show("Bill saved as PNG successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error saving Bill as PNG: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                formBitmap.Dispose();
                btnPrint.Visible = true;
                btnClose.Visible = true;
            }
        }
    }
}
