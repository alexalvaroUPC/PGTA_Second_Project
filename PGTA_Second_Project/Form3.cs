using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
using System.Reflection;
using System.Runtime.CompilerServices;

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
        List<string> desiredSquawks = new List<string>();
        GMapOverlay markerOverlay = new GMapOverlay("markerOverlay");
        GMapOverlay routeOverlay = new GMapOverlay("routeOverlay");
        GMapOverlay polygonOverlay = new GMapOverlay("polygonOverlay");
        List<GMapRoute> routeLists = new List<GMapRoute>();
        List<List<PointLatLng>> pointLists = new List<List<PointLatLng>>();
        List<GMapMarker> aircraftMarkers = new List<GMapMarker>();
        List<string> incursions = new List<string>();
        List<Aircraft> insursiveAircrafts = new List<Aircraft>();
        int cutOffFL = 400;
        bool seeOver = false;
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
            string[] resourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            Stream imageStream = null;
            foreach (string resourceName in resourceNames)
            {
                if (resourceName.Contains("aircraft_icon.png"))
                {
                    imageStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);

                }
            }
            if (imageStream != null)
            {
                Image image = Image.FromStream(imageStream);
                this.markerIcon = new Bitmap(image, new Size(25, 25));
                this.markerIcon.MakeTransparent();
            }
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
            gMapControl1.Overlays.Add(routeOverlay);
            gMapControl1.Overlays.Add(polygonOverlay);
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
            float heading;
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
                    if (message048s[k].Heading != "N/A") { heading = (float)Convert.ToDouble(message048s[k].Heading); } else { heading = 0; }
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
                GMapMarker marker = new GMarkerGoogle(new PointLatLng(initialLat, initialLon), markerIcon);
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                marker.ToolTipText = aircrafts[i].squawk;
                marker.ToolTip.Font = new Font("Aptos", 8);
                marker.ToolTip.Fill = new SolidBrush(Color.Transparent);
                marker.ToolTip.Foreground = new SolidBrush(Color.Black);
                //aircraftMarkers[i].Position = new PointLatLng(initialLat, initialLon);
                this.pointLists.Add(new List<PointLatLng>());
                GMapRoute newRoute = new GMapRoute(pointLists[i], aircrafts[i].squawk);
                routeLists.Add(newRoute);
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
            if (speedChange.Value >= speedChange.Minimum)
            {
                timer1.Interval = 1000 / (int)speedChange.Value;
            }
            else
            {
                speedChange.Value = speedChange.Minimum;
                timer1.Interval = 1000 / (int)speedChange.Value;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            routeOverlay.Clear();
            markerOverlay.Markers.Clear();
            this.j++;
            for (int i = 0; i < this.aircrafts.Count; i++)
            {
                this.aircrafts[i].moveAC();
                double X = this.aircrafts[i].getLatitude();
                double Y = this.aircrafts[i].getLongitude();
                if (X != 400)
                {
                    if ((this.seeOver && aircrafts[i].getHeight() > this.cutOffFL * 30.48) || (!this.seeOver && aircrafts[i].getHeight() < this.cutOffFL * 30.48))
                    {
                        pointLists[i].Add(new PointLatLng(X, Y));
                        routeLists[i] = new GMapRoute(pointLists[i], aircrafts[i].squawk);
                        aircraftMarkers[i] = new GMarkerGoogle(new PointLatLng(X, Y), RotateImage(markerIcon, aircrafts[i].getHeading()));
                        aircraftMarkers[i].ToolTipMode = MarkerTooltipMode.OnMouseOver;
                        aircraftMarkers[i].ToolTipText = aircrafts[i].squawk;
                        aircraftMarkers[i].ToolTip.Font = new Font("Aptos", 8);
                        aircraftMarkers[i].ToolTip.Fill = new SolidBrush(Color.Transparent);
                        aircraftMarkers[i].ToolTip.Foreground = new SolidBrush(Color.Black);
                        aircraftMarkers[i].ToolTipText = "Squawk: " + aircrafts[i].squawk + "\n" + Convert.ToString((int)aircrafts[i].getHeight()) + " m\n" + Convert.ToString(aircrafts[i].getHeading() + " º");

                    }
                }
                //markers.Markers.Add(aircraftMarkers[i]);
                label2.Text = TimeSpan.FromSeconds(this.firstClock + j).ToString();

            }
            //routeOverlay.Clear();
            //markerOverlay.Markers.Clear();
            for (int i = 0; i < aircraftMarkers.Count; i++)
            {
                if (((this.seeOver && aircrafts[i].getHeight() > this.cutOffFL * 30.48) || (!this.seeOver && aircrafts[i].getHeight() < this.cutOffFL * 30.48)) && aircrafts[i].getLatitude() != 400)
                {
                    markerOverlay.Markers.Add(aircraftMarkers[i]);
                    if (this.desiredSquawks.IndexOf(aircrafts[i].squawk) != -1)
                    {
                        routeLists[i].Stroke = new Pen(Color.Red, 3);
                        routeOverlay.Routes.Add(routeLists[i]);
                    }
                }
            }

            gMapControl1.Refresh();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.j++;
            routeOverlay.Clear();
            markerOverlay.Markers.Clear();
            for (int i = 0; i < this.aircrafts.Count; i++)
            {
                aircrafts[i].moveAC();
                double X = aircrafts[i].getLatitude();
                double Y = aircrafts[i].getLongitude();
                if (X != 400 && Y != 400)
                {

                    pointLists[i].Add(new PointLatLng(X, Y));
                    routeLists[i] = new GMapRoute(pointLists[i], aircrafts[i].squawk);
                    aircraftMarkers[i] = new GMarkerGoogle(new PointLatLng(X, Y), RotateImage(markerIcon, aircrafts[i].getHeading()));
                    aircraftMarkers[i].ToolTipMode = MarkerTooltipMode.OnMouseOver;
                    aircraftMarkers[i].ToolTipText = aircrafts[i].squawk;
                    aircraftMarkers[i].ToolTip.Font = new Font("Aptos", 8);
                    aircraftMarkers[i].ToolTip.Fill = new SolidBrush(Color.Transparent);
                    aircraftMarkers[i].ToolTip.Foreground = new SolidBrush(Color.Black);
                    aircraftMarkers[i].ToolTipText = "Squawk: " + aircrafts[i].squawk + "\n" + Convert.ToString((int)aircrafts[i].getHeight()) + " m\n" + Convert.ToString(aircrafts[i].getHeading() + " º");



                }
                //markers.Markers.Add(aircraftMarkers[i]);
            }

            label2.Text = TimeSpan.FromSeconds(this.firstClock + j).ToString();
            //markerOverlay.Markers.Clear();
            for (int i = 0; i < aircraftMarkers.Count; i++)
            {
                if ((this.seeOver && aircrafts[i].getHeight() > this.cutOffFL * 30.48) || (!this.seeOver && aircrafts[i].getHeight() < this.cutOffFL * 30.48))
                {
                    markerOverlay.Markers.Add(aircraftMarkers[i]);
                    if (this.desiredSquawks.IndexOf(aircrafts[i].squawk) != -1)
                    {
                        routeLists[i].Stroke = new Pen(Color.Red, 3);
                        routeOverlay.Routes.Add(routeLists[i]);
                    }
                }
            }

            gMapControl1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (j > 1)
            { //WHEN AN AIRCRAFT HAS NOT MOVED HOW DO WE MOVE IT BACK
                routeOverlay.Clear();
                markerOverlay.Markers.Clear();
                this.j--;
                for (int i = 0; i < this.aircrafts.Count; i++)
                {
                    this.aircrafts[i].moveACback();
                    double X = this.aircrafts[i].getLatitude();
                    double Y = this.aircrafts[i].getLongitude();
                    if (X != 400 && Y != 400)
                    {
                        pointLists[i].Add(new PointLatLng(X, Y));
                        routeLists[i] = new GMapRoute(pointLists[i], aircrafts[i].squawk);
                        aircraftMarkers[i] = new GMarkerGoogle(new PointLatLng(X, Y), RotateImage(markerIcon, aircrafts[i].getHeading()));
                        aircraftMarkers[i].ToolTipMode = MarkerTooltipMode.OnMouseOver;
                        aircraftMarkers[i].ToolTipText = aircrafts[i].squawk;
                        aircraftMarkers[i].ToolTip.Font = new Font("Aptos", 8);
                        aircraftMarkers[i].ToolTip.Fill = new SolidBrush(Color.Transparent);
                        aircraftMarkers[i].ToolTip.Foreground = new SolidBrush(Color.Black);
                        aircraftMarkers[i].ToolTipText = "Squawk: " + aircrafts[i].squawk + "\n" + Convert.ToString((int)aircrafts[i].getHeight()) + " m\n" + Convert.ToString(aircrafts[i].getHeading() + " º");



                    }
                    //markers.Markers.Add(aircraftMarkers[i]);

                }
                label2.Text = TimeSpan.FromSeconds(this.firstClock + j).ToString();
                //markerOverlay.Markers.Clear();
                for (int i = 0; i < aircraftMarkers.Count; i++)
                {
                    if ((this.seeOver && aircrafts[i].getHeight() > this.cutOffFL * 30.48) || (!this.seeOver && aircrafts[i].getHeight() < this.cutOffFL * 30.48))
                    {
                        markerOverlay.Markers.Add(aircraftMarkers[i]);
                        if (this.desiredSquawks.IndexOf(aircrafts[i].squawk) != -1)
                        {
                            routeLists[i].Stroke = new Pen(Color.Red, 3);
                            routeOverlay.Routes.Add(routeLists[i]);
                        }
                    }
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
            gfx.DrawString("HOJA DE REGISTRO AÉREO", title, XBrushes.Red, new XPoint(page.Width / 4, 50));
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
            if (this.incursions.Count > 0)
            {
                gfx.DrawString("Incursiones registradas", title, XBrushes.Black, new XPoint(page.Width / 4, posicionVerticalActual));
                posicionVerticalActual += 15;
                if (posicionVerticalActual >= page.Height - 40)
                {
                    page = pdf.AddPage();
                    gfx = XGraphics.FromPdfPage(page);
                    posicionVerticalActual = 80;
                }
                for (int i = 0; i <= aircrafts.Count; i++)
                {
                    XPoint TextLocation = new XPoint(10, posicionVerticalActual);
                    gfx.DrawString(this.incursions[i], font, XBrushes.Black, TextLocation);
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

        public Bitmap RotateImage(Bitmap bmp, float angle)
        {
            Bitmap rotatedImage = new Bitmap(bmp.Width, bmp.Height);
            rotatedImage.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);

            using (Graphics g = Graphics.FromImage(rotatedImage))
            {

                g.TranslateTransform(bmp.Width / 2, bmp.Height / 2);

                // Rotate the image
                g.RotateTransform(angle);

                // Move the image back to its original position
                g.TranslateTransform(-bmp.Width / 2, -bmp.Height / 2);

                // Draw the image onto the rotated bitmap
                g.DrawImage(bmp, new Point(0, 0));
            }

            return rotatedImage;
        }

        private void cutoffSelector_Scroll(object sender, EventArgs e)
        {
            label3.Text = "Cut-off FL:" + Convert.ToString(cutoffSelector.Value);
            this.cutOffFL = cutoffSelector.Value;
        }

        private void underButton_CheckedChanged(object sender, EventArgs e)
        {
            if (underButton.Checked)
            {
                this.seeOver = false;
            }
            else
            {
                this.seeOver = true;
            }
        }

        private void overButton_CheckedChanged(object sender, EventArgs e)
        {
            if (overButton.Checked)
            {
                this.seeOver = true;
            }
            else
            {
                this.seeOver = false;
            }
        }

        private void addRouteButton_Click(object sender, EventArgs e)
        {
            this.desiredSquawks.Add(squawkTextBox.Text);
            int rowId = routeView.Rows.Add();

            // Grab the new row!
            DataGridViewRow row = routeView.Rows[rowId];

            // Add the data
            row.Cells["RouteColumn"].Value = Convert.ToString(rowId);
            row.Cells["SquawkColumn"].Value = squawkTextBox.Text;
        }

        private void routeView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Confirm the deletion with a message box
                if (MessageBox.Show("Se va a borrar la ruta", "Confirmar operación", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.desiredSquawks.Remove(Convert.ToString(routeView[e.ColumnIndex, e.RowIndex]));
                    routeView.Rows.RemoveAt(e.RowIndex);

                }
            }
        }
        public GMapPolygon createZone(double lat, double lon, double distance1, double distance2)
        {
            double aEarth = 6371000;
            //BASED ON HAVERSINE FORMULA
            double d1meters = distance1 * 1852;
            double d2meters = distance2 * 1852;

            double latDiffRadiansLength = d1meters / aEarth;
            double latDiffRadiansWidth = d2meters / aEarth;
            double lonDiffRadiansLength = latDiffRadiansLength / Math.Cos(lat * Math.PI / 180);
            double lonDiffRadiansWidth = latDiffRadiansWidth / Math.Cos(lat * Math.PI / 180);

            double topLat = lat + latDiffRadiansLength * 180 / Math.PI/2;
            double leftLon = lon - lonDiffRadiansWidth * 180 / Math.PI/2;
            double rightLon = lon + lonDiffRadiansWidth * 180 / Math.PI/2;
            double bottomLat = lat - latDiffRadiansLength * 180 / Math.PI/2;

            GMapPolygon rectangle = new GMapPolygon(new List<PointLatLng> { new PointLatLng(topLat, leftLon), new PointLatLng(topLat, rightLon), new PointLatLng(bottomLat, rightLon), new PointLatLng(bottomLat, leftLon), new PointLatLng(topLat, leftLon) }, "Zone");
            rectangle.Stroke = new Pen(Color.Orange, 2);
            rectangle.Fill = new SolidBrush(Color.FromArgb(30, Color.Orange));
            return rectangle;
        }
        public bool checkIncursion(GMapMarker location, GMapPolygon checkArea)
        {
            bool incursion = false;
            double lat = location.Position.Lat;
            double lon = location.Position.Lng;
            double topLat = checkArea.Points[0].Lat;
            double leftLon = checkArea.Points[0].Lng;
            double rightLon = checkArea.Points[1].Lng;
            double bottomLat = checkArea.Points[2].Lat;
            if ((lat >= bottomLat && lat <= topLat) && (lon <= rightLon && lon >= leftLon))
            {
                incursion = true;
            }
            return incursion;
        }
        private void logIncursion(Aircraft intruder, string timeOfDay, GMapMarker location)
        {
            string report = "Aircraft with squawk: " + intruder.squawk + " was present in highlighted area at: " + timeOfDay + " in position: " + location.Position.ToString();
            this.incursions.Add(report);
            this.insursiveAircrafts.Add(intruder);
        }

        private void gMapControl1_MouseClick(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Left)
            {
                PointLatLng clickedPoint = gMapControl1.FromLocalToLatLng((int)e.X, (int)e.Y);
                double lat = clickedPoint.Lat;
                double lon = clickedPoint.Lng;
                Form4 F4 = new Form4();
                F4.ShowDialog();
                double d1 = F4.getWidth();
                double d2 = F4.getLength();
                F4.Close();
                if (d1 != -1)
                {
                    GMapPolygon zonaRegistro = createZone(lat, lon, d1, d2);
                    polygonOverlay.Polygons.Add(zonaRegistro);
                    gMapControl1.Overlays.Add(polygonOverlay);
                    gMapControl1.Refresh();
                }
            }
        }
    }
}
