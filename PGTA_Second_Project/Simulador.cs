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
using MaterialSkin;
using System.Security.Cryptography.X509Certificates;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using PdfSharp.UniversalAccessibility.Drawing;

namespace PGTA_Second_Project
{
    public partial class Simulador : Form
    {
        private List<message048> message048s;
        private List<message048> sendBack = new List<message048>();
        private List<Aircraft> aircrafts = new List<Aircraft>();
        private int j;
        private int firstClock;
        private int lastClock;
        Bitmap markerIcon;
        List<string> desiredcallsigns = new List<string>();
        GMapOverlay markerOverlay = new GMapOverlay("markerOverlay");
        GMapOverlay routeOverlay = new GMapOverlay("routeOverlay");
        GMapOverlay polygonOverlay = new GMapOverlay("polygonOverlay");
        List<GMapRoute> routeLists = new List<GMapRoute>();
        List<List<PointLatLng>> pointLists = new List<List<PointLatLng>>();
        List<GMapMarker> aircraftMarkers = new List<GMapMarker>();
        List<string> incursions = new List<string>();
        int cutOffFL = 400;
        bool seeOver = false;
        public void setData(List<message048> messages) { this.message048s = messages; }
        public Simulador()
        {
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            InitializeComponent();
        }


        private void gMapControl1_Load(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gMapControl1.Position = new PointLatLng(41.297, 2.078);
            gMapControl1.MinZoom = 6;
            gMapControl1.Zoom = 9;
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
                this.markerIcon = new Bitmap(image, new Size(26, 26));
                this.markerIcon.MakeTransparent();
            }
            if (gMapControl1.Overlays.Count == 0)
            {
                gMapControl1.Overlays.Add(markerOverlay);
                gMapControl1.Overlays.Add(routeOverlay);
                gMapControl1.Overlays.Add(polygonOverlay);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            this.j = -1;
            for (int j = 0; j < aircrafts.Count(); j++)
            {
                aircrafts[j].copyToStacks();
            }
            if(gMapControl1.Overlays.Count == 0)
            {
                gMapControl1.Overlays.Add(markerOverlay);
                gMapControl1.Overlays.Add(routeOverlay);
                gMapControl1.Overlays.Add(polygonOverlay);
            }
            
        }


