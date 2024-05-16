using System.Drawing;
using System.Windows.Forms;

namespace WinClipboard;

partial class Form2
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        button1 = new Button();
        button2 = new Button();
        SuspendLayout();
        // 
        // button1
        // 
        button1.FlatStyle = FlatStyle.Flat;
        button1.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
        button1.Location = new Point(1, 1);
        button1.Name = "button1";
        button1.Size = new Size(22, 20);
        button1.TabIndex = 0;
        button1.Text = "C";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // button2
        // 
        button2.FlatStyle = FlatStyle.Flat;
        button2.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
        button2.Location = new Point(22, 1);
        button2.Name = "button2";
        button2.Size = new Size(22, 20);
        button2.TabIndex = 1;
        button2.Text = "X";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // Form2
        // 
        ClientSize = new Size(66, 22);
        Controls.Add(button2);
        Controls.Add(button1);
        FormBorderStyle = FormBorderStyle.None;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "Form2";
        ShowIcon = false;
        TopMost = true;
        Load += Form2_Load;
        ResumeLayout(false);
    }

    #endregion

    private Button button1;
    private Button button2;
    private Button button3;
}
