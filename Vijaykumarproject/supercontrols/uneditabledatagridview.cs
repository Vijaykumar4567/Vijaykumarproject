using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vijaykumarproject.supercontrols
{
    public partial class uneditabledatagridview : DataGridView
    {
        public uneditabledatagridview()
        {
            this.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            this.CellBorderStyle = DataGridViewCellBorderStyle.None;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToResizeRows = false;
            this.AllowUserToDeleteRows = false;
            this.BorderStyle = BorderStyle.None;
            this.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.CellBorderStyle = DataGridViewCellBorderStyle.None;
            this.RowHeadersVisible = false;

            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }


       // remove border completely between devision of column headers : working
        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                e.Handled = true;
                using (Brush b = new SolidBrush(this.DefaultCellStyle.BackColor))
                {
                    e.Graphics.FillRectangle(b, e.CellBounds);
                }
                e.PaintContent(e.ClipBounds);
            }
        }

        private void uneditabledatagridview_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                e.PaintBackground(e.CellBounds, true);
                Rectangle r = e.CellBounds;
                r.X -= 2;

                // Check if it's the first column
                if (e.ColumnIndex == 0)
                { // Adjust the padding for the first column
                    r.X += 4;

                    // Align the text to the right for the first column
                    TextRenderer.DrawText(e.Graphics, this.Columns[e.ColumnIndex].HeaderText, e.CellStyle.Font, r, e.CellStyle.ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
                }
                else
                {
                    // Align the text to the left for other columns
                    TextRenderer.DrawText(e.Graphics, this.Columns[e.ColumnIndex].HeaderText, e.CellStyle.Font, r, e.CellStyle.ForeColor, TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
                }
                // Draw top double border
                int topBorderThickness = 3; // Set the thickness of the top border
                int bottomBorderThickness = 1; // Set the thickness of the bottom border
                int x = e.CellBounds.Left;
                int yTop = e.CellBounds.Top;
                int yBottom = e.CellBounds.Bottom - bottomBorderThickness;
                int width = e.CellBounds.Width;
                using (Pen topBorderPen = new Pen(Color.Black, topBorderThickness))
                using (Pen bottomBorderPen = new Pen(Color.Black, bottomBorderThickness))
                {
                    // Draw top border
                    e.Graphics.DrawLine(topBorderPen, x, yTop, x + width, yTop);

                    // Draw bottom border
                    e.Graphics.DrawLine(bottomBorderPen, x, yBottom, x + width, yBottom);
                }
                e.Handled = true;
            }
        }

        // set datagridview color to its parent
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            if (this.Parent != null)
            {
                this.BackgroundColor = this.Parent.BackColor;
                this.DefaultCellStyle.BackColor = this.Parent.BackColor;
            }
        }
    }
}
