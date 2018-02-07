using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestUtil;
using Newtonsoft.Json.Linq;


namespace Project3_Client_JankiPatel
{
    public partial class Form1 : Form
    {
        //keep all of my objects globally
        About About;
        Resources Resources;
        People People;
        Employment Employment;
        Degree Degree;
        Footer Foo;
        Research Research;
        Minors Minors;

        //my restful interface
        REST rj = new REST("http://ist.rit.edu/api");
        public string selectedPeopleTab = "faculty";

        public Form1()
        {
            InitializeComponent();

            #region getData
            //get the data  
            string about = rj.getJSON("/about/");
            string courses = rj.getJSON("/courses/");
            string degree = rj.getJSON("/degrees/");
            string people = rj.getJSON("/people/");
            string research = rj.getJSON("/research/");
            string employment = rj.getJSON("/employment/");
            string resources = rj.getJSON("/resources/");
           
            

            //convert data to objects 
            About = JToken.Parse(about).ToObject<About>();
            Employment = JToken.Parse(employment).ToObject<Employment>();
            Degree = JToken.Parse(degree).ToObject<Degree>();
            People = JToken.Parse(people).ToObject<People>();
            Research = JToken.Parse(research).ToObject<Research>();
            Resources = JToken.Parse(resources).ToObject<Resources>();
            #endregion getData
        }

        private void label1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://ist.rit.edu/index.php");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://ist.rit.edu/index.php");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            lbl_title.Text = About.title;
            txtbox_about.Text = '"' + About.description + '"';
            lbl_quote.Text = '"' + About.quote + '"';
            lbl_author.Text = "---" + About.quoteAuthor;
        }

        #region Degrees

        //On click of Undergraduate button 
        private void btn_undergraduate_Click(object sender, EventArgs e)
        {
            gb_advCert.Text = "";
            Label l1 = (Label)gb_advCert.Controls[0];
            Label l2 = (Label)gb_advCert.Controls[1];
            txt_degree_description.Text = "";
            gb_advCert.Visible = false;

            l1.Text = "";
            l2.Text = "";
            //declare and initialize varibles to hold data
            int i = 0;
            int j = 0;
            string[] underGradDegree = new string[3];
            string[] degreeDesc = new string[3];
            string[] conc = new string[7];

            //Get the json data for degrees
            string degree = rj.getJSON("/degrees/");
            Degree degrees = JToken.Parse(degree).ToObject<Degree>();

            foreach (Undergraduate ug in degrees.undergraduate)
            {
                underGradDegree[i] = ug.title;
                degreeDesc[i] = ug.description;
                i++;
                j = 0;
                foreach (string concentration in ug.concentrations)
                {
                    conc[j] = concentration;
                    j++;
                }
            }

            i = gb_degrees.Controls.Count - 1;
            foreach (Button b in gb_degrees.Controls)
            {
                b.Text = underGradDegree[i];
                b.Tag = degreeDesc[i];
                b.Enabled = true;
                i--;
            }
        }

        //Degrees
        //On click of graduate button
        private void btn_graduate_Click(object sender, EventArgs e)
        {
            txt_degree_description.Text = "";
            gb_advCert.Visible = true;
            //declare and initialize varibles to hold data
            int i = 0, j = 0;
            string[] gradDegree = new string[3];
            string[] degreeDesc = new string[3];
            string[] gradAdCert = new string[2];
            string[] conc = new string[7];

            foreach (Graduate gd in Degree.graduate)
            {
                if (gd.title != null)
                {
                    gradDegree[i] = gd.title;
                    degreeDesc[i] = gd.description;
                    i++;
                    j = 0;
                    foreach (string concentration in gd.concentrations)
                    {
                        conc[j] = concentration;
                        j++;
                    }
                }

                else
                {
                    gb_advCert.Text = gd.degreeName;
                    j = 0;
                    foreach (string adv in gd.availableCertificates)
                    {
                        gradAdCert[j] = adv;
                        j++;
                    }
                }

            }

            i = gb_degrees.Controls.Count - 1;
            foreach (Button b in gb_degrees.Controls)
            {
                b.Text = gradDegree[i];
                b.Tag = degreeDesc[i];
                b.Enabled = true;
                i--;
            }

            Label l1 = (Label)gb_advCert.Controls[0];
            Label l2 = (Label)gb_advCert.Controls[1];

            l1.Text = gradAdCert[0];
            l2.Text = gradAdCert[1];
        }

