namespace Project3_Client_JankiPatel
{
    partial class ResourcesDetails
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
            this.txt_resourcedetails = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_resourcedetails
            // 
            this.txt_resourcedetails.BackColor = System.Drawing.Color.Azure;
            this.txt_resourcedetails.Cursor = System.Windows.Forms.Cursors.Default;
            this.txt_resourcedetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_resourcedetails.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_resourcedetails.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txt_resourcedetails.Location = new System.Drawing.Point(0, 0);
            this.txt_resourcedetails.Margin = new System.Windows.Forms.Padding(5);
            this.txt_resourcedetails.Multiline = true;
            this.txt_resourcedetails.Name = "txt_resourcedetails";
            this.txt_resourcedetails.ReadOnly = true;
            this.txt_resourcedetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_resourcedetails.Size = new System.Drawing.Size(1543, 1038);
            this.txt_resourcedetails.TabIndex = 1;
            // 
            // ResourcesDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1543, 1038);
            this.Controls.Add(this.txt_resourcedetails);
            this.Name = "ResourcesDetails";
            this.Text = "ResourcesDetails";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_resourcedetails;
    }
}