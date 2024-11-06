namespace PGTA_Second_Project
{
    partial class Form2
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
            button1 = new Button();
            button2 = new Button();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(669, 555);
            button1.Name = "button1";
            button1.Size = new Size(312, 84);
            button1.TabIndex = 1;
            button1.Text = "Export CSV";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1246, 546);
            button2.Name = "button2";
            button2.Size = new Size(242, 100);
            button2.TabIndex = 2;
            button2.Text = "Access to simulator";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(571, 134);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(266, 34);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "Delete grounded aircraft";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(571, 184);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(217, 34);
            checkBox2.TabIndex = 4;
            checkBox2.Text = "Delete pure targets";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(571, 234);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(268, 34);
            checkBox3.TabIndex = 5;
            checkBox3.Text = "Delete fixed transponder";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(571, 284);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(290, 34);
            checkBox4.TabIndex = 6;
            checkBox4.Text = "Delimitate geographic area";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1140, 297);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(207, 35);
            textBox1.TabIndex = 7;
            textBox1.Text = "Minimum latitude";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(1140, 360);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(207, 35);
            textBox2.TabIndex = 8;
            textBox2.Text = "Maximum latitude";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(1393, 297);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(207, 35);
            textBox3.TabIndex = 9;
            textBox3.Text = "Minimum longitude";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(1393, 360);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(207, 35);
            textBox4.TabIndex = 10;
            textBox4.Text = "Maximum longitude";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1639, 752);
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
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private Button button2;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
    }
}