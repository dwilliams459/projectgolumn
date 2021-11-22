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
    public partial class ViewLog : BaseForm
    {
        public ViewLog()
        {
            InitializeComponent();

            try
            {
                if (!File.Exists(ConfigurationManager.AppSettings["filename"]))
                {
                    File.Create(ConfigurationManager.AppSettings["filename"]);
                }

                var logText = File.ReadAllText(ConfigurationManager.AppSettings["filename"]);
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
                        File.WriteAllText(ConfigurationManager.AppSettings["filename"], textBox1.Text);
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