        //On click of each button 
        private void btn_spec1_Click(object sender, EventArgs e)
        {
            txt_degree_description.Text = " ";
            txt_degree_description.AppendText(btn_spec1.Text + Environment.NewLine);
            txt_degree_description.AppendText(Environment.NewLine);
            txt_degree_description.AppendText((string)btn_spec1.Tag);
        }

        private void btn_spec2_Click(object sender, EventArgs e)
        {
            txt_degree_description.Text = " ";
            txt_degree_description.AppendText(btn_spec2.Text + Environment.NewLine);
            txt_degree_description.AppendText(Environment.NewLine);
            txt_degree_description.AppendText((string)btn_spec2.Tag);
        }

        private void btn_spec3_Click(object sender, EventArgs e)
        {
            txt_degree_description.Text = " ";
            txt_degree_description.AppendText(btn_spec3.Text + Environment.NewLine);
            txt_degree_description.AppendText(Environment.NewLine);
            txt_degree_description.AppendText((string)btn_spec3.Tag);
        }

        #endregion


        #region minors

        //click of each minor button to read in detail about each minor program 
        private void btn_dbddi_Click(object sender, EventArgs e)
        {
            MinorsDetailsWindow mdw = new MinorsDetailsWindow((string)btn_dbddi.Tag);
            mdw.ShowDialog();          
        }

        private void btn_gis_Click(object sender, EventArgs e)
        {
            MinorsDetailsWindow mdw = new MinorsDetailsWindow((string)btn_gis.Tag);
            mdw.ShowDialog();
        }

        private void btn_health_Click(object sender, EventArgs e)
        {
            MinorsDetailsWindow mdw = new MinorsDetailsWindow((string)btn_health.Tag);
            mdw.ShowDialog();
        }

        private void btn_mobiledes_Click(object sender, EventArgs e)
        {
            MinorsDetailsWindow mdw = new MinorsDetailsWindow((string)btn_mobiledes.Tag);
            mdw.ShowDialog();
        }

        private void btn_mobiledev_Click(object sender, EventArgs e)
        {
            MinorsDetailsWindow mdw = new MinorsDetailsWindow((string)btn_mobiledev.Tag);
            mdw.ShowDialog();
        }

        private void btn_netsys_Click(object sender, EventArgs e)
        {
            MinorsDetailsWindow mdw = new MinorsDetailsWindow((string)btn_netsys.Tag);
            mdw.ShowDialog();
        }

        private void btn_webdes_Click(object sender, EventArgs e)
        {
            MinorsDetailsWindow mdw = new MinorsDetailsWindow((string)btn_webdes.Tag);
            mdw.ShowDialog();
        }

        private void btn_webdev_Click(object sender, EventArgs e)
        {
            MinorsDetailsWindow mdw = new MinorsDetailsWindow((string)btn_webdev.Tag);
            mdw.ShowDialog();
        }

        #endregion


        #region Employment

        private void tb_employment_Enter(object sender, EventArgs e)
        {

            string jsonEmployment = rj.getJSON("/employment/");
            Employment emp = JToken.Parse(jsonEmployment).ToObject<Employment>();

            txt_emp.Text = "";
            lbl_empTitle.Text = emp.introduction.title;

            txt_emp.AppendText(emp.introduction.content[0].title + Environment.NewLine);
            txt_emp.AppendText(Environment.NewLine + emp.introduction.content[0].description);

            txt_coopedu.Text = "";
            txt_coopedu.AppendText(emp.introduction.content[1].title + Environment.NewLine);
            txt_coopedu.AppendText(Environment.NewLine + emp.introduction.content[1].description);

            int i = gb_degreeStats.Controls.Count - 1;
            gb_degreeStats.Text = emp.degreeStatistics.title;
            foreach (RichTextBox rtb in gb_degreeStats.Controls)
            {
                rtb.Text = "";
                rtb.AppendText(emp.degreeStatistics.statistics[i].value + Environment.NewLine);
                rtb.AppendText(emp.degreeStatistics.statistics[i].description);
                i--;
            }

            txt_employers.Text = "";
            txt_employers.AppendText(emp.employers.title + Environment.NewLine + Environment.NewLine);
            foreach (string s in emp.employers.employerNames)
            {
                txt_employers.AppendText(s + Environment.NewLine);
            }

            txt_careers.Text = "";
            txt_careers.AppendText(emp.careers.title + Environment.NewLine + Environment.NewLine);
            foreach (string s in emp.careers.careerNames)
            {
                txt_careers.AppendText(s + Environment.NewLine);
            }

        }

