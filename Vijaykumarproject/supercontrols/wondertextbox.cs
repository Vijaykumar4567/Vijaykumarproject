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
    public partial class wondertextbox : TextBox
    {
        // a textbox with changing carets and many other features0
        public wondertextbox()
        {
            base.AutoSize = false;
            this.BorderStyle = BorderStyle.None;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
         
            if (this.Parent != null)
            {
                this.BackColor = this.Parent.BackColor;
            }
        }
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;
         
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            this.ForeColor = Color.Black;
            this.BackColor = this.Parent.BackColor;
            
        }
    }
}
