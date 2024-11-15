namespace PGTA_Second_Project
{
    partial class Form1
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
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(620, 411);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(136, 44);
            button1.TabIndex = 0;
            button1.Text = "Select file";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1431, 833);
            Controls.Add(button1);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Init";
            ResumeLayout(false);
        }

        private Button button1;

        private void button1_Click(object sender, EventArgs e)
        {
            //Seleccion de fichero a abrir
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos binarios asterix(*.ast)|*.ast";
            openFileDialog.ShowDialog();
            //StreamReader R = new StreamReader(openFileDialog.FileName);
            //Lectura y almacenamiento de todos los bytes del fichero en totalBytes
            AsterixFile readFile = new AsterixFile();
            readFile.byteOperations(openFileDialog.FileName);
            Form2 F2 = new Form2();
            F2.setMessageList(readFile.get048List());
            F2.ShowDialog();
        }


        #endregion

        
    }
}
