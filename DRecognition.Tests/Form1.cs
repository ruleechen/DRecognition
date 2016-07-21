using DRecognition.ImageFilters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
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
            if (picSource.Image == null)
            {
                return;
            }

            try
            {
                var code = new StringBuilder();
                code.AppendLine("var filters = new List<IImageFilter>();");

                var filters = new List<IImageFilter>();
                var bitmap = new Bitmap((Image)picSource.Image.Clone());

                if (!string.IsNullOrWhiteSpace(txtThreshold.Text))
                {
                    int threshold;
                    if (int.TryParse(txtThreshold.Text.Trim(), out threshold))
                    {
                        var filter = new ThresholdFilter(threshold);
                        bitmap = filter.Apply(bitmap);
                        filters.Add(filter);

                        code.AppendLine("filters.Add(new ThresholdFilter(" + threshold + "));");
                    }
                }

                if (chkGray.Checked)
                {
                    var filter = new GrayscaleFilter();
                    bitmap = filter.Apply(bitmap);
                    filters.Add(filter);

                    code.AppendLine("filters.Add(new GrayscaleFilter());");
                }

                if (!string.IsNullOrWhiteSpace(txtGrayValue.Text))
                {
                    int maxNearPoints = 1;
                    int.TryParse(txtMaxNearPoints.Text, out maxNearPoints);

                    int grayValue;
                    if (int.TryParse(txtGrayValue.Text.Trim(), out grayValue))
                    {
                        maxNearPoints = Math.Max(maxNearPoints, 1);
                        var filter = new NoiseFilter(grayValue, maxNearPoints);
                        bitmap = filter.Apply(bitmap);
                        filters.Add(filter);

                        code.AppendLine("filters.Add(NoiseFilter(" + grayValue + ", " + maxNearPoints + "));");
                    }
                }

                picTarge.Image = bitmap;
                txtCode.Text = code.ToString();

                if (readText)
                {
                    var service = new RecognitionService();
                    //service.ImageFilters.AddRange(filters);
                    var text = service.GetText(bitmap);
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            picSource.Dispose();
            picTarge.Dispose();
        }

        private void txtThreshold_TextChanged(object sender, EventArgs e)
        {
            Recognizing();
        }

        private void txtGrayValue_TextChanged(object sender, EventArgs e)
        {
            Recognizing();
        }

        private void txtMaxNearPoints_TextChanged(object sender, EventArgs e)
        {
            Recognizing();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Recognizing();
        }
    }
}
