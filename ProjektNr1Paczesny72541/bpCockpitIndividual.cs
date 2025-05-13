using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using ProjektNr1Paczesny72541;

namespace ProjektNr1Paczesny72541
{
    public partial class bpCockpitIndividual : Form
    {
        // Lista Figur Geometrycznych
        List<Shape> bpLFG;
        // Rysownica
        Graphics bpRysownica;
        // Pomocnicze punkty do rysowania
        System.Drawing.Point bpPunktStart;
        bool bpPoczatekRysowania;
        bool bpPrzesuwanieFiguryAktywne = false;

        // Atrybuty graficzne dla nowo rysowanych figur
        Color bpAktualnyKolor = Color.Black;
        DashStyle bpAktualnyStylLinii = DashStyle.Solid;
        float bpAktualnaGruboscLinii = 1f;

        // Dla slajdera
        Timer bpTimerSlajdera;
        int bpIndexFigurySlajdera = -1; // -1 oznacza brak wybranej figury

        // --- For Glued Bezier ---
        private bool bpGluedBezierDrawing = false;
        private List<Point> bpGluedBezierPoints = new List<Point>();
        private Point? bpPreviewPoint = null;
        private Shape bpPreviewShape = null;

        public bpCockpitIndividual()
        {
            InitializeComponent();

            // Inicjalizacja LFG
            bpLFG = new List<Shape>();

            // Ustawienie PictureBox do rysowania
            if (bpPictureBox.Width <= 0) bpPictureBox.Width = 300;
            if (bpPictureBox.Height <= 0) bpPictureBox.Height = 300;

            bpPictureBox.BackColor = Color.Beige;
            bpPictureBox.Image = new Bitmap(bpPictureBox.Width, bpPictureBox.Height);
            bpRysownica = Graphics.FromImage(bpPictureBox.Image);
            bpRysownica.Clear(bpPictureBox.BackColor);

            // Inicjalizacja Timera dla slajdera
            bpTimerSlajdera = new Timer();
            bpTimerSlajdera.Interval = 1000;
            bpTimerSlajdera.Tick += new EventHandler(bpTimerSlajdera_Tick);

            // Inicjalizacja flagi rysowania
            bpPoczatekRysowania = false;

            // Ustawienie początkowego stanu kontrolek
            AktualizujStanKontrolek();

            // Podpięcie zdarzeń myszy do PictureBox
            this.bpPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bpPictureBox_MouseDown);
            this.bpPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bpPictureBox_MouseUp);
            this.bpPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.bpPictureBox_MouseMove);

            // Podpięcie zdarzeń do przycisków slajdera
            this.bpBtnOn.Click += new System.EventHandler(this.bpBtnOn_Click);
            this.bpBtnOff.Click += new System.EventHandler(this.bpBtnOff_Click);
            this.bpBtnNext.Click += new System.EventHandler(this.bpBtnNext_Click);
            this.bpBtnPrevious.Click += new System.EventHandler(this.bpBtnPrevious_Click);

            // Podpięcie zdarzenia do przycisku zmiany atrybutów
            this.bpBtnNewGraphicalAttrs.Click += new System.EventHandler(this.bpBtnNewGraphicalAttrs_Click);
            this.bpBtnMoveToNewLocation.Click += new System.EventHandler(this.bpBtnMoveToNewLocation_Click);

            // Podpięcie zdarzenia do przycisku pokazania wszystkich figur
            this.bpBtnShowAllShapes.Click += new System.EventHandler(this.bpBtnShowAllShapes_Click);

            // Ustawienie TextBoxa indeksu na tylko do odczytu
            this.bpTxtIndexLFG.ReadOnly = true;

            this.bpNumSquareSide.ValueChanged += new EventHandler(this.bpNumSquareSide_ValueChanged);
            this.bpNumSquareX.ValueChanged += new EventHandler(this.bpNumSquareXY_ValueChanged);
            this.bpNumSquareY.ValueChanged += new EventHandler(this.bpNumSquareXY_ValueChanged);

            this.Load += new System.EventHandler(this.bpCockpitIndividual_Load);
            this.Resize += new System.EventHandler(this.bpCockpitIndividual_Resize);

            // Menu strip event handlers
            this.drukujBitMapęRysownicyToolStripMenuItem.Click += new EventHandler(this.drukujBitMapęRysownicyToolStripMenuItem_Click);
            this.zapiszBitMapęWPlikuToolStripMenuItem.Click += new EventHandler(this.zapiszBitMapęWPlikuToolStripMenuItem_Click);
            this.odtwórzBitMapęRysownicyZPlikuToolStripMenuItem.Click += new EventHandler(this.odtwórzBitMapęRysownicyZPlikuToolStripMenuItem_Click);
            this.exitZFormularzaToolStripMenuItem.Click += new EventHandler(this.exitZFormularzaToolStripMenuItem_Click);
            this.restartProgramuToolStripMenuItem.Click += new EventHandler(this.restartProgramuToolStripMenuItem_Click);
        }

        private void bpPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            bpLblMouseCoordinatesValue.Text = $"X: {e.X}, Y: {e.Y}";
            if (bpGluedBezierDrawing && bpGluedBezierPoints.Count > 0)
            {
                bpPreviewPoint = e.Location;
                // Show preview of the current segment
                var tempPoints = new List<Point>(bpGluedBezierPoints) { e.Location };
                if (tempPoints.Count >= 4)
                {
                    bpPreviewShape = new GluedBezierShape(tempPoints, bpAktualnyKolor, bpAktualnyStylLinii, bpAktualnaGruboscLinii, previewOnly: true);
                }
                else if (tempPoints.Count >= 2)
                {
                    bpPreviewShape = new LineShape(tempPoints[0], tempPoints[tempPoints.Count - 1], bpAktualnyKolor, bpAktualnyStylLinii, bpAktualnaGruboscLinii);
                }
                OdswiezRysownice();
            }
            else if (bpPoczatekRysowania)
            {
                // Preview for all other shapes
                Point previewEnd = e.Location;
                Shape preview = null;
                bool isFilled = false;
                bool isBordered = true;
                Color fillColor = Color.LightSkyBlue;
                if (bpRdRectFilled.Checked)
                {
                    isFilled = true; isBordered = true;
                    preview = new RectangleShape(bpPunktStart, previewEnd, bpAktualnyKolor, fillColor, bpAktualnyStylLinii, bpAktualnaGruboscLinii, isFilled, isBordered);
                }
                else if (bpRdSqrFilled.Checked)
                {
                    isFilled = true; isBordered = true;
                    preview = new SquareShape(bpPunktStart, previewEnd, bpAktualnyKolor, fillColor, bpAktualnyStylLinii, bpAktualnaGruboscLinii, isFilled, isBordered);
                }
                else if (bpRdElipsFilled.Checked)
                {
                    isFilled = true; isBordered = true;
                    preview = new EllipseShape(bpPunktStart, previewEnd, bpAktualnyKolor, fillColor, bpAktualnyStylLinii, bpAktualnaGruboscLinii, isFilled, isBordered);
                }
                else if (bpRdCircFilled.Checked)
                {
                    isFilled = true; isBordered = true;
                    preview = new CircleShape(bpPunktStart, previewEnd, bpAktualnyKolor, fillColor, bpAktualnyStylLinii, bpAktualnaGruboscLinii, isFilled, isBordered);
                }
                else if (bpRdBezier.Checked)
                {
                    preview = new BezierCurveShape(bpPunktStart, previewEnd, bpAktualnyKolor, bpAktualnyStylLinii, bpAktualnaGruboscLinii);
                }
                else if (bpRdCardinalCurve.Checked)
                {
                    var points = new List<Point> { bpPunktStart, previewEnd };
                    preview = new CardinalCurveShape(points, bpAktualnyKolor, bpAktualnyStylLinii, bpAktualnaGruboscLinii, false, false, true, fillColor);
                    ((CardinalCurveShape)preview).IsClosed = false;
                }
                else if (bpRdClosedCardinalCurve.Checked)
                {
                    var points = new List<Point> { bpPunktStart, previewEnd, new Point(bpPunktStart.X, previewEnd.Y + (previewEnd.Y > bpPunktStart.Y ? -20 : 20)) };
                    preview = new CardinalCurveShape(points, bpAktualnyKolor, bpAktualnyStylLinii, bpAktualnaGruboscLinii, true, false, true, fillColor);
                    ((CardinalCurveShape)preview).IsClosed = true;
                }
                else if (bpRdFilledClosedCardinalCurve.Checked)
                {
                    var points = new List<Point> { bpPunktStart, previewEnd, new Point(bpPunktStart.X, previewEnd.Y + (previewEnd.Y > bpPunktStart.Y ? -20 : 20)) };
                    preview = new CardinalCurveShape(points, bpAktualnyKolor, bpAktualnyStylLinii, bpAktualnaGruboscLinii, true, true, false, fillColor);
                    ((CardinalCurveShape)preview).IsClosed = true;
                }
                else if (bpRdFilledBorderedClosedCardinalCurve.Checked)
                {
                    var points = new List<Point> { bpPunktStart, previewEnd, new Point(bpPunktStart.X, previewEnd.Y + (previewEnd.Y > bpPunktStart.Y ? -20 : 20)) };
                    preview = new CardinalCurveShape(points, bpAktualnyKolor, bpAktualnyStylLinii, bpAktualnaGruboscLinii, true, true, true, fillColor);
                    ((CardinalCurveShape)preview).IsClosed = true;
                }
                else if (bpRdArc.Checked)
                {
                    preview = new ArcShape(bpPunktStart, previewEnd, bpAktualnyKolor, bpAktualnyStylLinii, bpAktualnaGruboscLinii, 0f, 90f);
                }
                else if (bpRdPie.Checked)
                {
                    preview = new PieShape(bpPunktStart, previewEnd, bpAktualnyKolor, fillColor, bpAktualnyStylLinii, bpAktualnaGruboscLinii, false, true, 0f, 90f);
                }
                else if (bpRdFilledPie.Checked)
                {
                    preview = new PieShape(bpPunktStart, previewEnd, bpAktualnyKolor, fillColor, bpAktualnyStylLinii, bpAktualnaGruboscLinii, true, false, 0f, 90f);
                }
                else if (bpRdFilledBorderedPie.Checked)
                {
                    preview = new PieShape(bpPunktStart, previewEnd, bpAktualnyKolor, fillColor, bpAktualnyStylLinii, bpAktualnaGruboscLinii, true, true, 0f, 90f);
                }
                else
                {
                    preview = new LineShape(bpPunktStart, previewEnd, bpAktualnyKolor, bpAktualnyStylLinii, bpAktualnaGruboscLinii);
                }
                preview.Visible = true;
                bpPreviewShape = preview;
                OdswiezRysownice();
            }
        }

        private void bpPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            // Debug
            Console.WriteLine(
                $"MouseDown: {e.Button}, X: {e.X}, Y: {e.Y}, PoczatekRysowania: {bpPoczatekRysowania}, PrzesuwanieAktywne: {bpPrzesuwanieFiguryAktywne}, IndexFigurySlajdera: {bpIndexFigurySlajdera}"
                );
            if (e.Button == MouseButtons.Left)
            {
                if (bpRdGluedBezier.Checked)
                {
                    if (!bpGluedBezierDrawing)
                    {
                        bpGluedBezierDrawing = true;
                        bpGluedBezierPoints.Clear();
                    }
                    bpGluedBezierPoints.Add(e.Location);
                    bpPreviewPoint = null;
                    bpPreviewShape = null;
                    OdswiezRysownice();
                    return;
                }
                if (bpPrzesuwanieFiguryAktywne && bpIndexFigurySlajdera != -1 && bpIndexFigurySlajdera < bpLFG.Count)
                {
                    Shape wybranaFigura = bpLFG[bpIndexFigurySlajdera];
                    int dx = e.X - wybranaFigura.ControlPoints[0].X;
                    int dy = e.Y - wybranaFigura.ControlPoints[0].Y;
                    wybranaFigura.Move(dx, dy);

                    bpPrzesuwanieFiguryAktywne = false;
                    OdswiezRysownice();
                    AktualizujStanKontrolek();
                }
                else if (!bpTimerSlajdera.Enabled && bpIndexFigurySlajdera == -1 && !bpPrzesuwanieFiguryAktywne) // Standard drawing
                {
                    bpPunktStart = e.Location;
                    bpPoczatekRysowania = true;
                }
            }
            else if (e.Button == MouseButtons.Right && bpGluedBezierDrawing)
            {
                // Finish glued Bezier
                if (bpGluedBezierPoints.Count >= 4)
                {
                    var glued = new GluedBezierShape(new List<Point>(bpGluedBezierPoints), bpAktualnyKolor, bpAktualnyStylLinii, bpAktualnaGruboscLinii);
                    glued.Visible = true;
                    bpLFG.Add(glued);
                }
                bpGluedBezierDrawing = false;
                bpGluedBezierPoints.Clear();
                bpPreviewPoint = null;
                bpPreviewShape = null;
                OdswiezRysownice();
                AktualizujStanKontrolek();
                return;
            }
        }

        private void bpPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (bpGluedBezierDrawing)
            {
                // Do not add shape on mouse up in glued mode
                return;
            }

            if (e.Button == MouseButtons.Left && bpPoczatekRysowania && !bpTimerSlajdera.Enabled && bpIndexFigurySlajdera == -1 && !bpPrzesuwanieFiguryAktywne)
            {
                Point bpPunktKoniec = e.Location;

                if (bpPunktStart.X == bpPunktKoniec.X && bpPunktStart.Y == bpPunktKoniec.Y)
                {
                    bpPoczatekRysowania = false;
                    return;
                }

                Shape nowaFigura = null;
                bool isFilled = false;
                bool isBordered = true;
                Color fillColor = Color.LightSkyBlue;

                // Ustalenie typu figury i jej atrybutów na podstawie wybranego RadioButtona
                if (bpRdRectFilled.Checked)
                {
                    isFilled = true; isBordered = true;
                    nowaFigura = new RectangleShape(bpPunktStart, bpPunktKoniec, bpAktualnyKolor, fillColor, bpAktualnyStylLinii, bpAktualnaGruboscLinii, isFilled, isBordered);
                }
                else if (bpRdSqrFilled.Checked)
                {
                    isFilled = true; isBordered = true;
                    nowaFigura = new SquareShape(bpPunktStart, bpPunktKoniec, bpAktualnyKolor, fillColor, bpAktualnyStylLinii, bpAktualnaGruboscLinii, isFilled, isBordered);
                }
                else if (bpRdElipsFilled.Checked)
                {
                    isFilled = true; isBordered = true;
                    nowaFigura = new EllipseShape(bpPunktStart, bpPunktKoniec, bpAktualnyKolor, fillColor, bpAktualnyStylLinii, bpAktualnaGruboscLinii, isFilled, isBordered);
                }
                else if (bpRdCircFilled.Checked)
                {
                    isFilled = true; isBordered = true;
                    nowaFigura = new CircleShape(bpPunktStart, bpPunktKoniec, bpAktualnyKolor, fillColor, bpAktualnyStylLinii, bpAktualnaGruboscLinii, isFilled, isBordered);
                }
                else if (bpRdBezier.Checked)
                {
                    isFilled = false; isBordered = true;
                    nowaFigura = new BezierCurveShape(bpPunktStart, bpPunktKoniec, bpAktualnyKolor, bpAktualnyStylLinii, bpAktualnaGruboscLinii);
                }
                else if (bpRdGluedBezier.Checked)
                {
                    isFilled = false; isBordered = true;
                    nowaFigura = new BezierCurveShape(bpPunktStart, bpPunktKoniec, bpAktualnyKolor, bpAktualnyStylLinii, bpAktualnaGruboscLinii);
                    MessageBox.Show("Sklejana krzywa Beziera jest rysowana jako pojedyncza krzywa Beziera (uproszczenie).", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (bpRdCardinalCurve.Checked)
                {
                    var points = new List<System.Drawing.Point> { bpPunktStart, bpPunktKoniec }; // Minimal points for an open curve
                    nowaFigura = new CardinalCurveShape(points, bpAktualnyKolor, bpAktualnyStylLinii, bpAktualnaGruboscLinii, false, false, true, fillColor);
                    ((CardinalCurveShape)nowaFigura).IsClosed = false;
                }
                else if (bpRdClosedCardinalCurve.Checked)
                {
                    var points = new List<System.Drawing.Point> { bpPunktStart, bpPunktKoniec, new System.Drawing.Point(bpPunktStart.X, bpPunktKoniec.Y + (bpPunktKoniec.Y > bpPunktStart.Y ? -20 : 20)) };
                    nowaFigura = new CardinalCurveShape(points, bpAktualnyKolor, bpAktualnyStylLinii, bpAktualnaGruboscLinii, true, false, true, fillColor);
                    ((CardinalCurveShape)nowaFigura).IsClosed = true;
                }
                else if (bpRdFilledClosedCardinalCurve.Checked)
                {
                    var points = new List<System.Drawing.Point> { bpPunktStart, bpPunktKoniec, new System.Drawing.Point(bpPunktStart.X, bpPunktKoniec.Y + (bpPunktKoniec.Y > bpPunktStart.Y ? -20 : 20)) };
                    nowaFigura = new CardinalCurveShape(points, bpAktualnyKolor, bpAktualnyStylLinii, bpAktualnaGruboscLinii, true, true, false, fillColor);
                    ((CardinalCurveShape)nowaFigura).IsClosed = true;
                }
                else if (bpRdFilledBorderedClosedCardinalCurve.Checked)
                {
                    var points = new List<System.Drawing.Point> { bpPunktStart, bpPunktKoniec, new System.Drawing.Point(bpPunktStart.X, bpPunktKoniec.Y + (bpPunktKoniec.Y > bpPunktStart.Y ? -20 : 20)) };
                    nowaFigura = new CardinalCurveShape(points, bpAktualnyKolor, bpAktualnyStylLinii, bpAktualnaGruboscLinii, true, true, true, fillColor);
                    ((CardinalCurveShape)nowaFigura).IsClosed = true;
                }
                else if (bpRdArc.Checked)
                {
                    nowaFigura = new ArcShape(bpPunktStart, bpPunktKoniec, bpAktualnyKolor, bpAktualnyStylLinii, bpAktualnaGruboscLinii, 0f, 90f); // Default angles
                }
                else if (bpRdPie.Checked) // Bordered, not filled
                {
                    nowaFigura = new PieShape(bpPunktStart, bpPunktKoniec, bpAktualnyKolor, fillColor, bpAktualnyStylLinii, bpAktualnaGruboscLinii, false, true, 0f, 90f);
                }
                else if (bpRdFilledPie.Checked) // Filled, not bordered
                {
                    nowaFigura = new PieShape(bpPunktStart, bpPunktKoniec, bpAktualnyKolor, fillColor, bpAktualnyStylLinii, bpAktualnaGruboscLinii, true, false, 0f, 90f);
                }
                else if (bpRdFilledBorderedPie.Checked) // Filled and bordered
                {
                    nowaFigura = new PieShape(bpPunktStart, bpPunktKoniec, bpAktualnyKolor, fillColor, bpAktualnyStylLinii, bpAktualnaGruboscLinii, true, true, 0f, 90f);
                }
                else
                {
                    isFilled = false; isBordered = true;
                    nowaFigura = new LineShape(bpPunktStart, bpPunktKoniec, bpAktualnyKolor, bpAktualnyStylLinii, bpAktualnaGruboscLinii);
                }

                if (nowaFigura != null)
                {
                    nowaFigura.Visible = true;
                    bpLFG.Add(nowaFigura);
                    OdswiezRysownice();
                    AktualizujStanKontrolek();
                }
                bpPoczatekRysowania = false;
                AktualizujStanKontrolek();
                Console.WriteLine($"Shape added: {nowaFigura.GetType().Name}, Visible: {nowaFigura.Visible}, Points: ({bpPunktStart.X},{bpPunktStart.Y})-({bpPunktKoniec.X},{bpPunktKoniec.Y})");
            }
            bpPreviewShape = null;
        }

        private void ReinitializeDrawingSurface()
        {
            // Ensure PictureBox has valid dimensions
            if (bpPictureBox.Width <= 0) bpPictureBox.Width = 300;
            if (bpPictureBox.Height <= 0) bpPictureBox.Height = 300;

            // Create new bitmap with current PictureBox dimensions
            bpPictureBox.Image = new Bitmap(bpPictureBox.Width, bpPictureBox.Height);
            bpRysownica = Graphics.FromImage(bpPictureBox.Image);
            bpRysownica.Clear(bpPictureBox.BackColor);
            bpPictureBox.Refresh();
        }

        private void bpCockpitIndividual_Load(object sender, EventArgs e)
        {
            ReinitializeDrawingSurface();
        }

        private void bpCockpitIndividual_Resize(object sender, EventArgs e)
        {
            ReinitializeDrawingSurface();
            // Optionally redraw existing shapes
            OdswiezRysownice();
        }

        private void OdswiezRysownice()
        {
            bpRysownica.Clear(bpPictureBox.BackColor);
            if ((bpGluedBezierDrawing || bpPoczatekRysowania) && bpPreviewShape != null)
            {
                foreach (Shape figura in bpLFG)
                {
                    if (figura.Visible)
                        figura.Draw(bpRysownica);
                }
                bpPreviewShape.Draw(bpRysownica);
                bpPictureBox.Refresh();
                return;
            }

            if ((bpTimerSlajdera.Enabled || bpIndexFigurySlajdera != -1) && bpIndexFigurySlajdera >= 0 && bpIndexFigurySlajdera < bpLFG.Count)
            {
                if (bpLFG[bpIndexFigurySlajdera].Visible)
                {
                    bpLFG[bpIndexFigurySlajdera].Draw(bpRysownica);
                }
            }
            else
            {
                foreach (Shape figura in bpLFG)
                {
                    if (figura.Visible)
                    {
                        figura.Draw(bpRysownica);
                    }
                }
            }
            bpPictureBox.Refresh();
        }

        private void AktualizujStanKontrolek()
        {
            bool czySaFigury = bpLFG.Count > 0;

            if (bpPrzesuwanieFiguryAktywne)
            {
                groupBox1.Enabled = false; // Disable shape selection
                groupBox2.Enabled = false; // Disable slider controls
                bpBtnNewGraphicalAttrs.Enabled = false;
                bpBtnMoveToNewLocation.Text = "Kliknij nową lokalizację...";
                bpBtnMoveToNewLocation.Enabled = true; // Keep enabled to allow cancelling or to show status
            }
            else
            {
                groupBox1.Enabled = !bpTimerSlajdera.Enabled && bpIndexFigurySlajdera == -1;
                groupBox2.Enabled = czySaFigury;
                bpBtnMoveToNewLocation.Text = "Przesuń do nowej lokalizacji"; // Reset text

                if (!czySaFigury)
                {
                    bpBtnOn.Enabled = false;
                    bpBtnOff.Enabled = false;
                    bpBtnNext.Enabled = false;
                    bpBtnPrevious.Enabled = false;
                    bpTxtIndexLFG.Text = "";
                    bpIndexFigurySlajdera = -1;
                }
                else
                {
                    bpBtnOn.Enabled = !bpTimerSlajdera.Enabled;
                    bpBtnOff.Enabled = bpTimerSlajdera.Enabled;

                    if (bpTimerSlajdera.Enabled)
                    {
                        bpBtnNext.Enabled = false;
                        bpBtnPrevious.Enabled = false;
                    }
                    else
                    {
                        bpBtnNext.Enabled = bpIndexFigurySlajdera < bpLFG.Count - 1;
                        bpBtnPrevious.Enabled = bpIndexFigurySlajdera > 0;
                        if (bpIndexFigurySlajdera == -1 && bpLFG.Count > 0) bpBtnNext.Enabled = true;
                    }

                    if (bpIndexFigurySlajdera != -1)
                        bpTxtIndexLFG.Text = (bpIndexFigurySlajdera + 1).ToString();
                    else
                        bpTxtIndexLFG.Text = "";
                }
                bpBtnNewGraphicalAttrs.Enabled = czySaFigury && bpIndexFigurySlajdera != -1;
                bpBtnMoveToNewLocation.Enabled = czySaFigury && bpIndexFigurySlajdera != -1;
            }

            // Pokaz/ukryj kontrolki do kwadratu w zależności od wybranej figury
            bool isSquare = false;
            if (bpIndexFigurySlajdera >= 0 && bpIndexFigurySlajdera < bpLFG.Count)
            {
                var fig = bpLFG[bpIndexFigurySlajdera];
                isSquare = fig.ShapeType == ShapeType.SquareOutlined || fig.ShapeType == ShapeType.SquareFilled;
            }

            bpGrBoxGraphicalAttrs.Visible = bpGrBoxGraphicalAttrs.Visible = isSquare;

            if (isSquare)
            {
                var square = (SquareShape)bpLFG[bpIndexFigurySlajdera];
                int side = Math.Abs(square.EndPoint.X - square.StartPoint.X);
                bpNumSquareSide.Value = side > 0 ? side : 1;
                bpNumSquareX.Value = square.StartPoint.X;
                bpNumSquareY.Value = square.StartPoint.Y;
            }
        }

        private void bpBtnOn_Click(object sender, EventArgs e)
        {
            if (bpLFG.Count > 0 && !bpPrzesuwanieFiguryAktywne)
            {
                bpTimerSlajdera.Start();
                if (bpIndexFigurySlajdera == -1)
                   bpIndexFigurySlajdera = 0;
                OdswiezRysownice();
                AktualizujStanKontrolek();
            }
        }

        private void bpBtnOff_Click(object sender, EventArgs e)
        {
            bpTimerSlajdera.Stop();
            OdswiezRysownice();
            AktualizujStanKontrolek();
        }

        private void bpTimerSlajdera_Tick(object sender, EventArgs e)
        {
            if (bpLFG.Count > 0)
            {
                bpIndexFigurySlajdera = (bpIndexFigurySlajdera + 1) % bpLFG.Count;
                OdswiezRysownice();
                AktualizujStanKontrolek();
            }
        }

        private void bpBtnNext_Click(object sender, EventArgs e)
        {
            if (bpLFG.Count > 0 && !bpTimerSlajdera.Enabled && !bpPrzesuwanieFiguryAktywne)
            {
                if (bpIndexFigurySlajdera < bpLFG.Count - 1)
                {
                    bpIndexFigurySlajdera++;
                }
                else if (bpIndexFigurySlajdera == -1 && bpLFG.Count > 0)
                {
                    bpIndexFigurySlajdera = 0;
                }
                OdswiezRysownice();
                AktualizujStanKontrolek();
            }
        }

        private void bpBtnPrevious_Click(object sender, EventArgs e)
        {
            if (bpLFG.Count > 0 && !bpTimerSlajdera.Enabled && !bpPrzesuwanieFiguryAktywne)
            {
                if (bpIndexFigurySlajdera > 0)
                {
                    bpIndexFigurySlajdera--;
                }
                OdswiezRysownice();
                AktualizujStanKontrolek();
            }
        }

        private void bpBtnNewGraphicalAttrs_Click(object sender, EventArgs e)
        {
            if (bpIndexFigurySlajdera >= 0 && bpIndexFigurySlajdera < bpLFG.Count && !bpPrzesuwanieFiguryAktywne)
            {
                Shape wybranaFigura = bpLFG[bpIndexFigurySlajdera];

                // Determine if the shape supports filling and bordering
                bool supportsFillingAndBordering = wybranaFigura is RectangleShape ||
                                                   wybranaFigura is EllipseShape ||
                                                   wybranaFigura is SquareShape ||
                                                   wybranaFigura is CircleShape ||
                                                   wybranaFigura is PieShape ||
                                                   (wybranaFigura is CardinalCurveShape && ((CardinalCurveShape)wybranaFigura).IsClosed);

                // Create and show the attributes dialog
                using (var attributesDialog = new ShapeAttributesForm(
                           wybranaFigura.PenColor,
                           wybranaFigura.FillColor,
                           wybranaFigura.LineStyle,
                           wybranaFigura.LineWidth,
                           wybranaFigura.IsFilled,
                           wybranaFigura.IsBordered,
                           supportsFillingAndBordering))
                {
                    if (attributesDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Apply the new attributes
                        wybranaFigura.SetAttributes(
                            attributesDialog.PenColor,
                            attributesDialog.FillColor,
                            attributesDialog.LineStyle,
                            attributesDialog.LineWidth,
                            attributesDialog.IsFilled,
                            attributesDialog.IsBordered);

                        OdswiezRysownice();
                    }
                }
            }
            else
            {
                MessageBox.Show("Proszę wybrać figurę (używając przycisków Następny/Poprzedni lub włączając slajder), aby zmienić jej atrybuty.",
                    "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void bpBtnMoveToNewLocation_Click(object sender, EventArgs e)
        {
            if (bpPrzesuwanieFiguryAktywne)
            {
                bpPrzesuwanieFiguryAktywne = false;
                AktualizujStanKontrolek();
            }
            else if (bpIndexFigurySlajdera >= 0 && bpIndexFigurySlajdera < bpLFG.Count)
            {
                bpPrzesuwanieFiguryAktywne = true;
                AktualizujStanKontrolek();
                MessageBox.Show("Kliknij na rysownicy, aby wybrać nową lokalizację dla zaznaczonej figury.", "Przesuwanie Figury", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Proszę wybrać figurę (używając przycisków Następny/Poprzedni lub włączając slajder), aby ją przesunąć.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bpBtnShowAllShapes_Click(object sender, EventArgs e)
        {
            // Stop the slider if running
            bpTimerSlajdera.Stop();
            // Reset the slider index
            bpIndexFigurySlajdera = -1;
            // Refresh the drawing to show all shapes
            OdswiezRysownice();
            // Update controls
            AktualizujStanKontrolek();
        }

        private void bpCockpitIndividual_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy napewno chcesz zamknąć Projekt Indywidualny?", "Zamknij", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void bpNumSquareSide_ValueChanged(object sender, EventArgs e)
        {
            if (bpIndexFigurySlajdera >= 0 && bpIndexFigurySlajdera < bpLFG.Count)
            {
                var fig = bpLFG[bpIndexFigurySlajdera];
                if (fig.ShapeType == ShapeType.SquareOutlined || fig.ShapeType == ShapeType.SquareFilled)
                {
                    var square = (SquareShape)fig;
                    int newSide = (int)bpNumSquareSide.Value;
                    System.Drawing.Point start = square.StartPoint;
                    System.Drawing.Point newEnd = new System.Drawing.Point(start.X + newSide, start.Y + newSide);
                    square.ControlPoints[1] = newEnd;
                    OdswiezRysownice();
                }
            }
        }

        private void bpNumSquareXY_ValueChanged(object sender, EventArgs e)
        {
            if (bpIndexFigurySlajdera >= 0 && bpIndexFigurySlajdera < bpLFG.Count)
            {
                var fig = bpLFG[bpIndexFigurySlajdera];
                if (fig.ShapeType == ShapeType.SquareOutlined || fig.ShapeType == ShapeType.SquareFilled)
                {
                    var square = (SquareShape)fig;
                    int side = Math.Abs(square.EndPoint.X - square.StartPoint.X);
                    int newX = (int)bpNumSquareX.Value;
                    int newY = (int)bpNumSquareY.Value;
                    square.ControlPoints[0] = new System.Drawing.Point(newX, newY);
                    square.ControlPoints[1] = new System.Drawing.Point(newX + side, newY + side);
                    OdswiezRysownice();
                }
            }
        }

        // MENU STRIP HANDLERS
        private void drukujBitMapęRysownicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bpPictureBox.Image != null)
            {
                PrintDialog printDialog = new PrintDialog();
                System.Drawing.Printing.PrintDocument printDoc = new System.Drawing.Printing.PrintDocument();
                printDoc.PrintPage += (s, ev) =>
                {
                    ev.Graphics.DrawImage(bpPictureBox.Image, ev.MarginBounds);
                };
                printDialog.Document = printDoc;
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDoc.Print();
                }
            }
            else
            {
                MessageBox.Show("Brak obrazu do wydruku.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void zapiszBitMapęWPlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bpPictureBox.Image != null)
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Bitmapy (*.bmp)|*.bmp|PNG (*.png)|*.png|JPEG (*.jpg)|*.jpg";
                saveDialog.Title = "Zapisz BitMapę w pliku";
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var format = System.Drawing.Imaging.ImageFormat.Bmp;
                    if (saveDialog.FileName.EndsWith(".png")) format = System.Drawing.Imaging.ImageFormat.Png;
                    else if (saveDialog.FileName.EndsWith(".jpg")) format = System.Drawing.Imaging.ImageFormat.Jpeg;
                    bpPictureBox.Image.Save(saveDialog.FileName, format);
                }
            }
            else
            {
                MessageBox.Show("Brak obrazu do zapisania.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void odtwórzBitMapęRysownicyZPlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Bitmapy (*.bmp;*.png;*.jpg)|*.bmp;*.png;*.jpg";
            openDialog.Title = "Odtwórz BitMapę rysownicy z pliku";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var loadedImage = Image.FromFile(openDialog.FileName);
                    bpPictureBox.Image = new Bitmap(loadedImage);
                    bpRysownica = Graphics.FromImage(bpPictureBox.Image);
                    bpPictureBox.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd podczas wczytywania obrazu: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void exitZFormularzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void restartProgramuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}