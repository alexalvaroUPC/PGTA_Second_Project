using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using GMap.NET;
using System.Diagnostics;
namespace PGTA_Second_Project
{
    public partial class Form2 : Form
    {
        private List<message048> message048s;
        public Form2()
        {
            InitializeComponent();
        }
        public void setMessageList(List<message048> messageList)
        {
            this.message048s = messageList;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileSaver = new SaveFileDialog();
            fileSaver.Filter = "Archivo CSV (*.csv) | *.csv";
            fileSaver.ShowDialog();
            int csvStatus = csvExport(fileSaver.FileName);

        }
        public int csvExport(string path)
        {
            using (var writer = new StreamWriter(path))
            {
                string delimiter = ";";
                string columnHeaders = "SAC" + delimiter + "SIC" + delimiter + "TIME" + delimiter + "TIME(s)" + delimiter +
                    "LAT" + delimiter + "LON" + delimiter + "H" + delimiter + "TYP_020" + delimiter + "SIM_020" + delimiter +
                    "RDP_020" + delimiter + "SPI_020" + delimiter + "RAB_020" + delimiter + "TST_020" + delimiter + "ERR_020" + delimiter +
                    "XPP_020" + delimiter + "ME_020" + delimiter + "MI_020" + delimiter + "FOE_FRI_020" + delimiter + "RHO" + delimiter +
                    "THETA" + delimiter + "V_070" + delimiter + "G_070" + delimiter + "MODE 3/A" + delimiter + "V_090" + delimiter +
                    "G_090" + delimiter + "FL" + delimiter + "MODE C corrected" + delimiter + "SRL_130" + delimiter + "SSR_130" + delimiter +
                    "SAM_130" + delimiter + "PRL_130" + delimiter + "PAM_130" + delimiter + "RPD_130" + delimiter + "APD_130" + delimiter +
                    "TA" + delimiter + "TI" + delimiter + "MCP_ALT" + delimiter + "FMS_ALT" + delimiter + "BP" + delimiter + "VNAV" + delimiter +
                    "ALT_HOLD" + delimiter + "APP" + delimiter + "TARGET_ALT_SOURCE" + delimiter + "RA" + delimiter + "TTA" + delimiter +
                    "GS" + delimiter + "TAR" + delimiter + "TAS" + delimiter + "HDG" + delimiter + "IAS" + delimiter + "MACH" + delimiter +
                    "BAR" + delimiter + "IVV" + delimiter + "TN" + delimiter + "X" + delimiter + "Y" + delimiter + "GS_KT" + delimiter +
                    "HEADING" + delimiter + "CNF_170" + delimiter + "RAD_170" + delimiter + "DOU_170" + delimiter + "MAH_170" + delimiter +
                    "CDM_170" + delimiter + "TRE_170" + delimiter + "GHO_170" + delimiter + "SUP_170" + delimiter + "TCC_170" + delimiter +
                    "HEIGHT" + delimiter + "COM_230" + delimiter + "STAT_230" + delimiter + "SI_230" + delimiter + "MSCC_230" + delimiter +
                    "ARC_230" + delimiter + "AIC_230" + delimiter + "B1A_230" + delimiter + "B1B_230";
                ;
                writer.WriteLine(columnHeaders);

                for (int i = 0; i < this.message048s.Count; i++)
                {
                    message048 curMes = this.message048s[i];
                    string line = curMes.SAC + delimiter + curMes.SIC + delimiter + curMes.timeOfDay + delimiter + Convert.ToString(curMes.timeInSeconds)
                        + delimiter + curMes.LAT + delimiter + curMes.LON + delimiter + curMes.geodesicHeight + delimiter + curMes.TYP + delimiter + curMes.SIM +
                        delimiter + curMes.RDP + delimiter + curMes.SPI + delimiter + curMes.RAB + delimiter + curMes.TST + delimiter + curMes.ERR + delimiter + curMes.XPP +
                        delimiter + curMes.ME + delimiter + curMes.MI + delimiter + curMes.FOE_FRI + delimiter + curMes.RHO + delimiter + curMes.THETA + delimiter + 
                        curMes.mode3V + delimiter + curMes.mode3G + delimiter + curMes.mode3squawk + delimiter + curMes.V090 + delimiter + curMes.G090 + delimiter +
                        curMes.flightLevel;
                    writer.WriteLine(line);
                }
            }

            return 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 F3 = new Form3();
            F3.setData(this.message048s);
            F3.ShowDialog();
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
