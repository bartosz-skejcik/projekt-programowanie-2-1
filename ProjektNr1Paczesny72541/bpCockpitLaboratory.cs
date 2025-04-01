using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static ProjektNr1Paczesny72541.GeometricShapes;
using Point = System.Drawing.Point;

namespace ProjektNr1Paczesny72541
{
    public partial class bpCockpitLaboratory : Form
    {
        private const ushort FormMargin = 20;
        private const ushort Margin = 10;

        private Graphics drawingBoard;
        private Pen pen = new Pen(Color.Black, 1.0F);
        private SolidBrush brush = new SolidBrush((Color.Black));
        private GeometricShapes.Point[] bpTFG;
        private ushort IndexTFG;

        public bpCockpitLaboratory()
        {
            InitializeComponent();
            Location = new Point(Screen.PrimaryScreen.Bounds.X + FormMargin, Screen.PrimaryScreen.Bounds.Y + FormMargin);
            Width = (int)(Screen.PrimaryScreen.Bounds.Width * 0.65F);
            Height = (int)(Screen.PrimaryScreen.Bounds.Height * 0.7F);
            StartPosition = FormStartPosition.Manual;
            MaximizeBox = false;
            MinimizeBox = false;
            AutoScroll = true;

            // Control positioning relative to client area
            bpLblShapesCount.Location = new Point(FormMargin, FormMargin);
            bpTxtShapesCount.Location = new Point(FormMargin, bpLblShapesCount.Bottom + Margin);
            bpBtnStart.Location = new Point(FormMargin, bpTxtShapesCount.Bottom + Margin);
            bpBtnMoveShape.Location = new Point(FormMargin, bpBtnStart.Bottom + Margin);

            // PictureBox positioning and sizing
            int pictureBoxX = bpLblShapesCount.Right + FormMargin;
            int pictureBoxWidth = (int)(this.ClientSize.Width * 0.65F);
            int pictureBoxHeight = (int)(this.ClientSize.Height * 0.7F);
    
            bpPictureBox.Location = new Point(pictureBoxX, FormMargin);
            bpPictureBox.Size = new Size(pictureBoxWidth, pictureBoxHeight);
            bpPictureBox.BackColor = Color.Beige;
            bpPictureBox.BorderStyle = BorderStyle.Fixed3D;

            // Create bitmap with exact PictureBox dimensions
            bpPictureBox.Image = new Bitmap(bpPictureBox.Width, bpPictureBox.Height);
            drawingBoard = Graphics.FromImage(bpPictureBox.Image);
            pen.DashStyle = DashStyle.Solid;

            // Shapes list positioning
            int listX = bpPictureBox.Right + Margin;
            int listY = bpPictureBox.Top;
            bpShapesList.Location = new Point(listX, listY);
            bpShapesList.Size = new Size(
                this.ClientSize.Width - listX - FormMargin,
                this.ClientSize.Height - FormMargin - listY
            );
        }
        private void bpCockpitLaboratory_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = MessageBox.Show("Czy napewno chcesz zamknąć Projekt Laboratoryjny?", "Zamknij", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (DialogResult == DialogResult.Yes)
            {
                e.Cancel = false;
                
                bpCockpit bpMainForm = new bpCockpit();
                 
                this.Hide();
                bpMainForm.Show();
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void bpTxtShapesCount_TextChanged(object sender, EventArgs e)
        {
            ValidationResult<int> result = Helpers.ValidateInt(bpTxtShapesCount.Text);
            
            if (!result.Success)
            {
                MessageBox.Show(result.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bpTxtShapesCount.Text = "";
                return;
            }

            bpBtnStart.Enabled = true;
            
            // nie trzeba sprawdzac czy zostaly zaznaczone figury poniewaz przycisk bedzie zablokowany jezeli nie bedzie wybranych figur
        }

        private void bpShapesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bpShapesList.CheckedItems.Count > 0)
            {
                bpTxtShapesCount.Enabled = true;
            }
            else
            {
                bpTxtShapesCount.Enabled = false;
            }
        }

        private void bpBtnStart_Click(object sender, EventArgs e)
        {
            ValidationResult<int> result = Helpers.ValidateInt(bpTxtShapesCount.Text);
            
            if (!result.Success)
            {
                MessageBox.Show(result.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bpTxtShapesCount.Text = "";
                return;
            }
            
            // clear the drawing board
            drawingBoard.Clear(Color.Beige);
            
            // create a tfg table
            bpTFG = new GeometricShapes.Point[result.ParsedValue];
            IndexTFG = 0;
            CheckedListBox.CheckedItemCollection selectedShapes = bpShapesList.CheckedItems;
            bpShapesList.Enabled = false;

            int randomShapeIndex;
            string randomShape;
            
            Random rnd = new Random();

            int XMax = bpPictureBox.Width;
            int YMax = bpPictureBox.Height;
            int Xp, Yp, Xk, Yk;
            int circleRadius, bigAxis, smallAxis;
            int width, height;
            int SquareSide;
            int polygonDegree;

            for (int i = 0; i < result.ParsedValue; i++)
            {
                Xp = rnd.Next(FormMargin, XMax - FormMargin);
                Yp = rnd.Next(FormMargin, YMax - FormMargin);
                randomShapeIndex = rnd.Next(selectedShapes.Count);
                randomShape = selectedShapes[randomShapeIndex].ToString();

                switch (randomShape)
                {
                    case "Punkt":
                        bpTFG[IndexTFG] = new GeometricShapes.Point(Xp, Yp);
                        bpTFG[IndexTFG].Draw(drawingBoard);
                        bpPictureBox.Refresh(); 
                        IndexTFG++;
                        break;
                    case "Linia":
                        Xk = rnd.Next(FormMargin, XMax - FormMargin);
                        Yk = rnd.Next(FormMargin, YMax - FormMargin);
                        bpTFG[IndexTFG] = new Line(Xp, Yp, Xk, Yk);
                        bpTFG[IndexTFG].Draw(drawingBoard);
                        bpPictureBox.Refresh(); 
                        IndexTFG++;
                        break;
                    // case "Koło":
                    //     circleRadius = rnd.Next(1, 100);
                    //     bpTFG[IndexTFG] = new Circle(Xp, Yp, circleRadius);
                    //     IndexTFG++;
                    //     break;
                    // case "Elipsa":
                    //     bigAxis = rnd.Next(1, 100);
                    //     smallAxis = rnd.Next(1, 100);
                    //     bpTFG[IndexTFG] = new Ellipse(Xp, Yp, bigAxis, smallAxis);
                    //     IndexTFG++;
                    //     break;
                    // case "Prostokąt":
                    //     width = rnd.Next(1, 100);
                    //     height = rnd.Next(1, 100);
                    //     bpTFG[IndexTFG] = new Rectangle(Xp, Yp, width, height);
                    //     IndexTFG++;
                    //     break;
                    // case "Kwadrat":
                    //     SquareSide = rnd.Next(1, 100);
                    //     bpTFG[IndexTFG] = new Square(Xp, Yp, SquareSide);
                    //     IndexTFG++;
                    //     break;
                    // case "Wielokąt":
                    //     polygonDegree = rnd.Next(3, 10);
                    //     bpTFG[IndexTFG] = new Polygon(Xp, Yp, polygonDegree);
                    //     IndexTFG++;
                    //     break;
                    default:
                        MessageBox.Show("Wylosowana została figura o nazwie: " + randomShape + " ale jest ona w trakcie realizacji", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                } // switch case end
                
            } // for loop end
            
            bpShapesList.Enabled = true;
            bpBtnMoveShape.Enabled = true;
            
            bpBtnStart.Enabled = false;

        } // bpBtnStart_Click end

        private void bpBtnMoveShape_Click(object sender, EventArgs e)
        {
            if (IndexTFG == 0 || bpTFG == null)
            {
                MessageBox.Show("Brak figur do przesunięcia.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        
            Random rnd = new Random();
        
            drawingBoard.Clear(Color.Beige);

            int Xmax, Ymax;

            Xmax = bpPictureBox.Width;
            Ymax = bpPictureBox.Height;
        
            for (int i = 0; i < IndexTFG; i++)
            {
                if (bpTFG[i] != null)
                {
                    int offsetX = rnd.Next(FormMargin, Xmax - FormMargin);
                    int offsetY = rnd.Next(FormMargin, Ymax - FormMargin);
            
                    bpTFG[i].Move(drawingBoard, bpPictureBox, offsetX, offsetY);
                }
            }
        
            bpPictureBox.Refresh();
        }    
    }
}