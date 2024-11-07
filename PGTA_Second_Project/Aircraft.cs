using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA_Second_Project
{
    internal class Aircraft
    {
        private double lat;
        private double lon;
        private double height;
        private double heading;
        private List<double> lastPosition = new List<double>(0);
        public string squawk;
        private List<double> latitudes = new List<double>();
        private List<double> longitudes = new List<double>();
        private List<double> altitudes = new List<double>();
        private List<int> timestamps = new List<int>();
        private List<double> headings = new List<double>();

        public Aircraft(string squawk)
        {
            this.squawk = squawk;
        }
        public void fillCoordinates(double currentLatitude, double currentLongitude, double currentHeight, int moveTime, double currentHeading)
        {
            this.latitudes.Add(currentLatitude);
            this.longitudes.Add(currentLongitude);
            this.altitudes.Add(currentHeight);
            this.timestamps.Add(moveTime);
            this.headings.Add(currentHeading);
        }
        public void setPosition(double latitude, double longitude, double height, double heading) {this.lat = latitude; this.lon = longitude; this.height = height; this.heading = heading; }
        public double getLatitude() { return lat; }
        public double getLongitude() { return lon; }
        public double getHeight() { return height; }
        public double getHeading() { return heading; }

        public Aircraft moveAC(int clockTime)
        {
            int moveIndex = this.timestamps.IndexOf(clockTime);
            if (moveIndex != -1)
            {
                this.setPosition(this.latitudes[moveIndex], this.longitudes[moveIndex], this.altitudes[moveIndex], this.headings[moveIndex]);
            }
            else
            {
                this.setPosition(300, 300, 300, 0);
            }
            return this;
        }
    }
}
