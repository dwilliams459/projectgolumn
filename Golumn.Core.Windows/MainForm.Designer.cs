
namespace Golumn.Core.Windows
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            label1 = new System.Windows.Forms.Label();
            buttonReset = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            iconContextMenu = new System.Windows.Forms.ContextMenuStrip(components);
            logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            hotkeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            viewLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            pullRequestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            viewAlertsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            generateTimesheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            icon = new System.Windows.Forms.NotifyIcon(components);
            hotkeyTextBox = new Shortcut.Forms.HotkeyTextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            iconContextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(148, 21);
            label1.TabIndex = 0;
            label1.Text = "Hotkey for open log";
            // 
            // buttonReset
            // 
            buttonReset.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            buttonReset.Location = new System.Drawing.Point(176, 33);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new System.Drawing.Size(75, 27);
            buttonReset.TabIndex = 2;
            buttonReset.Text = "Reset";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += buttonReset_Click;
            // 
            // button1
            // 
            button1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button1.Location = new System.Drawing.Point(176, 66);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 27);
            button1.TabIndex = 3;
            button1.Text = "Ok";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // iconContextMenu
            // 
            iconContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { logToolStripMenuItem, hotkeyToolStripMenuItem, viewLogToolStripMenuItem, pullRequestsToolStripMenuItem, viewAlertsToolStripMenuItem, toolStripMenuItem1, toolStripMenuItem2, generateTimesheetToolStripMenuItem, exitToolStripMenuItem });
            iconContextMenu.Name = "iconContextMenu";
            iconContextMenu.Size = new System.Drawing.Size(181, 224);
            iconContextMenu.Opening += iconContextMenu_Opening;
            // 
            // logToolStripMenuItem
            // 
            logToolStripMenuItem.Name = "logToolStripMenuItem";
            logToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            logToolStripMenuItem.Text = "Log";
            logToolStripMenuItem.Click += logToolStripMenuItem_Click;
            // 
            // hotkeyToolStripMenuItem
            // 
            hotkeyToolStripMenuItem.Name = "hotkeyToolStripMenuItem";
            hotkeyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            hotkeyToolStripMenuItem.Text = "Hotkey";
            hotkeyToolStripMenuItem.Click += hotkeyToolStripMenuItem_Click;
            // 
            // viewLogToolStripMenuItem
            // 
            viewLogToolStripMenuItem.Name = "viewLogToolStripMenuItem";
            viewLogToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            viewLogToolStripMenuItem.Text = "Edit Log";
            viewLogToolStripMenuItem.Click += viewLogToolStripMenuItem_Click;
            // 
            // pullRequestsToolStripMenuItem
            // 
            pullRequestsToolStripMenuItem.Name = "pullRequestsToolStripMenuItem";
            pullRequestsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            pullRequestsToolStripMenuItem.Text = "Pull Requests";
            pullRequestsToolStripMenuItem.Click += pullRequestsToolStripMenuItem_Click;
            // 
            // viewAlertsToolStripMenuItem
            // 
            viewAlertsToolStripMenuItem.Name = "viewAlertsToolStripMenuItem";
            viewAlertsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            viewAlertsToolStripMenuItem.Text = "View Alerts";
            viewAlertsToolStripMenuItem.Click += viewAlertsToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            toolStripMenuItem1.Text = "Clean Clipboard";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // generateTimesheetToolStripMenuItem
            // 
            generateTimesheetToolStripMenuItem.Name = "generateTimesheetToolStripMenuItem";
            generateTimesheetToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            generateTimesheetToolStripMenuItem.Text = "Generate Timesheet";
            generateTimesheetToolStripMenuItem.Click += generateTimesheetToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // icon
            // 
            icon.ContextMenuStrip = iconContextMenu;
            icon.Icon = (System.Drawing.Icon)resources.GetObject("icon.Icon");
            icon.Text = "notifyIcon1";
            icon.Visible = true;
            icon.MouseClick += icon_MouseClick;
            // 
            // hotkeyTextBox
            // 
            hotkeyTextBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            hotkeyTextBox.Hotkey = null;
            hotkeyTextBox.Location = new System.Drawing.Point(12, 33);
            hotkeyTextBox.Name = "hotkeyTextBox";
            hotkeyTextBox.Size = new System.Drawing.Size(133, 27);
            hotkeyTextBox.TabIndex = 4;
            hotkeyTextBox.Text = "None";
            hotkeyTextBox.KeyDown += hotkeyTextBox_KeyDown;
            hotkeyTextBox.KeyPress += hotkeyTextBox_KeyPress;
            // 
            // timer1
            // 
            timer1.Interval = 990;
            timer1.Tick += timer1_Tick;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            toolStripMenuItem2.Text = "Open Toolbar";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(264, 105);
            Controls.Add(hotkeyTextBox);
            Controls.Add(button1);
            Controls.Add(buttonReset);
            Controls.Add(label1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "MainForm";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            iconContextMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip iconContextMenu;
        private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hotkeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pullRequestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private Shortcut.Forms.HotkeyTextBox hotkeyTextBox;
        public System.Windows.Forms.NotifyIcon icon;
        private System.Windows.Forms.ToolStripMenuItem generateTimesheetToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem viewAlertsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}