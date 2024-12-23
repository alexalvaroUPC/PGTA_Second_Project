﻿using MaterialSkin;
using MaterialSkin.Controls;

namespace PGTA_Second_Project
{
    partial class Simulador
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Simulador));
            gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            timer1 = new System.Windows.Forms.Timer(components);
            startButton = new MaterialRaisedButton();
            speedChange = new NumericUpDown();
            label1 = new Label();
            pauseButton = new MaterialRaisedButton();
            stepForwardButton = new MaterialRaisedButton();
            stepBackButton = new MaterialRaisedButton();
            savePDFbutton = new MaterialRaisedButton();
            label2 = new Label();
            resumeButton = new MaterialRaisedButton();
            cutoffSelector = new TrackBar();
            routeView = new DataGridView();
            RouteColumn = new DataGridViewTextBoxColumn();
            CallsignColumn = new DataGridViewTextBoxColumn();
            callsignTextBox = new TextBox();
            addRouteButton = new MaterialRaisedButton();
            label3 = new Label();
            overButton = new MaterialRadioButton();
            switchFLmode = new GroupBox();
            underButton = new MaterialRadioButton();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)speedChange).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cutoffSelector).BeginInit();
            ((System.ComponentModel.ISupportInitialize)routeView).BeginInit();
            switchFLmode.SuspendLayout();
            SuspendLayout();
            // 
            // gMapControl1
            // 
            gMapControl1.AutoSize = true;
            gMapControl1.Bearing = 0F;
            gMapControl1.CanDragMap = true;
            gMapControl1.EmptyTileColor = Color.Navy;
            gMapControl1.ForeColor = Color.Lime;
            gMapControl1.GrayScaleMode = false;
            gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            gMapControl1.LevelsKeepInMemory = 5;
            gMapControl1.Location = new Point(547, 22);
            gMapControl1.Margin = new Padding(4, 4, 10, 10);
            gMapControl1.MarkersEnabled = true;
            gMapControl1.MaxZoom = 18;
            gMapControl1.MinZoom = 2;
            gMapControl1.MouseWheelZoomEnabled = true;
            gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            gMapControl1.Name = "gMapControl1";
            gMapControl1.NegativeMode = false;
            gMapControl1.PolygonsEnabled = true;
            gMapControl1.RetryLoadTile = 0;
            gMapControl1.RoutesEnabled = true;
            gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            gMapControl1.SelectedAreaFillColor = Color.FromArgb(33, 65, 105, 225);
            gMapControl1.ShowTileGridLines = false;
            gMapControl1.Size = new Size(1053, 910);
            gMapControl1.TabIndex = 0;
            gMapControl1.Zoom = 2D;
            gMapControl1.Load += gMapControl1_Load;
            gMapControl1.MouseClick += gMapControl1_MouseClick;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // startButton
            // 
            startButton.BackColor = Color.White;
            startButton.Depth = 0;
            startButton.ForeColor = Color.Lime;
            startButton.Location = new Point(36, 22);
            startButton.Margin = new Padding(4);
            startButton.MouseState = MouseState.HOVER;
            startButton.Name = "startButton";
            startButton.Primary = true;
            startButton.Size = new Size(114, 37);
            startButton.TabIndex = 1;
            startButton.Text = "(Re)Start";
            startButton.UseVisualStyleBackColor = false;
            startButton.Click += button1_Click;
            // 
            // speedChange
            // 
            speedChange.BackColor = Color.Black;
            speedChange.BorderStyle = BorderStyle.FixedSingle;
            speedChange.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            speedChange.ForeColor = Color.Lime;
            speedChange.Location = new Point(51, 111);
            speedChange.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            speedChange.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            speedChange.Name = "speedChange";
            speedChange.Size = new Size(77, 23);
            speedChange.TabIndex = 2;
            speedChange.Value = new decimal(new int[] { 1, 0, 0, 0 });
            speedChange.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Black;
            label1.Font = new Font("Segoe UI", 11.1428576F, FontStyle.Bold);
            label1.ForeColor = Color.Lime;
            label1.Location = new Point(135, 114);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(129, 20);
            label1.TabIndex = 3;
            label1.Text = "Simulation speed";
            // 
            // pauseButton
            // 
            pauseButton.BackColor = Color.White;
            pauseButton.Depth = 0;
            pauseButton.ForeColor = Color.Lime;
            pauseButton.Location = new Point(172, 22);
            pauseButton.Margin = new Padding(4);
            pauseButton.MouseState = MouseState.HOVER;
            pauseButton.Name = "pauseButton";
            pauseButton.Primary = true;
            pauseButton.Size = new Size(92, 37);
            pauseButton.TabIndex = 4;
            pauseButton.Text = "Pause";
            pauseButton.UseVisualStyleBackColor = false;
            pauseButton.Click += button2_Click;
            // 
            // stepForwardButton
            // 
            stepForwardButton.BackColor = Color.White;
            stepForwardButton.Depth = 0;
            stepForwardButton.ForeColor = Color.Lime;
            stepForwardButton.Location = new Point(310, 82);
            stepForwardButton.Margin = new Padding(4);
            stepForwardButton.MouseState = MouseState.HOVER;
            stepForwardButton.Name = "stepForwardButton";
            stepForwardButton.Primary = true;
            stepForwardButton.Size = new Size(92, 37);
            stepForwardButton.TabIndex = 5;
            stepForwardButton.Text = "Step forward";
            stepForwardButton.UseVisualStyleBackColor = false;
            stepForwardButton.Click += button3_Click;
            // 
            // stepBackButton
            // 
            stepBackButton.BackColor = Color.White;
            stepBackButton.Depth = 0;
            stepBackButton.ForeColor = Color.Lime;
            stepBackButton.Location = new Point(410, 82);
            stepBackButton.Margin = new Padding(4);
            stepBackButton.MouseState = MouseState.HOVER;
            stepBackButton.Name = "stepBackButton";
            stepBackButton.Primary = true;
            stepBackButton.Size = new Size(92, 37);
            stepBackButton.TabIndex = 6;
            stepBackButton.Text = "Step back";
            stepBackButton.UseVisualStyleBackColor = false;
            stepBackButton.Click += button4_Click;
            // 
            // savePDFbutton
            // 
            savePDFbutton.BackColor = Color.Lime;
            savePDFbutton.Depth = 0;
            savePDFbutton.ForeColor = Color.Lime;
            savePDFbutton.Location = new Point(329, 127);
            savePDFbutton.Margin = new Padding(4);
            savePDFbutton.MouseState = MouseState.HOVER;
            savePDFbutton.Name = "savePDFbutton";
            savePDFbutton.Primary = true;
            savePDFbutton.Size = new Size(155, 37);
            savePDFbutton.TabIndex = 7;
            savePDFbutton.Text = "Guardar instantánea";
            savePDFbutton.UseVisualStyleBackColor = false;
            savePDFbutton.Click += button5_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Black;
            label2.Font = new Font("Segoe UI", 11.1428576F, FontStyle.Bold);
            label2.ForeColor = Color.Lime;
            label2.Location = new Point(372, 30);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(136, 20);
            label2.TabIndex = 8;
            label2.Text = "Time of day (UTC)";
            // 
            // resumeButton
            // 
            resumeButton.BackColor = Color.White;
            resumeButton.Depth = 0;
            resumeButton.ForeColor = Color.Lime;
            resumeButton.Location = new Point(272, 22);
            resumeButton.Margin = new Padding(4);
            resumeButton.MouseState = MouseState.HOVER;
            resumeButton.Name = "resumeButton";
            resumeButton.Primary = true;
            resumeButton.Size = new Size(92, 37);
            resumeButton.TabIndex = 9;
            resumeButton.Text = "Resume";
            resumeButton.UseVisualStyleBackColor = false;
            resumeButton.Click += button6_Click;
            // 
            // cutoffSelector
            // 
            cutoffSelector.BackColor = Color.Black;
            cutoffSelector.Location = new Point(51, 259);
            cutoffSelector.Margin = new Padding(4);
            cutoffSelector.Maximum = 500;
            cutoffSelector.Name = "cutoffSelector";
            cutoffSelector.Orientation = Orientation.Vertical;
            cutoffSelector.Size = new Size(45, 598);
            cutoffSelector.TabIndex = 10;
            cutoffSelector.TickFrequency = 10;
            cutoffSelector.Value = 500;
            cutoffSelector.Scroll += cutoffSelector_Scroll;
            // 
            // routeView
            // 
            dataGridViewCellStyle1.BackColor = Color.Black;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11.1428576F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Lime;
            routeView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            routeView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            routeView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            routeView.BackgroundColor = Color.Black;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Black;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11.1428576F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.Lime;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            routeView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            routeView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            routeView.Columns.AddRange(new DataGridViewColumn[] { RouteColumn, CallsignColumn });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Black;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11.1428576F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.Lime;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            routeView.DefaultCellStyle = dataGridViewCellStyle3;
            routeView.GridColor = Color.Lime;
            routeView.Location = new Point(147, 569);
            routeView.Margin = new Padding(4);
            routeView.MaximumSize = new Size(500, 1200);
            routeView.MinimumSize = new Size(0, 120);
            routeView.Name = "routeView";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.Black;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 11.1428576F, FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = Color.Lime;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            routeView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            routeView.RowHeadersWidth = 72;
            dataGridViewCellStyle5.BackColor = Color.Black;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 11.1428576F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.Lime;
            routeView.RowsDefaultCellStyle = dataGridViewCellStyle5;
            routeView.RowTemplate.DefaultCellStyle.BackColor = Color.Black;
            routeView.RowTemplate.DefaultCellStyle.ForeColor = Color.Lime;
            routeView.Size = new Size(233, 982);
            routeView.TabIndex = 11;
            routeView.CellClick += routeView_CellClick;
            // 
            // RouteColumn
            // 
            RouteColumn.HeaderText = "Route";
            RouteColumn.MinimumWidth = 9;
            RouteColumn.Name = "RouteColumn";
            RouteColumn.ReadOnly = true;
            RouteColumn.Width = 76;
            // 
            // CallsignColumn
            // 
            CallsignColumn.HeaderText = "Callsign";
            CallsignColumn.MinimumWidth = 9;
            CallsignColumn.Name = "CallsignColumn";
            CallsignColumn.ReadOnly = true;
            CallsignColumn.Width = 88;
            // 
            // callsignTextBox
            // 
            callsignTextBox.BackColor = Color.Lime;
            callsignTextBox.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            callsignTextBox.ForeColor = Color.Black;
            callsignTextBox.Location = new Point(152, 483);
            callsignTextBox.Margin = new Padding(4);
            callsignTextBox.Name = "callsignTextBox";
            callsignTextBox.Size = new Size(148, 23);
            callsignTextBox.TabIndex = 12;
            callsignTextBox.Text = "Type squawk";
            // 
            // addRouteButton
            // 
            addRouteButton.BackColor = Color.White;
            addRouteButton.Depth = 0;
            addRouteButton.ForeColor = Color.Lime;
            addRouteButton.Location = new Point(329, 472);
            addRouteButton.Margin = new Padding(4);
            addRouteButton.MouseState = MouseState.HOVER;
            addRouteButton.Name = "addRouteButton";
            addRouteButton.Primary = true;
            addRouteButton.Size = new Size(130, 40);
            addRouteButton.TabIndex = 13;
            addRouteButton.Text = "Add to routes";
            addRouteButton.UseVisualStyleBackColor = false;
            addRouteButton.Click += addRouteButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Black;
            label3.Font = new Font("Segoe UI", 11.1428576F, FontStyle.Bold);
            label3.ForeColor = Color.Lime;
            label3.Location = new Point(36, 210);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(114, 20);
            label3.TabIndex = 14;
            label3.Text = "Cut-off FL: 500";
            // 
            // overButton
            // 
            overButton.AutoSize = true;
            overButton.Depth = 0;
            overButton.Font = new Font("Roboto", 10F);
            overButton.ForeColor = Color.Lime;
            overButton.Location = new Point(23, 55);
            overButton.Margin = new Padding(0);
            overButton.MouseLocation = new Point(-1, -1);
            overButton.MouseState = MouseState.HOVER;
            overButton.Name = "overButton";
            overButton.Ripple = true;
            overButton.Size = new Size(82, 30);
            overButton.TabIndex = 15;
            overButton.Text = "See over";
            overButton.UseVisualStyleBackColor = true;
            overButton.CheckedChanged += overButton_CheckedChanged;
            // 
            // switchFLmode
            // 
            switchFLmode.BackColor = Color.Black;
            switchFLmode.Controls.Add(underButton);
            switchFLmode.Controls.Add(overButton);
            switchFLmode.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            switchFLmode.ForeColor = Color.Lime;
            switchFLmode.Location = new Point(135, 259);
            switchFLmode.Margin = new Padding(4);
            switchFLmode.Name = "switchFLmode";
            switchFLmode.Padding = new Padding(4);
            switchFLmode.Size = new Size(171, 160);
            switchFLmode.TabIndex = 16;
            switchFLmode.TabStop = false;
            switchFLmode.Text = "Select cut-off behavior";
            // 
            // underButton
            // 
            underButton.AutoSize = true;
            underButton.Checked = true;
            underButton.Depth = 0;
            underButton.Font = new Font("Roboto", 10F);
            underButton.ForeColor = Color.Lime;
            underButton.Location = new Point(23, 117);
            underButton.Margin = new Padding(0);
            underButton.MouseLocation = new Point(-1, -1);
            underButton.MouseState = MouseState.HOVER;
            underButton.Name = "underButton";
            underButton.Ripple = true;
            underButton.Size = new Size(91, 30);
            underButton.TabIndex = 16;
            underButton.TabStop = true;
            underButton.Text = "See under";
            underButton.UseVisualStyleBackColor = true;
            underButton.CheckedChanged += underButton_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Black;
            label4.Font = new Font("Segoe UI", 8.142858F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Lime;
            label4.Location = new Point(209, 537);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(171, 13);
            label4.TabIndex = 17;
            label4.Text = "Clicking on a route will delete it";
            // 
            // Simulador
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1650, 1010);
            Controls.Add(label4);
            Controls.Add(switchFLmode);
            Controls.Add(resumeButton);
            Controls.Add(gMapControl1);
            Controls.Add(cutoffSelector);
            Controls.Add(startButton);
            Controls.Add(addRouteButton);
            Controls.Add(speedChange);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(callsignTextBox);
            Controls.Add(routeView);
            Controls.Add(savePDFbutton);
            Controls.Add(pauseButton);
            Controls.Add(label3);
            Controls.Add(stepForwardButton);
            Controls.Add(stepBackButton);
            Font = new Font("Segoe UI", 11.1428576F, FontStyle.Bold);
            ForeColor = Color.Lime;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "Simulador";
            Text = "Simulador";
            WindowState = FormWindowState.Maximized;
            Load += Form3_Load;
            ((System.ComponentModel.ISupportInitialize)speedChange).EndInit();
            ((System.ComponentModel.ISupportInitialize)cutoffSelector).EndInit();
            ((System.ComponentModel.ISupportInitialize)routeView).EndInit();
            switchFLmode.ResumeLayout(false);
            switchFLmode.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.Timer timer1;
        private NumericUpDown speedChange;
        private TrackBar cutoffSelector;
        private DataGridView routeView;
        private TextBox callsignTextBox;
        private GroupBox switchFLmode;
        private MaterialRaisedButton startButton;
        private Label label1;
        private MaterialRaisedButton pauseButton;
        private MaterialRaisedButton stepForwardButton;
        private MaterialRaisedButton stepBackButton;
        private MaterialRaisedButton savePDFbutton;
        private Label label2;
        private MaterialRaisedButton resumeButton;
        private MaterialRaisedButton addRouteButton;
        private Label label3;
        private MaterialRadioButton overButton;
        private MaterialRadioButton underButton;
        private Label label4;
        private DataGridViewTextBoxColumn RouteColumn;
        private DataGridViewTextBoxColumn CallsignColumn;
    }
}