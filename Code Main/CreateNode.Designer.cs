namespace simulation2
{
    partial class CreateNode
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
            this.number_mn = new System.Windows.Forms.TextBox();
            this.number_ae = new System.Windows.Forms.TextBox();
            this.number_in = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // number_mn
            // 
            this.number_mn.Location = new System.Drawing.Point(128, 62);
            this.number_mn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.number_mn.Name = "number_mn";
            this.number_mn.Size = new System.Drawing.Size(193, 22);
            this.number_mn.TabIndex = 11;
            // 
            // number_ae
            // 
            this.number_ae.Location = new System.Drawing.Point(128, 108);
            this.number_ae.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.number_ae.Name = "number_ae";
            this.number_ae.Size = new System.Drawing.Size(193, 22);
            this.number_ae.TabIndex = 10;
            // 
            // number_in
            // 
            this.number_in.Location = new System.Drawing.Point(128, 14);
            this.number_in.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.number_in.Name = "number_in";
            this.number_in.Size = new System.Drawing.Size(193, 22);
            this.number_in.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 108);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Number AE:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Number MN:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Number IN:";
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(57, 161);
            this.button_ok.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(100, 28);
            this.button_ok.TabIndex = 12;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(184, 161);
            this.button_cancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(100, 28);
            this.button_cancel.TabIndex = 13;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            // 
            // InfoNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 204);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.number_mn);
            this.Controls.Add(this.number_ae);
            this.Controls.Add(this.number_in);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "InfoNode";
            this.Text = "CreateNode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox number_mn;
        private System.Windows.Forms.TextBox number_ae;
        private System.Windows.Forms.TextBox number_in;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
    }
}