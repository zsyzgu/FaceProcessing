using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenCvSharp;
using OpenCvSharp.CPlusPlus;

namespace FaceProcessing
{
    class FaceDetect
    {
        CascadeClassifier cascade;

        public FaceDetect()
        {
            cascade = new CascadeClassifier("haarcascade_frontalface_alt.xml");
        }

        public IplImage getFaceImage(IplImage image)
        {
            Mat mat = new Mat(image);
            var faces = cascade.DetectMultiScale(mat);

            if (faces.Length > 0)
            {
                int id = 0;
                int maxArea = 0;
                for (int i = 0; i < faces.Length; i++)
                {
                    if (faces[i].Width * faces[i].Height > maxArea)
                    {
                        id = i;
                        maxArea = faces[i].Width * faces[i].Height;
                    }
                }

                image = image.GetSubImage(faces[id]);
            }

            return image;
        }
    }
}
