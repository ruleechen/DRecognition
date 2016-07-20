using DRecognition.Processors;
using System;
using System.Drawing;

namespace DRecognition.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Users\rulee.chen\Desktop\DRecognition\DRecognition.Tests\images\6.jpg";
            var image = Image.FromFile(path);

            var service = new RecognitionService();
            service.Processor = new SzskProcessor();
            var text = service.GetText(image);
            Console.WriteLine(text);
        }
    }
}
