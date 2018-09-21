using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace MyoVisualizedApp
{
    public partial class Form1 : Form
    {
        List<Sample> runData = new List<Sample>();
        const float upperThreshold = 120;
        const float lowerThreshold = 120;
        bool aboveUpperThresholdValue = false;
        string SelectedAxis = "gyro"; // gyro as default

        int stepCounter = 0;

        public char SplitChar = ',';
        public float roll, pitch, yaw, gyro_x, gyro_y, gyro_z, accel_x, accel_y, accel_z;
        int simTimer = 0;

        public Form1()
        {
            InitializeComponent();
            //type setting buttons
            rbtnGyro.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            rbtnAccel.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            rbtnRotation.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                RadioButton radioButton = (RadioButton)sender;
                //Gyro
                if (rbtnGyro.Checked)
                {
                    SelectedAxis = "gyro";
                }
                else if (rbtnAccel.Checked)
                {
                    SelectedAxis = "accel";
                }
                else if (rbtnRotation.Checked)
                {
                    SelectedAxis = "rotation";
                }
            }
        }

        private void startTime_Tick(object sender, EventArgs e)
        {
            if(simTimer < runData.Last().time)
            {
                simTimer += 10;
                label1.Text = simTimer + "";
                dataTrackBar.Value = simTimer;
                foreach(Sample a in runData)
                {
                    if(a.time < simTimer + 10 && a.time > simTimer)
                    {
                        if(SelectedAxis == "gyro")
                        {
                            dataGraph.Series["Series1"].Points.AddXY(a.time, a.gyro_x);
                            dataGraph.Series["Series2"].Points.AddXY(a.time, a.gyro_y);
                            dataGraph.Series["Series3"].Points.AddXY(a.time, a.gyro_z);
                        }
                        else if(SelectedAxis == "accel")
                        {
                            dataGraph.Series["Series1"].Points.AddXY(a.time, a.accel_x);
                            dataGraph.Series["Series2"].Points.AddXY(a.time, a.accel_y);
                            dataGraph.Series["Series3"].Points.AddXY(a.time, a.accel_z);
                        }
                        else if(SelectedAxis == "rotation")
                        {
                            dataGraph.Series["Series1"].Points.AddXY(a.time, a.roll);
                            dataGraph.Series["Series2"].Points.AddXY(a.time, a.pitch);
                            dataGraph.Series["Series3"].Points.AddXY(a.time, a.yaw);
                        }

                        if (a.gyro_z > upperThreshold && !aboveUpperThresholdValue)
                        {
                            aboveUpperThresholdValue = true;
                            stepCounter++;
                        }
                        else if (a.gyro_z < upperThreshold && aboveUpperThresholdValue)
                        {
                            aboveUpperThresholdValue = false;
                            stepCounter++;
                        }
                    }
                }
                label2.Text = stepCounter + "";
            }
        }

        public Int32 time;

        private void btnStartSimulation_Click(object sender, EventArgs e)
        {
            startTime.Start();
            dataTrackBar.Minimum = 0;
            dataTrackBar.Maximum = runData.Last().time + 10;
        } 

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            string sFileName = "";
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    sFileName = openFileDialog.FileName;
                }
                /*
                dataGraph.Series.Add("Gyroscope");
                dataGraph.Series["Gyroscope"].ChartType = SeriesChartType.Line;
                dataGraph.Series.Add("Acceleration");
                dataGraph.Series["Acceleration"].ChartType = SeriesChartType.Line;
                dataGraph.Series.Add("Rotation");
                dataGraph.Series["Rotation"].ChartType = SeriesChartType.Line;
                */
                StreamReader reader = new StreamReader(sFileName);
                while (reader.Peek() > -1)
                {
                    string DataLine = reader.ReadLine();
                    if (DataLine == File.ReadAllLines(sFileName).Last())
                    {
                        //break;
                    }
                    else
                    {
                        string[] singleLine = DataLine.Split(SplitChar);
                        float.TryParse(singleLine[0], out roll);
                        float.TryParse(singleLine[1], out pitch);
                        float.TryParse(singleLine[2], out yaw);
                        float.TryParse(singleLine[3], out gyro_x);
                        float.TryParse(singleLine[4], out gyro_y);
                        float.TryParse(singleLine[5], out gyro_z);
                        float.TryParse(singleLine[6], out accel_x);
                        float.TryParse(singleLine[7], out accel_y);
                        float.TryParse(singleLine[8], out accel_z);
                        Int32.TryParse(singleLine[9], out time);

                        Sample sampleData = new Sample(roll, pitch, yaw, gyro_x, gyro_y, gyro_z, accel_x, accel_y, accel_z, time);
                        runData.Add(sampleData);
                    }
                }
                //set ChartAreas
                dataGraph.Series["Gyro"].ChartArea = "GyroArea";
                dataGraph.Series["Accel"].ChartArea = "AccelArea";
                dataGraph.Series["Rotation"].ChartArea = "RotationArea";
                //Set axis min/max for all 3 graphs
                //Gyro
                dataGraph.ChartAreas["GyroArea"].AxisY.Minimum = -300;
                dataGraph.ChartAreas["GyroArea"].AxisY.Maximum = 300;
                //Accel
                dataGraph.ChartAreas["AccelArea"].AxisY.Minimum = -300;
                dataGraph.ChartAreas["AccelArea"].AxisY.Maximum = 300;
                //Rotation
                dataGraph.ChartAreas["RotationArea"].AxisY.Minimum = -2;
                dataGraph.ChartAreas["RotationArea"].AxisY.Maximum = 2;
                //base X line based on maximum time
                dataGraph.ChartAreas[0].AxisX.Minimum = 0;
                dataGraph.ChartAreas[0].AxisX.Maximum = runData.Last().time;
            }
            catch (Exception)
            {

            }
        }
    }
}
