namespace PGTA_Second_Project
{
    partial class NuevaZonaRegistro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevaZonaRegistro));
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(269, 173);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(79, 38);
            textBox1.TabIndex = 0;
            textBox1.Text = "Ancho";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(452, 105);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(76, 38);
            textBox2.TabIndex = 1;
            textBox2.Text = "Alto";
            // 
            // button1
            // 
            button1.Location = new Point(360, 242);
            button1.Name = "button1";
            button1.Size = new Size(168, 53);
            button1.TabIndex = 2;
            button1.Text = "Aceptar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(83, 242);
            button2.Name = "button2";
            button2.Size = new Size(168, 53);
            button2.TabIndex = 3;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 8F);
            label1.Location = new Point(12, 36);
            label1.Name = "label1";
            label1.Size = new Size(540, 25);
            label1.TabIndex = 4;
            label1.Text = "Introduzca las dimensiones (MN) de la zona de registro a crear";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 192, 128);
            panel1.Location = new Point(190, 84);
            panel1.Name = "panel1";
            panel1.Size = new Size(244, 83);
            panel1.TabIndex = 5;
            // 
            // NuevaZonaRegistro
            // 
            AutoScaleDimensions = new SizeF(13F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(593, 356);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Font = new Font("Segoe UI Semibold", 9.857143F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "NuevaZonaRegistro";
            Text = "Crear nueva zona de registro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Button button2;
        private Label label1;
        private Panel panel1;
    }
}