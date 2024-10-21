using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using System.Globalization;
using System.IO;
using CsvHelper.Configuration;
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
                string columnHeaders = "SIC, SAC, TIME";
                writer.WriteLine(columnHeaders);
                for (int i = 0; i < this.message048s.Count; i++)
                {
                    string line = message048s[i].SIC + "," + message048s[i].SAC + "," + message048s[i].timeOfDay;
                    writer.WriteLine(line);
                }
            }
                
            return 0;
        }
    }
}
