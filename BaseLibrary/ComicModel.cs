using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BaseLibrary
{
    public class ComicModel
    {
        public int Num { get; set; }
        public string Img { get; set; }

        public static implicit operator ComicModel(Stream v)
        {
            throw new NotImplementedException();
        }
    }
}
