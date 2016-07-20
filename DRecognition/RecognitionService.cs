﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web;
using Tesseract;

namespace DRecognition
{
    public class RecognitionService
    {
        private TesseractEngine tesseract;

        public RecognitionService()
        {
            var language = "eng";
            var dataPath = AppDomain.CurrentDomain.BaseDirectory;

            if (HttpContext.Current == null)
            {
                dataPath = Path.Combine(dataPath, "..\\..\\tessdata");
            }
            else
            {
                dataPath = Path.Combine(dataPath, "App_Data", "tessdata");
            }

            tesseract = new TesseractEngine(dataPath, language, EngineMode.Default);
            tesseract.SetVariable("tessedit_pageseg_mode", PageSegMode.Auto.ToString());
            tesseract.SetVariable("tessedit_char_whitelist", "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQLSTUVWXYZ");

            Processors = new List<IImgProcessor>();
        }

        public List<IImgProcessor> Processors { get; set; }

        public string GetText(Image image)
        {
            if (Processors != null)
            {
                foreach (var item in Processors)
                {
                    image = item.Process(image);
                }
            }

            using (var bitmap = new Bitmap(image))
            {
                using (var page = tesseract.Process(bitmap))
                {
                    return page.GetText();
                }
            }
        }
    }
}