        #endregion


        #region Employment & Co-op Table

        private void btn_coopTable_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Employment.coopTable.coopInformation.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[1].Value = Employment.coopTable.coopInformation[i].employer;
                dataGridView1.Rows[i].Cells[0].Value = Employment.coopTable.coopInformation[i].degree;
                dataGridView1.Rows[i].Cells[2].Value = Employment.coopTable.coopInformation[i].city;
                dataGridView1.Rows[i].Cells[3].Value = Employment.coopTable.coopInformation[i].term;
            }
            btn_coopTable.Enabled = false;
        }

        private void btn_empTable_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Employment.employmentTable.professionalEmploymentInformation.Count; i++)
            {
                dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells[0].Value = Employment.employmentTable.professionalEmploymentInformation[i].degree;
                dataGridView2.Rows[i].Cells[1].Value = Employment.employmentTable.professionalEmploymentInformation[i].employer;
                dataGridView2.Rows[i].Cells[2].Value = Employment.employmentTable.professionalEmploymentInformation[i].city;
                dataGridView2.Rows[i].Cells[3].Value = Employment.employmentTable.professionalEmploymentInformation[i].title;
                dataGridView2.Rows[i].Cells[4].Value = Employment.employmentTable.professionalEmploymentInformation[i].startDate;
            }
            btn_empTable.Enabled = false;
        }

        #endregion


        #region People

        // People tab control 
        // Load all the faculty names
        private void tb_people_Enter(object sender, EventArgs e)
        {


            string[] facultyName = new string[35];
            string[] facultyUname = new string[35];

            int i = 0;

            foreach (Faculty fac in People.faculty)
            {
                facultyName[i] = fac.name;
                facultyUname[i] = fac.username;
                i++;
            }

            i = tb_faculty.Controls.Count - 1;
            foreach (Button b in tb_faculty.Controls)
            {
                b.Text = facultyName[i];
                b.Tag = facultyUname[i];
                i--;
            }
        }

        // Load staff names
        private void tb_staff_Enter(object sender, EventArgs e)
        {
            selectedPeopleTab = "staff";

            string[] staffName = new string[20];
            string[] staffUname = new string[20];
            int i = 0;

            foreach (Staff thisStaff in People.staff)
            {
                staffName[i] = thisStaff.name;
                staffUname[i] = thisStaff.username;
                i++;
            }

            i = tb_staff.Controls.Count - 1;
            foreach (Button b in tb_staff.Controls)
            {
                b.Text = staffName[i];
                b.Tag = staffUname[i];
                i--;
            }
        }

        // for url reference
        private void tb_faculty_Enter(object sender, EventArgs e)
        {
            selectedPeopleTab = "faculty";
        }



        // on click of each button
        private void button1_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button1.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button2.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button3.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button4.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button5.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button6.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button7.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button14.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button13.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button12.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button11.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button10.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button9.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button8.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button21.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button20.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button19.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button18.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button17.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button16.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button15.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button28.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button27.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button26.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button25.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button24.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button23.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button22.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button30.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button29.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button34.Tag, selectedPeopleTab);
            pds.Show();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button33.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button32.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button31.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        //on click of each staff
        private void button36_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button36.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button37.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button38.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button39.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button40.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button45_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button45.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button44_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button44.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button43_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button43.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button42_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button42.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button41_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button41.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }


        private void button48_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button48.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button46_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button46.Tag, selectedPeopleTab);
            pds.ShowDialog();

        }


        private void button47_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button47.Tag, selectedPeopleTab);
            pds.ShowDialog();

        }

        #endregion

        #region Research

        private void tab_research_Enter(object sender, EventArgs e)
        {
            interest_lookup.Items.Clear();
            interest_Faculty.Items.Clear();
            for (int i = 0; i < Research.byFaculty.Count; i++)
            {
                interest_Faculty.Items.Add(Research.byFaculty[i].facultyName);
            }

            for (int i = 0; i < Research.byInterestArea.Count; i++)
            {
                interest_lookup.Items.Add(Research.byInterestArea[i].areaName);
            }

        }

        private void facLookup_Click(object sender, EventArgs e)
        {
            getResearchInfo(interest_Faculty.SelectedIndex, "faculty");
        }

        private void interestLookup_Click(object sender, EventArgs e)
        {
            if (interest_lookup.SelectedIndex != -1)
            {
                getResearchInfo(interest_lookup.SelectedIndex, "interest");
            }
            else
            {
            }
        }

        public void getResearchInfo(int id, String type)
        {
            this.Visible = false;
            ResearchDetails researchDetails = new ResearchDetails(id, Research, this, type);
            researchDetails.Show();
        }

        #endregion Research

        //display the items selected in a browser window
        public void openInBrowser(String URL)
        {
            this.Visible = false;
            Uri uri = new Uri(URL);
            OpenBrowser ob = new OpenBrowser(uri, this);
            ob.Visible = true;
        }

        #region Social Presence
        private void tab_social_Enter(object sender, EventArgs e)
        {
            string footer = rj.getJSON("/footer/");
            Foo = JToken.Parse(footer).ToObject<Footer>();

            lbltweet.Text = Foo.social.tweet;
            lbl_tweet_by.Text = Foo.social.by;
            lbl_quick1.Text = Foo.quickLinks[0].title;
            lbl_quick2.Text = Foo.quickLinks[1].title;
            lbl_quick3.Text = Foo.quickLinks[2].title;
            lbl_quick4.Text = Foo.quickLinks[3].title;
            lbl_copyright.Text = Foo.copyright.title;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            openInBrowser(Foo.social.facebook);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            openInBrowser(Foo.social.twitter);
        }
        private void label6_Click(object sender, EventArgs e)
        {
            openInBrowser(Foo.quickLinks[1].href);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            openInBrowser(Foo.quickLinks[3].href);
        }

        private void lbl_quick1_Click(object sender, EventArgs e)
        {
            openInBrowser(Foo.quickLinks[0].href);
        }

        private void lbl_quick3_Click(object sender, EventArgs e)
        {
            openInBrowser(Foo.quickLinks[2].href);
        }

        private void lblNews_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            NewsDetail ns = new NewsDetail(this);
            ns.Visible = true;
        }


        private void LinkLabel21_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openInBrowser("http://www.rit.edu/copyright.html");
        }

        private void linkLabel22_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openInBrowser("http://www.rit.edu/nondiscrimination.html");
        }

        private void linkLabel23_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openInBrowser("http://www.rit.edu/privacystatement.html");
        }

        private void linkLabel24_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openInBrowser("http://www.rit.edu/disclaimer.html");
        }

        private void LinkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openInBrowser("http://www.rit.edu/");
        }
        #endregion Social Presence
        

        #region Resources
        //-- student resource

        private void tb_resources_Enter(object sender, EventArgs e)
        {
            lbl_resTitle.Text = Resources.title;
            lbl_resSub.Text = Resources.subTitle;
        }

        //study abroad

        private void btn_studyabroad_Click(object sender, EventArgs e)
        {
            ResourcesDetails rds = new ResourcesDetails((string)btn_studyabroad.Tag);
            rds.ShowDialog();
        }

        //service
        private void btn_studserv_Click(object sender, EventArgs e)
        {
            ResourcesDetails rds = new ResourcesDetails((string)btn_studserv.Tag);
            rds.ShowDialog();
        }

        //tutors
        private void btn_tutor_Click(object sender, EventArgs e)
        {
            ResourcesDetails rds = new ResourcesDetails((string)btn_tutor.Tag);
            rds.ShowDialog();
        }

        //student ambassadors
        private void btn_studamb_Click(object sender, EventArgs e)
        {
            ResourcesDetails rds = new ResourcesDetails((string)btn_studamb.Tag);
            rds.ShowDialog();
        }

        //forms
        private void btn_forms_Click(object sender, EventArgs e)
        {
            ResourcesDetails rds = new ResourcesDetails((string)btn_forms.Tag);
            rds.ShowDialog();
        }

        //coop
        private void btn_coop_Click(object sender, EventArgs e)
        {
            ResourcesDetails rds = new ResourcesDetails((string)btn_coop.Tag);
            rds.ShowDialog();
        }

        #endregion

        
        #region ContactForm
        private void tabContact_Enter(object sender, EventArgs e)
        {
            Uri uri = new Uri("http://ist.rit.edu/api/contactForm/");
            contactFormWebBrowser.Url = uri;
        }











        #endregion ContactForm

       
    }
}
