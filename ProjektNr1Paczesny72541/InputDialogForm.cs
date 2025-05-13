using System.Drawing;
using System.Windows.Forms;

public partial class InputDialogForm : Form
{
    private TextBox textBox;
    private Button btnOk;
    private Button btnCancel;
    public string InputText { get; private set; }

    public InputDialogForm(string prompt, string title, string defaultValue)
    {
        InitializeComponents(prompt, title, defaultValue);
    }

    private void InitializeComponents(string prompt, string title, string defaultValue)
    {
        this.Text = title;
        this.Size = new Size(300, 150);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.StartPosition = FormStartPosition.CenterParent;

        Label lblPrompt = new Label
        {
            Text = prompt,
            Location = new Point(10, 10),
            Size = new Size(260, 20)
        };

        textBox = new TextBox
        {
            Text = defaultValue,
            Location = new Point(10, 40),
            Size = new Size(260, 20)
        };

        btnOk = new Button
        {
            Text = "OK",
            Location = new Point(110, 80),
            DialogResult = DialogResult.OK
        };
        btnOk.Click += (s, e) => { InputText = textBox.Text; Close(); };

        btnCancel = new Button
        {
            Text = "Cancel",
            Location = new Point(190, 80),
            DialogResult = DialogResult.Cancel
        };

        this.Controls.AddRange(new Control[] { lblPrompt, textBox, btnOk, btnCancel });
        this.AcceptButton = btnOk;
        this.CancelButton = btnCancel;
    }
}