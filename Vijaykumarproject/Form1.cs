using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vijaykumarproject
{
    public partial class Form1 : Form
    {
        caretbycastorixsir cs;
        public Form1()
        {
            InitializeComponent();
           
            caretbycastorixsir.SetFocus(this.Handle);
           
            cs = new caretbycastorixsir();
            cs.InstallHook();
           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (IntPtr hWndEdit in caretbycastorixsir.EditWindows)
            {
                caretbycastorixsir.RemoveWindowSubclass(hWndEdit, cs.SubClassDelegate, 0);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            this.ActiveControl = textBox1;
        }
    }
}
