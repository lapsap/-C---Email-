namespace Client
{
    partial class index
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
            this.btn_sendMail = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_sendMail
            // 
            this.btn_sendMail.Location = new System.Drawing.Point(103, 278);
            this.btn_sendMail.Name = "btn_sendMail";
            this.btn_sendMail.Size = new System.Drawing.Size(100, 64);
            this.btn_sendMail.TabIndex = 0;
            this.btn_sendMail.Text = "Compose Mail";
            this.btn_sendMail.UseVisualStyleBackColor = true;
            this.btn_sendMail.Click += new System.EventHandler(this.btn_sendMail_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(280, 197);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 74);
            this.button1.TabIndex = 1;
            this.button1.Text = "login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 391);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_sendMail);
            this.Name = "index";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.index_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_sendMail;
        private System.Windows.Forms.Button button1;


    }
}

