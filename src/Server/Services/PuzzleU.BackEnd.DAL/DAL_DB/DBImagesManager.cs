using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PuzzleU.BackEnd.ComonTypes;

namespace PuzzleU.BackEnd.DAL
{
    class DBImagesManager : IImagesManager
    {
        public bool DeleteImage(int albumId, string imageName)
        {
            throw new NotImplementedException();
        }

        public bool SaveImage(int albumId, ImageFileData imageFileData, out string url)
        {
            throw new NotImplementedException();
        }

        public bool SaveImage(int albumId, string imageName, System.Drawing.Bitmap bm, out string url)
        {
            throw new NotImplementedException();
        }
    }
}
