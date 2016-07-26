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
                var filters = new List<IImageFilter>();

                if (!string.IsNullOrWhiteSpace(txtThreshold.Text))
                {
                    int threshold;
                    if (int.TryParse(txtThreshold.Text.Trim(), out threshold))
                    {
                        filters.Add(new ThresholdFilter(threshold));
                    }
                }

                if (chkGray.Checked)
                {
                    filters.Add(new GrayscaleFilter());
                }

                if (chkNegative.Checked)
                {
                    filters.Add(new NegativeFilter());
                }

                if (!string.IsNullOrWhiteSpace(txtGrayValue.Text))
                {
                    int maxNearPoints = 1;
                    int.TryParse(txtMaxNearPoints.Text, out maxNearPoints);

                    int grayValue;
                    if (int.TryParse(txtGrayValue.Text.Trim(), out grayValue))
                    {
                        maxNearPoints = Math.Max(maxNearPoints, 1);
                        filters.Add(new NoiseFilter(grayValue, maxNearPoints));
                    }
                }

                if (!string.IsNullOrWhiteSpace(txtRotateAngle.Text))
                {
                    int angle;
                    if (int.TryParse(txtRotateAngle.Text.Trim(), out angle))
                    {
                        filters.Add(new RotateFilter(angle));
                    }
                }

                if (!string.IsNullOrWhiteSpace(txtMedian.Text))
                {
                    var size = 0;
                    int.TryParse(txtMedian.Text.Trim(), out size);
                    if (size >= 2)
                    {
                        filters.Add(new MedianFilter(size));
                    }
                }

                var service = new RecognitionService();
                service.AddFilters(filters);

                var bitmap = new Bitmap((Image)picSource.Image.Clone());
                picTarge.Image = service.ApplyFilters(bitmap);
                txtCode.Text = new CodeBuilder().AddFilters(filters).GetCode();

                if (readText)
                {
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

        private void txtRotateAngle_TextChanged(object sender, EventArgs e)
        {
            Recognizing();
        }

        private void txtMedian_TextChanged(object sender, EventArgs e)
        {
            Recognizing();
        }

        private void chkNegative_CheckedChanged(object sender, EventArgs e)
        {
            Recognizing();
        }
    }

    public class CodeBuilder
    {
        public CodeBuilder()
        {
            Filters = new List<IImageFilter>();
        }

        public List<IImageFilter> Filters { get; private set; }

        public CodeBuilder AddFilter(IImageFilter filter)
        {
            Filters.Add(filter);
            return this;
        }

        public CodeBuilder AddFilters(IEnumerable<IImageFilter> filters)
        {
            Filters.AddRange(filters);
            return this;
        }

        public string GetCode()
        {
            var code = new StringBuilder();

            code.AppendLine("var filters = new List<IImageFilter>();");

            foreach (var item in Filters)
            {
                code.AppendLine("filters.Add(" + item.GetCode() + ");");
            }

            return code.ToString();
        }
    }
}
