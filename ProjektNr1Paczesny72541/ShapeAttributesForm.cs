using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProjektNr1Paczesny72541
{
    public class ShapeAttributesForm : Form
    {
        private Color penColor;
        private Color fillColor;
        private DashStyle lineStyle;
        private float lineWidth;
        private bool isFilled;
        private bool isBordered;
        private bool supportsFillingAndBordering;

        // UI Controls
        private Panel penColorPanel;
        private Panel fillColorPanel;
        private ComboBox lineStyleComboBox;
        private NumericUpDown lineWidthUpDown;
        private CheckBox isFilledCheckBox;
        private CheckBox isBorderedCheckBox;
        private Button btnOK;
        private Button btnCancel;
        private Label lblPenColor;
        private Label lblFillColor;
        private Label lblLineStyle;
        private Label lblLineWidth;
        private GroupBox grpFillOptions;

        public Color PenColor => penColor;
        public Color FillColor => fillColor;
        public DashStyle LineStyle => lineStyle;
        public float LineWidth => lineWidth;
        public bool IsFilled => isFilled;
        public bool IsBordered => isBordered;

        public ShapeAttributesForm(Color currentPenColor, Color currentFillColor, 
                                  DashStyle currentLineStyle, float currentLineWidth,
                                  bool currentIsFilled, bool currentIsBordered,
                                  bool supportsFillingAndBordering)
        {
            penColor = currentPenColor;
            fillColor = currentFillColor;
            lineStyle = currentLineStyle;
            lineWidth = currentLineWidth;
            isFilled = currentIsFilled;
            isBordered = currentIsBordered;
            this.supportsFillingAndBordering = supportsFillingAndBordering;

            Text = "Atrybuty Figury";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Size = new Size(350, supportsFillingAndBordering ? 330 : 230);
            DialogResult = DialogResult.Cancel;

            InitializeComponents();
            UpdateUI();
        }

        private void InitializeComponents()
        {
            // Pen Color
            lblPenColor = new Label { Text = "Kolor linii:", Location = new Point(20, 20), AutoSize = true };
            penColorPanel = new Panel { 
                Location = new Point(120, 20), 
                Size = new Size(30, 20), 
                BorderStyle = BorderStyle.FixedSingle 
            };
            Button btnPenColor = new Button { 
                Text = "Wybierz...", 
                Location = new Point(160, 18), 
                Size = new Size(80, 25) 
            };
            btnPenColor.Click += (s, e) =>
            {
                using (ColorDialog colorDialog = new ColorDialog { Color = penColor })
                {
                    if (colorDialog.ShowDialog() == DialogResult.OK)
                    {
                        penColor = colorDialog.Color;
                        UpdateUI();
                    }
                }
            };

            // Line Style
            lblLineStyle = new Label { Text = "Styl linii:", Location = new Point(20, 60), AutoSize = true };
            lineStyleComboBox = new ComboBox { 
                Location = new Point(120, 58), 
                Size = new Size(120, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            lineStyleComboBox.Items.AddRange(new object[] { 
                "Ciągła", "Kropkowana", "Kreskowana", 
                "Kropkowo-kreskowana", "Kropkowo-kreskowana 2" 
            });

            // Line Width
            lblLineWidth = new Label { Text = "Grubość linii:", Location = new Point(20, 100), AutoSize = true };
            lineWidthUpDown = new NumericUpDown { 
                Location = new Point(120, 98), 
                Size = new Size(80, 25),
                Minimum = 1,
                Maximum = 10,
                DecimalPlaces = 1,
                Increment = 0.5m
            };

            // Fill options group
            grpFillOptions = new GroupBox { 
                Text = "Opcje wypełnienia", 
                Location = new Point(20, 140), 
                Size = new Size(300, 100),
                Visible = supportsFillingAndBordering
            };

            // Fill Color
            lblFillColor = new Label { Text = "Kolor wypełnienia:", Location = new Point(15, 25), AutoSize = true };
            fillColorPanel = new Panel { 
                Location = new Point(120, 23), 
                Size = new Size(30, 20), 
                BorderStyle = BorderStyle.FixedSingle 
            };
            Button btnFillColor = new Button { 
                Text = "Wybierz...", 
                Location = new Point(160, 21), 
                Size = new Size(80, 25) 
            };
            btnFillColor.Click += (s, e) =>
            {
                using (ColorDialog colorDialog = new ColorDialog { Color = fillColor })
                {
                    if (colorDialog.ShowDialog() == DialogResult.OK)
                    {
                        fillColor = colorDialog.Color;
                        UpdateUI();
                    }
                }
            };

            // Checkboxes
            isFilledCheckBox = new CheckBox { 
                Text = "Wypełniona", 
                Location = new Point(15, 60), 
                AutoSize = true,
                Checked = isFilled
            };
            isBorderedCheckBox = new CheckBox { 
                Text = "Z obramowaniem", 
                Location = new Point(160, 60), 
                AutoSize = true,
                Checked = isBordered
            };

            grpFillOptions.Controls.AddRange(new Control[] { 
                lblFillColor, fillColorPanel, btnFillColor, 
                isFilledCheckBox, isBorderedCheckBox 
            });

            // Buttons
            btnOK = new Button { 
                Text = "OK", 
                DialogResult = DialogResult.OK, 
                Location = new Point(140, supportsFillingAndBordering ? 245 : 145), 
                Size = new Size(80, 30) 
            };
            btnOK.Click += (s, e) =>
            {
                lineStyle = (DashStyle)lineStyleComboBox.SelectedIndex;
                lineWidth = (float)lineWidthUpDown.Value;
                if (supportsFillingAndBordering)
                {
                    isFilled = isFilledCheckBox.Checked;
                    isBordered = isBorderedCheckBox.Checked;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            };

            btnCancel = new Button { 
                Text = "Anuluj", 
                DialogResult = DialogResult.Cancel, 
                Location = new Point(240, supportsFillingAndBordering ? 245 : 145), 
                Size = new Size(80, 30) 
            };
            btnCancel.Click += (s, e) => this.Close();

            this.Controls.AddRange(new Control[] {
                lblPenColor, penColorPanel, btnPenColor,
                lblLineStyle, lineStyleComboBox,
                lblLineWidth, lineWidthUpDown,
                grpFillOptions,
                btnOK, btnCancel
            });

            this.AcceptButton = btnOK;
            this.CancelButton = btnCancel;
        }

        private void UpdateUI()
        {
            penColorPanel.BackColor = penColor;
            fillColorPanel.BackColor = fillColor;
            lineStyleComboBox.SelectedIndex = (int)lineStyle;
            lineWidthUpDown.Value = (decimal)lineWidth;
            if (supportsFillingAndBordering)
            {
                isFilledCheckBox.Checked = isFilled;
                isBorderedCheckBox.Checked = isBordered;
            }
        }
    }
}