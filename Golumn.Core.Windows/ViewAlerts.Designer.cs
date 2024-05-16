
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
            alertBindingSource = new System.Windows.Forms.BindingSource(components);
            calendarEventBindingSource = new System.Windows.Forms.BindingSource(components);
            button3 = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)alertBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)calendarEventBindingSource).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            button2.Location = new System.Drawing.Point(694, 413);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(75, 23);
            button2.TabIndex = 1;
            button2.Text = "Save";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            button1.Location = new System.Drawing.Point(778, 413);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 2;
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
            dataGridView1.Size = new System.Drawing.Size(841, 396);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
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
            button3.Location = new System.Drawing.Point(12, 413);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(75, 23);
            button3.TabIndex = 6;
            button3.Text = "Add";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
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
            // ViewAlerts
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(865, 448);
            Controls.Add(button3);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(button2);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "ViewAlerts";
            Text = "ViewAlerts";
            Load += ViewAlerts_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)alertBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)calendarEventBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
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
    }
}