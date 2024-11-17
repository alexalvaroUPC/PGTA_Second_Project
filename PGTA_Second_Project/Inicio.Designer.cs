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
            button1 = new Button();
            checkBox1 = new CheckBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(605, 428);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(136, 44);
            button1.TabIndex = 0;
            button1.Text = "Select file";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(363, 314);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(695, 34);
            checkBox1.TabIndex = 1;
            checkBox1.Text = "Mostrar datos en tabla (ralentizará la operación para archivos pesados)";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1431, 833);
            Controls.Add(checkBox1);
            Controls.Add(button1);
            Margin = new Padding(4);
            Name = "Inicio";
            Text = "Init";
            ResumeLayout(false);
            PerformLayout();
        }

        private Button button1;

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


        #endregion


        private CheckBox checkBox1;
    }
}
