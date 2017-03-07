using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
using OpenCvSharp.Extensions;

namespace FaceProcessing
{
    public partial class MainForm : Form
    {
        CvCapture cvCapture;
        IplImage frame;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cvCapture = new CvCapture(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            capture();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getFace();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            downSample();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cartoon();
        }

        private void capture()
        {
            frame = cvCapture.QueryFrame();
            pictureBox1.Image = frame.ToBitmap();
        }

        private void getFace()
        {
            frame = new FaceDetect().getFaceImage(frame);
            pictureBox1.Image = frame.ToBitmap();
        }

        private void downSample()
        {
            frame = new DownSample().downSample(frame);
            pictureBox1.Image = frame.ToBitmap();
        }

        private void cartoon()
        {
            frame = new Cartoon().cartoon(frame);
            pictureBox1.Image = frame.ToBitmap();
        }
    }
}
