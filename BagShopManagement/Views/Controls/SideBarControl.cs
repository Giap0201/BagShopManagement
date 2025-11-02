using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BagShopManagement.Views.Controls
{

    
    public partial class SideBarControl : UserControl
    {
        public event Action<string> NavigationButtonClicked;
        public SideBarControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
            NavigationButtonClicked?.Invoke("KhuyenMai");
        }
    }
}
