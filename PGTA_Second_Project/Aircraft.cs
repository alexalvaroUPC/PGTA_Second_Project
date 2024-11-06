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
        private List<double> lastPosition = new List<double>(0);
        public string squawk;
        private List<double> latitudes = new List<double>();
        private List<double> longitudes = new List<double>();
        private List<double> altitudes = new List<double>();
        private List<int> timestamps = new List<int>();

        public Aircraft(string squawk)
        {
            this.squawk = squawk;
        }
        public void fillCoordinates(double currentLatitude, double currentLongitude, double currentHeight, int moveTime)
        {
            this.latitudes.Add(currentLatitude);
            this.longitudes.Add(currentLongitude);
            this.altitudes.Add(currentHeight);
            this.timestamps.Add(moveTime);
        }
        public void setPosition(double latitude, double longitude, double height) {this.lat = latitude; this.lon = longitude; this.height = height;}
        public double getLatitude() { return lat; }
        public double getLongitude() { return lon; }
        public double getHeight() { return height; }

        public Aircraft moveAC(int clockTime)
        {
            int moveIndex = this.timestamps.IndexOf(clockTime);
            if (moveIndex != -1)
            {
                this.setPosition(this.latitudes[moveIndex], this.longitudes[moveIndex], this.altitudes[moveIndex]);
            }
            else
            {
                this.setPosition(300, 300, 300);
            }
            return this;
        }
    }
}
