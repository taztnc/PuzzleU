using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using PuzzleU.BackEnd.ComonTypes;

namespace PuzzleU.BackEnd.DAL
{
    class JSONImagesManager : PuzzleU.BackEnd.DAL.IImagesManager
    {
        #region Constants

        public const string IMAGES_FOLDER_PATH = "Images";

        #endregion

        #region Singelton

        private JSONImagesManager()
        {
        }

        private static JSONImagesManager instance;
        public static JSONImagesManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JSONImagesManager();                    
                }

                return instance;
            }
        }

        #endregion

        #region Methods

        public bool SaveImage(int albumId, string imageName, Bitmap bm, out string url)
        {
            url = string.Empty;

            try
            {
                string path = GetImagePath(albumId, imageName);

                url = path;

                if (!Directory.Exists(Path.GetDirectoryName(path)))
                    Directory.CreateDirectory(Path.GetDirectoryName(path));

                bm.Save(path);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool SaveImage(int albumId, ImageFileData imageFileData, out string url)
        {
            url = string.Empty;

            try
            {
                string path = GetImagePath(albumId, imageFileData.ImageName);

                url = path;

                if (!Directory.Exists(Path.GetDirectoryName(path)))
                    Directory.CreateDirectory(Path.GetDirectoryName(path));

                using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    using (BinaryWriter writer = new BinaryWriter(fileStream))
                    {
                        writer.Write(imageFileData.ImageStream);
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        #endregion

        private string GetImagePath(int albumId, string imageName)
        {
            string path = IMAGES_FOLDER_PATH;
            path = Path.Combine(path, string.Format("Album{0}", albumId));
            path = Path.Combine(path, imageName);

            return path;
        }

        public bool DeleteImage(int albumId, string imageName)
        {
            try
            {
                string path = GetImagePath(albumId, imageName);
                if (File.Exists(path))
                    File.Delete(path);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
