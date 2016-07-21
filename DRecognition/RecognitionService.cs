using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web;
using Tesseract;

namespace DRecognition
{
    public class RecognitionService
    {
        public RecognitionService()
        {
            Language = "eng";
            CharWhitelist = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQLSTUVWXYZ";
            ImageFilters = new List<IImageFilter>();
        }

        public string Language { get; set; }

        public string CharWhitelist { get; set; }

        public List<IImageFilter> ImageFilters { get; set; }

        private TesseractEngine CreateTesseract()
        {
            var dataPath = AppDomain.CurrentDomain.BaseDirectory;

            if (HttpContext.Current == null)
            {
                dataPath = Path.Combine(dataPath, "..\\..\\tessdata");
            }
            else
            {
                dataPath = Path.Combine(dataPath, "App_Data", "tessdata");
            }

            var tesseract = new TesseractEngine(dataPath, Language, EngineMode.Default);
            tesseract.SetVariable("tessedit_pageseg_mode", PageSegMode.Auto.ToString());
            tesseract.SetVariable("tessedit_char_whitelist", CharWhitelist);

            return tesseract;
        }

        public string GetText(Bitmap bitmap)
        {
            if (ImageFilters != null)
            {
                foreach (var item in ImageFilters)
                {
                    bitmap = item.Apply(bitmap);
                }
            }

            using (var tesseract = CreateTesseract())
            {
                using (var page = tesseract.Process(bitmap))
                {
                    return page.GetText();
                }
            }
        }
    }
}
