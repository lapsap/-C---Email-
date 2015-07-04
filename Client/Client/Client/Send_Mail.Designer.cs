namespace Client
{
    partial class Send_Mail
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
            this.btn_send = new System.Windows.Forms.Button();
            this.tb_msg = new System.Windows.Forms.TextBox();
            this.lb_to = new System.Windows.Forms.Label();
            this.lb_subject = new System.Windows.Forms.Label();
            this.tb_to = new System.Windows.Forms.TextBox();
            this.tb_subject = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(820, 525);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(81, 61);
            this.btn_send.TabIndex = 1;
            this.btn_send.Text = "Send";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // tb_msg
            // 
            this.tb_msg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_msg.Location = new System.Drawing.Point(31, 202);
            this.tb_msg.Multiline = true;
            this.tb_msg.Name = "tb_msg";
            this.tb_msg.Size = new System.Drawing.Size(860, 305);
            this.tb_msg.TabIndex = 2;
            // 
            // lb_to
            // 
            this.lb_to.AutoSize = true;
            this.lb_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_to.Location = new System.Drawing.Point(27, 120);
            this.lb_to.Name = "lb_to";
            this.lb_to.Size = new System.Drawing.Size(43, 24);
            this.lb_to.TabIndex = 3;
            this.lb_to.Text = "To :";
            // 
            // lb_subject
            // 
            this.lb_subject.AutoSize = true;
            this.lb_subject.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_subject.Location = new System.Drawing.Point(27, 157);
            this.lb_subject.Name = "lb_subject";
            this.lb_subject.Size = new System.Drawing.Size(88, 24);
            this.lb_subject.TabIndex = 4;
            this.lb_subject.Text = "Subject : ";
            // 
            // tb_to
            // 
            this.tb_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_to.Location = new System.Drawing.Point(121, 123);
            this.tb_to.Name = "tb_to";
            this.tb_to.Size = new System.Drawing.Size(770, 23);
            this.tb_to.TabIndex = 5;
            // 
            // tb_subject
            // 
            this.tb_subject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_subject.Location = new System.Drawing.Point(121, 160);
            this.tb_subject.Name = "tb_subject";
            this.tb_subject.Size = new System.Drawing.Size(770, 23);
            this.tb_subject.TabIndex = 6;
            // 
            // Send_Mail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 598);
            this.Controls.Add(this.tb_subject);
            this.Controls.Add(this.tb_to);
            this.Controls.Add(this.lb_subject);
            this.Controls.Add(this.lb_to);
            this.Controls.Add(this.tb_msg);
            this.Controls.Add(this.btn_send);
            this.Name = "Send_Mail";
            this.Text = "Send_Mail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TextBox tb_msg;
        private System.Windows.Forms.Label lb_to;
        private System.Windows.Forms.Label lb_subject;
        private System.Windows.Forms.TextBox tb_to;
        private System.Windows.Forms.TextBox tb_subject;

    }
}