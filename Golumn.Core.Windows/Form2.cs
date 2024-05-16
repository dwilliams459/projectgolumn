using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinClipboard;

public partial class Form2 : Form
{
    private bool dragging = false;
    private Point dragCursorPoint;
    private Point dragFormPoint;

    public Form2()
    {
        InitializeComponent();
        this.FormBorderStyle = FormBorderStyle.None;
        this.Text = "";

        this.MouseDown += new MouseEventHandler(FormWithMinimalTitleBar_MouseDown);
        this.MouseMove += new MouseEventHandler(FormWithMinimalTitleBar_MouseMove);
        this.MouseUp += new MouseEventHandler(FormWithMinimalTitleBar_MouseUp);
        this.Padding = new Padding(0);
        this.Margin = new Padding(0);

        //this.ClientSize = new System.Drawing.Size(150, 5);
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

    private void button1_Click(object sender, EventArgs e)
    {
        var text = Clipboard.GetText();
        text = text.Replace(Environment.NewLine, string.Empty);
        SetClipboardText(text);
    }

    private void button2_Click(object sender, EventArgs e)
    {
        this.Close();

    }

    void FormWithMinimalTitleBar_MouseDown(object sender, MouseEventArgs e)
    {
        dragging = true;
        dragCursorPoint = Cursor.Position;
        dragFormPoint = this.Location;
    }

    void FormWithMinimalTitleBar_MouseMove(object sender, MouseEventArgs e)
    {
        if (dragging)
        {
            Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
            this.Location = Point.Add(dragFormPoint, new Size(dif));
        }
    }

    void FormWithMinimalTitleBar_MouseUp(object sender, MouseEventArgs e)
    {
        dragging = false;
    }

    private void button3_MouseDown(object sender, MouseEventArgs e)
    {
        FormWithMinimalTitleBar_MouseDown(sender, e);
    }

    private void button3_MouseMove(object sender, MouseEventArgs e)
    {
        FormWithMinimalTitleBar_MouseMove(sender, e);
    }

    private void button3_MouseUp(object sender, MouseEventArgs e)
    {
        FormWithMinimalTitleBar_MouseUp(sender, e);
    }

    private void Form2_Load(object sender, EventArgs e)
    {
        this.ClientSize = new Size(66, 22);
    }
}
