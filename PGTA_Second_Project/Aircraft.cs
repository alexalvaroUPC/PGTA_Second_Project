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
        private string squawk;

        public Aircraft(double lat, double lon, double height, string squawk)
        {
            this.lat = lat;
            this.lon = lon;
            this.height = height;
            this.squawk = squawk;
        }
    }
}
