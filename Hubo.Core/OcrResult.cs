using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubo
{
    public class OcrResult
    {
        public List<Line> Regions { get; set; }
    }

    public class Line
    {
        public List<Word> Lines { get; set; }
    }

    public class Word
    {
        public string Text { get; set; }
    }
}
