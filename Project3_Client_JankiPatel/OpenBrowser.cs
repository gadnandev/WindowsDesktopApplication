using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project3_Client_JankiPatel
{
    public partial class OpenBrowser : Form
    {
        Uri Url = null;
        Form parent = null;

        public OpenBrowser(Uri url, Form that)
        {
            InitializeComponent();
            this.Url = url;
            this.parent = that;
            webBrowser1.Url = Url;
        }

        public OpenBrowser()
        {
            InitializeComponent();
        }

        private void btn_Browser_close_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Visible = true;
        }
    }

}