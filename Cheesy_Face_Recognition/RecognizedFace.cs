using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheesy_Face_Recognition
{
    [Serializable]
    internal class RecognizedFace
    {
        private FaceClass _faceClass;
        private Rectangle _rect;
        private Mat _histogram;
        private Image<Gray, Byte> _face;
        private Image<Gray, Byte> _lbp;
        private double _distance;

        public RecognizedFace(FaceClass fc, Rectangle r, Image<Gray, Byte> f, Image<Gray, Byte> l, Mat h, double d)
        {
            _faceClass = fc;
            _rect = r;
            _histogram = h;
            _face = f;
            _lbp = l;
            _distance = d;
        }
        public FaceClass GetFaceClass()
        {
            return _faceClass;
        }

        public void SetFaceClass(FaceClass inp_faceClass)
        {
            _faceClass = inp_faceClass;
        }

        public Rectangle GetRect()
        {
            return _rect;
        }

        public void SetRect(Rectangle inp_rect)
        {
            _rect = inp_rect;
        }

        public Mat GetHist()
        {
            return _histogram;
        }

        public void SetHist(Mat inp_hist)
        {
            _histogram = inp_hist;
        }

        public Image <Gray,byte> GetFace()
        {
            return _face;
        }

        public void SetFace(Image <Gray,byte> inp_face)
        {
            _face = inp_face;
        }

        public Image<Gray, byte> GetLBP()
        {
            return _lbp;
        }

        public void SetLBP(Image<Gray, byte> inp_lbp)
        {
            _lbp = inp_lbp;
        }


        public double GetDist()
        {
            return _distance;
        }

        public void SetDist(double inp_dist)
        {
            _distance = inp_dist;
        }




    }
}
