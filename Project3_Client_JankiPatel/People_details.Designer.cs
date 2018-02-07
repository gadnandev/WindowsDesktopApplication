namespace Project3_Client_JankiPatel
{
    partial class People_details
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(People_details));
            this.pb_peopledetails = new System.Windows.Forms.PictureBox();
            this.txt_peopledetails = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_peopledetails)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb_peopledetails
            // 
            this.pb_peopledetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_peopledetails.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pb_peopledetails.ErrorImage")));
            this.pb_peopledetails.InitialImage = ((System.Drawing.Image)(resources.GetObject("pb_peopledetails.InitialImage")));
            this.pb_peopledetails.Location = new System.Drawing.Point(56, 148);
            this.pb_peopledetails.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.pb_peopledetails.Name = "pb_peopledetails";
            this.pb_peopledetails.Size = new System.Drawing.Size(303, 257);
            this.pb_peopledetails.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb_peopledetails.TabIndex = 1;
            this.pb_peopledetails.TabStop = false;
            // 
            // txt_peopledetails
            // 
            this.txt_peopledetails.Location = new System.Drawing.Point(440, 148);
            this.txt_peopledetails.Margin = new System.Windows.Forms.Padding(5);
            this.txt_peopledetails.Multiline = true;
            this.txt_peopledetails.Name = "txt_peopledetails";
            this.txt_peopledetails.ReadOnly = true;
            this.txt_peopledetails.Size = new System.Drawing.Size(780, 537);
            this.txt_peopledetails.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.pb_peopledetails);
            this.groupBox1.Controls.Add(this.txt_peopledetails);
            this.groupBox1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBox1.Location = new System.Drawing.Point(40, 38);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.groupBox1.Size = new System.Drawing.Size(1343, 853);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // People_details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1425, 947);
            this.Controls.Add(this.groupBox1);
            this.Name = "People_details";
            this.Text = "People_details";
            ((System.ComponentModel.ISupportInitialize)(this.pb_peopledetails)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_peopledetails;
        private System.Windows.Forms.TextBox txt_peopledetails;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}