        private void Form3_Load(object sender, EventArgs e)
        {
            this.message048s = this.message048s.OrderBy(message048s => message048s.timeInSeconds).ToList();
            this.sendBack.AddRange(this.message048s);
            this.firstClock = message048s[0].timeInSeconds;
            this.lastClock = message048s.Last().timeInSeconds;
            double currentLat;
            double currentLon;
            double currentHeight;
            int moveTime = this.firstClock;
            float heading;
            int timeIndex = 0;
            List<string> neededcallsigns = message048s.Where(item => item.acID != "N/A").Select(item => item.acID).Distinct().ToList();
            for (int i = 0; i < neededcallsigns.Count; i++)
            {
                Aircraft aircraft = new Aircraft(neededcallsigns[i]);
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
                int hitIndex = aircrafts.FindIndex(item => item.callsign == message048s[k].acID);
                if (hitIndex != -1)
                {
                    currentLat = Convert.ToDouble(message048s[k].LAT);
                    currentLon = Convert.ToDouble(message048s[k].LON);
                    currentHeight = Convert.ToDouble(message048s[k].geodesicHeight);
                    if (message048s[k].Heading != "N/A") { heading = (float)Convert.ToDouble(message048s[k].Heading); } else { heading = 0; }
                    double inputFL = 0;
                    if (message048s[k].flightLevel != "N/A")
                    {
                        inputFL = Convert.ToDouble(message048s[k].flightLevel);

                    }
                    if (message048s[k].CorrectedModeC != "N/A") { inputFL = (Convert.ToDouble(message048s[k].CorrectedModeC) / 100); }
                    aircrafts[hitIndex].fillCoordinates(currentLat, currentLon, currentHeight, heading, timeIndex, inputFL);
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
                marker.ToolTipText = aircrafts[i].callsign;
                marker.ToolTip.Font = new Font("Aptos", 8);
                marker.ToolTip.Fill = new SolidBrush(Color.Transparent);
                marker.ToolTip.Foreground = new SolidBrush(Color.Black);
                this.pointLists.Add(new List<PointLatLng>());
                GMapRoute newRoute = new GMapRoute(pointLists[i], aircrafts[i].callsign);
                routeLists.Add(newRoute);
                aircraftMarkers.Add(marker);

            }

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
            moveAllForward();
        }
        private void moveAllForward()
        {
            routeOverlay.Routes.Clear();
            markerOverlay.Markers.Clear();
            this.j++;
            string ToDay = TimeSpan.FromSeconds(this.firstClock + j).ToString();
            label2.Text = ToDay;
            for (int i = 0; i < this.aircrafts.Count; i++)
            {
                this.aircrafts[i].moveAC();
                Aircraft movingAC = this.aircrafts[i];
                double X = movingAC.getLatitude();
                double Y = movingAC.getLongitude();
                double FL = Convert.ToDouble(movingAC.getFL());
                if (X != 400)
                {
                    if ((this.seeOver && FL > this.cutOffFL) || (!this.seeOver && FL < this.cutOffFL))
                    {
                        PointLatLng currentMove = new PointLatLng(X, Y);
                        aircraftMarkers[i] = new GMarkerGoogle(currentMove, RotateImage(markerIcon, movingAC.getHeading()));
                        aircraftMarkers[i].Offset = new Point(-13, -13);
                        aircraftMarkers[i].ToolTipMode = MarkerTooltipMode.OnMouseOver;
                        aircraftMarkers[i].ToolTipText = movingAC.callsign;
                        aircraftMarkers[i].ToolTip.Font = new Font("Arial", 8, FontStyle.Bold);
                        aircraftMarkers[i].ToolTip.Fill = new SolidBrush(Color.Transparent);
                        aircraftMarkers[i].ToolTip.Foreground = new SolidBrush(Color.Black);
                        aircraftMarkers[i].ToolTipText = movingAC.callsign + "\n" +"FL: " + movingAC.getFL() + " \n Heading: " + movingAC.getHeading().ToString() + " º";
                        routeLists[i].Points.Add(currentMove);
                        if (polygonOverlay.Polygons.Count > 0)
                        {
                            for(int k =0; k < polygonOverlay.Polygons.Count; k++)
                            {
                                if (!movingAC.incursionFlag[k])
                                {
                                    if (checkIncursion(aircraftMarkers[i], polygonOverlay.Polygons[k]))
                                    {
                                        logIncursion(movingAC, ToDay, aircraftMarkers[i], k);
                                        movingAC.routeFlag[k] = true;
                                        movingAC.incursionFlag[k] = true;
                                        this.desiredcallsigns.Add(movingAC.callsign);
                                        int rowId = routeView.Rows.Add();

                                        DataGridViewRow row = routeView.Rows[rowId];
                                        row.Cells["RouteColumn"].Value = (rowId+1).ToString();
                                        row.Cells["callsignColumn"].Value = this.aircrafts[i].callsign;
                                        
                                    }
                                }
                                if (movingAC.routeFlag[k])
                                {
                                    routeLists[i].Stroke = polygonOverlay.Polygons[k].Stroke;
                                    routeOverlay.Routes.Add(routeLists[i]);
                                }                                                           
                            }
                        }
                        if (this.aircrafts[i].routeFlag[4])
                        {
                            routeLists[i].Stroke = new Pen(Color.Black, 3);
                            routeOverlay.Routes.Add(routeLists[i]);
                        }
                        markerOverlay.Markers.Add(aircraftMarkers[i]);
                        this.aircrafts[i] = movingAC;
                    }
                }
            }


            gMapControl1.Refresh();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            moveAllForward();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (j > 1)
            {
                
                routeOverlay.Clear();
                markerOverlay.Markers.Clear();
                this.j--;
                string ToDay = TimeSpan.FromSeconds(this.firstClock + j).ToString();
                label2.Text = ToDay;
                for (int i = 0; i < this.aircrafts.Count; i++)
                {
                    this.aircrafts[i].moveACback();
                    Aircraft movingAC = this.aircrafts[i];
                    double X = movingAC.getLatitude();
                    double Y = movingAC.getLongitude();
                    double FL = Convert.ToDouble(movingAC.getFL());
                    if (X != 400)
                    {
                        if ((this.seeOver && FL > this.cutOffFL) || (!this.seeOver && FL < this.cutOffFL))
                        {
                            PointLatLng currentMove = new PointLatLng(X, Y);
                            aircraftMarkers[i] = new GMarkerGoogle(currentMove, RotateImage(markerIcon, movingAC.getHeading()));
                            aircraftMarkers[i].Offset = new Point(-13, -13);
                            aircraftMarkers[i].ToolTipMode = MarkerTooltipMode.OnMouseOver;
                            aircraftMarkers[i].ToolTipText = movingAC.callsign;
                            aircraftMarkers[i].ToolTip.Font = new Font("Arial", 8, FontStyle.Bold);
                            aircraftMarkers[i].ToolTip.Fill = new SolidBrush(Color.Transparent);
                            aircraftMarkers[i].ToolTip.Foreground = new SolidBrush(Color.Black);
                            aircraftMarkers[i].ToolTipText = movingAC.callsign + "\n" + "FL: " + movingAC.getFL() + " \n Heading: " + movingAC.getHeading().ToString() + " º";
                            markerOverlay.Markers.Add(aircraftMarkers[i]);
                            this.aircrafts[i] = movingAC;

                        }

                    }
                }
                gMapControl1.Refresh();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            writePDF();
            if (desiredcallsigns.Count > 0)
            {
                this.sendBack.Clear();
                for (int i = 0; i < desiredcallsigns.Count; i++)
                {
                    List<message048> wantedMessages = this.message048s.FindAll(item => item.acID == desiredcallsigns[i]);
                    this.sendBack.AddRange(wantedMessages);
                }
            }
            this.Close();
        }
        public List<message048> getTargetCallsigns() {
            return this.sendBack;
        }
        private void writePDF()
        {
            SaveFileDialog fileSaver = new SaveFileDialog();
            fileSaver.Filter = "Archivo PDF (*.pdf) | *.pdf";
            if(fileSaver.ShowDialog() == DialogResult.OK)
            {
                Size mapsize = gMapControl1.Size;
                Bitmap mapImage = new Bitmap(mapsize.Width, mapsize.Height);
                gMapControl1.DrawToBitmap(mapImage, new Rectangle(0, 0, mapsize.Width, mapsize.Height));
                MemoryStream imageStream = new MemoryStream();
                //mapImage.Save("savedMap.png", System.Drawing.Imaging.ImageFormat.Png);
                mapImage.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
                //XImage pdfImageMap = XImage.From("savedMap.png");
                XImage pdfImage = XImage.FromStream(imageStream);
                DateTime thisDay = DateTime.UtcNow;
                int posicionVerticalActual = 80;
                PdfDocument pdf = new PdfDocument();
                PdfPage page = pdf.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);
                XFont font = new XFont("Arial", 8, XFontStyleEx.Regular);
                XFont title = new XFont("Arial", 20, XFontStyleEx.Bold);
                XFont subtitulos = new XFont("Arial", 6, XFontStyleEx.Italic);
                XPen pen = new XPen(XColor.FromArgb(220, 220, 220), 1.5);
                gfx.DrawString("HOJA DE REGISTRO AÉREO", title, XBrushes.Red, new XPoint(page.Width / 4, 50));
                gfx.DrawString("ICAO | No distribuir | Generado (UTC):" + Convert.ToString(thisDay), subtitulos, XBrushes.Black, new XPoint(4, 20));
                gfx.DrawLine(pen, new XPoint(0, 60), new XPoint(page.Width.Point, 60));
                XRect ImageLocation = new XRect(page.Width / 16, posicionVerticalActual, page.Width - 2 * page.Width / 16, (page.Width - 3 * page.Width / 16) * mapsize.Height / mapsize.Width);
                gfx.DrawImage(pdfImage, ImageLocation);
                posicionVerticalActual += (int)ImageLocation.Height + 40;
                for (int i = 0; i < aircrafts.Count; i++)
                {

                    if (aircraftMarkers[i].Position.Lat != 90)
                    {
                        XPoint TextLocation = new XPoint(10, posicionVerticalActual);
                        gfx.DrawString(aircraftMarkers[i].ToolTipText.Replace("\n", " | ") + "L:" + Math.Round(aircraftMarkers[i].Position.Lat, 3).ToString() + "ºN |" + "l:" + Math.Round(aircraftMarkers[i].Position.Lng, 3).ToString() + "ºE", font, XBrushes.Black, TextLocation);
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
                    posicionVerticalActual += 15;
                    title = new XFont("Arial", 14, XFontStyleEx.BoldItalic);
                    gfx.DrawString("Incursiones registradas", title, XBrushes.Black, new XPoint(20, posicionVerticalActual));
                    posicionVerticalActual += 15;
                    if (posicionVerticalActual >= page.Height - 40)
                    {
                        page = pdf.AddPage();
                        gfx = XGraphics.FromPdfPage(page);
                        posicionVerticalActual = 80;
                    }
                    for (int i = 0; i < this.incursions.Count; i++)
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
                mapImage.Dispose();
                imageStream.Close();
                gfx.Dispose();
            }
            
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
            
            int hitIndex = this.aircrafts.FindIndex(item=>item.callsign == callsignTextBox.Text);
            if (hitIndex != -1)
            {
                this.desiredcallsigns.Add(callsignTextBox.Text);
                this.aircrafts[hitIndex].routeFlag[4] = true;
                int rowId = routeView.Rows.Add();

                DataGridViewRow row = routeView.Rows[rowId];

                row.Cells["RouteColumn"].Value = Convert.ToString(rowId + 1);
                row.Cells["callsignColumn"].Value = callsignTextBox.Text;
            }
            else
            {
                MessageBox.Show("callsign not found");
            }
            
        }

        private void routeView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && routeView.Rows.Count!=0)
            {
                // Confirm the deletion with a message box
                if (MessageBox.Show("Se va a borrar la ruta", "Confirmar operación", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int hitIndex = this.aircrafts.FindIndex(item => item.callsign == desiredcallsigns[e.RowIndex]);
                    this.aircrafts[hitIndex].routeFlag[4] = false;
                    for (int i = 0; i < 4; i++)
                    {
                        this.aircrafts[hitIndex].incursionFlag[i] = false;
                        this.aircrafts[hitIndex].routeFlag[i] = false;
                    }
                    this.desiredcallsigns.RemoveAt(e.RowIndex);
                    routeView.Rows.RemoveAt(e.RowIndex);
                    routeOverlay.Routes.RemoveAt(e.RowIndex);

                }
            }
        }
        public GMapPolygon createZone(double lat, double lon, double distance1, double distance2, int zoneNumber)
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
            Color zoneColor = Color.Red;
            if (zoneNumber == 0)
            {
                zoneColor = Color.Orange;
            }
            else if (zoneNumber == 1)
            {
                zoneColor = Color.Green;
            }
            else if(zoneNumber == 2)
            {
                zoneColor = Color.Blue;
            }
            
                
            rectangle.Stroke = new Pen(zoneColor, 2);
            rectangle.Fill = new SolidBrush(Color.FromArgb(30, zoneColor));
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
        private void logIncursion(Aircraft intruder, string timeOfDay, GMapMarker location, int zoneNumber)
        {
            int cleanZoneNumber = zoneNumber + 1;
            string report = "Aircraft with callsign: " + intruder.callsign + " entered highlighted area #"+cleanZoneNumber+" at: " + timeOfDay + " in position: L: " + Math.Round(location.Position.Lat,3).ToString()+"ºN | l: "+Math.Round(location.Position.Lng,3).ToString()+"ºE | Geodesic height: " + ((int)intruder.getHeight()).ToString()+" m";
            this.incursions.Add(report);
        }

        private void gMapControl1_MouseClick(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Left && polygonOverlay.Polygons.Count<4)
            {
                PointLatLng clickedPoint = gMapControl1.FromLocalToLatLng((int)e.X, (int)e.Y);
                double lat = clickedPoint.Lat;
                double lon = clickedPoint.Lng;
                NuevaZonaRegistro F4 = new NuevaZonaRegistro();
                F4.ShowDialog();
                double d1 = F4.getWidth();
                double d2 = F4.getLength();
                F4.Close();
                if (d1 != -1)
                {
                    if (polygonOverlay.Polygons.Count == 0)
                    {
                        gMapControl1.Overlays.Add(polygonOverlay);
                    }
                    GMapPolygon zonaRegistro = createZone(lat, lon, d1, d2, polygonOverlay.Polygons.Count);
                    polygonOverlay.Polygons.Add(zonaRegistro);
                    gMapControl1.Refresh();
                }
            }
            else if(e.Button == MouseButtons.Right)
            {
                if(polygonOverlay.Polygons.Count > 0)
                {
                    PointLatLng clickedPoint = gMapControl1.FromLocalToLatLng((int)e.X, (int)e.Y);
                    GMapMarker markerTemp = new GMarkerGoogle(clickedPoint, GMarkerGoogleType.black_small);
                    for (int i = 0; i < polygonOverlay.Polygons.Count; i++)
                    {
                        if (checkIncursion(markerTemp, polygonOverlay.Polygons[i]))
                        {
                            polygonOverlay.Polygons.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Solo se permiten 4 zonas de registro. Puede eliminar existentes con el botón derecho");
            }
        }
    }
}
