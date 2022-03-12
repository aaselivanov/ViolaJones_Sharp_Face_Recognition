using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheesy_Face_Recognition
{
    internal static class LBPTransformer
    {
        public static Image<Gray, Byte> CSTransform(Image<Gray, Byte> input)
        {
            Image<Gray, Byte> res_image = new Image<Gray, Byte>(input.Rows, input.Cols);

            // Source: https://www.bytefish.de/blog/local_binary_patterns.html

            //-1, чтобы окно смогло собрать всё, а не свалилось с ошибкой на границе;

            for (int i=1;i<input.Rows-1;i++)
            {
                for (int j=1;j<input.Cols-1;j++)
                {
                    byte code = 0;

                    byte cur_pixel = input.Data[i, j, 0];

                    code |= Convert.ToByte((Convert.ToByte(input.Data[i - 1, j - 1, 0] > cur_pixel)) << 7);
                    code |= Convert.ToByte((Convert.ToByte(input.Data[i - 1, j, 0] > cur_pixel)) << 6);
                    code |= Convert.ToByte((Convert.ToByte(input.Data[i - 1, j + 1, 0] > cur_pixel)) << 5);
                    code |= Convert.ToByte((Convert.ToByte(input.Data[i, j + 1, 0] > cur_pixel)) << 4);
                    code |= Convert.ToByte((Convert.ToByte(input.Data[i + 1, j + 1, 0] > cur_pixel)) << 3);
                    code |= Convert.ToByte((Convert.ToByte(input.Data[i + 1, j, 0] > cur_pixel)) << 2);
                    code |= Convert.ToByte((Convert.ToByte(input.Data[i + 1, j - 1, 0] > cur_pixel)) << 1);
                    code |= Convert.ToByte((Convert.ToByte(input.Data[i, j - 1, 0] > cur_pixel)) << 0);

                    res_image.Data[i, j, 0] = code;
                }
            }

            for (int i = 1; i < input.Rows - 1; i++)
            {

            }

                return res_image;
        }
    }
}
