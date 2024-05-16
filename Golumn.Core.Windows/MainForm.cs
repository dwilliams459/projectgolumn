using Golumn.Core.Domain;
using Golumn.Core.Service;
using Microsoft.Win32;
using Newtonsoft.Json;
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
using WinClipboard;

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

        public static MainForm Instance;

        public List<Alert> Alerts { get; set; } = new List<Alert>();
        public AlertService AlertService { get; private set; } = new AlertService();

        public MainForm()
        {
            InitializeComponent();
            Instance = this;
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

            try
            {
                // Setup Alerts
                Alerts = this.AlertService.ReadAlertsFromFile("alerts.json");

                timer1 = new Timer(this.components);
                timer1.Tick += Timer1_Tick;
                timer1.Interval = 10000;

                timer1.Start();
            }
            catch (Exception)
            {
                // Ignored because no alert file found does not cause and issue. 
            }

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

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this.Alerts?.ForEach(alert =>
            {
                if (this.AlertService.AlertMatch(alert))
                {
                    string alertMessage = $"Alert: {alert.Title} \nDate Time: {alert.AlertDateTime.ToString("M/d h:mm tt")} \nRepeat: {alert.Repeat} \nDays of Week: {alert.DaysOfWeek()} ";
                    MessageBox.Show(alertMessage, alert.Title, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                    // Sleep for 1 second
                    System.Threading.Thread.Sleep(60000);
                    timer1.Enabled = true;
                    return;
                }
            });

            timer1.Enabled = true;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") == DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"))
            {
                MessageBox.Show("Alert");
                // Sleep for 1 second
                System.Threading.Thread.Sleep(800);
                timer1.Enabled = true;
                return;
            }
        }

        private void pullRequestsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewAlertsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var viewAlertsForm = new ViewAlerts();
            viewAlertsForm.ShowDialog();
        }

        private void iconContextMenu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var text = Clipboard.GetText();
            text = text.Replace(Environment.NewLine, string.Empty);
            SetClipboardText(text);
        }

        private void SetClipboardText(string text)
        {
            for (int i = 0; i < 10; i++) // Retry 10 times
            {
                try
                {
                    Clipboard.SetText(text);
                    break; // If successful, break the loop
                }
                catch (System.Runtime.InteropServices.ExternalException)
                {
                    System.Threading.Thread.Sleep(10); // Wait for the clipboard to be available
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
