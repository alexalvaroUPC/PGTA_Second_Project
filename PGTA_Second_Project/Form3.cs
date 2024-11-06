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

        GMapOverlay markers = new GMapOverlay("markers");
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
            this.markerIcon = new Bitmap(image, new Size(25,25));
            this.markerIcon.MakeTransparent();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            this.j = firstClock;
            GMapOverlay markers = new GMapOverlay("markers");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            for (int i = 0; i < this.aircrafts.Count; i++)
            {
                Aircraft moveAC = this.aircrafts[i].moveAC(j);
                double X = moveAC.getLatitude();
                double Y = moveAC.getLongitude();
                if (X != 300 && Y != 300)
                {
                    aircraftMarkers[i].Position = new PointLatLng(X, Y);
                    markers.Markers.Add(aircraftMarkers[i]);
                }

            }
            this.j++;
            gMapControl1.Overlays.Add(markers);
            gMapControl1.Refresh();

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.firstClock = message048s[0].timeInSeconds;
            this.lastClock = message048s.Last().timeInSeconds;
            double currentLat;
            double currentLon;
            double currentHeight;
            int moveTime;
            List<string> neededSquawks = message048s.Where(item => item.mode3squawk != "N/A").Select(item => item.mode3squawk).Distinct().ToList();
            for (int i = 0; i < neededSquawks.Count; i++)
            {
                Aircraft aircraft = new Aircraft(neededSquawks[i]);
                this.aircrafts.Add(aircraft);
            }
            for (int k = 0; k < message048s.Count; k++)
            {
                int hitIndex = aircrafts.FindIndex(item => item.squawk == message048s[k].mode3squawk);
                if (hitIndex != -1)
                {
                    currentLat = Convert.ToDouble(message048s[k].LAT);
                    currentLon = Convert.ToDouble(message048s[k].LON);
                    currentHeight = Convert.ToDouble(message048s[k].geodesicHeight);
                    moveTime = message048s[k].timeInSeconds;
                    aircrafts[hitIndex].fillCoordinates(currentLat, currentLon, currentHeight, moveTime);
                }
            }
            double initialLat = 47.3;
            double initialLon = 2.1;
            for (int i = 0; i < this.aircrafts.Count; i++)
            {
                GMapMarker marker = new GMarkerGoogle(new PointLatLng(initialLat, initialLon), markerIcon);
                //aircraftMarkers[i].Position = new PointLatLng(initialLat, initialLon);
                aircraftMarkers.Add(marker);
            }

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

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.aircrafts.Count; i++)
            {
                Aircraft moveAC = this.aircrafts[i].moveAC(j);
                double X = moveAC.getLatitude();
                double Y = moveAC.getLongitude();
                if (X != 300 && Y != 300)
                {
                    aircraftMarkers[i].Position = new PointLatLng(X, Y);
                    markers.Markers.Add(aircraftMarkers[i]);
                }

            }
            this.j++;
            gMapControl1.Overlays.Add(markers);
            gMapControl1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (j > firstClock)
            {
                this.j--;
                for (int i = 0; i < this.aircrafts.Count; i++)
                {
                    Aircraft moveAC = this.aircrafts[i].moveAC(j);
                    double X = moveAC.getLatitude();
                    double Y = moveAC.getLongitude();
                    if (X != 300 && Y != 300)
                    {
                        aircraftMarkers[i].Position = new PointLatLng(X, Y);
                        markers.Markers.Add(aircraftMarkers[i]);
                    }

                }
                gMapControl1.Overlays.Add(markers);
                gMapControl1.Refresh();
            }
        }
    }
}
