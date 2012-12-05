using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace Utilities
{
    public class ImagesManager
    {
        #region Constants

        public const string IMAGES_FOLDER_PATH = "Images";

        #endregion

        #region Singelton

        private ImagesManager()
        {
        }

        private static ImagesManager instance;
        public static ImagesManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ImagesManager();                    
                }

                return instance;
            }
        }

        #endregion

        #region Methods

        public bool SaveImage(int albumId, string imageName, Bitmap bmImage, out string url)
        {
            url = string.Empty;

            try
            {
                string path = IMAGES_FOLDER_PATH;
                path = Path.Combine(path, string.Format("Album{0}", albumId));
                path = Path.Combine(path, imageName);

                url = path;

                if (!Directory.Exists(Path.GetDirectoryName(path)))
                    Directory.CreateDirectory(Path.GetDirectoryName(path));

                bmImage.Save(path);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool SaveImage(int albumId, PuzzleUServices.ImageFileData imageFileData, out string url)
        {
            url = string.Empty;

            try
            {
                string path = IMAGES_FOLDER_PATH;
                path = Path.Combine(path, string.Format("Album{0}", albumId));
                path = Path.Combine(path, imageFileData.ImageName);
                path = Path.ChangeExtension(path, imageFileData.ImageFormat);

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
    }
}
