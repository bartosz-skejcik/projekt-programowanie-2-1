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
            this.bpShapesList = new System.Windows.Forms.CheckedListBox();
            this.bpLblShapesCount = new System.Windows.Forms.Label();
            this.bpTxtShapesCount = new System.Windows.Forms.TextBox();
            this.bpBtnStart = new System.Windows.Forms.Button();
            this.bpPictureBox = new System.Windows.Forms.PictureBox();
            this.bpBtnMoveShape = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bpPictureBox)).BeginInit();
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
            // bpCockpitLaboratory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button bpBtnMoveShape;

        private System.Windows.Forms.PictureBox bpPictureBox;

        private System.Windows.Forms.Button bpBtnStart;

        private System.Windows.Forms.TextBox bpTxtShapesCount;

        private System.Windows.Forms.Label bpLblShapesCount;

        private System.Windows.Forms.CheckedListBox bpShapesList;

        #endregion
    }
}