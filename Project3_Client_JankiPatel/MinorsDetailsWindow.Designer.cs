namespace Project3_Client_JankiPatel
{
    partial class MinorsDetailsWindow
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
            this.txt_minordetails = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_minordetails
            // 
            this.txt_minordetails.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txt_minordetails.Cursor = System.Windows.Forms.Cursors.Default;
            this.txt_minordetails.Font = new System.Drawing.Font("Comic Sans MS", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_minordetails.ForeColor = System.Drawing.Color.Navy;
            this.txt_minordetails.Location = new System.Drawing.Point(62, 63);
            this.txt_minordetails.Margin = new System.Windows.Forms.Padding(5);
            this.txt_minordetails.Multiline = true;
            this.txt_minordetails.Name = "txt_minordetails";
            this.txt_minordetails.ReadOnly = true;
            this.txt_minordetails.Size = new System.Drawing.Size(1548, 1061);
            this.txt_minordetails.TabIndex = 1;
            // 
            // MinorsDetailsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1693, 1197);
            this.Controls.Add(this.txt_minordetails);
            this.Name = "MinorsDetailsWindow";
            this.Text = "MinorsDetailsWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_minordetails;
    }
}