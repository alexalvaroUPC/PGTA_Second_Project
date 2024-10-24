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
        private List<Aircraft> aircrafts;
        private int j;
        private int secondClock;
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
            gMapControl1.Zoom = 15;
            gMapControl1.MaxZoom = 20;
            double initialLat = 47.3;
            double initialLon = 2.1;
            for (int i = 0; i < 10; i++)
            {
                GMapMarker marker = new GMarkerGoogle(new PointLatLng(initialLat, initialLon), GMarkerGoogleType.green);
                //aircraftMarkers[i].Position = new PointLatLng(initialLat, initialLon);
                aircraftMarkers.Add(marker);
            }
            this.secondClock = message048s[0].timeInSeconds;  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            this.j = 0;
            GMapOverlay markers = new GMapOverlay("markers");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
           
            for (int i = 0; i < 10; i++)
            {
                double X = 41.297 + 0.001 * i-0.002*j;
                double Y = 2.1 + 0.001 * i-0.002*j;
                aircraftMarkers[i].Position = new PointLatLng(X, Y);
                markers.Markers.Add(aircraftMarkers[i]);
            }
            this.j++;
            gMapControl1.Overlays.Add(markers);
            gMapControl1.Refresh();

        }
        
    }
}
