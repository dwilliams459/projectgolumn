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
    public partial class ViewLog : Form
    {
        private IConfigurationRoot _config;

        public ViewLog()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();

            InitializeComponent();

            try
            {
                if (!File.Exists(_config.GetValue<string>("logFilename")))
                {
                    File.Create(_config.GetValue<string>("logFilename")); // ConfigurationManager.AppSettings["logFilename"]) ;
                }

                var logText = File.ReadAllText(_config.GetValue<string>("logFilename"));
                textBox1.Text = logText;

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
                    DialogResult dialogResult = MessageBox.Show("Save Log?", "Save Log", MessageBoxButtons.OKCancel);
                    if (dialogResult == DialogResult.OK)
                    {
                        File.WriteAllText(_config.GetValue<string>("logFilename"), textBox1.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;

            }
        }
    }
}
