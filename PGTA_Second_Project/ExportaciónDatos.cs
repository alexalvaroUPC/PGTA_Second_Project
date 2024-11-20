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
using static GMap.NET.Entity.OpenStreetMapGraphHopperRouteEntity;
using System.Reflection.Metadata;
using MaterialSkin;
using MaterialSkin.Controls;
namespace PGTA_Second_Project
{
    public partial class ExportaciónDatos : Form
    {
        private List<message048> message048s;
        private List<message048> wantedData;
        bool showTableFlag = false;
        public ExportaciónDatos()
        {
            InitializeComponent();
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
        }
        public void setTableFlag(bool status) { this.showTableFlag = status; }
        public void setMessageList(List<message048> messageList)
        {
            this.message048s = messageList;
            this.wantedData = messageList;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileSaver = new SaveFileDialog();
            fileSaver.Filter = "Archivo CSV (*.csv) | *.csv";
            if (fileSaver.ShowDialog() == DialogResult.OK)
            {
                if (checkBox1.Checked)
                {
                    wantedData = wantedData.FindAll(item => !item.Grounded);
                }
                if (checkBox2.Checked)
                {
                    wantedData = wantedData.FindAll(item => !item.Purity);
                }
                if (checkBox3.Checked)
                {
                    wantedData = wantedData.FindAll(item => !item.Fixed);
                }
                if (checkBox4.Checked)
                {
                    try
                    {
                        double minLat = Convert.ToDouble(textBox1.Text);
                        double maxLat = Convert.ToDouble(textBox2.Text);
                        double minLon = Convert.ToDouble(textBox3.Text);
                        double maxLon = Convert.ToDouble(textBox4.Text);
                        wantedData = wantedData.FindAll(item => (Convert.ToDouble(item.LAT) >= minLat) && (Convert.ToDouble(item.LAT) <= maxLat) && (Convert.ToDouble(item.LON) >= minLon) && (Convert.ToDouble(item.LON) <= maxLon));
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Revise formato de los datos numéricos");
                    }
                }
                int csvStatus = csvExport(fileSaver.FileName, this.wantedData);
                if (csvStatus == 0)
                {
                    MessageBox.Show("¡CSV exportado! \n Los filtros han sido reiniciados");
                    wantedData = message048s;
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                    checkBox4.Checked = false;
                }
                else
                {
                    MessageBox.Show("Error inesperado en la exportación");
                }
            }

        }
        private string[] prepareString(List<message048> dataList)
        {
            string delimiter = ";";
            string[] dataString = new string[dataList.Count + 1];
            dataString[0] = "Number" + delimiter
                + "SAC" + delimiter
                + "SIC" + delimiter
                + "TIME" + delimiter
                + "TIME(s)" + delimiter
                + "acADRESS" + delimiter
                + "acID" + delimiter
                + "trackNum" + delimiter
                + "LAT" + delimiter
                + "LON" + delimiter
                + "H" + delimiter
                + "TYP" + delimiter
                + "SIM" + delimiter
                + "RDP" + delimiter
                + "SPI" + delimiter
                + "RAB" + delimiter
                + "TST" + delimiter
                + "ERR" + delimiter
                + "XPP" + delimiter
                + "ME" + delimiter
                + "MI" + delimiter
                + "FOE_FRI" + delimiter
                + "RHO" + delimiter
                + "THETA" + delimiter
                + "mode3V" + delimiter
                + "mode3G" + delimiter
                + "mode3squawk" + delimiter
                + "V090" + delimiter
                + "G090" + delimiter
                + "flightLevel" + delimiter
                + "CorrectedModeC" + delimiter
                + "SRL" + delimiter
                + "SRR" + delimiter
                + "SAM" + delimiter
                + "PRL" + delimiter
                + "PAM" + delimiter
                + "RPD" + delimiter
                + "APD" + delimiter
                + "cartesianX" + delimiter
                + "cartesianY" + delimiter
                + "groundSpeedKT" + delimiter
                + "Heading" + delimiter
                + "CNF" + delimiter
                + "RAD" + delimiter
                + "DOU" + delimiter
                + "MAH" + delimiter
                + "CDM" + delimiter
                + "TRE" + delimiter
                + "GHO" + delimiter
                + "SUP" + delimiter
                + "TCC" + delimiter
                + "BDS" + delimiter
                + "mcp_fcu_Status" + delimiter
                + "mcp_fcu_SelectedAltitude" + delimiter
                + "fms_Status" + delimiter
                + "fms_SelectedAltitude" + delimiter
                + "bp_Status" + delimiter
                + "bp" + delimiter
                + "mcp_fcu_Mode" + delimiter
                + "altHoldMode" + delimiter
                + "approachMode" + delimiter
                + "targetAltitudeStatus" + delimiter
                + "targetAltitudeSource" + delimiter
                + "groundSpeedStatus" + delimiter
                + "groundSpeed" + delimiter
                + "trackAngleRateStatus" + delimiter
                + "trackAngleRate" + delimiter
                + "trueAirspeedStatus" + delimiter
                + "trueAirspeed" + delimiter
                + "magneticHeadingStatus" + delimiter
                + "magneticHeading" + delimiter
                + "indicatedAirspeedStatus" + delimiter
                + "indicatedAirspeed" + delimiter
                + "machNumberStatus" + delimiter
                + "machNumber" + delimiter
                + "barometricAltitudeRateStatus" + delimiter
                + "barometricAltitudeRate" + delimiter
                + "inertialVerticalVelocityStatus" + delimiter
                + "inertialVerticalVelocity" + delimiter
                + "heightMeasured3DRadar" + delimiter
                + "COM" + delimiter
                + "STAT" + delimiter
                + "SI" + delimiter
                + "MSSC" + delimiter
                + "ARC" + delimiter
                + "AIC" + delimiter
                + "B1A" + delimiter
                + "B1B";


            for (int i = 0; i < dataList.Count; i++)
            {
                message048 curMes = dataList[i];
                string line = curMes.messageNumber + delimiter
                    + curMes.SAC + delimiter
                    + curMes.SIC + delimiter
                    + curMes.timeOfDay + delimiter
                    + Convert.ToString(curMes.timeInSeconds) + delimiter
                    + curMes.acAddress + delimiter
                    + curMes.acID + delimiter
                    + curMes.trackNum + delimiter
                    + curMes.LAT + delimiter
                    + curMes.LON + delimiter
                    + curMes.geodesicHeight + delimiter
                    + curMes.TYP + delimiter
                    + curMes.SIM + delimiter
                    + curMes.RDP + delimiter
                    + curMes.SPI + delimiter
                    + curMes.RAB + delimiter
                    + curMes.TST + delimiter
                    + curMes.ERR + delimiter
                    + curMes.XPP + delimiter
                    + curMes.ME + delimiter
                    + curMes.MI + delimiter
                    + curMes.FOE_FRI + delimiter
                    + curMes.RHO + delimiter
                    + curMes.THETA + delimiter
                    + curMes.mode3V + delimiter
                    + curMes.mode3G + delimiter
                    + curMes.mode3squawk + delimiter
                    + curMes.V090 + delimiter
                    + curMes.G090 + delimiter
                    + curMes.flightLevel + delimiter
                    + curMes.CorrectedModeC + delimiter
                    + curMes.SRL + delimiter
                    + curMes.SRR + delimiter
                    + curMes.SAM + delimiter
                    + curMes.PRL + delimiter
                    + curMes.PAM + delimiter
                    + curMes.RPD + delimiter
                    + curMes.APD + delimiter
                    + curMes.cartesianX + delimiter
                    + curMes.cartesianY + delimiter
                    + curMes.groundSpeedKT + delimiter
                    + curMes.Heading + delimiter
                    + curMes.CNF + delimiter
                    + curMes.RAD + delimiter
                    + curMes.DOU + delimiter
                    + curMes.MAH + delimiter
                    + curMes.CDM + delimiter
                    + curMes.TRE + delimiter
                    + curMes.GHO + delimiter
                    + curMes.SUP + delimiter
                    + curMes.TCC + delimiter
                    + curMes.BDSex + delimiter
                    + curMes.mcp_fcu_Status + delimiter
                    + curMes.mcp_fcu_SelectedAltitude + delimiter
                    + curMes.fms_Status + delimiter
                    + curMes.fms_SelectedAltitude + delimiter
                    + curMes.bp_Status + delimiter
                    + curMes.bp + delimiter
                    + curMes.mcp_fcu_Mode + delimiter
                    + curMes.altHoldMode + delimiter
                    + curMes.approachMode + delimiter
                    + curMes.targetAltitudeStatus + delimiter
                    + curMes.targetAltitudeSource + delimiter
                    + curMes.groundSpeedStatus + delimiter
                    + curMes.groundSpeed + delimiter
                    + curMes.trackAngleRateStatus + delimiter
                    + curMes.trackAngleRate + delimiter
                    + curMes.trueAirspeedStatus + delimiter
                    + curMes.trueAirspeed + delimiter
                    + curMes.magneticHeadingStatus + delimiter
                    + curMes.magneticHeading + delimiter
                    + curMes.indicatedAirspeedStatus + delimiter
                    + curMes.indicatedAirspeed + delimiter
                    + curMes.machNumberStatus + delimiter
                    + curMes.machNumber + delimiter
                    + curMes.barometricAltitudeRateStatus + delimiter
                    + curMes.barometricAltitudeRate + delimiter
                    + curMes.inertialVerticalVelocityStatus + delimiter
                    + curMes.inertialVerticalVelocity + delimiter
                    + curMes.heightMeasured3DRadar + delimiter
                    + curMes.COM + delimiter
                    + curMes.STAT + delimiter
                    + curMes.SI + delimiter
                    + curMes.MSSC + delimiter
                    + curMes.ARC + delimiter
                    + curMes.AIC + delimiter
                    + curMes.B1A + delimiter
                    + curMes.B1B;
                dataString[i + 1] = line;
            }

            return dataString;
        }


