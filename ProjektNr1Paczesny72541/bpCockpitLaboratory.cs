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

            if (selectedShapes.Count == 0)
            {
                MessageBox.Show("Proszę wybrać przynajmniej jedną figurę.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bpShapesList.Enabled = true;
                return;
            }

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

                // Generate a random color different from the background
                do
                {
                    color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                } while (color == Color.Beige);
                
                dashStyle = (DashStyle)rnd.Next(5);
                lineWidth = rnd.Next(1, 5);

                switch (currentShape)
                {
                    case "Punkt":
                        bpTFG[IndexTFG] = new GeometricShapes.Point(Xp, Yp, color);
                        bpTFG[IndexTFG].SetAttributes(color, dashStyle, lineWidth);
                        IndexTFG++;
                        break;
                    case "Linia":
                        Xk = rnd.Next(FormMargin, XMax - FormMargin);
                        Yk = rnd.Next(FormMargin, YMax - FormMargin);
                        bpTFG[IndexTFG] = new Line(Xp, Yp, Xk, Yk, color);
                        bpTFG[IndexTFG].SetAttributes(color, dashStyle, lineWidth);
                        IndexTFG++;
                        break;
                    case "Okrąg":
                        circleRadius = rnd.Next(10, 50);
                        bpTFG[IndexTFG] = new Circle(Xp, Yp, circleRadius, color, dashStyle, lineWidth);
                        IndexTFG++;
                        break;
                    case "Elipsa":
                        bigAxis = rnd.Next(20, 100);
                        smallAxis = rnd.Next(10, 50);
                        bpTFG[IndexTFG] = new Elipse(Xp, Yp, bigAxis, smallAxis, color, dashStyle, lineWidth);
                        IndexTFG++;
                        break;
                    default:
                        MessageBox.Show("Wylosowana została figura o nazwie: " + currentShape + " ale jest ona w trakcie realizacji", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                } // switch case end
                
            } // for loop end
            
            // Draw all the shapes
            for (int i = 0; i < IndexTFG; i++)
            {
                if (bpTFG[i] != null)
                {
                    bpTFG[i].Draw(drawingBoard);
                }
            } // for loop end
            
            bpPictureBox.Refresh();
            
            bpShapesList.Enabled = true;
            bpBtnMoveShape.Enabled = IndexTFG > 0;
            bpBtnSetRandomAttributes.Enabled = IndexTFG > 0;
            bpBtnTurnOnSlider.Enabled = IndexTFG > 0;
            
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
            if (IndexTFG == 0 || bpTFG == null)
            {
                MessageBox.Show("Brak figur do wyświetlenia.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            drawingBoard.Clear(bpPictureBox.BackColor);

            int XMax = bpPictureBox.Width;
            int YMax = bpPictureBox.Height;
            
            // ustawic indeks pierwszej figury do wyswietlenia
            bpTimer.Tag = 0;
            bpTxtIndexTVG.Text = "0";
            
            // Center and draw the first shape
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
                bpTxtColorPicker.BackColor = bpTFG[0].Color;

                // Update sliders to match current position
                bpTBarX.Value = bpTFG[0].X;
                bpTBarY.Value = bpTFG[0].Y;
                
                bpTxtTBarX.Text = bpTBarX.Value.ToString();
                bpTxtTBarY.Text = bpTBarY.Value.ToString();

                // Set the line style dropdown to match the current shape
                bpCBoxLineStyle.SelectedIndex = (int)bpTFG[0].DashStyle;
                
                // Set the line thickness control
                decimal lineWidth = (decimal)bpTFG[0].LineWidth;
                if (lineWidth < bpNumUpDownLineThicknes.Minimum)
                    lineWidth = bpNumUpDownLineThicknes.Minimum;
                bpNumUpDownLineThicknes.Value = lineWidth;
            }
            
            // deactivate the button
            bpBtnTurnOnSlider.Enabled = false;
            // activate the button to turn off the slider
            bpBtnTurnOfSlider.Enabled = true;
        }

        private void bpTimer_Tick(object sender, EventArgs e)
        {
            if (IndexTFG == 0 || bpTFG == null) return;
            
            drawingBoard.Clear(bpPictureBox.BackColor);

            int XMax = bpPictureBox.Width;
            int YMax = bpPictureBox.Height;
            
            int currentIndex = (int)bpTimer.Tag;
            if (currentIndex >= IndexTFG) currentIndex = 0;
            
            // presenting the next geometric shape in the central part of the bpPictureBox
            bpTFG[currentIndex].Move(drawingBoard, bpPictureBox, XMax/2, YMax/2);
            
            bpPictureBox.Refresh();
            
            // wyznaczenie indeksu nastepnej figury do prezentacji
            bpTimer.Tag = (currentIndex + 1) % IndexTFG;
            bpTxtIndexTVG.Text = bpTimer.Tag.ToString();
        }

        private void bpBtnNext_Click(object sender, EventArgs e)
        {
            if (IndexTFG == 0 || bpTFG == null)
            {
                MessageBox.Show("Brak figur do wyświetlenia.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            // validate the index
            ValidationResult<int> result = Helpers.ValidateInt(bpTxtIndexTVG.Text);

            if (!result.Success)
            {
                MessageBox.Show(result.Message);
                bpTxtIndexTVG.Text = "0";
                return;
            }

            int bpShapeIndex = result.ParsedValue;

            // Clear the entire drawing board
            drawingBoard.Clear(bpPictureBox.BackColor);

            // Calculate the next index
            if (bpShapeIndex < IndexTFG - 1)
            {
                bpShapeIndex++;
            }
            else
            {
                bpShapeIndex = 0;
            }

            // Check for valid index
            if (bpShapeIndex >= IndexTFG || bpShapeIndex < 0)
            {
                bpShapeIndex = 0;
            }

            if (bpTFG[bpShapeIndex] == null)
            {
                MessageBox.Show("Brak figury dla indeksu " + bpShapeIndex, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int XMax = bpPictureBox.Width;
            int YMax = bpPictureBox.Height;

            // Center the shape
            bpTFG[bpShapeIndex].Move(drawingBoard, bpPictureBox, XMax/2, YMax/2);

            // Update UI controls
            bpTBarX.Maximum = XMax;
            bpTBarX.Value = bpTFG[bpShapeIndex].X;
            bpTBarY.Maximum = YMax;
            bpTBarY.Value = bpTFG[bpShapeIndex].Y;
            bpTxtColorPicker.BackColor = bpTFG[bpShapeIndex].Color;
            bpTxtTBarX.Text = bpTBarX.Value.ToString();
            bpTxtTBarY.Text = bpTBarY.Value.ToString();
            bpCBoxLineStyle.SelectedIndex = (int)bpTFG[bpShapeIndex].DashStyle;
    
            // Check if LineWidth is less than the minimum allowed value
            decimal lineWidth = (decimal)bpTFG[bpShapeIndex].LineWidth;
            if (lineWidth < bpNumUpDownLineThicknes.Minimum)
                lineWidth = bpNumUpDownLineThicknes.Minimum;
    
            bpNumUpDownLineThicknes.Value = lineWidth;

            bpTxtIndexTVG.Text = bpShapeIndex.ToString();
            bpPictureBox.Refresh();
        }

        private void bpTBarX_Scroll(object sender, EventArgs e)
        {
            // get the index value of the shape that is currently being displayed
            ValidationResult<int> result = Helpers.ValidateInt(bpTxtIndexTVG.Text);
            if (!result.Success)
            {
                MessageBox.Show(result.Message);
                bpTxtIndexTVG.Text = "";
                return;
            }
            
            int bpShapeIndex = result.ParsedValue;
            
            // Move the shape directly - the Move method already handles erasing and redrawing
            bpTFG[bpShapeIndex].Move(drawingBoard, bpPictureBox, bpTBarX.Value, bpTFG[bpShapeIndex].Y);
            
            // update the text box with the current value of the slider
            bpTxtTBarX.Text = bpTBarX.Value.ToString();
            
            // Refresh the picture box to show the updated shape
            bpPictureBox.Refresh();
        }

        private void bpTBarY_Scroll(object sender, EventArgs e)
        {
            // get the index value of the shape that is currently being displayed
            ValidationResult<int> result = Helpers.ValidateInt(bpTxtIndexTVG.Text);
            if (!result.Success)
            {
                MessageBox.Show(result.Message);
                bpTxtIndexTVG.Text = "";
                return;
            }
            
            int bpShapeIndex = result.ParsedValue;
            
            // Move the shape directly - the Move method already handles erasing and redrawing
            bpTFG[bpShapeIndex].Move(drawingBoard, bpPictureBox, bpTFG[bpShapeIndex].X, bpTBarY.Value);
            
            // update the text box with the current value of the slider
            bpTxtTBarY.Text = bpTBarY.Value.ToString();
            
            // Refresh the picture box to show the updated shape
            bpPictureBox.Refresh();
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
                return;
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

        private void bpBtnPrevious_Click(object sender, EventArgs e)
        {
            if (IndexTFG == 0 || bpTFG == null)
            {
                MessageBox.Show("Brak figur do wyświetlenia.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            // get the index value of the shape that is currently being displayed
            ValidationResult<int> result = Helpers.ValidateInt(bpTxtIndexTVG.Text);
            if (!result.Success)
            {
                MessageBox.Show(result.Message);
                bpTxtIndexTVG.Text = "0";
                return;
            }

            int bpShapeIndex = result.ParsedValue;

            // Clear the entire drawing board
            drawingBoard.Clear(bpPictureBox.BackColor);

            // Calculate the previous index
            if (bpShapeIndex > 0)
            {
                bpShapeIndex--;
            }
            else
            {
                bpShapeIndex = IndexTFG - 1;
            }

            // Check for valid index
            if (bpShapeIndex >= IndexTFG || bpShapeIndex < 0)
            {
                bpShapeIndex = 0;
            }

            if (bpTFG[bpShapeIndex] == null)
            {
                MessageBox.Show("Brak figury dla indeksu " + bpShapeIndex, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int XMax = bpPictureBox.Width;
            int YMax = bpPictureBox.Height;

            // Center the shape
            bpTFG[bpShapeIndex].Move(drawingBoard, bpPictureBox, XMax/2, YMax/2);

            // Update UI controls
            bpTBarX.Maximum = XMax;
            bpTBarX.Value = bpTFG[bpShapeIndex].X;
            bpTBarY.Maximum = YMax;
            bpTBarY.Value = bpTFG[bpShapeIndex].Y;
            bpTxtColorPicker.BackColor = bpTFG[bpShapeIndex].Color;
            bpTxtTBarX.Text = bpTBarX.Value.ToString();
            bpTxtTBarY.Text = bpTBarY.Value.ToString();
            bpCBoxLineStyle.SelectedIndex = (int)bpTFG[bpShapeIndex].DashStyle;
    
            // Check if LineWidth is less than the minimum allowed value
            decimal lineWidth = (decimal)bpTFG[bpShapeIndex].LineWidth;
            if (lineWidth < bpNumUpDownLineThicknes.Minimum)
                lineWidth = bpNumUpDownLineThicknes.Minimum;
    
            bpNumUpDownLineThicknes.Value = lineWidth;

            bpTxtIndexTVG.Text = bpShapeIndex.ToString();
            bpPictureBox.Refresh();
        }
    }
}
