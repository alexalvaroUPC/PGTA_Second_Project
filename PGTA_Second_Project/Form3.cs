using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection.Metadata;
using System.Xml;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Data.SQLite;
using Microsoft.VisualBasic.Devices;
using Accord;
namespace PGTA_Second_Project
{
    public partial class Form3 : Form
    {
        private List<message048> message048s;
        private List<Aircraft> aircrafts = new List<Aircraft>();
        private int j;
        private int firstClock;
        private int lastClock;
        Bitmap markerIcon;
        GMapOverlay markerOverlay = new GMapOverlay("markerOverlay");
        List<GMapMarker> aircraftMarkers = new List<GMapMarker>();
        public void setData(List<message048> messages) { this.message048s = messages; }
        public Form3()
        {
            InitializeComponent();
        }


        private void gMapControl1_Load(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gMapControl1.Position = new PointLatLng(41.297, 2.078);
            gMapControl1.MinZoom = 8;
            gMapControl1.Zoom = 10;
            gMapControl1.MaxZoom = 20;
            Image image = Image.FromFile("aircraft.png");
            this.markerIcon = new Bitmap(image, new Size(50, 50));
            this.markerIcon.MakeTransparent();
            gMapControl1.Overlays.Add(markerOverlay);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            this.j = -1;
            for (int j = 0; j < aircrafts.Count(); j++)
            {
                aircrafts[j].copyToStacks();
            }
            gMapControl1.Overlays.Add(markerOverlay);
        }


