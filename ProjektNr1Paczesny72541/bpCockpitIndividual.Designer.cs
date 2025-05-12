using System.ComponentModel;

namespace ProjektNr1Paczesny72541
{
    partial class bpCockpitIndividual
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
            this.bpPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bpLblMouseCoordinatesValue = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bpRdFilledPie = new System.Windows.Forms.RadioButton();
            this.bpRdFilledBorderedPie = new System.Windows.Forms.RadioButton();
            this.bpRdPie = new System.Windows.Forms.RadioButton();
            this.bpRdArc = new System.Windows.Forms.RadioButton();
            this.bpRdFilledBorderedClosedCardinalCurve = new System.Windows.Forms.RadioButton();
            this.bpRdFilledClosedCardinalCurve = new System.Windows.Forms.RadioButton();
            this.bpRdClosedCardinalCurve = new System.Windows.Forms.RadioButton();
            this.bpRdCardinalCurve = new System.Windows.Forms.RadioButton();
            this.bpRdGluedBezier = new System.Windows.Forms.RadioButton();
            this.bpRdBezier = new System.Windows.Forms.RadioButton();
            this.bpRdCircFilled = new System.Windows.Forms.RadioButton();
            this.bpRdElipsFilled = new System.Windows.Forms.RadioButton();
            this.bpRdSqrFilled = new System.Windows.Forms.RadioButton();
            this.bpRdRectFilled = new System.Windows.Forms.RadioButton();
            this.bpBtnMoveToNewLocation = new System.Windows.Forms.Button();
            this.bpBtnNewGraphicalAttrs = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bpBtnOff = new System.Windows.Forms.Button();
            this.bpTxtIndexLFG = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bpBtnPrevious = new System.Windows.Forms.Button();
            this.bpBtnNext = new System.Windows.Forms.Button();
            this.bpBtnOn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bpPictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bpPictureBox
            // 
            this.bpPictureBox.Location = new System.Drawing.Point(12, 28);
            this.bpPictureBox.Name = "bpPictureBox";
            this.bpPictureBox.Size = new System.Drawing.Size(562, 568);
            this.bpPictureBox.TabIndex = 0;
            this.bpPictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Wspolrzedne (x, y) myszy:\r\n";
            // 
            // bpLblMouseCoordinatesValue
            // 
            this.bpLblMouseCoordinatesValue.Location = new System.Drawing.Point(153, 9);
            this.bpLblMouseCoordinatesValue.Name = "bpLblMouseCoordinatesValue";
            this.bpLblMouseCoordinatesValue.Size = new System.Drawing.Size(88, 16);
            this.bpLblMouseCoordinatesValue.TabIndex = 2;
            this.bpLblMouseCoordinatesValue.Text = "label2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bpRdFilledPie);
            this.groupBox1.Controls.Add(this.bpRdFilledBorderedPie);
            this.groupBox1.Controls.Add(this.bpRdPie);
            this.groupBox1.Controls.Add(this.bpRdArc);
            this.groupBox1.Controls.Add(this.bpRdFilledBorderedClosedCardinalCurve);
            this.groupBox1.Controls.Add(this.bpRdFilledClosedCardinalCurve);
            this.groupBox1.Controls.Add(this.bpRdClosedCardinalCurve);
            this.groupBox1.Controls.Add(this.bpRdCardinalCurve);
            this.groupBox1.Controls.Add(this.bpRdGluedBezier);
            this.groupBox1.Controls.Add(this.bpRdBezier);
            this.groupBox1.Controls.Add(this.bpRdCircFilled);
            this.groupBox1.Controls.Add(this.bpRdElipsFilled);
            this.groupBox1.Controls.Add(this.bpRdSqrFilled);
            this.groupBox1.Controls.Add(this.bpRdRectFilled);
            this.groupBox1.Location = new System.Drawing.Point(580, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 422);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Wybierz (zaznacz) figure lub linię geometryczną";
            // 
            // bpRdFilledPie
            // 
            this.bpRdFilledPie.Location = new System.Drawing.Point(6, 384);
            this.bpRdFilledPie.Name = "bpRdFilledPie";
            this.bpRdFilledPie.Size = new System.Drawing.Size(342, 21);
            this.bpRdFilledPie.TabIndex = 13;
            this.bpRdFilledPie.TabStop = true;
            this.bpRdFilledPie.Text = "Wypełniony wycinek elipsy (FillPie)";
            this.bpRdFilledPie.UseVisualStyleBackColor = true;
            // 
            // bpRdFilledBorderedPie
            // 
            this.bpRdFilledBorderedPie.Location = new System.Drawing.Point(6, 357);
            this.bpRdFilledBorderedPie.Name = "bpRdFilledBorderedPie";
            this.bpRdFilledBorderedPie.Size = new System.Drawing.Size(342, 21);
            this.bpRdFilledBorderedPie.TabIndex = 12;
            this.bpRdFilledBorderedPie.TabStop = true;
            this.bpRdFilledBorderedPie.Text = "Wypełniony i obramowany wycinek elipsy (FillDrawPie)";
            this.bpRdFilledBorderedPie.UseVisualStyleBackColor = true;
            // 
            // bpRdPie
            // 
            this.bpRdPie.Location = new System.Drawing.Point(6, 330);
            this.bpRdPie.Name = "bpRdPie";
            this.bpRdPie.Size = new System.Drawing.Size(342, 21);
            this.bpRdPie.TabIndex = 11;
            this.bpRdPie.TabStop = true;
            this.bpRdPie.Text = "Wycinek elipsy (DrawPie)";
            this.bpRdPie.UseVisualStyleBackColor = true;
            // 
            // bpRdArc
            // 
            this.bpRdArc.Location = new System.Drawing.Point(6, 303);
            this.bpRdArc.Name = "bpRdArc";
            this.bpRdArc.Size = new System.Drawing.Size(342, 21);
            this.bpRdArc.TabIndex = 10;
            this.bpRdArc.TabStop = true;
            this.bpRdArc.Text = "Łuk elipsy (DrawArc)";
            this.bpRdArc.UseVisualStyleBackColor = true;
            // 
            // bpRdFilledBorderedClosedCardinalCurve
            // 
            this.bpRdFilledBorderedClosedCardinalCurve.Location = new System.Drawing.Point(6, 262);
            this.bpRdFilledBorderedClosedCardinalCurve.Name = "bpRdFilledBorderedClosedCardinalCurve";
            this.bpRdFilledBorderedClosedCardinalCurve.Size = new System.Drawing.Size(342, 35);
            this.bpRdFilledBorderedClosedCardinalCurve.TabIndex = 9;
            this.bpRdFilledBorderedClosedCardinalCurve.TabStop = true;
            this.bpRdFilledBorderedClosedCardinalCurve.Text = "Wypełniona, obramowana i zamknięta krzywa kardynalna (FillDrawClosedCurve)";
            this.bpRdFilledBorderedClosedCardinalCurve.UseVisualStyleBackColor = true;
            // 
            // bpRdFilledClosedCardinalCurve
            // 
            this.bpRdFilledClosedCardinalCurve.Location = new System.Drawing.Point(6, 235);
            this.bpRdFilledClosedCardinalCurve.Name = "bpRdFilledClosedCardinalCurve";
            this.bpRdFilledClosedCardinalCurve.Size = new System.Drawing.Size(342, 21);
            this.bpRdFilledClosedCardinalCurve.TabIndex = 8;
            this.bpRdFilledClosedCardinalCurve.TabStop = true;
            this.bpRdFilledClosedCardinalCurve.Text = "Wypełniona, zamknięta krzywa kardynalna (FillClosedCurve)";
            this.bpRdFilledClosedCardinalCurve.UseVisualStyleBackColor = true;
            // 
            // bpRdClosedCardinalCurve
            // 
            this.bpRdClosedCardinalCurve.Location = new System.Drawing.Point(6, 208);
            this.bpRdClosedCardinalCurve.Name = "bpRdClosedCardinalCurve";
            this.bpRdClosedCardinalCurve.Size = new System.Drawing.Size(342, 21);
            this.bpRdClosedCardinalCurve.TabIndex = 7;
            this.bpRdClosedCardinalCurve.TabStop = true;
            this.bpRdClosedCardinalCurve.Text = "Zamknięta krzywa kardynalna (DrawClosedCurve)";
            this.bpRdClosedCardinalCurve.UseVisualStyleBackColor = true;
            // 
            // bpRdCardinalCurve
            // 
            this.bpRdCardinalCurve.Location = new System.Drawing.Point(6, 181);
            this.bpRdCardinalCurve.Name = "bpRdCardinalCurve";
            this.bpRdCardinalCurve.Size = new System.Drawing.Size(342, 21);
            this.bpRdCardinalCurve.TabIndex = 6;
            this.bpRdCardinalCurve.TabStop = true;
            this.bpRdCardinalCurve.Text = "Krzywa kardynalna (DrawCurve)";
            this.bpRdCardinalCurve.UseVisualStyleBackColor = true;
            // 
            // bpRdGluedBezier
            // 
            this.bpRdGluedBezier.Location = new System.Drawing.Point(6, 154);
            this.bpRdGluedBezier.Name = "bpRdGluedBezier";
            this.bpRdGluedBezier.Size = new System.Drawing.Size(342, 21);
            this.bpRdGluedBezier.TabIndex = 5;
            this.bpRdGluedBezier.TabStop = true;
            this.bpRdGluedBezier.Text = "Sklejana krzywa Beziera";
            this.bpRdGluedBezier.UseVisualStyleBackColor = true;
            // 
            // bpRdBezier
            // 
            this.bpRdBezier.Location = new System.Drawing.Point(6, 127);
            this.bpRdBezier.Name = "bpRdBezier";
            this.bpRdBezier.Size = new System.Drawing.Size(342, 21);
            this.bpRdBezier.TabIndex = 4;
            this.bpRdBezier.TabStop = true;
            this.bpRdBezier.Text = "Krzywa Beziera (DrawBeziers)";
            this.bpRdBezier.UseVisualStyleBackColor = true;
            // 
            // bpRdCircFilled
            // 
            this.bpRdCircFilled.Location = new System.Drawing.Point(6, 100);
            this.bpRdCircFilled.Name = "bpRdCircFilled";
            this.bpRdCircFilled.Size = new System.Drawing.Size(342, 21);
            this.bpRdCircFilled.TabIndex = 3;
            this.bpRdCircFilled.TabStop = true;
            this.bpRdCircFilled.Text = "Koło (okrąg wypełniony)";
            this.bpRdCircFilled.UseVisualStyleBackColor = true;
            // 
            // bpRdElipsFilled
            // 
            this.bpRdElipsFilled.Location = new System.Drawing.Point(6, 73);
            this.bpRdElipsFilled.Name = "bpRdElipsFilled";
            this.bpRdElipsFilled.Size = new System.Drawing.Size(342, 21);
            this.bpRdElipsFilled.TabIndex = 2;
            this.bpRdElipsFilled.TabStop = true;
            this.bpRdElipsFilled.Text = "Elipsa wypełniona (FillElipse)";
            this.bpRdElipsFilled.UseVisualStyleBackColor = true;
            // 
            // bpRdSqrFilled
            // 
            this.bpRdSqrFilled.Location = new System.Drawing.Point(6, 46);
            this.bpRdSqrFilled.Name = "bpRdSqrFilled";
            this.bpRdSqrFilled.Size = new System.Drawing.Size(342, 21);
            this.bpRdSqrFilled.TabIndex = 1;
            this.bpRdSqrFilled.TabStop = true;
            this.bpRdSqrFilled.Text = "Kwadrat wypełniony";
            this.bpRdSqrFilled.UseVisualStyleBackColor = true;
            // 
            // bpRdRectFilled
            // 
            this.bpRdRectFilled.Location = new System.Drawing.Point(6, 19);
            this.bpRdRectFilled.Name = "bpRdRectFilled";
            this.bpRdRectFilled.Size = new System.Drawing.Size(342, 21);
            this.bpRdRectFilled.TabIndex = 0;
            this.bpRdRectFilled.TabStop = true;
            this.bpRdRectFilled.Text = "Prostokąt wypełniony (FillRectangle)";
            this.bpRdRectFilled.UseVisualStyleBackColor = true;
            // 
            // bpBtnMoveToNewLocation
            // 
            this.bpBtnMoveToNewLocation.Location = new System.Drawing.Point(580, 456);
            this.bpBtnMoveToNewLocation.Name = "bpBtnMoveToNewLocation";
            this.bpBtnMoveToNewLocation.Size = new System.Drawing.Size(174, 23);
            this.bpBtnMoveToNewLocation.TabIndex = 4;
            this.bpBtnMoveToNewLocation.Text = "Przesunięcie do nowej lokalizacji";
            this.bpBtnMoveToNewLocation.UseVisualStyleBackColor = true;
            // 
            // bpBtnNewGraphicalAttrs
            // 
            this.bpBtnNewGraphicalAttrs.Location = new System.Drawing.Point(760, 456);
            this.bpBtnNewGraphicalAttrs.Name = "bpBtnNewGraphicalAttrs";
            this.bpBtnNewGraphicalAttrs.Size = new System.Drawing.Size(174, 23);
            this.bpBtnNewGraphicalAttrs.TabIndex = 5;
            this.bpBtnNewGraphicalAttrs.Text = "Ustaw nowe atrybuty graficzne";
            this.bpBtnNewGraphicalAttrs.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bpBtnOff);
            this.groupBox2.Controls.Add(this.bpTxtIndexLFG);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.bpBtnPrevious);
            this.groupBox2.Controls.Add(this.bpBtnNext);
            this.groupBox2.Controls.Add(this.bpBtnOn);
            this.groupBox2.Location = new System.Drawing.Point(580, 485);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(354, 111);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Slajder";
            // 
            // bpBtnOff
            // 
            this.bpBtnOff.Enabled = false;
            this.bpBtnOff.Location = new System.Drawing.Point(273, 19);
            this.bpBtnOff.Name = "bpBtnOff";
            this.bpBtnOff.Size = new System.Drawing.Size(75, 86);
            this.bpBtnOff.TabIndex = 5;
            this.bpBtnOff.Text = "Włącz";
            this.bpBtnOff.UseVisualStyleBackColor = true;
            // 
            // bpTxtIndexLFG
            // 
            this.bpTxtIndexLFG.Location = new System.Drawing.Point(168, 66);
            this.bpTxtIndexLFG.Name = "bpTxtIndexLFG";
            this.bpTxtIndexLFG.Size = new System.Drawing.Size(99, 20);
            this.bpTxtIndexLFG.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(168, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 41);
            this.label2.TabIndex = 3;
            this.label2.Text = "Index LFG";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // bpBtnPrevious
            // 
            this.bpBtnPrevious.Location = new System.Drawing.Point(87, 66);
            this.bpBtnPrevious.Name = "bpBtnPrevious";
            this.bpBtnPrevious.Size = new System.Drawing.Size(75, 39);
            this.bpBtnPrevious.TabIndex = 2;
            this.bpBtnPrevious.Text = "Poprzedni";
            this.bpBtnPrevious.UseVisualStyleBackColor = true;
            // 
            // bpBtnNext
            // 
            this.bpBtnNext.Location = new System.Drawing.Point(87, 19);
            this.bpBtnNext.Name = "bpBtnNext";
            this.bpBtnNext.Size = new System.Drawing.Size(75, 41);
            this.bpBtnNext.TabIndex = 1;
            this.bpBtnNext.Text = "Nastepny";
            this.bpBtnNext.UseVisualStyleBackColor = true;
            // 
            // bpBtnOn
            // 
            this.bpBtnOn.Enabled = false;
            this.bpBtnOn.Location = new System.Drawing.Point(6, 19);
            this.bpBtnOn.Name = "bpBtnOn";
            this.bpBtnOn.Size = new System.Drawing.Size(75, 86);
            this.bpBtnOn.TabIndex = 0;
            this.bpBtnOn.Text = "Włącz";
            this.bpBtnOn.UseVisualStyleBackColor = true;
            // 
            // bpCockpitIndividual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 608);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.bpBtnNewGraphicalAttrs);
            this.Controls.Add(this.bpBtnMoveToNewLocation);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bpLblMouseCoordinatesValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bpPictureBox);
            this.Name = "bpCockpitIndividual";
            this.Text = "bpCockpitIndividual";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.bpCockpitIndividual_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.bpPictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.RadioButton bpRdFilledPie;

        private System.Windows.Forms.RadioButton bpRdFilledBorderedClosedCardinalCurve;
        private System.Windows.Forms.RadioButton bpRdArc;
        private System.Windows.Forms.RadioButton bpRdPie;
        private System.Windows.Forms.RadioButton bpRdFilledBorderedPie;

        private System.Windows.Forms.RadioButton bpRdRectFilled;
        private System.Windows.Forms.RadioButton bpRdSqrFilled;
        private System.Windows.Forms.RadioButton bpRdElipsFilled;
        private System.Windows.Forms.RadioButton bpRdCircFilled;
        private System.Windows.Forms.RadioButton bpRdBezier;
        private System.Windows.Forms.RadioButton bpRdGluedBezier;
        private System.Windows.Forms.RadioButton bpRdCardinalCurve;
        private System.Windows.Forms.RadioButton bpRdClosedCardinalCurve;
        private System.Windows.Forms.RadioButton bpRdFilledClosedCardinalCurve;

        private System.Windows.Forms.Button bpBtnOff;

        private System.Windows.Forms.TextBox bpTxtIndexLFG;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Button bpBtnNext;
        private System.Windows.Forms.Button bpBtnPrevious;

        private System.Windows.Forms.Button bpBtnOn;

        private System.Windows.Forms.GroupBox groupBox2;

        private System.Windows.Forms.Button bpBtnMoveToNewLocation;
        private System.Windows.Forms.Button bpBtnNewGraphicalAttrs;

        private System.Windows.Forms.GroupBox groupBox1;

        private System.Windows.Forms.Label bpLblMouseCoordinatesValue;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.PictureBox bpPictureBox;

        #endregion
    }
}