namespace Hourly_Reminder
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.TrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TrayEnableBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.TrayShowBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.TraySeparator = new System.Windows.Forms.ToolStripSeparator();
            this.TrayExitBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.LabelMinute = new System.Windows.Forms.Label();
            this.TxtMinute = new System.Windows.Forms.TextBox();
            this.LabelMsg = new System.Windows.Forms.Label();
            this.TxtMsg = new System.Windows.Forms.TextBox();
            this.BtnApply = new System.Windows.Forms.Button();
            this.BtnTest = new System.Windows.Forms.Button();
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.BoxAutoStart = new System.Windows.Forms.CheckBox();
            this.BoxStartHidden = new System.Windows.Forms.CheckBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnReset = new System.Windows.Forms.Button();
            this.LabelAuthor = new System.Windows.Forms.LinkLabel();
            this.TrayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TrayMenu
            // 
            this.TrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TrayEnableBtn,
            this.TrayShowBtn,
            this.TraySeparator,
            this.TrayExitBtn});
            this.TrayMenu.Name = "TrayMenu";
            this.TrayMenu.Size = new System.Drawing.Size(110, 76);
            // 
            // TrayEnableBtn
            // 
            this.TrayEnableBtn.Checked = true;
            this.TrayEnableBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TrayEnableBtn.Name = "TrayEnableBtn";
            this.TrayEnableBtn.Size = new System.Drawing.Size(109, 22);
            this.TrayEnableBtn.Text = "Enable";
            this.TrayEnableBtn.Click += new System.EventHandler(this.TrayEnableBtn_Click);
            // 
            // TrayShowBtn
            // 
            this.TrayShowBtn.Name = "TrayShowBtn";
            this.TrayShowBtn.Size = new System.Drawing.Size(109, 22);
            this.TrayShowBtn.Text = "Show";
            this.TrayShowBtn.Click += new System.EventHandler(this.TrayShowBtn_Click);
            // 
            // TraySeparator
            // 
            this.TraySeparator.Name = "TraySeparator";
            this.TraySeparator.Size = new System.Drawing.Size(106, 6);
            // 
            // TrayExitBtn
            // 
            this.TrayExitBtn.Name = "TrayExitBtn";
            this.TrayExitBtn.Size = new System.Drawing.Size(109, 22);
            this.TrayExitBtn.Text = "Exit";
            this.TrayExitBtn.Click += new System.EventHandler(this.TrayExitBtn_Click);
            // 
            // TrayIcon
            // 
            this.TrayIcon.ContextMenuStrip = this.TrayMenu;
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "Hourly Reminder";
            this.TrayIcon.Visible = true;
            this.TrayIcon.DoubleClick += new System.EventHandler(this.TrayShowBtn_Click);
            // 
            // LabelMinute
            // 
            this.LabelMinute.AutoSize = true;
            this.LabelMinute.Location = new System.Drawing.Point(12, 40);
            this.LabelMinute.Name = "LabelMinute";
            this.LabelMinute.Size = new System.Drawing.Size(99, 13);
            this.LabelMinute.TabIndex = 0;
            this.LabelMinute.Text = "Minute of the hour: ";
            // 
            // TxtMinute
            // 
            this.TxtMinute.Location = new System.Drawing.Point(155, 37);
            this.TxtMinute.Name = "TxtMinute";
            this.TxtMinute.Size = new System.Drawing.Size(217, 20);
            this.TxtMinute.TabIndex = 4;
            this.TxtMinute.Text = "0";
            this.TxtMinute.TextChanged += new System.EventHandler(this.SettingsUpdate);
            // 
            // LabelMsg
            // 
            this.LabelMsg.AutoSize = true;
            this.LabelMsg.Location = new System.Drawing.Point(12, 69);
            this.LabelMsg.Name = "LabelMsg";
            this.LabelMsg.Size = new System.Drawing.Size(56, 13);
            this.LabelMsg.TabIndex = 0;
            this.LabelMsg.Text = "Message: ";
            // 
            // TxtMsg
            // 
            this.TxtMsg.Location = new System.Drawing.Point(77, 66);
            this.TxtMsg.Multiline = true;
            this.TxtMsg.Name = "TxtMsg";
            this.TxtMsg.Size = new System.Drawing.Size(295, 95);
            this.TxtMsg.TabIndex = 5;
            this.TxtMsg.Text = "This is an hourly reminder. ";
            this.TxtMsg.TextChanged += new System.EventHandler(this.SettingsUpdate);
            this.TxtMsg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtMsg_KeyDown);
            // 
            // BtnApply
            // 
            this.BtnApply.Location = new System.Drawing.Point(77, 168);
            this.BtnApply.Name = "BtnApply";
            this.BtnApply.Size = new System.Drawing.Size(112, 48);
            this.BtnApply.TabIndex = 8;
            this.BtnApply.Text = "Apply";
            this.BtnApply.UseVisualStyleBackColor = true;
            this.BtnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // BtnTest
            // 
            this.BtnTest.Location = new System.Drawing.Point(195, 168);
            this.BtnTest.Name = "BtnTest";
            this.BtnTest.Size = new System.Drawing.Size(112, 48);
            this.BtnTest.TabIndex = 9;
            this.BtnTest.Text = "Test";
            this.BtnTest.UseVisualStyleBackColor = true;
            this.BtnTest.Click += new System.EventHandler(this.BtnTest_Click);
            // 
            // MainTimer
            // 
            this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
            // 
            // BoxAutoStart
            // 
            this.BoxAutoStart.AutoSize = true;
            this.BoxAutoStart.Location = new System.Drawing.Point(14, 14);
            this.BoxAutoStart.Name = "BoxAutoStart";
            this.BoxAutoStart.Size = new System.Drawing.Size(117, 17);
            this.BoxAutoStart.TabIndex = 1;
            this.BoxAutoStart.Text = "Start with Windows";
            this.BoxAutoStart.UseVisualStyleBackColor = true;
            this.BoxAutoStart.CheckedChanged += new System.EventHandler(this.SettingsUpdate);
            // 
            // BoxStartHidden
            // 
            this.BoxStartHidden.AutoSize = true;
            this.BoxStartHidden.Location = new System.Drawing.Point(155, 13);
            this.BoxStartHidden.Name = "BoxStartHidden";
            this.BoxStartHidden.Size = new System.Drawing.Size(83, 17);
            this.BoxStartHidden.TabIndex = 2;
            this.BoxStartHidden.Text = "Start hidden";
            this.BoxStartHidden.UseVisualStyleBackColor = true;
            this.BoxStartHidden.CheckedChanged += new System.EventHandler(this.SettingsUpdate);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(12, 168);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(59, 48);
            this.BtnCancel.TabIndex = 7;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnReset
            // 
            this.BtnReset.Location = new System.Drawing.Point(313, 168);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(59, 48);
            this.BtnReset.TabIndex = 10;
            this.BtnReset.Text = "Reset";
            this.BtnReset.UseVisualStyleBackColor = true;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // LabelAuthor
            // 
            this.LabelAuthor.AutoSize = true;
            this.LabelAuthor.Location = new System.Drawing.Point(283, 14);
            this.LabelAuthor.Name = "LabelAuthor";
            this.LabelAuthor.Size = new System.Drawing.Size(91, 13);
            this.LabelAuthor.TabIndex = 3;
            this.LabelAuthor.TabStop = true;
            this.LabelAuthor.Text = "By jspenguin2017";
            this.LabelAuthor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LabelAuthor_LinkClicked);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 229);
            this.Controls.Add(this.LabelAuthor);
            this.Controls.Add(this.BtnReset);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BoxStartHidden);
            this.Controls.Add(this.BoxAutoStart);
            this.Controls.Add(this.BtnTest);
            this.Controls.Add(this.BtnApply);
            this.Controls.Add(this.TxtMsg);
            this.Controls.Add(this.LabelMsg);
            this.Controls.Add(this.TxtMinute);
            this.Controls.Add(this.LabelMinute);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 268);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hourly Reminder Settings";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            this.Load += new System.EventHandler(this.Form_Load);
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.TrayMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip TrayMenu;
        private System.Windows.Forms.ToolStripMenuItem TrayShowBtn;
        private System.Windows.Forms.ToolStripMenuItem TrayExitBtn;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.ToolStripSeparator TraySeparator;
        private System.Windows.Forms.Label LabelMinute;
        private System.Windows.Forms.TextBox TxtMinute;
        private System.Windows.Forms.Label LabelMsg;
        private System.Windows.Forms.TextBox TxtMsg;
        private System.Windows.Forms.Button BtnApply;
        private System.Windows.Forms.Button BtnTest;
        private System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.CheckBox BoxAutoStart;
        private System.Windows.Forms.CheckBox BoxStartHidden;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.ToolStripMenuItem TrayEnableBtn;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.LinkLabel LabelAuthor;
    }
}
