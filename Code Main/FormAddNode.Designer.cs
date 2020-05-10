namespace simulation2
{
    partial class FormAddNode
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.number_mn = new System.Windows.Forms.TextBox();
            this.number_ae = new System.Windows.Forms.TextBox();
            this.number_in = new System.Windows.Forms.TextBox();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number IN:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Number MN:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Number AE:";
            // 
            // number_mn
            // 
            this.number_mn.Location = new System.Drawing.Point(119, 61);
            this.number_mn.Margin = new System.Windows.Forms.Padding(4);
            this.number_mn.Name = "number_mn";
            this.number_mn.Size = new System.Drawing.Size(133, 22);
            this.number_mn.TabIndex = 14;
            // 
            // number_ae
            // 
            this.number_ae.Location = new System.Drawing.Point(119, 107);
            this.number_ae.Margin = new System.Windows.Forms.Padding(4);
            this.number_ae.Name = "number_ae";
            this.number_ae.Size = new System.Drawing.Size(133, 22);
            this.number_ae.TabIndex = 13;
            // 
            // number_in
            // 
            this.number_in.Location = new System.Drawing.Point(119, 13);
            this.number_in.Margin = new System.Windows.Forms.Padding(4);
            this.number_in.Name = "number_in";
            this.number_in.Size = new System.Drawing.Size(133, 22);
            this.number_in.TabIndex = 12;
            this.number_in.TextChanged += new System.EventHandler(this.number_in_TextChanged);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(151, 168);
            this.button_cancel.Margin = new System.Windows.Forms.Padding(4);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(100, 28);
            this.button_cancel.TabIndex = 16;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(24, 168);
            this.button_ok.Margin = new System.Windows.Forms.Padding(4);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(100, 28);
            this.button_ok.TabIndex = 15;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click_1);
            // 
            // FormAddNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 209);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.number_mn);
            this.Controls.Add(this.number_ae);
            this.Controls.Add(this.number_in);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "FormAddNode";
            this.Text = "FormAddNode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox number_mn;
        private System.Windows.Forms.TextBox number_ae;
        private System.Windows.Forms.TextBox number_in;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_ok;
    }
}