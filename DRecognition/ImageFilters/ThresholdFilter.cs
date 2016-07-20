using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRecognition.Processors
{
    public class ThresholdFilter : IImageFilter
    {
        public ThresholdFilter(int value)
        {
            ThresholdValue = value;
        }

        public int ThresholdValue { get; set; }

        public Image Apply(Image image)
        {
            return null;
        }
    }
}
