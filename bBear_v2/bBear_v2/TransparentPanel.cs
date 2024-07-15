using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bBear_v2
{
    public class TransparentPanel : Panel
    {
        public TransparentPanel()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (Brush brush = new SolidBrush(Color.FromArgb(128, Color.Gray))) // 128 คือค่าอัลฟา (0-255) สีเทา (Gray)
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
    }
}
