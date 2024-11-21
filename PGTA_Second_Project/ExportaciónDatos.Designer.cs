using MaterialSkin;
using MaterialSkin.Controls;
using System.Windows.Forms;

namespace PGTA_Second_Project
{
    partial class ExportaciónDatos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportaciónDatos));
            button1 = new MaterialRaisedButton();
            button2 = new MaterialRaisedButton();
            checkBox1 = new MaterialCheckBox();
            checkBox2 = new MaterialCheckBox();
            checkBox3 = new MaterialCheckBox();
            checkBox4 = new MaterialCheckBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            message048View = new DataGridView();
            button3 = new MaterialRaisedButton();
            materialRaisedButton1 = new MaterialRaisedButton();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)message048View).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Depth = 0;
            button1.Location = new Point(445, 223);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.MouseState = MouseState.HOVER;
            button1.Name = "button1";
            button1.Primary = true;
            button1.Size = new Size(153, 49);
            button1.TabIndex = 1;
            button1.Text = "Exportar CSV";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Depth = 0;
            button2.Location = new Point(633, 223);
            button2.Margin = new Padding(4, 3, 4, 3);
            button2.MouseState = MouseState.HOVER;
            button2.Name = "button2";
            button2.Primary = true;
            button2.Size = new Size(153, 49);
            button2.TabIndex = 2;
            button2.Text = "INICIAR SIMULACIÓN";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Depth = 0;
            checkBox1.Font = new Font("Roboto", 10F);
            checkBox1.Location = new Point(203, 46);
            checkBox1.Margin = new Padding(0);
            checkBox1.MouseLocation = new Point(-1, -1);
            checkBox1.MouseState = MouseState.HOVER;
            checkBox1.Name = "checkBox1";
            checkBox1.Ripple = true;
            checkBox1.Size = new Size(186, 30);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "Eliminar aviones en tierra";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Depth = 0;
            checkBox2.Font = new Font("Roboto", 10F);
            checkBox2.Location = new Point(203, 76);
            checkBox2.Margin = new Padding(0);
            checkBox2.MouseLocation = new Point(-1, -1);
            checkBox2.MouseState = MouseState.HOVER;
            checkBox2.Name = "checkBox2";
            checkBox2.Ripple = true;
            checkBox2.Size = new Size(170, 30);
            checkBox2.TabIndex = 4;
            checkBox2.Text = "Eliminar blancos puros";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Depth = 0;
            checkBox3.Font = new Font("Roboto", 10F);
            checkBox3.Location = new Point(203, 106);
            checkBox3.Margin = new Padding(0);
            checkBox3.MouseLocation = new Point(-1, -1);
            checkBox3.MouseState = MouseState.HOVER;
            checkBox3.Name = "checkBox3";
            checkBox3.Ripple = true;
            checkBox3.Size = new Size(218, 30);
            checkBox3.TabIndex = 5;
            checkBox3.Text = "Eliminar transpondedores fijos";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Depth = 0;
            checkBox4.Font = new Font("Roboto", 10F);
            checkBox4.Location = new Point(203, 136);
            checkBox4.Margin = new Padding(0);
            checkBox4.MouseLocation = new Point(-1, -1);
            checkBox4.MouseState = MouseState.HOVER;
            checkBox4.Name = "checkBox4";
            checkBox4.Ripple = true;
            checkBox4.Size = new Size(188, 30);
            checkBox4.TabIndex = 6;
            checkBox4.Text = "Delimitar zona geográfica";
            checkBox4.UseVisualStyleBackColor = true;
            checkBox4.CheckedChanged += checkBox4_CheckedChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(464, 111);
            textBox1.Margin = new Padding(4, 3, 4, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(140, 25);
            textBox1.TabIndex = 7;
            textBox1.Text = "Latitud mínima";
            textBox1.Visible = false;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(464, 177);
            textBox2.Margin = new Padding(4, 3, 4, 3);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(140, 25);
            textBox2.TabIndex = 8;
            textBox2.Text = "Latitud máxima";
            textBox2.Visible = false;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(628, 111);
            textBox3.Margin = new Padding(4, 3, 4, 3);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(140, 25);
            textBox3.TabIndex = 9;
            textBox3.Text = "Longitud mínima";
            textBox3.Visible = false;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(628, 177);
            textBox4.Margin = new Padding(4, 3, 4, 3);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(140, 25);
            textBox4.TabIndex = 10;
            textBox4.Text = "Longitud máxima";
            textBox4.Visible = false;
            // 
            // message048View
            // 
            message048View.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            message048View.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            message048View.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            message048View.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            message048View.Location = new Point(30, 296);
            message048View.Margin = new Padding(4, 3, 4, 3);
            message048View.Name = "message048View";
            message048View.RowHeadersWidth = 72;
            message048View.Size = new Size(1607, 576);
            message048View.TabIndex = 11;
            // 
            // button3
            // 
            button3.Depth = 0;
            button3.Location = new Point(197, 223);
            button3.Margin = new Padding(4, 3, 4, 3);
            button3.MouseState = MouseState.HOVER;
            button3.Name = "button3";
            button3.Primary = true;
            button3.Size = new Size(206, 49);
            button3.TabIndex = 12;
            button3.Text = "Actualizar tabla";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // materialRaisedButton1
            // 
            materialRaisedButton1.Depth = 0;
            materialRaisedButton1.Location = new Point(822, 223);
            materialRaisedButton1.Margin = new Padding(4, 3, 4, 3);
            materialRaisedButton1.MouseState = MouseState.HOVER;
            materialRaisedButton1.Name = "materialRaisedButton1";
            materialRaisedButton1.Primary = true;
            materialRaisedButton1.Size = new Size(206, 49);
            materialRaisedButton1.TabIndex = 13;
            materialRaisedButton1.Text = "Restaurar a datos del archivo";
            materialRaisedButton1.UseVisualStyleBackColor = true;
            materialRaisedButton1.Click += materialRaisedButton1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.1428576F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(164, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(212, 25);
            label1.TabIndex = 14;
            label1.Text = "CONFIGURAR FILTROS";
            // 
            // ExportaciónDatos
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(1650, 1010);
            Controls.Add(label1);
            Controls.Add(materialRaisedButton1);
            Controls.Add(button3);
            Controls.Add(message048View);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(checkBox4);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Font = new Font("Segoe UI", 9.857143F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "ExportaciónDatos";
            Text = "Análisis de datos";
            WindowState = FormWindowState.Maximized;
            Load += ExportaciónDatos_Load;
            ((System.ComponentModel.ISupportInitialize)message048View).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private DataGridView message048View;
        private MaterialRaisedButton materialRaisedButton1;
        private MaterialRaisedButton button1;
        private MaterialRaisedButton button2;
        private MaterialCheckBox checkBox1;
        private MaterialCheckBox checkBox2;
        private MaterialCheckBox checkBox3;
        private MaterialCheckBox checkBox4;
        private MaterialRaisedButton button3;
        private Label label1;
    }
}