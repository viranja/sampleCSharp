using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageUpdate
{
    public class ImageFile
    {
        public void Save(string ImagePath)
        {
           
           byte[] imageData= null;

           imageData = System.IO.File.ReadAllBytes(ImagePath);

           if (imageData != null)
           {
               System.IO.File.WriteAllBytes("../../testImage.jpg", imageData);
           }
        

        }
    }
}
