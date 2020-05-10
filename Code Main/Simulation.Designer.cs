namespace simulation2
{
    partial class Simulation
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel_simu = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtColumn = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.button_step = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button_pause = new System.Windows.Forms.Button();
            this.button_run = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.motesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGidMonitor = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGidMonitor)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.26252F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.73748F));
            this.tableLayoutPanel1.Controls.Add(this.panel_simu, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGidMonitor, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1613, 548);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel_simu
            // 
            this.panel_simu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_simu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel_simu.Location = new System.Drawing.Point(4, 49);
            this.panel_simu.Margin = new System.Windows.Forms.Padding(4);
            this.panel_simu.Name = "panel_simu";
            this.panel_simu.Size = new System.Drawing.Size(867, 495);
            this.panel_simu.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtColumn);
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.btnFind);
            this.panel2.Controls.Add(this.txtFind);
            this.panel2.Controls.Add(this.button_step);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button_pause);
            this.panel2.Controls.Add(this.button_run);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(879, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(730, 37);
            this.panel2.TabIndex = 2;
            // 
            // txtColumn
            // 
            this.txtColumn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtColumn.Location = new System.Drawing.Point(365, 6);
            this.txtColumn.Name = "txtColumn";
            this.txtColumn.Size = new System.Drawing.Size(100, 22);
            this.txtColumn.TabIndex = 7;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(662, 6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(65, 23);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Cancel";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.Location = new System.Drawing.Point(594, 6);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(62, 23);
            this.btnFind.TabIndex = 5;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtFind
            // 
            this.txtFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFind.Location = new System.Drawing.Point(471, 6);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(117, 22);
            this.txtFind.TabIndex = 4;
            // 
            // button_step
            // 
            this.button_step.Location = new System.Drawing.Point(179, 3);
            this.button_step.Margin = new System.Windows.Forms.Padding(4);
            this.button_step.Name = "button_step";
            this.button_step.Size = new System.Drawing.Size(71, 28);
            this.button_step.TabIndex = 3;
            this.button_step.Text = "Step";
            this.button_step.UseVisualStyleBackColor = true;
            this.button_step.Click += new System.EventHandler(this.button_step_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(258, 3);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(70, 28);
            this.button4.TabIndex = 2;
            this.button4.Text = "Reload";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button_pause
            // 
            this.button_pause.Location = new System.Drawing.Point(91, 3);
            this.button_pause.Margin = new System.Windows.Forms.Padding(4);
            this.button_pause.Name = "button_pause";
            this.button_pause.Size = new System.Drawing.Size(80, 28);
            this.button_pause.TabIndex = 1;
            this.button_pause.Text = "Pause";
            this.button_pause.UseVisualStyleBackColor = true;
            this.button_pause.Click += new System.EventHandler(this.button_pause_Click);
            // 
            // button_run
            // 
            this.button_run.Location = new System.Drawing.Point(4, 3);
            this.button_run.Margin = new System.Windows.Forms.Padding(4);
            this.button_run.Name = "button_run";
            this.button_run.Size = new System.Drawing.Size(79, 28);
            this.button_run.TabIndex = 0;
            this.button_run.Text = "Run";
            this.button_run.UseVisualStyleBackColor = true;
            this.button_run.Click += new System.EventHandler(this.button_run_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.simulationToolStripMenuItem,
            this.motesToolStripMenuItem,
            this.toolToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(875, 45);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.savaToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 41);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // savaToolStripMenuItem
            // 
            this.savaToolStripMenuItem.Name = "savaToolStripMenuItem";
            this.savaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.savaToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.savaToolStripMenuItem.Text = "Sava";
            this.savaToolStripMenuItem.Click += new System.EventHandler(this.savaToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.saveAsToolStripMenuItem.Text = "Save As";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // simulationToolStripMenuItem
            // 
            this.simulationToolStripMenuItem.Name = "simulationToolStripMenuItem";
            this.simulationToolStripMenuItem.Size = new System.Drawing.Size(94, 41);
            this.simulationToolStripMenuItem.Text = "Simulation";
            // 
            // motesToolStripMenuItem
            // 
            this.motesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMotesToolStripMenuItem});
            this.motesToolStripMenuItem.Name = "motesToolStripMenuItem";
            this.motesToolStripMenuItem.Size = new System.Drawing.Size(64, 41);
            this.motesToolStripMenuItem.Text = "Motes";
            // 
            // addMotesToolStripMenuItem
            // 
            this.addMotesToolStripMenuItem.Name = "addMotesToolStripMenuItem";
            this.addMotesToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.addMotesToolStripMenuItem.Text = "Add Motes";
            this.addMotesToolStripMenuItem.Click += new System.EventHandler(this.addMotesToolStripMenuItem_Click);
            // 
            // toolToolStripMenuItem
            // 
            this.toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            this.toolToolStripMenuItem.Size = new System.Drawing.Size(58, 41);
            this.toolToolStripMenuItem.Text = "Tools";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(76, 41);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // helpsToolStripMenuItem
            // 
            this.helpsToolStripMenuItem.Name = "helpsToolStripMenuItem";
            this.helpsToolStripMenuItem.Size = new System.Drawing.Size(55, 41);
            this.helpsToolStripMenuItem.Text = "Help";
            // 
            // dataGidMonitor
            // 
            this.dataGidMonitor.AllowUserToAddRows = false;
            this.dataGidMonitor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGidMonitor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGidMonitor.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGidMonitor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGidMonitor.Location = new System.Drawing.Point(878, 47);
            this.dataGidMonitor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGidMonitor.Name = "dataGidMonitor";
            this.dataGidMonitor.RowHeadersVisible = false;
            this.dataGidMonitor.RowHeadersWidth = 51;
            this.dataGidMonitor.RowTemplate.Height = 24;
            this.dataGidMonitor.Size = new System.Drawing.Size(732, 499);
            this.dataGidMonitor.TabIndex = 5;
            // 
            // Simulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1613, 548);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Simulation";
            this.Text = "Simulation";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGidMonitor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem motesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addMotesToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_run;
        private System.Windows.Forms.Button button_step;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button_pause;
        private System.Windows.Forms.Panel panel_simu;
        private System.Windows.Forms.DataGridView dataGidMonitor;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtColumn;
    }
}