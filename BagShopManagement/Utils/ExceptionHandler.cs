using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Utils
{
    //phuong thuc xu li loi cua toan he thong
    public static class ExceptionHandler
    {
        //xu li mot ex, hien thi thong bao cho user
        public static void Handle(Exception ex, string userMessage = "Đã xảy ra lỗi không mong muốn.")
        {
            //kiem tra loai loi
            if (ex is ArgumentException)
            {
                //neu la loi nhap lieu sai hien thi chi tiet cho nguoi dung
                MessageBox.Show(ex.Message, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (ex is ApplicationException)
            {
                //neu la loi nghiep vu hoac loi db hien thi thong bao chung khong hien thi loi chi tiet
                MessageBox.Show(ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //loi chua xac dinh
                MessageBox.Show(userMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}