        private void Form3_Load(object sender, EventArgs e)
        {
            message048s = message048s.OrderBy(message048s => message048s.timeInSeconds).ToList();
            this.firstClock = message048s[0].timeInSeconds;
            this.lastClock = message048s.Last().timeInSeconds;
            double currentLat;
            double currentLon;
            double currentHeight;
            int moveTime = this.firstClock;
            double heading;
            int timeIndex = 0;
            List<string> neededSquawks = message048s.Where(item => item.mode3squawk != "N/A").Select(item => item.mode3squawk).Distinct().ToList();
            for (int i = 0; i < neededSquawks.Count; i++)
            {
                Aircraft aircraft = new Aircraft(neededSquawks[i]);
                this.aircrafts.Add(aircraft);
            }
            for (int i = 0; i <= (this.lastClock - this.firstClock); i++)
            {
                for (int j = 0; j < aircrafts.Count(); j++)
                {
                    aircrafts[j].fill400();
                }
            }
            for (int k = 0; k < message048s.Count; k++)
            {

                if (moveTime != message048s[k].timeInSeconds)
                {
                    timeIndex++;
                }
                moveTime = message048s[k].timeInSeconds;
                int hitIndex = aircrafts.FindIndex(item => item.squawk == message048s[k].mode3squawk);
                if (hitIndex != -1)
                {
                    currentLat = Convert.ToDouble(message048s[k].LAT);
                    currentLon = Convert.ToDouble(message048s[k].LON);
                    currentHeight = Convert.ToDouble(message048s[k].geodesicHeight);
                    if (message048s[k].Heading != "N/A") { heading = Convert.ToDouble(message048s[k].Heading); } else { heading = 0; }
                    aircrafts[hitIndex].fillCoordinates(currentLat, currentLon, currentHeight, heading, timeIndex);
                }

            }
            for (int j = 0; j < aircrafts.Count(); j++)
            {
                aircrafts[j].copyToStacks();
            }
            double initialLat = 90;
            double initialLon = 90;
            for (int i = 0; i < this.aircrafts.Count; i++)
            {
                GMapMarker marker = new GMarkerGoogle(new PointLatLng(initialLat, initialLon), GMarkerGoogleType.arrow);
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                marker.ToolTipText = aircrafts[i].squawk;
                marker.ToolTip.Font = new Font("Arial", 12);
                marker.ToolTip.Fill = new SolidBrush(Color.Transparent);
                marker.ToolTip.Foreground = new SolidBrush(Color.Black);
                //aircraftMarkers[i].Position = new PointLatLng(initialLat, initialLon);
                aircraftMarkers.Add(marker);
            }
            //GMapOverlay markers = new GMapOverlay("markers");
            

        }


        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value >= numericUpDown1.Minimum)
            {
                timer1.Interval = 1000 / (int)numericUpDown1.Value;
            }
            else
            {
                numericUpDown1.Value = numericUpDown1.Minimum;
                timer1.Interval = 1000 / (int)numericUpDown1.Value;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.j++;
            for (int i = 0; i < this.aircrafts.Count; i++)
            {
                this.aircrafts[i].moveAC();
                double X = this.aircrafts[i].getLatitude();
                double Y = this.aircrafts[i].getLongitude();
                if (X != 400)
                {
                    aircraftMarkers[i].Position = new PointLatLng(X, Y);
                    aircraftMarkers[i].ToolTipText = "Squawk: " + aircrafts[i].squawk + "\n" + Convert.ToString((int)aircrafts[i].getHeight()) + " m\n" + Convert.ToString(aircrafts[i].getHeading() + " º");
                    
                }
                //markers.Markers.Add(aircraftMarkers[i]);
                label2.Text = TimeSpan.FromSeconds(this.firstClock + j).ToString();

            }
            markerOverlay.Markers.Clear();
            for(int i = 0; i < aircraftMarkers.Count; i++){
                markerOverlay.Markers.Add(aircraftMarkers[i]);
            }
            
            gMapControl1.Refresh();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.j++;

            for (int i = 0; i < this.aircrafts.Count; i++)
            {
                aircrafts[i].moveAC();
                double X = aircrafts[i].getLatitude();
                double Y = aircrafts[i].getLongitude();
                if (X != 400 && Y != 400)
                {
                    aircraftMarkers[i].Position = new PointLatLng(X, Y);
                    aircraftMarkers[i].ToolTipText = "Squawk: " + aircrafts[i].squawk + "\n" + Convert.ToString((int)aircrafts[i].getHeight()) + " m\n" + Convert.ToString(aircrafts[i].getHeading() + " º");

                }
                //markers.Markers.Add(aircraftMarkers[i]);
            }
            
            label2.Text = TimeSpan.FromSeconds(this.firstClock + j).ToString();
            markerOverlay.Markers.Clear();
            for (int i = 0; i < aircraftMarkers.Count; i++)
            {
                markerOverlay.Markers.Add(aircraftMarkers[i]);
            }

            gMapControl1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (j > 1)
            { //WHEN AN AIRCRAFT HAS NOT MOVED HOW DO WE MOVE IT BACK
                this.j--;
                for (int i = 0; i < this.aircrafts.Count; i++)
                {
                    this.aircrafts[i].moveACback();
                    double X = this.aircrafts[i].getLatitude();
                    double Y = this.aircrafts[i].getLongitude();
                    if (X != 400 && Y != 400)
                    {
                        aircraftMarkers[i].Position = new PointLatLng(X, Y);
                        aircraftMarkers[i].ToolTipText = "Squawk: " + aircrafts[i].squawk + "\n" + Convert.ToString((int)aircrafts[i].getHeight()) + " m\n" + Convert.ToString(aircrafts[i].getHeading() + " º");
                        
                    }
                    //markers.Markers.Add(aircraftMarkers[i]);

                }
                label2.Text = TimeSpan.FromSeconds(this.firstClock + j).ToString();
                markerOverlay.Markers.Clear();
                for (int i = 0; i < aircraftMarkers.Count; i++)
                {
                    markerOverlay.Markers.Add(aircraftMarkers[i]);
                }

                gMapControl1.Refresh();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileSaver = new SaveFileDialog();
            fileSaver.Filter = "Archivo PDF (*.pdf) | *.pdf";
            fileSaver.ShowDialog();
            Size mapsize = gMapControl1.Size;
            Bitmap mapImage = new Bitmap(mapsize.Width, mapsize.Height);
            gMapControl1.DrawToBitmap(mapImage, new Rectangle(0, 0, mapsize.Width, mapsize.Height));
            mapImage.Save("savedMap.png", System.Drawing.Imaging.ImageFormat.Png);
            XImage pdfImageMap = XImage.FromFile("savedMap.png");
            DateTime thisDay = DateTime.UtcNow;
            int posicionVerticalActual = 80;
            PdfDocument pdf = new PdfDocument();
            PdfPage page = pdf.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 8, XFontStyleEx.Regular);
            XFont title = new XFont("Verdana", 20, XFontStyleEx.Bold);
            XFont subtitulos = new XFont("Verdana", 4, XFontStyleEx.Italic);
            XPen pen = new XPen(XColor.FromArgb(220, 220, 220), 1.5);
            gfx.DrawString("HOJA DE REGISTRO AÉREA", title, XBrushes.Red, new XPoint(page.Width / 4, 50));
            gfx.DrawString("ICAO | No distribuir | Generado (UTC):" + Convert.ToString(thisDay), subtitulos, XBrushes.Black, new XPoint(4, 20));
            gfx.DrawLine(pen, new XPoint(0, 60), new XPoint(page.Width.Point, 60));
            XRect ImageLocation = new XRect(page.Width / 16, posicionVerticalActual, mapsize.Width / 4, mapsize.Height / 4);
            gfx.DrawImage(pdfImageMap, ImageLocation);
            posicionVerticalActual += mapsize.Width / 6 + 20;
            for (int i = 0; i < aircrafts.Count; i++)
            {

                if (aircraftMarkers[i].Position.Lat != 90)
                {
                    XPoint TextLocation = new XPoint(10, posicionVerticalActual);
                    gfx.DrawString(aircraftMarkers[i].ToolTipText.Replace("\n", " | ") + aircraftMarkers[i].Position.ToString(), font, XBrushes.Black, TextLocation);
                    posicionVerticalActual += 15;
                    if (posicionVerticalActual >= page.Height - 40)
                    {
                        page = pdf.AddPage();
                        gfx = XGraphics.FromPdfPage(page);
                        posicionVerticalActual = 80;
                    }
                }

            }
            pdf.Save(fileSaver.FileName);
            MessageBox.Show("Guardado con éxito");

        }

        private void button6_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
