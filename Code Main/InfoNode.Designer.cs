namespace simulation2
{
    partial class InfoNode
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
            this.button_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.node_Port = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.node_IP = new System.Windows.Forms.TextBox();
            this.node_ID = new System.Windows.Forms.TextBox();
            this.node_Name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.node_Range = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(207, 266);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 19;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click_1);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(44, 266);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 18;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "Port:";
            // 
            // node_Port
            // 
            this.node_Port.Location = new System.Drawing.Point(132, 171);
            this.node_Port.Name = "node_Port";
            this.node_Port.Size = new System.Drawing.Size(149, 22);
            this.node_Port.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Name:";
            // 
            // node_IP
            // 
            this.node_IP.Location = new System.Drawing.Point(132, 128);
            this.node_IP.Name = "node_IP";
            this.node_IP.Size = new System.Drawing.Size(150, 22);
            this.node_IP.TabIndex = 12;
            // 
            // node_ID
            // 
            this.node_ID.Location = new System.Drawing.Point(132, 79);
            this.node_ID.Name = "node_ID";
            this.node_ID.Size = new System.Drawing.Size(150, 22);
            this.node_ID.TabIndex = 11;
            // 
            // node_Name
            // 
            this.node_Name.Location = new System.Drawing.Point(132, 37);
            this.node_Name.Name = "node_Name";
            this.node_Name.Size = new System.Drawing.Size(150, 22);
            this.node_Name.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "Range:";
            // 
            // node_Range
            // 
            this.node_Range.Location = new System.Drawing.Point(131, 214);
            this.node_Range.Name = "node_Range";
            this.node_Range.Size = new System.Drawing.Size(150, 22);
            this.node_Range.TabIndex = 20;
            // 
            // InfoNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 313);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.node_Range);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.node_Port);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.node_IP);
            this.Controls.Add(this.node_ID);
            this.Controls.Add(this.node_Name);
            this.Name = "InfoNode";
            this.Text = "Infomation Node";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox node_Port;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox node_IP;
        private System.Windows.Forms.TextBox node_ID;
        private System.Windows.Forms.TextBox node_Name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox node_Range;
    }
}