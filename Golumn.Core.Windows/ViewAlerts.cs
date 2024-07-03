using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PR.Ado.Core.Domain;
using Golumn.Core.Domain;
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
using System.Globalization;
using Golumn.Core.Domain;

namespace Golumn.Core.Windows
{
    public partial class ViewAlerts : Form
    {
        private IConfigurationRoot _config;
        private List<Alert> alerts;

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
                //richTextBox1.Text = alertsText;

                //richTextBox1.VisibleChanged += (sender, e) =>
                //{
                //    if (richTextBox1.Visible)
                //    {
                //        richTextBox1.SelectionLength = 0;
                //        richTextBox1.SelectionStart = richTextBox1.Text.Length;
                //        richTextBox1.ScrollToCaret();
                //    }
                //};

                dataGridView1.CellContentClick += DataGridView_CellContentClick;
                // Add ColumnHeaderMouseClick event handler
                dataGridView1.ColumnHeaderMouseClick += DataGridView_ColumnHeaderMouseClick;

                LoadCalendarEventsFromJson();
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

        private void LoadCalendarEventsFromJson()
        {
            string jsonFilePath = _config.GetValue<string>("alertsfilename"); // Replace with your JSON file path

            // Read JSON file content
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Deserialize JSON content to List<CalendarEvent>
            alerts = JsonConvert.DeserializeObject<List<Alert>>(jsonContent);

            // Set DataGridView DataSource
            this.dataGridView1.DataSource = alerts;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                label1.Text = string.Empty;

                DialogResult dialogResult = MessageBox.Show("Save Alerts?", "Save Alerts", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    var alertText = JsonConvert.SerializeObject(alerts, Formatting.Indented);
                    File.WriteAllText(_config.GetValue<string>("alertsfilename"), alertText);

                    //File.WriteAllText(_config.GetValue<string>("alertsfilename"), richTextBox1.Text);
                }

                MainForm.Instance.Alerts = MainForm.Instance.AlertService.ReadAlertsFromFile(_config.GetValue<string>("alertsfilename"));

                LoadCalendarEventsFromJson();
            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;

            }
        }

        private void DataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "AlertDateTime" || dataGridView1.Columns[e.ColumnIndex].Name == "AlertEndTime")
            {
                DateTime temp;
                if (!string.IsNullOrEmpty(e.FormattedValue.ToString()) && !DateTime.TryParse(e.FormattedValue.ToString(), out temp))
                {
                    dataGridView1.Rows[e.RowIndex].ErrorText = "Invalid date format";
                    e.Cancel = true;
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].ErrorText = string.Empty;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Get the clicked column
            DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];

            // Toggle the sort direction
            column.HeaderCell.SortGlyphDirection = column.HeaderCell.SortGlyphDirection == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;

            // Sort the DataGridView by the selected column
            dataGridView1.Sort(column, column.HeaderCell.SortGlyphDirection == SortOrder.Ascending ? System.ComponentModel.ListSortDirection.Ascending : System.ComponentModel.ListSortDirection.Descending);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Create a new CalendarEvent
            Alert newEvent = new Alert();

            // Add the new CalendarEvent to the list
            alerts.Add(newEvent);

            // Refresh the DataGridView
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = alerts;
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is a DataGridViewButtonCell
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                // Get the selected CalendarEvent
                Alert selectedEvent = (Alert)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                // Remove the selected CalendarEvent from the list
                alerts.Remove(selectedEvent);

                // Refresh the DataGridView
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = alerts;
            }
        }



        private void ViewAlerts_Load(object sender, EventArgs e)
        {

        }

        private void alertBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
