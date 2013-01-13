using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace PuzzleU.BackEnd.DAL.Utilities
{
    /// <summary>
    /// Utilities methods to help storing images.
    /// </summary>
    static class ImageStoreUtilities
    {
        static public String GenerateUrl(int albumId,int imageId,String extension)
        {
#warning yossim : Currently the "..\\Albums\\" part in path is hard coded , we should reconsider this as we move to a real deployment
            return String.Format("..\\Albums\\{0}\\{1}{2}", albumId,imageId, extension);
        }

        static public void Store(String Url, Bitmap bitmap)
        {
            CreateDirectoryFromFilePath(Url);
            bitmap.Save(Url);
        }

        static public void Store(String Url, byte[] bytes)
        {
            CreateDirectoryFromFilePath(Url);
            File.WriteAllBytes(Url, bytes);
        }

        private static void CreateDirectoryFromFilePath(String Url)
        {
            String dir = Path.GetDirectoryName(Url);
            Directory.CreateDirectory(dir);
        }
    }
}
