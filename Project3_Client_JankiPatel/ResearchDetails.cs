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
    public partial class ResearchDetails : Form
    {
        Form parent = null;
        int id;
        Research r;
        String type;

        public ResearchDetails(int id, Research r, Form that, String type)
        {
            InitializeComponent();
            this.parent = that;
            this.id = id;
            this.type = type;
            this.r = r;

            if (type.Equals("interest"))
            {
                research_title.Text = "Research Interest: " + r.byInterestArea[id].areaName;

                richTextBox1.Clear();
                for (int i = 0; i < r.byInterestArea[id].citations.Count; i++)
                {
                    richTextBox1.Text += clean(r.byInterestArea[id].citations[i]).ToString();
                }
            }
            else
            {
                research_title.Text = ("Research done by: " + r.byFaculty[id].facultyName);
                for (int i = 0; i < r.byFaculty[id].citations.Count; i++)
                {
                    richTextBox1.Text += clean(r.byFaculty[id].citations[i]).ToString();
                }
            }

        }
        private string clean(string sent)
        {
            return (sent == null) ? "" : sent;
        }

        public ResearchDetails()
        {
            InitializeComponent();

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
            richTextBox1.Clear();
            parent.Visible = true;
        }
    }
}
