using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA_Second_Project
{
    internal class Aircraft
    {
        private double lat = 400;
        private double lon = 400;
        private double height = 400;
        private float heading = 400;
        public string squawk;
        private List<double> latitudes = new List<double>();
        private List<double> longitudes = new List<double>();
        private List<double> altitudes = new List<double>();
        private List<float> headings = new List<float>();
        private Stack<double> stackedLats = new Stack<double>();
        private Stack<double> stackedLons = new Stack<double>();
        private Stack<double> stackedAlts = new Stack<double>();
        private Stack<float> stackedHdgs = new Stack<float>();
        private Stack<double> undoLats = new Stack<double>();
        private Stack<double> undoLons = new Stack<double>();
        private Stack<double> undoAlts = new Stack<double>();
        private Stack<float> undoHdgs = new Stack<float>();


        public Aircraft(string squawk)
        {
            this.squawk = squawk;
        }
        public void fillCoordinates(double currentLatitude, double currentLongitude, double currentHeight, float currentHeading, int listIndex)
        {

            this.latitudes[listIndex] = currentLatitude;
            this.longitudes[listIndex] = currentLongitude;
            this.altitudes[listIndex] = currentHeight;
            this.headings[listIndex] = currentHeading;
        }
        public void fill400()
        {
            this.latitudes.Add(400);
            this.longitudes.Add(400);
            this.altitudes.Add(400);
            this.headings.Add(400);
        }
        public void setPosition(double latitude, double longitude, double height, float heading) {this.lat = latitude; this.lon = longitude; this.height = height; this.heading = heading; }
        public double getLatitude() { return lat; }
        public double getLongitude() { return lon; }
        public double getHeight() { return height; }
        public float getHeading() { return heading; }

        public void moveAC()
        {
            double setLat = this.stackedLats.Pop();
            double setLon = this.stackedLons.Pop();
            double setAlt = this.stackedAlts.Pop();
            float setHdg = this.stackedHdgs.Pop();
            undoLats.Push(setLat);
            undoLons.Push(setLon);
            undoAlts.Push(setAlt);
            undoHdgs.Push(setHdg);
            if((setLat != 400) && (setLon!=400))
            {
                this.setPosition(setLat, setLon , setAlt , setHdg);
            }
        }
        public void moveACback()
        {
            double setLat = this.undoLats.Pop();
            double setLon = this.undoLons.Pop();
            double setAlt = this.undoAlts.Pop();
            float setHdg = this.undoHdgs.Pop();
            stackedLats.Push(setLat);
            stackedLons.Push(setLon);
            stackedAlts.Push(setAlt);
            stackedHdgs.Push(setHdg);
            if ((setLat != 400) && (setLon != 400))
            {
                this.setPosition(setLat, setLon, setAlt, setHdg);
            }
        }
        public void copyToStacks()
        {
            while (stackedLats.Count > 0)
            {
                stackedLats.Pop();
                stackedLons.Pop();
                stackedAlts.Pop();
                stackedHdgs.Pop();
            }
            while (undoLats.Count > 0)
            {
                undoLats.Pop();
                undoLons.Pop();
                undoAlts.Pop();
                undoHdgs.Pop();
            }
            for (int i = this.latitudes.Count - 1; i >= 0; i--)
            {
                stackedLats.Push(this.latitudes[i]);
                stackedLons.Push(this.longitudes[i]);
                stackedAlts.Push(this.altitudes[i]);
                stackedHdgs.Push(this.headings[i]);
            }
        }
    }
}
