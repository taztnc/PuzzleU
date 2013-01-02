using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PuzzleU.BackEnd.ComonTypes;
using PuzzleU.BackEnd.DAL.DAL_DB;
using PuzzleU.BackEnd.DAL.Utilities;
using System.IO;

namespace PuzzleU.BackEnd.DAL
{
    class DBImagesManager : IImagesManager
    {
        static private PuzzleUDBContext context = PuzzleUDBContext.Instance;

        public bool DeleteImage(int imageId)
        {
            AlbumImageData image = context.AlbumImages.First(x=>x.AlbumImageDataId == imageId);
            if (image == null)
            {
                return false;
            }

            context.AlbumImages.Remove(image);
            context.SaveChanges();
            return true;
        }

        public bool SaveImage(int albumId, ImageFileData imageFileData, out string url)
        {
            Album album = context.Albums.Find(albumId);
            if (album == null)
            {
                url = "";
                return false;
            }

            AlbumImageData imageToAdd = new AlbumImageData()
            {
                AlbumId = albumId
            };
            context.AlbumImages.Add(imageToAdd);
            context.SaveChanges();
#warning yossim: jpg extension shouldn't be hard coded
            imageToAdd.URL = ImageStoreUtilities.GenerateUrl(albumId, imageToAdd.AlbumImageDataId, ".jpg");

            {
#warning yossim: Should be transactive
                ImageStoreUtilities.Store(imageToAdd.URL,imageFileData.ImageStream);
                context.SaveChanges();
            }

            url = imageToAdd.URL;
            return true;
        }

        public bool SaveImage(int albumId, System.Drawing.Bitmap bm, out string url)
        {        
            Album album = context.Albums.Find(albumId);
            if (album == null)
            {
                url = "";
                return false;
            }

            AlbumImageData imageToAdd = new AlbumImageData()
            {
                AlbumId = albumId
            };
            context.AlbumImages.Add(imageToAdd);
            context.SaveChanges();
#warning yossim: jpg extension shouldn't be hard coded
            imageToAdd.URL = ImageStoreUtilities.GenerateUrl(albumId, imageToAdd.AlbumImageDataId, ".jpg");

            {//TODO : Should be transactive
                ImageStoreUtilities.Store(imageToAdd.URL, bm);
                context.SaveChanges();
            }

            url = imageToAdd.URL;
            return true;
        }

    }
}
