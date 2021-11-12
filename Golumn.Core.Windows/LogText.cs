using Golumn.Core.LogFile;
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
    public partial class LogText : Form
    {
        public LogText()
        {
            InitializeComponent();
        }

        private void txtUsId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
                this.Close();
            }
        }

        private void txtLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
                this.Close();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                try
                {
                    //FileLog.LogEvent(txtDescription.Text, txtUsId.Text, txtLength.Text);
                    FileLog.LogEventCSV(txtDescription.Text, txtUsId.Text, txtLength.Text);

                    e.Handled = true;

                    this.Close();
                }
                catch (Exception ex)
                {
                    var text = txtDescription.Text;

                    var dateNow = DateTime.Now.ToString("MM/dd/yy HH:mm");
                    Console.WriteLine($"{dateNow}, {ex.Message}");

                    txtDescription.Text = "";
                }
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
                this.Close();
            }

        }
    }
}
