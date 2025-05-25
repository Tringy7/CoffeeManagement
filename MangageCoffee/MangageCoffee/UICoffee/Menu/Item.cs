using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MangageCoffee.DTO;

namespace MangageCoffee.UICoffee.Menu
{
    public partial class Item : UserControl
    {
        private Menu_add parentMenu;
        public event EventHandler ItemSelected;
        public Item()
        {
            InitializeComponent();
            this.Click += Menu_item_click; // click vào control
            foreach (Control c in this.Controls) // click vào con cũng tính
                c.Click += Menu_item_click;
        }


    // load dữ liệu
        public Class_Menu menuData { get; private set; }
        private void Menu_item_click(object sender, EventArgs e)
        {
            ItemSelected?.Invoke(this, EventArgs.Empty);
        }
        public void setdata(Class_Menu menuItem)
        {
            this.menuData = menuItem;
            name_Item.Text = menuItem.Name;
            Item_cost.Text = menuItem.Price.ToString("C");
        }
// thuộc tính thêm
        public void SetParentMenu(Menu_add menu)
        {
            this.parentMenu = menu;
        }
        private void btnHome_Click_1(object sender, EventArgs e)
        {
            if (parentMenu == null || menuData == null)
                return;

            var panel = parentMenu.flowLayoutPaneloder_Menu;

            // Tìm xem đã có món này trong panel chưa
            foreach (Control control in panel.Controls)
            {
                if (control is Item_Order order && order.ItemName == menuData.Name)
                {
                    order.IncreaseQuantity(); // Tăng số lượng nếu đã tồn tại
                    parentMenu.UpdateTotalMoney();
                    return;
                }
            }

            // Nếu chưa có thì tạo mới
            Item_Order newOrder = new Item_Order(menuData.Name, menuData.Price,parentMenu) ;
            panel.Controls.Add(newOrder);
        // cập nhật giá tiền
            parentMenu.UpdateTotalMoney();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }






























        private void btnHome_Click(object sender, EventArgs e)
        {

        }

        private void Item_Load(object sender, EventArgs e)
        {

        }

        private void name_Item_Click(object sender, EventArgs e)
        {

        }
    }
}
