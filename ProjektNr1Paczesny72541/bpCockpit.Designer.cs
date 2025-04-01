namespace ProjektNr1Paczesny72541
{
    partial class bpCockpit
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
            this.bpTitle = new System.Windows.Forms.Label();
            this.bpLabBtn = new System.Windows.Forms.Button();
            this.bpIndividualBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bpTitle
            // 
            this.bpTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bpTitle.Location = new System.Drawing.Point(127, 41);
            this.bpTitle.Name = "bpTitle";
            this.bpTitle.Size = new System.Drawing.Size(562, 105);
            this.bpTitle.TabIndex = 0;
            this.bpTitle.Text = "KOKPIT PROJEKTU Nr1\r\n(kreślenie figur i linii geometrycznych)";
            this.bpTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bpLabBtn
            // 
            this.bpLabBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bpLabBtn.Location = new System.Drawing.Point(127, 281);
            this.bpLabBtn.Name = "bpLabBtn";
            this.bpLabBtn.Size = new System.Drawing.Size(243, 42);
            this.bpLabBtn.TabIndex = 1;
            this.bpLabBtn.Text = "Laboratorium Nr 1\r\n(kreślenie figur geometrycznych)";
            this.bpLabBtn.UseVisualStyleBackColor = true;
            this.bpLabBtn.Click += new System.EventHandler(this.bpLabBtn_Click);
            // 
            // bpIndividualBtn
            // 
            this.bpIndividualBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bpIndividualBtn.Location = new System.Drawing.Point(454, 281);
            this.bpIndividualBtn.Name = "bpIndividualBtn";
            this.bpIndividualBtn.Size = new System.Drawing.Size(235, 42);
            this.bpIndividualBtn.TabIndex = 2;
            this.bpIndividualBtn.Text = "Projekt Indywidualny Nr 1\r\n(kreślenie linii geometrycznych)";
            this.bpIndividualBtn.UseVisualStyleBackColor = true;
            this.bpIndividualBtn.Click += new System.EventHandler(this.bpIndividualBtn_Click);
            // 
            // bpCockpit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bpIndividualBtn);
            this.Controls.Add(this.bpLabBtn);
            this.Controls.Add(this.bpTitle);
            this.Name = "bpCockpit";
            this.Text = "Kokpit projektu Nr 1 - Bartłomiej Paczesny";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.bpCockpit_FormClosing);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button bpIndividualBtn;

        private System.Windows.Forms.Button bpLabBtn;

        private System.Windows.Forms.Label bpTitle;

        #endregion
    }
}