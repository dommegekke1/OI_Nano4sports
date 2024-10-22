﻿namespace MyoVisualizedApp
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dataLoadBtn = new System.Windows.Forms.Button();
            this.startTime = new System.Windows.Forms.Timer(this.components);
            this.btnStartSimulation = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rbtnGyro = new System.Windows.Forms.RadioButton();
            this.rbtnAccel = new System.Windows.Forms.RadioButton();
            this.rbtnRotation = new System.Windows.Forms.RadioButton();
            this.gbGyro = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnLive = new System.Windows.Forms.Button();
            this.btnStopOnClick = new System.Windows.Forms.Button();
            this.btnClearOnClick = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStartOnClick = new System.Windows.Forms.Button();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.dataGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gbGyro.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLoadBtn
            // 
            this.dataLoadBtn.Location = new System.Drawing.Point(3, 342);
            this.dataLoadBtn.Name = "dataLoadBtn";
            this.dataLoadBtn.Size = new System.Drawing.Size(75, 23);
            this.dataLoadBtn.TabIndex = 1;
            this.dataLoadBtn.Text = "Load";
            this.dataLoadBtn.UseVisualStyleBackColor = true;
            this.dataLoadBtn.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // startTime
            // 
            this.startTime.Interval = 1;
            this.startTime.Tick += new System.EventHandler(this.startTime_Tick);
            // 
            // btnStartSimulation
            // 
            this.btnStartSimulation.Location = new System.Drawing.Point(112, 342);
            this.btnStartSimulation.Name = "btnStartSimulation";
            this.btnStartSimulation.Size = new System.Drawing.Size(75, 23);
            this.btnStartSimulation.TabIndex = 3;
            this.btnStartSimulation.Text = "Start";
            this.btnStartSimulation.UseVisualStyleBackColor = true;
            this.btnStartSimulation.Click += new System.EventHandler(this.btnStartSimulation_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(303, 339);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(494, 339);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
            // 
            // rbtnGyro
            // 
            this.rbtnGyro.AutoSize = true;
            this.rbtnGyro.Checked = true;
            this.rbtnGyro.Location = new System.Drawing.Point(6, 19);
            this.rbtnGyro.Name = "rbtnGyro";
            this.rbtnGyro.Size = new System.Drawing.Size(76, 17);
            this.rbtnGyro.TabIndex = 9;
            this.rbtnGyro.TabStop = true;
            this.rbtnGyro.Text = "Gyroscope";
            this.rbtnGyro.UseVisualStyleBackColor = true;
            // 
            // rbtnAccel
            // 
            this.rbtnAccel.AutoSize = true;
            this.rbtnAccel.Location = new System.Drawing.Point(6, 42);
            this.rbtnAccel.Name = "rbtnAccel";
            this.rbtnAccel.Size = new System.Drawing.Size(84, 17);
            this.rbtnAccel.TabIndex = 10;
            this.rbtnAccel.Text = "Acceleration";
            this.rbtnAccel.UseVisualStyleBackColor = true;
            // 
            // rbtnRotation
            // 
            this.rbtnRotation.AutoSize = true;
            this.rbtnRotation.Location = new System.Drawing.Point(6, 65);
            this.rbtnRotation.Name = "rbtnRotation";
            this.rbtnRotation.Size = new System.Drawing.Size(65, 17);
            this.rbtnRotation.TabIndex = 11;
            this.rbtnRotation.Text = "Rotation";
            this.rbtnRotation.UseVisualStyleBackColor = true;
            // 
            // gbGyro
            // 
            this.gbGyro.Controls.Add(this.rbtnGyro);
            this.gbGyro.Controls.Add(this.rbtnRotation);
            this.gbGyro.Controls.Add(this.rbtnAccel);
            this.gbGyro.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbGyro.Location = new System.Drawing.Point(3, 3);
            this.gbGyro.Name = "gbGyro";
            this.gbGyro.Size = new System.Drawing.Size(103, 88);
            this.gbGyro.TabIndex = 12;
            this.gbGyro.TabStop = false;
            this.gbGyro.Text = "Axis";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tableLayoutPanel1.Controls.Add(this.dataGraph, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.gbGyro, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataLoadBtn, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnStartSimulation, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.comboBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnLive, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnStopOnClick, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnClearOnClick, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnStartOnClick, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.005F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.99251F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0025F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(685, 370);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 143);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(103, 21);
            this.comboBox1.TabIndex = 14;
            // 
            // btnLive
            // 
            this.btnLive.Location = new System.Drawing.Point(3, 173);
            this.btnLive.Name = "btnLive";
            this.btnLive.Size = new System.Drawing.Size(75, 23);
            this.btnLive.TabIndex = 13;
            this.btnLive.Text = "Live";
            this.btnLive.UseVisualStyleBackColor = true;
            this.btnLive.Click += new System.EventHandler(this.btnLive_Click);
            // 
            // btnStopOnClick
            // 
            this.btnStopOnClick.Location = new System.Drawing.Point(303, 312);
            this.btnStopOnClick.Name = "btnStopOnClick";
            this.btnStopOnClick.Size = new System.Drawing.Size(75, 23);
            this.btnStopOnClick.TabIndex = 18;
            this.btnStopOnClick.Text = "Stop";
            this.btnStopOnClick.UseVisualStyleBackColor = true;
            // 
            // btnClearOnClick
            // 
            this.btnClearOnClick.Location = new System.Drawing.Point(494, 312);
            this.btnClearOnClick.Name = "btnClearOnClick";
            this.btnClearOnClick.Size = new System.Drawing.Size(75, 23);
            this.btnClearOnClick.TabIndex = 19;
            this.btnClearOnClick.Text = "Clear";
            this.btnClearOnClick.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "label3";
            // 
            // btnStartOnClick
            // 
            this.btnStartOnClick.Location = new System.Drawing.Point(112, 312);
            this.btnStartOnClick.Name = "btnStartOnClick";
            this.btnStartOnClick.Size = new System.Drawing.Size(75, 23);
            this.btnStartOnClick.TabIndex = 17;
            this.btnStartOnClick.Text = "Start Live";
            this.btnStartOnClick.UseVisualStyleBackColor = true;
            // 
            // dataGraph
            // 
            chartArea1.Name = "ChartArea1";
            chartArea2.Name = "ChartArea2";
            chartArea3.Name = "ChartArea3";
            this.dataGraph.ChartAreas.Add(chartArea1);
            this.dataGraph.ChartAreas.Add(chartArea2);
            this.dataGraph.ChartAreas.Add(chartArea3);
            this.tableLayoutPanel1.SetColumnSpan(this.dataGraph, 3);
            this.dataGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.dataGraph.Legends.Add(legend1);
            this.dataGraph.Location = new System.Drawing.Point(112, 3);
            this.dataGraph.Name = "dataGraph";
            this.tableLayoutPanel1.SetRowSpan(this.dataGraph, 4);
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea2";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea3";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Series3";
            this.dataGraph.Series.Add(series1);
            this.dataGraph.Series.Add(series2);
            this.dataGraph.Series.Add(series3);
            this.dataGraph.Size = new System.Drawing.Size(570, 303);
            this.dataGraph.TabIndex = 20;
            this.dataGraph.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 370);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gbGyro.ResumeLayout(false);
            this.gbGyro.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGraph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button dataLoadBtn;
        private System.Windows.Forms.Timer startTime;
        private System.Windows.Forms.Button btnStartSimulation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbtnGyro;
        private System.Windows.Forms.RadioButton rbtnAccel;
        private System.Windows.Forms.RadioButton rbtnRotation;
        private System.Windows.Forms.GroupBox gbGyro;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnLive;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStopOnClick;
        private System.Windows.Forms.Button btnClearOnClick;
        private System.Windows.Forms.Button btnStartOnClick;
        private System.Windows.Forms.DataVisualization.Charting.Chart dataGraph;
    }
}

