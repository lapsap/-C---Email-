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
            this.btn_login = new System.Windows.Forms.Button();
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
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(165, 163);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(100, 64);
            this.btn_login.TabIndex = 1;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 391);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.btn_sendMail);
            this.Name = "index";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.index_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_sendMail;
        private System.Windows.Forms.Button btn_login;


    }
}

