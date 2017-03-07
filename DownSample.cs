using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
using OpenCvSharp.Extensions;

namespace FaceProcessing
{
    class DownSample
    {
        public IplImage downSample(IplImage image)
        {
            Mat mat = new Mat(image);
            Cv2.PyrDown(mat, mat, new Size(mat.Cols / 2, mat.Rows / 2));
            image = mat.ToIplImage();
            return image;
        }
    }
}
