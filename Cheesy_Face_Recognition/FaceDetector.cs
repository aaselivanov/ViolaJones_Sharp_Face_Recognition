using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Emgu.CV.Structure;
using Emgu.CV.Features2D;
using Emgu.CV.UI;
using Emgu.CV;
using System.Drawing;

namespace Cheesy_Face_Recognition
{
    internal class FaceDetector
    {
        //каскадный классификатор
        private CascadeClassifier _haar;

        //конструктор класса
        public FaceDetector()
        {
            //загрузка каскадов хаара для распознавания лиц
            _haar = new CascadeClassifier("haarcascade_frontalface_default.xml");
        }
        //возвращает список прямоугольных областей кадра с лицами
        public Rectangle[] GetFacesRect(Image<Bgr, Byte> frame, double scaleFactor,
        int minNeighbors, int sz)
        {
            try
            {
                Rectangle[] rect = _haar.DetectMultiScale(frame.Convert<Gray, Byte>(), scaleFactor, minNeighbors, new Size(sz, sz));
                //Rectangle[] rect1 = new Rectangle[rect.Length];
                return rect;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw;
                //return null;
            }
        }
    }
}
