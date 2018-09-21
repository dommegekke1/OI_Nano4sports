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

        int stepCounter = 0;

        public char SplitChar = ',';
        public float roll, pitch, yaw, gyro_x, gyro_y, gyro_z, accel_x, accel_y, accel_z;
        int simTimer = 0;

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
                        dataGraph.Series["Roll"].Points.AddXY(a.time, a.gyro_z);

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
            //label1.Text = startTime.Tick();
        }

        public Int32 time;

        private void btnStartSimulation_Click(object sender, EventArgs e)
        {
            startTime.Start();
            dataTrackBar.Minimum = 0;
            dataTrackBar.Maximum = runData.Last().time+10;
            /*
            foreach (Sample a in runData)
            {

                if(a.time.ToString() == startTime.ToString())
                {
                    MessageBox.Show("Test");
                }
            }
            */
        }

        public Form1()
        {
            InitializeComponent();
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

                dataGraph.Series.Add("Roll");
                dataGraph.Series["Roll"].ChartType = SeriesChartType.Line;
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
                dataGraph.Series["Roll"].ChartArea = "ChartArea1";
                dataGraph.ChartAreas[0].AxisY.Minimum = -300;
                dataGraph.ChartAreas[0].AxisY.Maximum = 300;
                dataGraph.ChartAreas[0].AxisX.Minimum = 0;
                dataGraph.ChartAreas[0].AxisX.Maximum = runData.Last().time+10;
            }
            catch (Exception)
            {

            }
        }
    }
}
