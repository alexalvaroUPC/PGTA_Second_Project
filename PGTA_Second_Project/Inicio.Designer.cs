using System.Diagnostics;
using static System.Net.WebRequestMethods;

namespace PGTA_Second_Project
{
    partial class Inicio
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            button1 = new Button();
            checkBox1 = new CheckBox();
            label1 = new Label();
            linkLabel1 = new LinkLabel();
            label2 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button1.Location = new Point(343, 204);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(146, 22);
            button1.TabIndex = 0;
            button1.Text = "Seleccionar archivo";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            checkBox1.Location = new Point(208, 170);
            checkBox1.Margin = new Padding(2);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(397, 19);
            checkBox1.TabIndex = 1;
            checkBox1.Text = "Mostrar datos en tabla (ralentizará la operación para archivos pesados)";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 14.1428576F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(164, 42);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(530, 25);
            label1.TabIndex = 2;
            label1.Text = "Bienvenido/a al decodificador de ASTERIX Categoría 48";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(280, 263);
            linkLabel1.Margin = new Padding(2, 0, 2, 0);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(244, 15);
            linkLabel1.TabIndex = 3;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Consultar información, manual de uso y más";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 8.142858F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(189, 378);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(445, 13);
            label2.TabIndex = 4;
            label2.Text = "Álvaro Cerón, Pol Mas, Galder Bilbao, Álex Álvaro, Santiago Barrios, Aleix Balust. EETAC 2024";
            // 
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(835, 416);
            Controls.Add(label2);
            Controls.Add(linkLabel1);
            Controls.Add(label1);
            Controls.Add(checkBox1);
            Controls.Add(button1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "Inicio";
            Text = "Selección de archivo";
            ResumeLayout(false);
            PerformLayout();
        }

        private Button button1;

        private CheckBox checkBox1;
        private Label label1;
        private LinkLabel linkLabel1;

        private void button1_Click(object sender, EventArgs e)
        {
            //Seleccion de fichero a abrir
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos binarios asterix(*.ast)|*.ast";
            if(openFileDialog.ShowDialog()== DialogResult.OK)
            {
                //StreamReader R = new StreamReader(openFileDialog.FileName);
                //Lectura y almacenamiento de todos los bytes del fichero en totalBytes
                AsterixFile readFile = new AsterixFile();
                readFile.byteOperations(openFileDialog.FileName);
                ExportaciónDatos F2 = new ExportaciónDatos();
                F2.setMessageList(readFile.get048List());
                F2.setTableFlag(checkBox1.Checked);
                F2.ShowDialog();
            }

        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var ps = new ProcessStartInfo("https://github.com/alexalvaroUPC/PGTA_Second_Project")
            {
                UseShellExecute = true,
                Verb = "open"
            };
            Process.Start(ps);
        }

        #endregion


        private Label label2;
    }
}
