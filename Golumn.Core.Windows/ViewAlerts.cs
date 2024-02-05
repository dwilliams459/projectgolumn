using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Golumn.Core.Windows
{
    public partial class ViewAlerts : Form
    {
        private IConfigurationRoot _config;

        public ViewAlerts()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();

            InitializeComponent();

            try
            {
                if (!File.Exists(_config.GetValue<string>("alertsfilename")))
                {
                    File.Create(_config.GetValue<string>("alertsfilename")); // ConfigurationManager.AppSettings["logFilename"]) ;
                }

                var alertsText = File.ReadAllText(_config.GetValue<string>("alertsfilename"));
                textBox1.Text = alertsText;

                textBox1.VisibleChanged += (sender, e) =>
                {
                    if (textBox1.Visible)
                    {
                        textBox1.SelectionLength = 0;
                        textBox1.SelectionStart = textBox1.Text.Length;
                        textBox1.ScrollToCaret();
                    }
                };
            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    label1.Text = "No text to save";
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Save Alerts?", "Save Alerts", MessageBoxButtons.OKCancel);
                    if (dialogResult == DialogResult.OK)
                    {
                        File.WriteAllText(_config.GetValue<string>("alertsfilename"), textBox1.Text);
                    }

                    MainForm.Instance.Alerts = MainForm.Instance.AlertService.ReadAlertsFromFile(_config.GetValue<string>("alertsfilename"));
                }
            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;

            }
        }
    }
}
