using DRecognition.Processors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DRecognition.Tests
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Recognizing()
        {
            var processors = new List<IImgProcessor>();
            var image = (Image)picSource.Image.Clone();

            if (!string.IsNullOrWhiteSpace(txtThreshold.Text))
            {
                int threshold;
                if (int.TryParse(txtThreshold.Text.Trim(), out threshold))
                {
                    var processor = new ThresholdProcessor(threshold);
                    image = processor.Process(image);
                    processors.Add(processor);
                }
            }

            var service = new RecognitionService();
            service.Processors.AddRange(processors);
            var text = service.GetText(image);
            txtRecognizing.Text = text;
            picTarge.Image = image;
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            var openFile = new OpenFileDialog();
            var result = openFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    picSource.Load(openFile.FileName);
                    Recognizing();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtThreshold_TextChanged(object sender, EventArgs e)
        {
            Recognizing();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            picSource.Dispose();
            picTarge.Dispose();
        }
    }
}
