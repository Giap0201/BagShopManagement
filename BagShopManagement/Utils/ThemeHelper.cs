using System.Drawing;
using System.Windows.Forms;

namespace BagShopManagement.Utils
{
    /// <summary>
    /// Helper class để áp dụng theme GenZ Vibrant cho các control
    /// </summary>
    public static class ThemeHelper
    {
        /// <summary>
        /// Áp dụng theme cho DataGridView với màu sắc GenZ
        /// </summary>
        public static void ApplyThemeToDataGridView(DataGridView dgv)
        {
            if (dgv == null) return;

            // Header Style
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = ThemeColors.GridHeader;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = ThemeColors.GridHeaderText;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersHeight = 40;

            // Row Style
            dgv.DefaultCellStyle.BackColor = ThemeColors.Card;
            dgv.DefaultCellStyle.ForeColor = ThemeColors.TextPrimary;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgv.DefaultCellStyle.SelectionBackColor = ThemeColors.GridSelection;
            dgv.DefaultCellStyle.SelectionForeColor = ThemeColors.Card;
            dgv.RowTemplate.Height = 35;

            // Alternating Row Style
            dgv.AlternatingRowsDefaultCellStyle.BackColor = ThemeColors.GridAlternateRow;

            // Border and Grid
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = ThemeColors.Border;
            dgv.BackgroundColor = ThemeColors.Background;

            // Misc
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Áp dụng theme cho Button (Primary)
        /// </summary>
        public static void ApplyPrimaryButtonStyle(Button btn)
        {
            if (btn == null) return;

            btn.BackColor = ThemeColors.Primary;
            btn.ForeColor = ThemeColors.Card;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;

            // Hover effect
            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = ThemeColors.PrimaryLight;
            };
            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = ThemeColors.Primary;
            };
        }

        /// <summary>
        /// Áp dụng theme cho Button (Secondary)
        /// </summary>
        public static void ApplySecondaryButtonStyle(Button btn)
        {
            if (btn == null) return;

            btn.BackColor = ThemeColors.Secondary;
            btn.ForeColor = ThemeColors.Card;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;

            // Hover effect
            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = ThemeColors.SecondaryLight;
            };
            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = ThemeColors.Secondary;
            };
        }

        /// <summary>
        /// Áp dụng theme cho Button (Success)
        /// </summary>
        public static void ApplySuccessButtonStyle(Button btn)
        {
            if (btn == null) return;

            btn.BackColor = ThemeColors.Success;
            btn.ForeColor = ThemeColors.Card;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Áp dụng theme cho Button (Warning/Accent)
        /// </summary>
        public static void ApplyAccentButtonStyle(Button btn)
        {
            if (btn == null) return;

            btn.BackColor = ThemeColors.Accent;
            btn.ForeColor = ThemeColors.TextPrimary;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Áp dụng theme cho Button (Error)
        /// </summary>
        public static void ApplyErrorButtonStyle(Button btn)
        {
            if (btn == null) return;

            btn.BackColor = ThemeColors.Error;
            btn.ForeColor = ThemeColors.Card;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Áp dụng theme cho Panel (Card style)
        /// </summary>
        public static void ApplyCardStyle(Panel panel)
        {
            if (panel == null) return;

            panel.BackColor = ThemeColors.Card;
            panel.Padding = new Padding(20);
        }

        /// <summary>
        /// Áp dụng theme cho GroupBox
        /// </summary>
        public static void ApplyGroupBoxStyle(GroupBox groupBox)
        {
            if (groupBox == null) return;

            groupBox.BackColor = ThemeColors.Card;
            groupBox.ForeColor = ThemeColors.TextPrimary;
            groupBox.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }

        /// <summary>
        /// Áp dụng theme cho Label (tiêu đề)
        /// </summary>
        public static void ApplyTitleLabelStyle(Label label)
        {
            if (label == null) return;

            label.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label.ForeColor = ThemeColors.Primary;
        }

        /// <summary>
        /// Áp dụng theme cho TextBox
        /// </summary>
        public static void ApplyTextBoxStyle(TextBox textBox)
        {
            if (textBox == null) return;

            textBox.BackColor = ThemeColors.Card;
            textBox.ForeColor = ThemeColors.TextPrimary;
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Font = new Font("Segoe UI", 10F);
        }

        /// <summary>
        /// Áp dụng theme cho ComboBox
        /// </summary>
        public static void ApplyComboBoxStyle(ComboBox comboBox)
        {
            if (comboBox == null) return;

            comboBox.BackColor = ThemeColors.Card;
            comboBox.ForeColor = ThemeColors.TextPrimary;
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.Font = new Font("Segoe UI", 10F);
        }
    }
}
