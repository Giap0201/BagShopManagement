using System.Drawing;

namespace BagShopManagement.Utils
{
    /// <summary>
    /// Theme màu GenZ Vibrant - Rực rỡ, tươi trẻ, phù hợp với đối tượng sinh viên
    /// </summary>
    public static class ThemeColors
    {
        // === Màu Chính ===
        /// <summary>Pink Coral - Màu hồng san hô nổi bật (Dùng cho các nút chính, header)</summary>
        public static readonly Color Primary = ColorTranslator.FromHtml("#FF6B9D");

        /// <summary>Vivid Purple - Tím sống động (Dùng cho sidebar, accent)</summary>
        public static readonly Color Secondary = ColorTranslator.FromHtml("#6C63FF");

        /// <summary>Sunny Yellow - Vàng rạng rỡ (Dùng cho highlight, warning)</summary>
        public static readonly Color Accent = ColorTranslator.FromHtml("#FFD93D");

        /// <summary>Fresh Green - Xanh tươi mát (Dùng cho success, badges)</summary>
        public static readonly Color Success = ColorTranslator.FromHtml("#6BCF7F");

        // === Màu Nền ===
        /// <summary>Soft White - Trắng mềm mại (Nền tổng thể)</summary>
        public static readonly Color Background = ColorTranslator.FromHtml("#F8F9FA");

        /// <summary>Pure White - Trắng tinh khiết (Card, panel)</summary>
        public static readonly Color Card = Color.White;

        // === Màu Text ===
        /// <summary>Dark Gray - Xám đậm (Text chính)</summary>
        public static readonly Color TextPrimary = ColorTranslator.FromHtml("#2D3748");

        /// <summary>Medium Gray - Xám vừa (Text phụ)</summary>
        public static readonly Color TextSecondary = ColorTranslator.FromHtml("#718096");

        // === Màu Bổ Sung ===
        /// <summary>Soft Pink - Hồng nhạt (Hover effect cho primary)</summary>
        public static readonly Color PrimaryLight = ColorTranslator.FromHtml("#FFB3CC");

        /// <summary>Light Purple - Tím nhạt (Hover effect cho secondary)</summary>
        public static readonly Color SecondaryLight = ColorTranslator.FromHtml("#A5A0FF");

        /// <summary>Error Red - Đỏ cảnh báo</summary>
        public static readonly Color Error = ColorTranslator.FromHtml("#FF5757");

        /// <summary>Border Gray - Xám viền nhẹ</summary>
        public static readonly Color Border = ColorTranslator.FromHtml("#E2E8F0");

        /// <summary>Gradient Start - Màu bắt đầu gradient (Primary)</summary>
        public static readonly Color GradientStart = Primary;

        /// <summary>Gradient End - Màu kết thúc gradient (Secondary)</summary>
        public static readonly Color GradientEnd = Secondary;

        // === Màu cho DataGridView ===
        /// <summary>Màu dòng chẵn trong DataGridView</summary>
        public static readonly Color GridAlternateRow = ColorTranslator.FromHtml("#FFF5F9");

        /// <summary>Màu header DataGridView</summary>
        public static readonly Color GridHeader = Secondary;

        /// <summary>Màu text header DataGridView</summary>
        public static readonly Color GridHeaderText = Color.White;

        /// <summary>Màu selection trong DataGridView</summary>
        public static readonly Color GridSelection = Primary;
    }
}
