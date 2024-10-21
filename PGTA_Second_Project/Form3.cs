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
        public void setData(List<message048> messages) { this.message048s = messages; }
        public Form3()
        {
            InitializeComponent();
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMapControl1.SetPositionByKeywords("World");
            gMapControl1.Zoom = 15;
        }
    }
}
