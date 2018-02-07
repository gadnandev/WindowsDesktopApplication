using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using RestUtil;

namespace Project3_Client_JankiPatel
{
    public partial class NewsDetail : Form
    {
        Form parent = null;
        REST rj = new REST("http://ist.rit.edu/api");
        News News;

        public NewsDetail()
        {
            InitializeComponent();
        }

        //display all the news
        public NewsDetail(Form that)
        {
            InitializeComponent();
            this.parent = that;
            string news = rj.getJSON("/news/");
            News = JToken.Parse(news).ToObject<News>();
        }

        private void btn_News_close_Click(object sender, EventArgs e)
        {
            parent.Visible = true;
            this.Close();
        }
    }
}
