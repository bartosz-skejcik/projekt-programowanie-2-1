using System.ComponentModel;

namespace ProjektNr1Paczesny72541
{
    partial class bpCockpitLaboratory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.bpShapesList = new System.Windows.Forms.CheckedListBox();
            this.bpLblShapesCount = new System.Windows.Forms.Label();
            this.bpTxtShapesCount = new System.Windows.Forms.TextBox();
            this.bpBtnStart = new System.Windows.Forms.Button();
            this.bpPictureBox = new System.Windows.Forms.PictureBox();
            this.bpBtnMoveShape = new System.Windows.Forms.Button();
            this.bpBtnSetRandomAttributes = new System.Windows.Forms.Button();
            this.bpBtnTurnOnSlider = new System.Windows.Forms.Button();
            this.bpGrBoxViewStyle = new System.Windows.Forms.GroupBox();
            this.bpRdBtnInterval = new System.Windows.Forms.RadioButton();
            this.bpRdBtnButton = new System.Windows.Forms.RadioButton();
            this.bpGrBoxNavigation = new System.Windows.Forms.GroupBox();
            this.bpBtnPrevious = new System.Windows.Forms.Button();
            this.bpTxtIndexTVG = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bpBtnNext = new System.Windows.Forms.Button();
            this.bpBtnTurnOfSlider = new System.Windows.Forms.Button();
            this.bpGrBoxAttrChange = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bpNumUpDownLineThicknes = new System.Windows.Forms.NumericUpDown();
            this.bpCBoxLineStyle = new System.Windows.Forms.ComboBox();
            this.bpBtnColorPicker = new System.Windows.Forms.Button();
            this.bpTBarY = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.bpTBarX = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.bpTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bpPictureBox)).BeginInit();
            this.bpGrBoxViewStyle.SuspendLayout();
            this.bpGrBoxNavigation.SuspendLayout();
            this.bpGrBoxAttrChange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bpNumUpDownLineThicknes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bpTBarY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bpTBarX)).BeginInit();
            this.SuspendLayout();
            // 
            // bpShapesList
            // 
            this.bpShapesList.FormattingEnabled = true;
            this.bpShapesList.Items.AddRange(new object[] { "Punkt", "Linia", "Elipsa", "Okrąg", "Prostokąt", "Kwadrat", "Wielokąt" });
            this.bpShapesList.Location = new System.Drawing.Point(668, 49);
            this.bpShapesList.Name = "bpShapesList";
            this.bpShapesList.Size = new System.Drawing.Size(120, 139);
            this.bpShapesList.TabIndex = 0;
            this.bpShapesList.SelectedIndexChanged += new System.EventHandler(this.bpShapesList_SelectedIndexChanged);
            // 
            // bpLblShapesCount
            // 
            this.bpLblShapesCount.Location = new System.Drawing.Point(12, 49);
            this.bpLblShapesCount.Name = "bpLblShapesCount";
            this.bpLblShapesCount.Size = new System.Drawing.Size(100, 29);
            this.bpLblShapesCount.TabIndex = 1;
            this.bpLblShapesCount.Text = "Podaj liczbę figur\r\ndo prezentacji";
            // 
            // bpTxtShapesCount
            // 
            this.bpTxtShapesCount.Enabled = false;
            this.bpTxtShapesCount.Location = new System.Drawing.Point(12, 81);
            this.bpTxtShapesCount.Name = "bpTxtShapesCount";
            this.bpTxtShapesCount.Size = new System.Drawing.Size(100, 20);
            this.bpTxtShapesCount.TabIndex = 2;
            this.bpTxtShapesCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.bpTxtShapesCount.TextChanged += new System.EventHandler(this.bpTxtShapesCount_TextChanged);
            // 
            // bpBtnStart
            // 
            this.bpBtnStart.Location = new System.Drawing.Point(12, 107);
            this.bpBtnStart.Name = "bpBtnStart";
            this.bpBtnStart.Size = new System.Drawing.Size(100, 23);
            this.bpBtnStart.TabIndex = 3;
            this.bpBtnStart.Text = "Start";
            this.bpBtnStart.UseVisualStyleBackColor = true;
            this.bpBtnStart.Click += new System.EventHandler(this.bpBtnStart_Click);
            // 
            // bpPictureBox
            // 
            this.bpPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bpPictureBox.Location = new System.Drawing.Point(118, 49);
            this.bpPictureBox.Name = "bpPictureBox";
            this.bpPictureBox.Size = new System.Drawing.Size(544, 389);
            this.bpPictureBox.TabIndex = 4;
            this.bpPictureBox.TabStop = false;
            // 
            // bpBtnMoveShape
            // 
            this.bpBtnMoveShape.Enabled = false;
            this.bpBtnMoveShape.Location = new System.Drawing.Point(12, 136);
            this.bpBtnMoveShape.Name = "bpBtnMoveShape";
            this.bpBtnMoveShape.Size = new System.Drawing.Size(100, 23);
            this.bpBtnMoveShape.TabIndex = 5;
            this.bpBtnMoveShape.Text = "Przesuń figure";
            this.bpBtnMoveShape.UseVisualStyleBackColor = true;
            this.bpBtnMoveShape.Click += new System.EventHandler(this.bpBtnMoveShape_Click);
            // 
            // bpBtnSetRandomAttributes
            // 
            this.bpBtnSetRandomAttributes.Enabled = false;
            this.bpBtnSetRandomAttributes.Location = new System.Drawing.Point(12, 165);
            this.bpBtnSetRandomAttributes.Name = "bpBtnSetRandomAttributes";
            this.bpBtnSetRandomAttributes.Size = new System.Drawing.Size(100, 23);
            this.bpBtnSetRandomAttributes.TabIndex = 6;
            this.bpBtnSetRandomAttributes.Text = "Losowe atrybuty";
            this.bpBtnSetRandomAttributes.UseVisualStyleBackColor = true;
            this.bpBtnSetRandomAttributes.Click += new System.EventHandler(this.bpBtnSetRandomAttributes_Click);
            // 
            // bpBtnTurnOnSlider
            // 
            this.bpBtnTurnOnSlider.Enabled = false;
            this.bpBtnTurnOnSlider.Location = new System.Drawing.Point(12, 194);
            this.bpBtnTurnOnSlider.Name = "bpBtnTurnOnSlider";
            this.bpBtnTurnOnSlider.Size = new System.Drawing.Size(100, 23);
            this.bpBtnTurnOnSlider.TabIndex = 7;
            this.bpBtnTurnOnSlider.Text = "Włącz slider";
            this.bpBtnTurnOnSlider.UseVisualStyleBackColor = true;
            this.bpBtnTurnOnSlider.Click += new System.EventHandler(this.bpBtnTurnOnSlider_Click);
            // 
            // bpGrBoxViewStyle
            // 
            this.bpGrBoxViewStyle.Controls.Add(this.bpRdBtnInterval);
            this.bpGrBoxViewStyle.Controls.Add(this.bpRdBtnButton);
            this.bpGrBoxViewStyle.Enabled = false;
            this.bpGrBoxViewStyle.Location = new System.Drawing.Point(12, 223);
            this.bpGrBoxViewStyle.Name = "bpGrBoxViewStyle";
            this.bpGrBoxViewStyle.Size = new System.Drawing.Size(100, 82);
            this.bpGrBoxViewStyle.TabIndex = 8;
            this.bpGrBoxViewStyle.TabStop = false;
            this.bpGrBoxViewStyle.Text = "Tryb pokazu";
            this.bpGrBoxViewStyle.UseWaitCursor = true;
            // 
            // bpRdBtnInterval
            // 
            this.bpRdBtnInterval.Location = new System.Drawing.Point(6, 19);
            this.bpRdBtnInterval.Name = "bpRdBtnInterval";
            this.bpRdBtnInterval.Size = new System.Drawing.Size(88, 24);
            this.bpRdBtnInterval.TabIndex = 1;
            this.bpRdBtnInterval.Text = "Zegarowy";
            this.bpRdBtnInterval.UseVisualStyleBackColor = true;
            this.bpRdBtnInterval.UseWaitCursor = true;
            // 
            // bpRdBtnButton
            // 
            this.bpRdBtnButton.Checked = true;
            this.bpRdBtnButton.Location = new System.Drawing.Point(6, 49);
            this.bpRdBtnButton.Name = "bpRdBtnButton";
            this.bpRdBtnButton.Size = new System.Drawing.Size(88, 24);
            this.bpRdBtnButton.TabIndex = 0;
            this.bpRdBtnButton.TabStop = true;
            this.bpRdBtnButton.Text = "Przyciskowy";
            this.bpRdBtnButton.UseVisualStyleBackColor = true;
            this.bpRdBtnButton.UseWaitCursor = true;
            // 
            // bpGrBoxNavigation
            // 
            this.bpGrBoxNavigation.Controls.Add(this.bpBtnPrevious);
            this.bpGrBoxNavigation.Controls.Add(this.bpTxtIndexTVG);
            this.bpGrBoxNavigation.Controls.Add(this.label1);
            this.bpGrBoxNavigation.Controls.Add(this.bpBtnNext);
            this.bpGrBoxNavigation.Enabled = false;
            this.bpGrBoxNavigation.Location = new System.Drawing.Point(12, 311);
            this.bpGrBoxNavigation.Name = "bpGrBoxNavigation";
            this.bpGrBoxNavigation.Size = new System.Drawing.Size(100, 127);
            this.bpGrBoxNavigation.TabIndex = 9;
            this.bpGrBoxNavigation.TabStop = false;
            this.bpGrBoxNavigation.Text = "Nawigacja";
            // 
            // bpBtnPrevious
            // 
            this.bpBtnPrevious.Location = new System.Drawing.Point(6, 88);
            this.bpBtnPrevious.Name = "bpBtnPrevious";
            this.bpBtnPrevious.Size = new System.Drawing.Size(88, 23);
            this.bpBtnPrevious.TabIndex = 3;
            this.bpBtnPrevious.Text = "Poprzedni";
            this.bpBtnPrevious.UseVisualStyleBackColor = true;
            // 
            // bpTxtIndexTVG
            // 
            this.bpTxtIndexTVG.Location = new System.Drawing.Point(6, 62);
            this.bpTxtIndexTVG.Name = "bpTxtIndexTVG";
            this.bpTxtIndexTVG.Size = new System.Drawing.Size(88, 20);
            this.bpTxtIndexTVG.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Indeks w TVG\r\n";
            // 
            // bpBtnNext
            // 
            this.bpBtnNext.Location = new System.Drawing.Point(6, 19);
            this.bpBtnNext.Name = "bpBtnNext";
            this.bpBtnNext.Size = new System.Drawing.Size(88, 23);
            this.bpBtnNext.TabIndex = 0;
            this.bpBtnNext.Text = "Następny";
            this.bpBtnNext.UseVisualStyleBackColor = true;
            this.bpBtnNext.Click += new System.EventHandler(this.bpBtnNext_Click);
            // 
            // bpBtnTurnOfSlider
            // 
            this.bpBtnTurnOfSlider.Enabled = false;
            this.bpBtnTurnOfSlider.Location = new System.Drawing.Point(12, 444);
            this.bpBtnTurnOfSlider.Name = "bpBtnTurnOfSlider";
            this.bpBtnTurnOfSlider.Size = new System.Drawing.Size(100, 23);
            this.bpBtnTurnOfSlider.TabIndex = 10;
            this.bpBtnTurnOfSlider.Text = "Wyłącz slider\r\n";
            this.bpBtnTurnOfSlider.UseVisualStyleBackColor = true;
            // 
            // bpGrBoxAttrChange
            // 
            this.bpGrBoxAttrChange.Controls.Add(this.label4);
            this.bpGrBoxAttrChange.Controls.Add(this.bpNumUpDownLineThicknes);
            this.bpGrBoxAttrChange.Controls.Add(this.bpCBoxLineStyle);
            this.bpGrBoxAttrChange.Controls.Add(this.bpBtnColorPicker);
            this.bpGrBoxAttrChange.Controls.Add(this.bpTBarY);
            this.bpGrBoxAttrChange.Controls.Add(this.label3);
            this.bpGrBoxAttrChange.Controls.Add(this.bpTBarX);
            this.bpGrBoxAttrChange.Controls.Add(this.label2);
            this.bpGrBoxAttrChange.Enabled = false;
            this.bpGrBoxAttrChange.Location = new System.Drawing.Point(668, 196);
            this.bpGrBoxAttrChange.Name = "bpGrBoxAttrChange";
            this.bpGrBoxAttrChange.Size = new System.Drawing.Size(120, 286);
            this.bpGrBoxAttrChange.TabIndex = 11;
            this.bpGrBoxAttrChange.TabStop = false;
            this.bpGrBoxAttrChange.Text = "Atrybuty";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "Grubosc linii";
            // 
            // bpNumUpDownLineThicknes
            // 
            this.bpNumUpDownLineThicknes.Location = new System.Drawing.Point(6, 185);
            this.bpNumUpDownLineThicknes.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.bpNumUpDownLineThicknes.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.bpNumUpDownLineThicknes.Name = "bpNumUpDownLineThicknes";
            this.bpNumUpDownLineThicknes.Size = new System.Drawing.Size(108, 20);
            this.bpNumUpDownLineThicknes.TabIndex = 9;
            this.bpNumUpDownLineThicknes.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // bpCBoxLineStyle
            // 
            this.bpCBoxLineStyle.FormattingEnabled = true;
            this.bpCBoxLineStyle.Items.AddRange(new object[] { "Krokowy (Dash)", "KreskowoKropkowy (DashDot)", "KreskowoKropkowoKropkowy (DashDotDot)", "Kropkowy (Dot)", "Ciągły (Solid)" });
            this.bpCBoxLineStyle.Location = new System.Drawing.Point(6, 144);
            this.bpCBoxLineStyle.Name = "bpCBoxLineStyle";
            this.bpCBoxLineStyle.Size = new System.Drawing.Size(108, 21);
            this.bpCBoxLineStyle.TabIndex = 7;
            this.bpCBoxLineStyle.Text = "Zmien styl lini";
            // 
            // bpBtnColorPicker
            // 
            this.bpBtnColorPicker.Location = new System.Drawing.Point(6, 115);
            this.bpBtnColorPicker.Name = "bpBtnColorPicker";
            this.bpBtnColorPicker.Size = new System.Drawing.Size(108, 23);
            this.bpBtnColorPicker.TabIndex = 6;
            this.bpBtnColorPicker.Text = "Zmiana koloru";
            this.bpBtnColorPicker.UseVisualStyleBackColor = true;
            // 
            // bpTBarY
            // 
            this.bpTBarY.Location = new System.Drawing.Point(6, 84);
            this.bpTBarY.Maximum = 1000;
            this.bpTBarY.Minimum = 1;
            this.bpTBarY.Name = "bpTBarY";
            this.bpTBarY.Size = new System.Drawing.Size(108, 45);
            this.bpTBarY.TabIndex = 5;
            this.bpTBarY.Value = 1;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Wspolrzedna Y\r\n";
            // 
            // bpTBarX
            // 
            this.bpTBarX.Location = new System.Drawing.Point(6, 33);
            this.bpTBarX.Maximum = 1000;
            this.bpTBarX.Minimum = 1;
            this.bpTBarX.Name = "bpTBarX";
            this.bpTBarX.Size = new System.Drawing.Size(108, 45);
            this.bpTBarX.TabIndex = 3;
            this.bpTBarX.Value = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Wspolrzedna X";
            // 
            // bpTimer
            // 
            this.bpTimer.Tick += new System.EventHandler(this.bpTimer_Tick);
            // 
            // bpCockpitLaboratory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 553);
            this.Controls.Add(this.bpGrBoxAttrChange);
            this.Controls.Add(this.bpBtnTurnOfSlider);
            this.Controls.Add(this.bpGrBoxNavigation);
            this.Controls.Add(this.bpGrBoxViewStyle);
            this.Controls.Add(this.bpBtnTurnOnSlider);
            this.Controls.Add(this.bpBtnSetRandomAttributes);
            this.Controls.Add(this.bpBtnMoveShape);
            this.Controls.Add(this.bpPictureBox);
            this.Controls.Add(this.bpBtnStart);
            this.Controls.Add(this.bpTxtShapesCount);
            this.Controls.Add(this.bpLblShapesCount);
            this.Controls.Add(this.bpShapesList);
            this.Name = "bpCockpitLaboratory";
            this.Text = "bpCockpitLaboratory";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.bpCockpitLaboratory_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.bpPictureBox)).EndInit();
            this.bpGrBoxViewStyle.ResumeLayout(false);
            this.bpGrBoxNavigation.ResumeLayout(false);
            this.bpGrBoxNavigation.PerformLayout();
            this.bpGrBoxAttrChange.ResumeLayout(false);
            this.bpGrBoxAttrChange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bpNumUpDownLineThicknes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bpTBarY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bpTBarX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Timer bpTimer;

        private System.Windows.Forms.NumericUpDown bpNumUpDownLineThicknes;
        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.ComboBox bpCBoxLineStyle;

        private System.Windows.Forms.Button bpBtnColorPicker;

        private System.Windows.Forms.GroupBox bpGrBoxAttrChange;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar bpTBarX;
        private System.Windows.Forms.TrackBar bpTBarY;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.TextBox bpTxtIndexTVG;
        private System.Windows.Forms.Button bpBtnPrevious;
        private System.Windows.Forms.Button bpBtnTurnOfSlider;

        private System.Windows.Forms.GroupBox bpGrBoxNavigation;
        private System.Windows.Forms.Button bpBtnNext;
        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.RadioButton bpRdBtnButton;
        private System.Windows.Forms.RadioButton bpRdBtnInterval;

        private System.Windows.Forms.GroupBox bpGrBoxViewStyle;

        private System.Windows.Forms.Button bpBtnTurnOnSlider;

        private System.Windows.Forms.Button bpBtnSetRandomAttributes;

        private System.Windows.Forms.Button bpBtnMoveShape;

        private System.Windows.Forms.PictureBox bpPictureBox;

        private System.Windows.Forms.Button bpBtnStart;

        private System.Windows.Forms.TextBox bpTxtShapesCount;

        private System.Windows.Forms.Label bpLblShapesCount;

        private System.Windows.Forms.CheckedListBox bpShapesList;

        #endregion
    }
}