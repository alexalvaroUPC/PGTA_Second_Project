using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA_Second_Project
{
    internal class geoStuff
    {
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
        private double radarLocLatRad;
        private double radarLocLonRad;
        private double e2 = 0.00669437999013;
        private double a = 6378137.0;
        private double b = 6356752.314245;
        private double radarLocX;
        private double radarLocY;
        private double radarLocZ;
        private double targetGeocentricX;
        private double targetGeocentricY;
        private double targetGeocentricZ;
        private double targetLat;
        private double targetLon;
        private double targetHeight;


        public geoStuff(double r, double az, double height)
        {
            this.radR = r;
            this.radAz = az*Math.PI/180;
            double cosineLaw = (2.0 * Rearth * (height - radarLocHeight) + height * height - radarLocHeight * radarLocHeight - r * r) / (2.0 * r * (Rearth + radarLocHeight));
            this.radElev = Math.Asin(cosineLaw);
        }
        public void radarSpherical2radarCartesian()
        {
            this.radCartesianX = this.radR*Math.Cos(this.radElev)*Math.Sin(this.radAz);
            this.radCartesianY = this.radR * Math.Cos(this.radElev) * Math.Cos(this.radAz);
            this.radCartesianZ = this.radR * Math.Sin(this.radElev);
        }
        public void radarCartesian2geocentric()
        {
            List <double> translationVector = [this.radarLocX, this.radarLocY, this.radarLocZ];
            List <double> geocentricTargetCoordinates = new List <double>();
            List<double> targetCartesian = [this.radCartesianX, this.radCartesianY, this.radCartesianZ];
            double[,] transposedRotationMatrix = { { -Math.Sin(this.radarLocLonRad), -Math.Sin(this.radarLocLatRad) * Math.Cos(this.radarLocLonRad), Math.Cos(this.radarLocLatRad) * Math.Cos(this.radarLocLonRad) }, { Math.Cos(this.radarLocLonRad), -Math.Sin(this.radarLocLatRad) * Math.Sin(this.radarLocLonRad), Math.Cos(this.radarLocLatRad) * Math.Sin(this.radarLocLonRad) }, { 0, Math.Cos(this.radarLocLatRad), Math.Sin(radarLocLatRad) } };
            double operationResult = 0;
            for (int i = 0; i < 3; i++)
            {
                operationResult = 0;
                for (int j = 0; j < 3; j++)
                {
                    operationResult = transposedRotationMatrix[i,j] * targetCartesian[j] + operationResult;

                }
                geocentricTargetCoordinates.Add(operationResult);
                
            }
            this.targetGeocentricX = geocentricTargetCoordinates[0]+ translationVector[0];
            this.targetGeocentricY = geocentricTargetCoordinates[1] + translationVector[1];
            this.targetGeocentricZ = geocentricTargetCoordinates[2] + translationVector[2];
        }

        public void targetGeocentric2targetGeodesic()
        {
            double Z = this.targetGeocentricZ;
            double dxy = Math.Sqrt(Math.Pow(this.targetGeocentricX, 2) + Math.Pow(this.targetGeocentricY, 2));
            double currentLat = Math.Atan(Z/dxy*1/(1-this.a*this.e2/Math.Sqrt(dxy*dxy+Z*Z)));
            double denominator = 1 - this.e2 * Math.Pow(Math.Sin(currentLat), 2);
            double nu = this.a / Math.Sqrt(denominator);
            double currentHeight = dxy/Math.Cos(currentLat) - nu;
            double precisionError = 1;
            double tolerance = Math.Pow(10, -8);
            double newLat;
            if (currentLat >= 0) {
                newLat = 0.1;
            }
            else
            {
                newLat = -0.1;
            }
            while (precisionError >= tolerance)
            {
                precisionError = Math.Abs(newLat - currentLat);
                newLat = currentLat;
                currentLat = Math.Atan(Z/dxy*(1+currentHeight/nu)/(1-this.e2+currentHeight/nu));
                denominator = 1 - this.e2 * Math.Pow(Math.Sin(currentLat), 2);
                nu = this.a / Math.Sqrt(denominator);
                currentHeight = dxy / Math.Cos(currentLat) - nu;      
            }
            this.targetLat = 180/Math.PI * currentLat;
            this.targetLon = 180/Math.PI*Math.Atan(this.targetGeocentricY / this.targetGeocentricX);
            this.targetHeight = currentHeight;


        }
        public void getRadarGeocentric()
        {
            this.radarLocLatRad = radarLocLat * Math.PI / 180;
            this.radarLocLonRad = radarLocLon * Math.PI / 180;
            double denominator = 1 - this.e2 * Math.Pow(Math.Sin(radarLocLatRad), 2);
            double nu = this.a/ Math.Sqrt(denominator);
            this.radarLocX = (nu + this.radarLocHeight) * Math.Cos(radarLocLatRad) * Math.Cos(radarLocLonRad);
            this.radarLocY = (nu + this.radarLocHeight) * Math.Cos(radarLocLatRad) * Math.Sin(radarLocLonRad);
            this.radarLocZ = (nu*(1-this.e2)+this.radarLocHeight)*Math.Sin(radarLocLatRad);
        }
        public double getLatitude() { return this.targetLat; }
        public double getLongitude() { return this.targetLon; }
        public double getGeodesicHeight() {  return this.targetHeight; }
    }
}
