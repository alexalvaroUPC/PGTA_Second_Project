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
            ((System.ComponentModel.ISupportInitialize)message048View).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Depth = 0;
            button1.Location = new Point(669, 555);
            button1.MouseState = MouseState.HOVER;
            button1.Name = "button1";
            button1.Primary = true;
            button1.Size = new Size(312, 84);
            button1.TabIndex = 1;
            button1.Text = "Export CSV";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Depth = 0;
            button2.Location = new Point(1246, 546);
            button2.MouseState = MouseState.HOVER;
            button2.Name = "button2";
            button2.Primary = true;
            button2.Size = new Size(242, 100);
            button2.TabIndex = 2;
            button2.Text = "Access to simulator";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Depth = 0;
            checkBox1.Font = new Font("Roboto", 10F);
            checkBox1.Location = new Point(571, 134);
            checkBox1.Margin = new Padding(0);
            checkBox1.MouseLocation = new Point(-1, -1);
            checkBox1.MouseState = MouseState.HOVER;
            checkBox1.Name = "checkBox1";
            checkBox1.Ripple = true;
            checkBox1.Size = new Size(294, 30);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "Delete grounded aircraft";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Depth = 0;
            checkBox2.Font = new Font("Roboto", 10F);
            checkBox2.Location = new Point(571, 184);
            checkBox2.Margin = new Padding(0);
            checkBox2.MouseLocation = new Point(-1, -1);
            checkBox2.MouseState = MouseState.HOVER;
            checkBox2.Name = "checkBox2";
            checkBox2.Ripple = true;
            checkBox2.Size = new Size(238, 30);
            checkBox2.TabIndex = 4;
            checkBox2.Text = "Delete pure targets";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Depth = 0;
            checkBox3.Font = new Font("Roboto", 10F);
            checkBox3.Location = new Point(571, 234);
            checkBox3.Margin = new Padding(0);
            checkBox3.MouseLocation = new Point(-1, -1);
            checkBox3.MouseState = MouseState.HOVER;
            checkBox3.Name = "checkBox3";
            checkBox3.Ripple = true;
            checkBox3.Size = new Size(298, 30);
            checkBox3.TabIndex = 5;
            checkBox3.Text = "Delete fixed transponder";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Depth = 0;
            checkBox4.Font = new Font("Roboto", 10F);
            checkBox4.Location = new Point(571, 284);
            checkBox4.Margin = new Padding(0);
            checkBox4.MouseLocation = new Point(-1, -1);
            checkBox4.MouseState = MouseState.HOVER;
            checkBox4.Name = "checkBox4";
            checkBox4.Ripple = true;
            checkBox4.Size = new Size(323, 30);
            checkBox4.TabIndex = 6;
            checkBox4.Text = "Delimitate geographic area";
            checkBox4.UseVisualStyleBackColor = true;
            checkBox4.CheckedChanged += checkBox4_CheckedChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1140, 297);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(207, 35);
            textBox1.TabIndex = 7;
            textBox1.Text = "Minimum latitude";
            textBox1.Visible = false;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(1140, 360);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(207, 35);
            textBox2.TabIndex = 8;
            textBox2.Text = "Maximum latitude";
            textBox2.Visible = false;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(1393, 297);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(207, 35);
            textBox3.TabIndex = 9;
            textBox3.Text = "Minimum longitude";
            textBox3.Visible = false;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(1393, 360);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(207, 35);
            textBox4.TabIndex = 10;
            textBox4.Text = "Maximum longitude";
            textBox4.Visible = false;
            // 
            // message048View
            // 
            message048View.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            message048View.Location = new Point(88, 730);
            message048View.Name = "message048View";
            message048View.RowHeadersWidth = 72;
            message048View.Size = new Size(2848, 864);
            message048View.TabIndex = 11;
            // 
            // button3
            // 
            button3.Depth = 0;
            button3.Location = new Point(593, 359);
            button3.MouseState = MouseState.HOVER;
            button3.Name = "button3";
            button3.Primary = true;
            button3.Size = new Size(277, 71);
            button3.TabIndex = 12;
            button3.Text = "Actualizar tabla";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // materialRaisedButton1
            // 
            materialRaisedButton1.Depth = 0;
            materialRaisedButton1.Location = new Point(202, 561);
            materialRaisedButton1.MouseState = MouseState.HOVER;
            materialRaisedButton1.Name = "materialRaisedButton1";
            materialRaisedButton1.Primary = true;
            materialRaisedButton1.Size = new Size(277, 71);
            materialRaisedButton1.TabIndex = 13;
            materialRaisedButton1.Text = "Restaurar a datos del archivo";
            materialRaisedButton1.UseVisualStyleBackColor = true;
            materialRaisedButton1.Click += materialRaisedButton1_Click;
            // 
            // ExportaciónDatos
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2884, 1624);
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
            Name = "ExportaciónDatos";
            Text = "Form2";
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
    }
}