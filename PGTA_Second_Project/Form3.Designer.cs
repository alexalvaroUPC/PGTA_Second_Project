namespace PGTA_Second_Project
{
    partial class Form3
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
            gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            timer1 = new System.Windows.Forms.Timer(components);
            startButton = new Button();
            speedChange = new NumericUpDown();
            label1 = new Label();
            pauseButton = new Button();
            stepForwardButton = new Button();
            stepBackButton = new Button();
            savePDFbutton = new Button();
            label2 = new Label();
            resumeButton = new Button();
            cutoffSelector = new TrackBar();
            routeView = new DataGridView();
            RouteColumn = new DataGridViewTextBoxColumn();
            SquawkColumn = new DataGridViewTextBoxColumn();
            squawkTextBox = new TextBox();
            addRouteButton = new Button();
            label3 = new Label();
            overButton = new RadioButton();
            switchFLmode = new GroupBox();
            underButton = new RadioButton();
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
            gMapControl1.GrayScaleMode = false;
            gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            gMapControl1.LevelsKeepInMemory = 5;
            gMapControl1.Location = new Point(105, 288);
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
            gMapControl1.Size = new Size(2041, 1106);
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
            startButton.Location = new Point(71, 42);
            startButton.Name = "startButton";
            startButton.Size = new Size(155, 58);
            startButton.TabIndex = 1;
            startButton.Text = "(Re)Start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += button1_Click;
            // 
            // speedChange
            // 
            speedChange.Location = new Point(587, 54);
            speedChange.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            speedChange.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            speedChange.Name = "speedChange";
            speedChange.Size = new Size(77, 35);
            speedChange.TabIndex = 2;
            speedChange.Value = new decimal(new int[] { 1, 0, 0, 0 });
            speedChange.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(670, 56);
            label1.Name = "label1";
            label1.Size = new Size(172, 30);
            label1.TabIndex = 3;
            label1.Text = "Simulation speed";
            // 
            // pauseButton
            // 
            pauseButton.Location = new Point(246, 42);
            pauseButton.Name = "pauseButton";
            pauseButton.Size = new Size(160, 58);
            pauseButton.TabIndex = 4;
            pauseButton.Text = "Pause";
            pauseButton.UseVisualStyleBackColor = true;
            pauseButton.Click += button2_Click;
            // 
            // stepForwardButton
            // 
            stepForwardButton.Location = new Point(246, 123);
            stepForwardButton.Name = "stepForwardButton";
            stepForwardButton.Size = new Size(160, 51);
            stepForwardButton.TabIndex = 5;
            stepForwardButton.Text = "Step forward";
            stepForwardButton.UseVisualStyleBackColor = true;
            stepForwardButton.Click += button3_Click;
            // 
            // stepBackButton
            // 
            stepBackButton.Location = new Point(412, 123);
            stepBackButton.Name = "stepBackButton";
            stepBackButton.Size = new Size(141, 51);
            stepBackButton.TabIndex = 6;
            stepBackButton.Text = "Step back";
            stepBackButton.UseVisualStyleBackColor = true;
            stepBackButton.Click += button4_Click;
            // 
            // savePDFbutton
            // 
            savePDFbutton.Location = new Point(332, 209);
            savePDFbutton.Name = "savePDFbutton";
            savePDFbutton.Size = new Size(221, 45);
            savePDFbutton.TabIndex = 7;
            savePDFbutton.Text = "Guardar instantánea";
            savePDFbutton.UseVisualStyleBackColor = true;
            savePDFbutton.Click += button5_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(71, 133);
            label2.Name = "label2";
            label2.Size = new Size(177, 30);
            label2.TabIndex = 8;
            label2.Text = "Time of day (UTC)";
            // 
            // resumeButton
            // 
            resumeButton.Location = new Point(412, 42);
            resumeButton.Name = "resumeButton";
            resumeButton.Size = new Size(141, 58);
            resumeButton.TabIndex = 9;
            resumeButton.Text = "Resume";
            resumeButton.UseVisualStyleBackColor = true;
            resumeButton.Click += button6_Click;
            // 
            // cutoffSelector
            // 
            cutoffSelector.Location = new Point(2270, 350);
            cutoffSelector.Maximum = 400;
            cutoffSelector.Name = "cutoffSelector";
            cutoffSelector.Orientation = Orientation.Vertical;
            cutoffSelector.Size = new Size(80, 662);
            cutoffSelector.TabIndex = 10;
            cutoffSelector.TickFrequency = 10;
            cutoffSelector.Value = 400;
            cutoffSelector.Scroll += cutoffSelector_Scroll;
            // 
            // routeView
            // 
            routeView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            routeView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            routeView.Columns.AddRange(new DataGridViewColumn[] { RouteColumn, SquawkColumn });
            routeView.Location = new Point(2627, 580);
            routeView.MaximumSize = new Size(450, 1000);
            routeView.MinimumSize = new Size(450, 100);
            routeView.Name = "routeView";
            routeView.RowHeadersWidth = 72;
            routeView.Size = new Size(450, 661);
            routeView.TabIndex = 11;
            routeView.CellClick += routeView_CellClick;
            // 
            // RouteColumn
            // 
            RouteColumn.HeaderText = "Route";
            RouteColumn.MinimumWidth = 9;
            RouteColumn.Name = "RouteColumn";
            RouteColumn.ReadOnly = true;
            RouteColumn.Width = 175;
            // 
            // SquawkColumn
            // 
            SquawkColumn.HeaderText = "Squawk";
            SquawkColumn.MinimumWidth = 9;
            SquawkColumn.Name = "SquawkColumn";
            SquawkColumn.ReadOnly = true;
            SquawkColumn.Width = 175;
            // 
            // squawkTextBox
            // 
            squawkTextBox.Location = new Point(2627, 470);
            squawkTextBox.Name = "squawkTextBox";
            squawkTextBox.Size = new Size(261, 35);
            squawkTextBox.TabIndex = 12;
            squawkTextBox.Text = "Type squawk";
            // 
            // addRouteButton
            // 
            addRouteButton.Location = new Point(2910, 469);
            addRouteButton.Name = "addRouteButton";
            addRouteButton.Size = new Size(163, 39);
            addRouteButton.TabIndex = 13;
            addRouteButton.Text = "Add to routes";
            addRouteButton.UseVisualStyleBackColor = true;
            addRouteButton.Click += addRouteButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(2245, 1075);
            label3.Name = "label3";
            label3.Size = new Size(105, 30);
            label3.TabIndex = 14;
            label3.Text = "Cut-off FL";
            // 
            // overButton
            // 
            overButton.AutoSize = true;
            overButton.Location = new Point(39, 48);
            overButton.Name = "overButton";
            overButton.Size = new Size(117, 34);
            overButton.TabIndex = 15;
            overButton.Text = "See over";
            overButton.UseVisualStyleBackColor = true;
            overButton.CheckedChanged += overButton_CheckedChanged;
            // 
            // switchFLmode
            // 
            switchFLmode.Controls.Add(underButton);
            switchFLmode.Controls.Add(overButton);
            switchFLmode.Location = new Point(2245, 1144);
            switchFLmode.Name = "switchFLmode";
            switchFLmode.Size = new Size(350, 175);
            switchFLmode.TabIndex = 16;
            switchFLmode.TabStop = false;
            switchFLmode.Text = "Select cut-off behavior";
            // 
            // underButton
            // 
            underButton.AutoSize = true;
            underButton.Checked = true;
            underButton.Location = new Point(39, 100);
            underButton.Name = "underButton";
            underButton.Size = new Size(131, 34);
            underButton.TabIndex = 16;
            underButton.TabStop = true;
            underButton.Text = "See under";
            underButton.UseVisualStyleBackColor = true;
            underButton.CheckedChanged += underButton_CheckedChanged;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(3217, 1528);
            Controls.Add(switchFLmode);
            Controls.Add(label3);
            Controls.Add(addRouteButton);
            Controls.Add(squawkTextBox);
            Controls.Add(routeView);
            Controls.Add(cutoffSelector);
            Controls.Add(resumeButton);
            Controls.Add(label2);
            Controls.Add(savePDFbutton);
            Controls.Add(stepBackButton);
            Controls.Add(stepForwardButton);
            Controls.Add(pauseButton);
            Controls.Add(label1);
            Controls.Add(speedChange);
            Controls.Add(startButton);
            Controls.Add(gMapControl1);
            Name = "Form3";
            Text = "Form3";
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
        private Button startButton;
        private NumericUpDown speedChange;
        private Label label1;
        private Button pauseButton;
        private Button stepForwardButton;
        private Button stepBackButton;
        private Button savePDFbutton;
        private Label label2;
        private Button resumeButton;
        private TrackBar cutoffSelector;
        private DataGridView routeView;
        private DataGridViewTextBoxColumn RouteColumn;
        private DataGridViewTextBoxColumn SquawkColumn;
        private TextBox squawkTextBox;
        private Button addRouteButton;
        private Label label3;
        private RadioButton overButton;
        private GroupBox switchFLmode;
        private RadioButton underButton;
    }
}