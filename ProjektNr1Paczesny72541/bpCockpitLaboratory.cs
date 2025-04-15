using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Timers;
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
            bpBtnSetRandomAttributes.Location = new Point(FormMargin, bpBtnMoveShape.Bottom + Margin);
            bpBtnTurnOnSlider.Location = new Point(FormMargin, bpBtnSetRandomAttributes.Bottom + Margin);
            bpGrBoxViewStyle.Location = new Point(FormMargin, bpBtnTurnOnSlider.Bottom + Margin);
            bpGrBoxNavigation.Location = new Point(FormMargin, bpGrBoxViewStyle.Bottom + Margin);
            bpBtnTurnOfSlider.Location = new Point(FormMargin, bpGrBoxNavigation.Bottom + Margin);

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
                (int)(this.ClientSize.Height * 0.7F - FormMargin - listY)
            );
            bpGrBoxAttrChange.Location = new Point(this.ClientSize.Width - bpGrBoxAttrChange.Width - FormMargin, bpShapesList.Bottom + Margin);
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

            int currentShapeIndex;
            string currentShape;
            
            Random rnd = new Random();

            int XMax = bpPictureBox.Width;
            int YMax = bpPictureBox.Height;
            int Xp, Yp, Xk, Yk;
            int circleRadius, bigAxis, smallAxis;
            Color color;
            DashStyle dashStyle;
            int lineWidth;
            int width, height;
            int SquareSide;
            int polygonDegree;

            for (int i = 0; i < result.ParsedValue; i++)
            {
                Xp = rnd.Next(FormMargin, XMax - FormMargin);
                Yp = rnd.Next(FormMargin, YMax - FormMargin);
                currentShapeIndex = rnd.Next(selectedShapes.Count);
                currentShape = selectedShapes[currentShapeIndex].ToString();

                switch (currentShape)
                {
                    case "Punkt":
                        bpTFG[IndexTFG] = new GeometricShapes.Point(Xp, Yp);
                        IndexTFG++;
                        break;
                    case "Linia":
                        Xk = rnd.Next(FormMargin, XMax - FormMargin);
                        Yk = rnd.Next(FormMargin, YMax - FormMargin);
                        bpTFG[IndexTFG] = new Line(Xp, Yp, Xk, Yk);
                        
                        IndexTFG++;
                        break;
                    case "Okrąg":
                        circleRadius = rnd.Next(1, 100);
                        do
                        {
                            color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                        } while (color == Color.Beige);
                        dashStyle = (DashStyle)rnd.Next(5);
                        lineWidth = (int)(rnd.NextDouble() * 10);
                        bpTFG[IndexTFG] = new Circle(Xp, Yp, circleRadius, color, dashStyle, lineWidth);
                        
                        IndexTFG++;
                        break;
                    case "Elipsa":
                        bigAxis = rnd.Next(1, 100);
                        smallAxis = rnd.Next(1, 100);
                        do
                        {
                            color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                        } while (color == Color.Beige);
                        dashStyle = (DashStyle)rnd.Next(5);
                        lineWidth = (int)(rnd.NextDouble() * 10);
                        bpTFG[IndexTFG] = new Elipse(Xp, Yp, bigAxis, smallAxis, color, dashStyle, lineWidth);
                        
                        IndexTFG++;
                        break;
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
                        MessageBox.Show("Wylosowana została figura o nazwie: " + currentShape + " ale jest ona w trakcie realizacji", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                } // switch case end
                
            } // for loop end
            
            for (int i = 0; i < IndexTFG; i++)
            {
                if (bpTFG[i] != null)
                {
                    bpTFG[i].Draw(drawingBoard);
                }
            } // for loop end
            
            bpPictureBox.Refresh();
            
            bpShapesList.Enabled = true;
            bpBtnMoveShape.Enabled = true;
            bpBtnSetRandomAttributes.Enabled = true;
            bpBtnTurnOnSlider.Enabled = true;
            
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

        private void bpBtnSetRandomAttributes_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            Color color;
            DashStyle dashStyle;
            int X, Y;
            float lineWidth;
            
            drawingBoard.Clear(Color.Beige);
            
            for (int i = 0; i < IndexTFG; i++)
            {
                if (bpTFG[i] != null)
                {
                    bpTFG[i].Erase(drawingBoard, bpPictureBox);
                    
                    do
                    {
                        color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                    } while (color == Color.Beige);
                    
                    dashStyle = (DashStyle)rnd.Next(0, 5);
                    lineWidth = (float)rnd.NextDouble() * 10;

                    bpTFG[i].SetAttributes(color, dashStyle, lineWidth);
                    
                    bpTFG[i].Draw(drawingBoard);
                } // if end
                else
                {
                    Console.WriteLine($"bpTFG[{i}] is null");
                }
            } // for loop end
            
            bpPictureBox.Refresh();
        } // bpBtnSetRandomAttributes_Click end

        private void bpBtnTurnOnSlider_Click(object sender, EventArgs e)
        {
            // turn off the error provider
            
            drawingBoard.Clear(bpPictureBox.BackColor);

            int XMax = bpPictureBox.Width;
            int YMax = bpPictureBox.Height;
            
            // ustawic indeks pierwszej figury do wyswietlenia
            bpTimer.Tag = 0;
            bpTxtIndexTVG.Text = "0";
            
            bpTFG[0].Move(drawingBoard, bpPictureBox, XMax / 2, YMax / 2);
            
            bpPictureBox.Refresh();
            
            // rozpoznanie wybranego trybu prezentacji figur

            if (bpRdBtnInterval.Checked)
            {
                bpTimer.Enabled = true;
            }
            else
            {
                bpGrBoxNavigation.Enabled = true;
                bpGrBoxAttrChange.Enabled = true;
                
                // set values for tools responsible for changing the attributes of shapes
                bpTBarX.Maximum = XMax;
                bpTBarX.Value = XMax / 2;
                
                bpTBarY.Maximum = YMax;
                bpTBarY.Value = YMax / 2;

                // set background color of the color picker to the color of the first shape
                // bpBtnColorPicker.BackColor = bpTFG[0].Color;
                bpTxtColorPicker.BackColor = bpTFG[0].Color;

                // set the x and y coordinates of the shape to the tbars
                bpTBarX.Value = bpTFG[0].X;
                bpTBarY.Value = bpTFG[0].Y;
                
                bpTxtTBarX.Text = bpTBarX.Value.ToString();
                bpTxtTBarY.Text = bpTBarY.Value.ToString();

                bpCBoxLineStyle.SelectedItem = bpTFG[0].DashStyle;
                
                bpNumUpDownLineThicknes.Value = (decimal)bpTFG[0].LineWidth;
            }
            
            // deactivate the button
            bpBtnTurnOnSlider.Enabled = false;
            // activate the button to turn off the slider
            bpBtnTurnOfSlider.Enabled = true;
        }

        private void bpTimer_Tick(object sender, EventArgs e)
        {
            drawingBoard.Clear(bpPictureBox.BackColor);

            int XMax = bpPictureBox.Width;
            int YMax = bpPictureBox.Height;
            
            // presenting the next geometric shape in the central part of the bpPictureBox
            bpTFG[(int)bpTimer.Tag].Move(drawingBoard, bpPictureBox, XMax/2, YMax/2);
            
            bpPictureBox.Refresh();
            
            // wyznaczenie indeksu nastepnej figury do prezentacji

            bpTimer.Tag = ((int)bpTimer.Tag + 1) % IndexTFG;
            bpTxtIndexTVG.Text = bpTimer.Tag.ToString();
        }

        private void bpBtnNext_Click(object sender, EventArgs e)
        {
            // validate the index
            ValidationResult<int> result = Helpers.ValidateInt(bpTxtIndexTVG.Text);

            if (!result.Success)
            {
                MessageBox.Show(result.Message);
                bpTxtIndexTVG.Text = "";
            }

            int bpShapeIndex = result.ParsedValue;
            
            bpTFG[bpShapeIndex].Erase(drawingBoard, bpPictureBox);

            if (bpShapeIndex < IndexTFG - 1)
            {
                bpShapeIndex++;
            }
            else
            {
                bpShapeIndex = 0;
            }

            int XMax = bpPictureBox.Width;
            int YMax = bpPictureBox.Height;
            
            // set values for tools responsible for changing the attributes of shapes
            bpTBarX.Maximum = XMax;
            bpTBarX.Value = int.Parse((XMax / 2).ToString());
            
            bpTBarY.Maximum = YMax;
            bpTBarY.Value = int.Parse((YMax / 2).ToString());

            // set background color of the color picker to the color of the first shape
            bpTxtColorPicker.BackColor = bpTFG[bpShapeIndex].Color;
            
            // set the x and y coordinates of the shape to the tbars
            bpTBarX.Value = bpTFG[bpShapeIndex].X;
            bpTBarY.Value = bpTFG[bpShapeIndex].Y;
            
            bpTxtTBarX.Text = bpTBarX.Value.ToString();
            bpTxtTBarY.Text = bpTBarY.Value.ToString();

            bpCBoxLineStyle.SelectedItem = bpTFG[bpShapeIndex].DashStyle;
            
            bpNumUpDownLineThicknes.Value = (decimal)bpTFG[bpShapeIndex].LineWidth;
            
            // presenting the next geometric shape in the central part of the bpPictureBox
            bpTFG[bpShapeIndex].Move(drawingBoard, bpPictureBox, XMax/2, YMax/2);
            
            bpTxtIndexTVG.Text = bpShapeIndex.ToString();
            
            bpPictureBox.Refresh();
        }

        private void bpTBarX_Scroll(object sender, EventArgs e)
        {
            // clear the error provider
            
            // get the index value of the shape that is currently being displayed
            ValidationResult<int> result = Helpers.ValidateInt(bpTxtIndexTVG.Text);
            if (!result.Success)
            {
                MessageBox.Show(result.Message);
                bpTxtIndexTVG.Text = "";
            }
            
            int bpShapeIndex = result.ParsedValue;
            
            bpTFG[bpShapeIndex].Erase(drawingBoard, bpPictureBox);
            
            bpPictureBox.Refresh();
            
            bpTFG[bpShapeIndex].Move(drawingBoard, bpPictureBox, bpTBarX.Value, bpTFG[bpShapeIndex].Y);
            // update the text box with the current value of the slider
            bpTxtTBarX.Text = bpTBarX.Value.ToString();
        }

        private void bpTBarY_Scroll(object sender, EventArgs e)
        {
            // clear the error provider
            
            // get the index value of the shape that is currently being displayed
            ValidationResult<int> result = Helpers.ValidateInt(bpTxtIndexTVG.Text);
            if (!result.Success)
            {
                MessageBox.Show(result.Message);
                bpTxtIndexTVG.Text = "";
            }
            
            int bpShapeIndex = result.ParsedValue;
            
            bpTFG[bpShapeIndex].Erase(drawingBoard, bpPictureBox);
            
            bpPictureBox.Refresh();
            
            bpTFG[bpShapeIndex].Move(drawingBoard, bpPictureBox, bpTFG[bpShapeIndex].X, bpTBarY.Value);
            // update the text box with the current value of the slider
            bpTxtTBarY.Text = bpTBarY.Value.ToString();
        }

        private void bpBtnColorPicker_Click(object sender, EventArgs e)
        {
            // show a modal dialog to select a color
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = bpTxtColorPicker.BackColor;
            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = true;
            DialogResult dialogResult = colorDialog.ShowDialog();

            if (dialogResult == DialogResult.Cancel)
            {
                return;
            }
            
            // set the selected color as the background color of the button
            bpTxtColorPicker.BackColor = colorDialog.Color;
            // set the selected color as the color of the shape
            // bpTFG[bpShapeIndex].Color = colorDialog.Color;
            // get the index value of the shape that is currently being displayed
            ValidationResult<int> result = Helpers.ValidateInt(bpTxtIndexTVG.Text);
            if (!result.Success)
            {
                MessageBox.Show(result.Message);
                bpTxtIndexTVG.Text = "";
            }
            
            int bpShapeIndex = result.ParsedValue;
            // erase the shape
            bpTFG[bpShapeIndex].Erase(drawingBoard, bpPictureBox);
            
            bpPictureBox.Refresh();
            
            // set the color of the shape
            bpTFG[bpShapeIndex].SetAttributes(bpTxtColorPicker.BackColor, bpTFG[bpShapeIndex].DashStyle, bpTFG[bpShapeIndex].LineWidth);
            // draw the shape
            bpTFG[bpShapeIndex].Draw(drawingBoard);
            
            bpPictureBox.Refresh();
            
        }

        private void bpCBoxLineStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the index value of the shape that is currently being displayed
            ValidationResult<int> result = Helpers.ValidateInt(bpTxtIndexTVG.Text);
            if (!result.Success)
            {
                MessageBox.Show(result.Message);
                bpTxtIndexTVG.Text = "";
            }
            
            int bpShapeIndex = result.ParsedValue;
            
            // erase the shape
            bpTFG[bpShapeIndex].Erase(drawingBoard, bpPictureBox);
            
            bpPictureBox.Refresh();
            
            // set the line style of the shape
            if (bpCBoxLineStyle.SelectedItem != null)
            {
                DashStyle selectedDashStyle = (DashStyle)bpCBoxLineStyle.SelectedIndex;
                bpTFG[bpShapeIndex].SetAttributes(bpTFG[bpShapeIndex].Color, selectedDashStyle, bpTFG[bpShapeIndex].LineWidth);
            }
            
            // draw the shape
            bpTFG[bpShapeIndex].Draw(drawingBoard);
            
            bpPictureBox.Refresh();
        }

        private void bpNumUpDownLineThicknes_ValueChanged(object sender, EventArgs e)
        {
            // get the index value of the shape that is currently being displayed
            ValidationResult<int> result = Helpers.ValidateInt(bpTxtIndexTVG.Text);
            if (!result.Success)
            {
                MessageBox.Show(result.Message);
                bpTxtIndexTVG.Text = "";
            }
            
            int bpShapeIndex = result.ParsedValue;
            
            // erase the shape
            bpTFG[bpShapeIndex].Erase(drawingBoard, bpPictureBox);
            
            bpPictureBox.Refresh();
            
            // set the line thickness of the shape
            float selectedLineWidth = (float)bpNumUpDownLineThicknes.Value;
            bpTFG[bpShapeIndex].SetAttributes(bpTFG[bpShapeIndex].Color, bpTFG[bpShapeIndex].DashStyle, selectedLineWidth);
            
            // draw the shape
            bpTFG[bpShapeIndex].Draw(drawingBoard);
            
            bpPictureBox.Refresh();
        }
    }
}