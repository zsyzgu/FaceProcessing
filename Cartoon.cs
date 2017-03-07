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
    class Cartoon
    {
        public IplImage cartoon(IplImage image)
        {
            Mat mat = new Mat(image);
            Mat tmp = new Mat(mat.Size(), MatType.CV_8UC3);

            int repetitions = 7;
            int kernelSize = 9;
            double sigmaColor = 9;
            double sigmaSpace = 7;
            for (int i = 0; i < repetitions; i++)
            {
                Cv2.BilateralFilter(mat, tmp, kernelSize, sigmaColor, sigmaSpace);
                Cv2.BilateralFilter(tmp, mat, kernelSize, sigmaColor, sigmaSpace);
            }

            image = mat.ToIplImage();
            return image;
        }
    }
}
