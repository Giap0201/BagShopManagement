using BagShopManagement.Views.Common;
using BagShopManagement.Views.Dev6;
using OfficeOpenXml;

namespace BagShopManagement
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //NKS
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //END NKS

            //Application.Run(new Form1());
            Application.Run(new QuanLiBanHang());
            //Application.Run(new Views.Dev2.SanPhamEditForm());
        }
    }
}