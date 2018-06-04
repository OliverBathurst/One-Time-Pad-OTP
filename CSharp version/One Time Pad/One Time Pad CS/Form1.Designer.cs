namespace One_Time_Pad_CS
{
    partial class otp
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encryptDecryptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateNewKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openKeyFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeKeyToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeNewKeyToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyFrom = new System.Windows.Forms.ToolStripComboBox();
            this.fileOptions = new System.Windows.Forms.ToolStripComboBox();
            this.log = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.keyToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 38);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.encryptDecryptToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(56, 34);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(253, 34);
            this.openFileToolStripMenuItem.Text = "Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // encryptDecryptToolStripMenuItem
            // 
            this.encryptDecryptToolStripMenuItem.Name = "encryptDecryptToolStripMenuItem";
            this.encryptDecryptToolStripMenuItem.Size = new System.Drawing.Size(253, 34);
            this.encryptDecryptToolStripMenuItem.Text = "Encrypt/Decrypt";
            this.encryptDecryptToolStripMenuItem.Click += new System.EventHandler(this.encryptDecryptToolStripMenuItem_Click);
            // 
            // keyToolStripMenuItem
            // 
            this.keyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateNewKeyToolStripMenuItem,
            this.openKeyFileToolStripMenuItem,
            this.writeKeyToFileToolStripMenuItem,
            this.writeNewKeyToFileToolStripMenuItem});
            this.keyToolStripMenuItem.Name = "keyToolStripMenuItem";
            this.keyToolStripMenuItem.Size = new System.Drawing.Size(58, 34);
            this.keyToolStripMenuItem.Text = "Key";
            // 
            // generateNewKeyToolStripMenuItem
            // 
            this.generateNewKeyToolStripMenuItem.Name = "generateNewKeyToolStripMenuItem";
            this.generateNewKeyToolStripMenuItem.Size = new System.Drawing.Size(305, 34);
            this.generateNewKeyToolStripMenuItem.Text = "Generate New Key";
            this.generateNewKeyToolStripMenuItem.Click += new System.EventHandler(this.generateNewKeyToolStripMenuItem_Click);
            // 
            // openKeyFileToolStripMenuItem
            // 
            this.openKeyFileToolStripMenuItem.Name = "openKeyFileToolStripMenuItem";
            this.openKeyFileToolStripMenuItem.Size = new System.Drawing.Size(305, 34);
            this.openKeyFileToolStripMenuItem.Text = "Read Key From File";
            this.openKeyFileToolStripMenuItem.Click += new System.EventHandler(this.openKeyFileToolStripMenuItem_Click);
            // 
            // writeKeyToFileToolStripMenuItem
            // 
            this.writeKeyToFileToolStripMenuItem.Name = "writeKeyToFileToolStripMenuItem";
            this.writeKeyToFileToolStripMenuItem.Size = new System.Drawing.Size(305, 34);
            this.writeKeyToFileToolStripMenuItem.Text = "Write Key To File";
            this.writeKeyToFileToolStripMenuItem.Click += new System.EventHandler(this.writeKeyToFileToolStripMenuItem_Click);
            // 
            // writeNewKeyToFileToolStripMenuItem
            // 
            this.writeNewKeyToFileToolStripMenuItem.Name = "writeNewKeyToFileToolStripMenuItem";
            this.writeNewKeyToFileToolStripMenuItem.Size = new System.Drawing.Size(305, 34);
            this.writeNewKeyToFileToolStripMenuItem.Text = "Write New Key To File";
            this.writeNewKeyToFileToolStripMenuItem.Click += new System.EventHandler(this.writeNewKeyToFileToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keyFrom,
            this.fileOptions});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(98, 34);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // keyFrom
            // 
            this.keyFrom.Items.AddRange(new object[] {
            "Use Key From Memory",
            "Use Key From File"});
            this.keyFrom.Name = "keyFrom";
            this.keyFrom.Size = new System.Drawing.Size(121, 38);
            this.keyFrom.SelectedIndexChanged += new System.EventHandler(this.selectKeyFile);
            // 
            // fileOptions
            // 
            this.fileOptions.Items.AddRange(new object[] {
            "Overwrite Existing File",
            "Create Duplicate File"});
            this.fileOptions.Name = "fileOptions";
            this.fileOptions.Size = new System.Drawing.Size(121, 38);
            this.fileOptions.SelectedIndexChanged += new System.EventHandler(this.selectDuplicate);
            // 
            // log
            // 
            this.log.Enabled = false;
            this.log.Location = new System.Drawing.Point(0, 41);
            this.log.Name = "log";
            this.log.ReadOnly = true;
            this.log.Size = new System.Drawing.Size(800, 408);
            this.log.TabIndex = 3;
            this.log.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // otp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.log);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "otp";
            this.Text = "One Time Pad";
            this.Load += new System.EventHandler(this.otp_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem encryptDecryptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateNewKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openKeyFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writeKeyToFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writeNewKeyToFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox keyFrom;
        private System.Windows.Forms.ToolStripComboBox fileOptions;
        private System.Windows.Forms.RichTextBox log;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