        public int csvExport(string path, List<message048> exportList)
        {
            using (var writer = new StreamWriter(path))
            {
                string delimiter = ";";
                string columnHeaders = "SAC" + delimiter
                    + "SIC" + delimiter
                    + "TIME" + delimiter
                    + "TIME(s)" + delimiter
                    + "acADRESS" + delimiter
                    + "acID" + delimiter
                    + "trackNum" + delimiter
                    + "LAT" + delimiter
                    + "LON" + delimiter
                    + "H" + delimiter
                    + "TYP" + delimiter
                    + "SIM" + delimiter
                    + "RDP" + delimiter
                    + "SPI" + delimiter
                    + "RAB" + delimiter
                    + "TST" + delimiter
                    + "ERR" + delimiter
                    + "XPP" + delimiter
                    + "ME" + delimiter
                    + "MI" + delimiter
                    + "FOE_FRI" + delimiter
                    + "RHO" + delimiter
                    + "THETA" + delimiter
                    + "mode3V" + delimiter
                    + "mode3G" + delimiter
                    + "mode3squawk" + delimiter
                    + "V090" + delimiter
                    + "G090" + delimiter
                    + "flightLevel" + delimiter
                    + "CorrectedModeC" + delimiter
                    + "SRL" + delimiter
                    + "SRR" + delimiter
                    + "SAM" + delimiter
                    + "PRL" + delimiter
                    + "PAM" + delimiter
                    + "RPD" + delimiter
                    + "APD" + delimiter
                    + "cartesianX" + delimiter
                    + "cartesianY" + delimiter
                    + "groundSpeedKT" + delimiter
                    + "Heading" + delimiter
                    + "CNF" + delimiter
                    + "RAD" + delimiter
                    + "DOU" + delimiter
                    + "MAH" + delimiter
                    + "CDM" + delimiter
                    + "TRE" + delimiter
                    + "GHO" + delimiter
                    + "SUP" + delimiter
                    + "TCC" + delimiter
                    + "BDS" + delimiter
                    + "mcp_fcu_Status" + delimiter
                    + "mcp_fcu_SelectedAltitude" + delimiter
                    + "fms_Status" + delimiter
                    + "fms_SelectedAltitude" + delimiter
                    + "bp_Status" + delimiter
                    + "bp" + delimiter
                    + "mcp_fcu_Mode" + delimiter
                    + "altHoldMode" + delimiter
                    + "approachMode" + delimiter
                    + "targetAltitudeStatus" + delimiter
                    + "targetAltitudeSource" + delimiter
                    + "groundSpeedStatus" + delimiter
                    + "groundSpeed" + delimiter
                    + "trackAngleRateStatus" + delimiter
                    + "trackAngleRate" + delimiter
                    + "trueAirspeedStatus" + delimiter
                    + "trueAirspeed" + delimiter
                    + "magneticHeadingStatus" + delimiter
                    + "magneticHeading" + delimiter
                    + "indicatedAirspeedStatus" + delimiter
                    + "indicatedAirspeed" + delimiter
                    + "machNumberStatus" + delimiter
                    + "machNumber" + delimiter
                    + "barometricAltitudeRateStatus" + delimiter
                    + "barometricAltitudeRate" + delimiter
                    + "inertialVerticalVelocityStatus" + delimiter
                    + "inertialVerticalVelocity" + delimiter
                    + "heightMeasured3DRadar" + delimiter
                    + "COM" + delimiter
                    + "STAT" + delimiter
                    + "SI" + delimiter
                    + "MSSC" + delimiter
                    + "ARC" + delimiter
                    + "AIC" + delimiter
                    + "B1A" + delimiter
                    + "B1B" + delimiter;
                writer.WriteLine(columnHeaders);

                for (int i = 0; i < exportList.Count; i++)
                {
                    message048 curMes = exportList[i];
                    string line = curMes.SAC + delimiter
                        + curMes.SIC + delimiter
                        + curMes.timeOfDay + delimiter
                        + Convert.ToString(curMes.timeInSeconds) + delimiter
                        + curMes.acAddress + delimiter
                        + curMes.acID + delimiter
                        + curMes.trackNum + delimiter
                        + curMes.LAT + delimiter
                        + curMes.LON + delimiter
                        + curMes.geodesicHeight + delimiter
                        + curMes.TYP + delimiter
                        + curMes.SIM + delimiter
                        + curMes.RDP + delimiter
                        + curMes.SPI + delimiter
                        + curMes.RAB + delimiter
                        + curMes.TST + delimiter
                        + curMes.ERR + delimiter
                        + curMes.XPP + delimiter
                        + curMes.ME + delimiter
                        + curMes.MI + delimiter
                        + curMes.FOE_FRI + delimiter
                        + curMes.RHO + delimiter
                        + curMes.THETA + delimiter
                        + curMes.mode3V + delimiter
                        + curMes.mode3G + delimiter
                        + curMes.mode3squawk + delimiter
                        + curMes.V090 + delimiter
                        + curMes.G090 + delimiter
                        + curMes.flightLevel + delimiter
                        + curMes.CorrectedModeC + delimiter
                        + curMes.SRL + delimiter
                        + curMes.SRR + delimiter
                        + curMes.SAM + delimiter
                        + curMes.PRL + delimiter
                        + curMes.PAM + delimiter
                        + curMes.RPD + delimiter
                        + curMes.APD + delimiter
                        + curMes.cartesianX + delimiter
                        + curMes.cartesianY + delimiter
                        + curMes.groundSpeedKT + delimiter
                        + curMes.Heading + delimiter
                        + curMes.CNF + delimiter
                        + curMes.RAD + delimiter
                        + curMes.DOU + delimiter
                        + curMes.MAH + delimiter
                        + curMes.CDM + delimiter
                        + curMes.TRE + delimiter
                        + curMes.GHO + delimiter
                        + curMes.SUP + delimiter
                        + curMes.TCC + delimiter
                        + curMes.BDSex + delimiter
                        + curMes.mcp_fcu_Status + delimiter
                        + curMes.mcp_fcu_SelectedAltitude + delimiter
                        + curMes.fms_Status + delimiter
                        + curMes.fms_SelectedAltitude + delimiter
                        + curMes.bp_Status + delimiter
                        + curMes.bp + delimiter
                        + curMes.mcp_fcu_Mode + delimiter
                        + curMes.altHoldMode + delimiter
                        + curMes.approachMode + delimiter
                        + curMes.targetAltitudeStatus + delimiter
                        + curMes.targetAltitudeSource + delimiter
                        + curMes.groundSpeedStatus + delimiter
                        + curMes.groundSpeed + delimiter
                        + curMes.trackAngleRateStatus + delimiter
                        + curMes.trackAngleRate + delimiter
                        + curMes.trueAirspeedStatus + delimiter
                        + curMes.trueAirspeed + delimiter
                        + curMes.magneticHeadingStatus + delimiter
                        + curMes.magneticHeading + delimiter
                        + curMes.indicatedAirspeedStatus + delimiter
                        + curMes.indicatedAirspeed + delimiter
                        + curMes.machNumberStatus + delimiter
                        + curMes.machNumber + delimiter
                        + curMes.barometricAltitudeRateStatus + delimiter
                        + curMes.barometricAltitudeRate + delimiter
                        + curMes.inertialVerticalVelocityStatus + delimiter
                        + curMes.inertialVerticalVelocity + delimiter
                        + curMes.heightMeasured3DRadar + delimiter
                        + curMes.COM + delimiter
                        + curMes.STAT + delimiter
                        + curMes.SI + delimiter
                        + curMes.MSSC + delimiter
                        + curMes.ARC + delimiter
                        + curMes.AIC + delimiter
                        + curMes.B1A + delimiter
                        + curMes.B1B + delimiter;

                    writer.WriteLine(line);
                }
            }

            return 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                wantedData = wantedData.FindAll(item => !item.Grounded);
            }
            if (checkBox2.Checked)
            {
                wantedData = wantedData.FindAll(item => !item.Purity);
            }
            if (checkBox3.Checked)
            {
                wantedData = wantedData.FindAll(item => !item.Fixed);
            }
            if (checkBox4.Checked)
            {
                double minLat = Convert.ToDouble(textBox1.Text);
                double maxLat = Convert.ToDouble(textBox2.Text);
                double minLon = Convert.ToDouble(textBox3.Text);
                double maxLon = Convert.ToDouble(textBox4.Text);
                wantedData = wantedData.FindAll(item => (Convert.ToDouble(item.LAT) >= minLat) && (Convert.ToDouble(item.LAT) <= maxLat) && (Convert.ToDouble(item.LON) >= minLon) && (Convert.ToDouble(item.LON) <= maxLon));
            }
            List<message048> simData = wantedData;
            wantedData = message048s;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            Simulador F3 = new Simulador();
            F3.setData(simData);
            F3.ShowDialog();
            wantedData = F3.getTargetCallsigns();
            string[] dataForGrid = prepareString(this.wantedData);
            fillTable(dataForGrid);
            button3.Text = "Actualizar tabla";
            F3.Close();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
            }
            else
            {
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                wantedData = wantedData.FindAll(item => !item.Grounded);
            }
            if (checkBox2.Checked)
            {
                wantedData = wantedData.FindAll(item => !item.Purity);
            }
            if (checkBox3.Checked)
            {
                wantedData = wantedData.FindAll(item => !item.Fixed);
            }
            if (checkBox4.Checked)
            {
                try
                {
                    double minLat = Convert.ToDouble(textBox1.Text);
                    double maxLat = Convert.ToDouble(textBox2.Text);
                    double minLon = Convert.ToDouble(textBox3.Text);
                    double maxLon = Convert.ToDouble(textBox4.Text);
                    wantedData = wantedData.FindAll(item => (Convert.ToDouble(item.LAT) >= minLat) && (Convert.ToDouble(item.LAT) <= maxLat) && (Convert.ToDouble(item.LON) >= minLon) && (Convert.ToDouble(item.LON) <= maxLon));
                }
                catch (FormatException)
                {
                    MessageBox.Show("Revise formato de los datos numéricos");
                }
            }
            string[] dataForGrid = prepareString(this.wantedData);
            fillTable(dataForGrid);
            button3.Text = "Actualizar tabla";

        }

        private void ExportaciónDatos_Load(object sender, EventArgs e)
        {

            if (showTableFlag)
            {

                string[] dataForGrid = prepareString(this.message048s);
                fillTable(dataForGrid);
            }
            else
            {
                button3.Text = "Mostrar tabla";
            }

        }
        private void fillTable(string[] dataSource)
        {

            DataTable dataTable = new DataTable();

            string[] columnNames = dataSource[0].Split(';');

            foreach (string columnName in columnNames)
            {
                dataTable.Columns.Add(columnName);
            }
            int rowCount = dataSource.Length;
            for (int i = 1; i < rowCount; i++)
            {
                string[] rowData = dataSource[i].Split(';');
                DataRow dataRow = dataTable.NewRow();

                for (int j = 0; j < columnNames.Length; j++)
                {
                    dataRow[j] = rowData[j];
                }

                dataTable.Rows.Add(dataRow);
            }

            message048View.DataSource = dataTable;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            this.wantedData = this.message048s;
            string[] dataForGrid = prepareString(this.wantedData);
            fillTable(dataForGrid);
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
        }
    }
}
