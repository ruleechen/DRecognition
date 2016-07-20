using DRecognition.ImageFilters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DRecognition.Tests
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Recognizing(bool readText = true)
        {
            try
            {
                var filters = new List<IImageFilter>();
                var image = (Image)picSource.Image.Clone();

                if (!string.IsNullOrWhiteSpace(txtThreshold.Text))
                {
                    int threshold;
                    if (int.TryParse(txtThreshold.Text.Trim(), out threshold))
                    {
                        var filter = new ThresholdFilter(threshold);
                        image = filter.Apply(image);
                        filters.Add(filter);
                    }
                }

                picTarge.Image = image;

                if (readText)
                {
                    var service = new RecognitionService();
                    service.ImageFilters.AddRange(filters);
                    var text = service.GetText(image);
                    txtRecognizing.Text = text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
