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
    public partial class LogText : BaseForm
    {
        private bool isValid;

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
               if (Validate())
                {
                    try
                    {
                        FileLog.LogEvent(txtDescription.Text, txtUsId.Text, txtLength.Text);
                        //FileLog.LogEventCSV(txtDescription.Text, txtUsId.Text, txtLength.Text);

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
                
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
                this.Close();
            }

        }

        private void txtUsId_TextChanged(object sender, EventArgs e)
        {
            ValidateNumeric(txtUsId);
        }

        private void txtLength_TextChanged(object sender, EventArgs e)
        {
            ValidateNumeric(txtLength);
        }

        private bool Validate()
        {
            bool isValid = true;
            isValid = (ValidateNumeric(txtLength)) ? isValid : false;
            isValid = (ValidateNumeric(txtUsId)) ? isValid : false;

            return isValid;
        }

        private bool ValidateNumeric(TextBox txtBox)
        {
            txtBox.BackColor = Color.White;
            // If not (either all whitepace OR a number), show pink background
            if (!(string.IsNullOrWhiteSpace(txtBox.Text) || decimal.TryParse(txtBox.Text, out decimal eventLength)))
            {
                txtBox.BackColor = Color.FromArgb(255, 232, 232);
                return false;
            }
            return true;
        }
    }
}
