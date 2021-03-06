﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OCR.TesseractWrapper;

namespace CloudOcr
{
    class TesseractWrapper
    {
        private readonly string dictionaryData = Directory.GetCurrentDirectory() + @"\tessdata\eng.traineddata";
        public TesseractWrapper() { }

        public string doOcr(Image img, string language)
        {
            using (TesseractProcessor processor = new TesseractProcessor())
            {
                if (processor.Init(dictionaryData, language, (int)eOcrEngineMode.OEM_DEFAULT))
                {
                    string text = processor.Recognize(img);
                    return text;
                }
            }
            return null;
        }
    }
}
