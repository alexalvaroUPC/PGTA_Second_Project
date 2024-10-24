using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA_Second_Project
{
    internal class geoStuff
    {
        private double latitude;
        private double longitude;
        private double height;
        private double radR;
        private double radAz;
        private double radElev;
        private double radCartesianX;
        private double radCartesianY;
        private double radCartesianZ;
        private double Rearth = 6371000;
        private double radarLocHeight = 25.25 + 2.007;
        private double radarLocLat = 41.30070233;
        private double radarLocLon = 2.102058194;


        public void setRadarSpherical(double r, double az, double height)
        {
            this.radR = r;
            this.radAz = az*Math.PI/180;
            double cosineLaw = (2.0 * Rearth * (height - radarLocHeight) + height * height - radarLocHeight * radarLocHeight - r * r) / (2.0 * r * (Rearth + radarLocHeight));
            this.radElev = Math.Asin(cosineLaw);
        }
        public void radarSpherical2radarCartesian()
        {
            this.radCartesianX = this.radR*Math.Cos(this.radElev)*Math.Sin(this.radAz);
            this.radCartesianY = this.radR * Math.Cos(this.radElev) * Math.Sin(this.radAz);
            this.radCartesianZ = this.radR * Math.Sin(this.radElev);
        }
        public void radarCartesian2geocentric()
        {

        }
        public void getRadarGeodesic()
        {

        }
    }
}
