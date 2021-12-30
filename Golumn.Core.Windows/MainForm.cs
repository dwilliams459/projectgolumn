using Golumn.Core.Service;
using Microsoft.Win32;
using PR.Ado.Core.Domain;
using Shortcut;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Golumn.Core.Windows
{
    public partial class MainForm : Form
    {
        private readonly HotkeyBinder hotkeyBinder = new HotkeyBinder();
        private readonly RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\WinGlmCore");

        // toggle
        private readonly string registryKeyName = "Hotkey";
        private Hotkey hotkey;

        private bool myVisible;
        public bool MyVisible
        {
            get { return myVisible; }
            set { myVisible = value; Visible = value; }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MyHide()
        {
            ShowInTaskbar = false;
            Location = new Point(-10000, -10000);
            MyVisible = false;
        }

        private void MyShow()
        {
            MyVisible = true;
            ShowInTaskbar = true;
            CenterToScreen();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MyHide();

            // toggle
            var hotkeyValue = registryKey.GetValue(registryKeyName);
            if (hotkeyValue == null || String.IsNullOrEmpty(hotkeyValue.ToString()))
            {
                hotkeyValue = "None, Scroll";
            }

            if (hotkeyValue != null)
            {
                try
                {
                    var converter = new Shortcut.Forms.HotkeyConverter();
                    hotkey = (Hotkey)converter.ConvertFromString(hotkeyValue.ToString());
                    if (!hotkeyBinder.IsHotkeyAlreadyBound(hotkey)) hotkeyBinder.Bind(hotkey).To(ShowLogText);
                }
                catch (Exception)
                {
                }
            }
        }

        public async void ShowLogText()
        {
            try
            {
                var logForm = new LogText();
                logForm.ShowDialog();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception showing log: " + ex.Message);
            }
        }

        private void icon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ShowLogText();
            }
        }

        private void hotkeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // toggle
            if (hotkey != null)
            {
                hotkeyTextBox.Hotkey = hotkey;
                if (hotkeyBinder.IsHotkeyAlreadyBound(hotkey)) hotkeyBinder.Unbind(hotkey);
            }

            MyShow();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MyVisible)
            {
                MyHide();
                e.Cancel = true;

                hotkey = hotkeyTextBox.Hotkey;

                if (hotkey == null)
                {
                    registryKey.DeleteValue(registryKeyName, false);
                }
                else
                {
                    if (!hotkeyBinder.IsHotkeyAlreadyBound(hotkey))
                    {
                        registryKey.SetValue(registryKeyName, hotkey);
                        if (!hotkeyBinder.IsHotkeyAlreadyBound(hotkey)) hotkeyBinder.Bind(hotkey).To(ShowLogText);
                    }
                }
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            hotkeyTextBox.Hotkey = null;
            hotkeyTextBox.Text = "None";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var viewLogForm = new ViewLog();
            viewLogForm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void hotkeyTextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void hotkeyTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private async void generateTimesheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var timeEntryReport = new TimeReportService();
            await timeEntryReport.GetWorkItemsAndWriteCSVFile(new Options { CSV = true });
        }

        private async void generateTimesheetToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }
    }
}
