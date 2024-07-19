﻿
using PR.Ado.Core.Domain;

namespace Golumn.Core.Windows
{
    partial class ViewAlerts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewAlerts));
            button2 = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            AlertDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            AlertEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Repeat = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            Monday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            Tuesday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            Wednesday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            Thursday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            Friday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            alertBindingSource = new System.Windows.Forms.BindingSource(components);
            calendarEventBindingSource = new System.Windows.Forms.BindingSource(components);
            button3 = new System.Windows.Forms.Button();
            button4 = new System.Windows.Forms.Button();
            newEventDatePicker = new System.Windows.Forms.DateTimePicker();
            groupBox1 = new System.Windows.Forms.GroupBox();
            newEventTimeMin = new System.Windows.Forms.ComboBox();
            newEventTimeHour = new System.Windows.Forms.ComboBox();
            ddlNewEventAmPm = new System.Windows.Forms.ComboBox();
            txtNewEventDescription = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)alertBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)calendarEventBindingSource).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            button2.Location = new System.Drawing.Point(786, 454);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "Save";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            button1.Location = new System.Drawing.Point(867, 454);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "Close";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.Color.Maroon;
            label1.Location = new System.Drawing.Point(12, 656);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(0, 15);
            label1.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Delete, titleDataGridViewTextBoxColumn, AlertDateTime, AlertEndTime, Repeat, Monday, Tuesday, Wednesday, Thursday, Friday });
            dataGridView1.DataSource = alertBindingSource;
            dataGridView1.Location = new System.Drawing.Point(12, 11);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new System.Drawing.Size(930, 430);
            dataGridView1.TabIndex = 7;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Delete
            // 
            Delete.HeaderText = " -";
            Delete.MinimumWidth = 25;
            Delete.Name = "Delete";
            Delete.Text = " -";
            Delete.ToolTipText = "Delete";
            Delete.UseColumnTextForButtonValue = true;
            Delete.Width = 25;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            titleDataGridViewTextBoxColumn.HeaderText = "Title";
            titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            titleDataGridViewTextBoxColumn.Width = 300;
            // 
            // AlertDateTime
            // 
            AlertDateTime.DataPropertyName = "AlertDateTime";
            AlertDateTime.HeaderText = "AlertDateTime";
            AlertDateTime.Name = "AlertDateTime";
            AlertDateTime.Width = 120;
            // 
            // AlertEndTime
            // 
            AlertEndTime.DataPropertyName = "AlertEndTime";
            AlertEndTime.HeaderText = "AlertEndTime";
            AlertEndTime.Name = "AlertEndTime";
            AlertEndTime.Width = 120;
            // 
            // Repeat
            // 
            Repeat.DataPropertyName = "Repeat";
            Repeat.HeaderText = "Repeat";
            Repeat.Name = "Repeat";
            Repeat.Width = 50;
            // 
            // Monday
            // 
            Monday.DataPropertyName = "Monday";
            Monday.HeaderText = " M";
            Monday.Name = "Monday";
            Monday.Width = 33;
            // 
            // Tuesday
            // 
            Tuesday.DataPropertyName = "Tuesday";
            Tuesday.HeaderText = " T";
            Tuesday.Name = "Tuesday";
            Tuesday.Width = 33;
            // 
            // Wednesday
            // 
            Wednesday.DataPropertyName = "Wednesday";
            Wednesday.HeaderText = " W";
            Wednesday.Name = "Wednesday";
            Wednesday.Width = 33;
            // 
            // Thursday
            // 
            Thursday.DataPropertyName = "Thursday";
            Thursday.HeaderText = " T";
            Thursday.Name = "Thursday";
            Thursday.Width = 33;
            // 
            // Friday
            // 
            Friday.DataPropertyName = "Friday";
            Friday.HeaderText = " F";
            Friday.Name = "Friday";
            Friday.Width = 33;
            // 
            // alertBindingSource
            // 
            alertBindingSource.DataSource = typeof(Domain.Alert);
            alertBindingSource.CurrentChanged += alertBindingSource_CurrentChanged;
            // 
            // calendarEventBindingSource
            // 
            calendarEventBindingSource.DataSource = typeof(CalendarEvent);
            // 
            // button3
            // 
            button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            button3.Location = new System.Drawing.Point(12, 454);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(75, 23);
            button3.TabIndex = 0;
            button3.Text = "Add Blank";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            button4.Location = new System.Drawing.Point(591, 15);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(75, 23);
            button4.TabIndex = 5;
            button4.Text = "Add Event";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // newEventDatePicker
            // 
            newEventDatePicker.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            newEventDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            newEventDatePicker.Location = new System.Drawing.Point(6, 15);
            newEventDatePicker.Name = "newEventDatePicker";
            newEventDatePicker.Size = new System.Drawing.Size(110, 23);
            newEventDatePicker.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            groupBox1.Controls.Add(newEventTimeMin);
            groupBox1.Controls.Add(newEventTimeHour);
            groupBox1.Controls.Add(ddlNewEventAmPm);
            groupBox1.Controls.Add(txtNewEventDescription);
            groupBox1.Controls.Add(newEventDatePicker);
            groupBox1.Controls.Add(button4);
            groupBox1.Location = new System.Drawing.Point(94, 440);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(672, 44);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // newEventTimeMin
            // 
            newEventTimeMin.FormattingEnabled = true;
            newEventTimeMin.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" });
            newEventTimeMin.Location = new System.Drawing.Point(181, 15);
            newEventTimeMin.Name = "newEventTimeMin";
            newEventTimeMin.Size = new System.Drawing.Size(44, 23);
            newEventTimeMin.TabIndex = 2;
            // 
            // newEventTimeHour
            // 
            newEventTimeHour.FormattingEnabled = true;
            newEventTimeHour.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
            newEventTimeHour.Location = new System.Drawing.Point(122, 15);
            newEventTimeHour.Name = "newEventTimeHour";
            newEventTimeHour.Size = new System.Drawing.Size(53, 23);
            newEventTimeHour.TabIndex = 1;
            // 
            // ddlNewEventAmPm
            // 
            ddlNewEventAmPm.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
            ddlNewEventAmPm.FormattingEnabled = true;
            ddlNewEventAmPm.Items.AddRange(new object[] { "AM", "PM" });
            ddlNewEventAmPm.Location = new System.Drawing.Point(231, 15);
            ddlNewEventAmPm.Name = "ddlNewEventAmPm";
            ddlNewEventAmPm.Size = new System.Drawing.Size(43, 23);
            ddlNewEventAmPm.TabIndex = 3;
            // 
            // txtNewEventDescription
            // 
            txtNewEventDescription.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtNewEventDescription.Location = new System.Drawing.Point(294, 15);
            txtNewEventDescription.Name = "txtNewEventDescription";
            txtNewEventDescription.Size = new System.Drawing.Size(291, 23);
            txtNewEventDescription.TabIndex = 4;
            // 
            // ViewAlerts
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(954, 489);
            Controls.Add(dataGridView1);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(groupBox1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "ViewAlerts";
            Text = "ViewAlerts";
            Load += ViewAlerts_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)alertBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)calendarEventBindingSource).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtNewEventDescription;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource calendarEventBindingSource;
        private System.Windows.Forms.BindingSource alertBindingSource;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlertDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlertEndTime;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Repeat;
        private System.Windows.Forms.DataGridViewTextBoxColumn DaysOfWeek;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Monday;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Tuesday;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Wednesday;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Thursday;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Friday;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DateTimePicker newEventDatePicker;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox ddlNewEventAmPm;
        private System.Windows.Forms.ComboBox newEventTimeMin;
        private System.Windows.Forms.ComboBox newEventTimeHour;
    }
}