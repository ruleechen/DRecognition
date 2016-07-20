using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRecognition.Processors
{
    public class ThresholdProcessor : IImgProcessor
    {
        public ThresholdProcessor(int value)
        {
            Threshold = value;
        }

        public int Threshold { get; set; }

        public Image Process(Image image)
        {
            throw new NotImplementedException();
        }
    }
}
