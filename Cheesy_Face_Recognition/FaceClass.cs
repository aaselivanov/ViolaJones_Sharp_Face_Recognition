using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Emgu.CV.Structure;
using Emgu.CV.Features2D;
using Emgu.CV.UI;
using Emgu.CV;

namespace Cheesy_Face_Recognition
{   
    [Serializable]
    internal class FaceClass
    {
        //изображение лица в grayscale
        private Image<Gray, Byte> _img;
        //Local Binary Patterns - гистограмма
        private Mat[] _histogram;
        //имя класса лица
        private String _name;

        public FaceClass(Image<Gray, Byte> faceimg, Mat[] facehist, String facename)
        {
            _img = faceimg;
            _histogram = facehist;
            _name = facename;
        }

        public Mat[] GetHist()
        {
            return _histogram;
        }
        public String GetName()
        {
            return _name;
        }
        public Image<Gray, Byte> GetImg()
        {
            return _img;
        }
    }
}