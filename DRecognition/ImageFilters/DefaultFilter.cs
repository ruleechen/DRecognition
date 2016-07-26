using System;
using System.Drawing;

namespace DRecognition.ImageFilters
{
    public class DefaultFilter : IImageFilter
    {
        public Bitmap Apply(Bitmap bitmap)
        {
            return bitmap;
        }

        public string GetCode()
        {
            return $"new {GetType().Name}()";
        }
    }
}
