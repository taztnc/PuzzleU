using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PuzzleU.BackEnd.ComonTypes;

namespace PuzzleU.BackEnd.DAL
{
    class DBAlbumsDataManager : IAlbumsDataManager
    {
        public bool AddAlbumImage(int albumId, string imageName, string url, out string errorString)
        {
            throw new NotImplementedException();
        }

        public bool AlbumImageExists(int albumId, string imageName)
        {
            throw new NotImplementedException();
        }

        public bool CreateAlbum(int userId, string albumName, out int id, out string errorString)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAlbum(int id, out string errorString)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAlbumImage(int albumId, string imageName, out string errorString)
        {
            throw new NotImplementedException();
        }

        public bool GetAlbumID(int userId, string albumName, out int id, out string errorString)
        {
            throw new NotImplementedException();
        }

        public bool GetAlbumImages(int albumId, out List<string> images, out string errorString)
        {
            throw new NotImplementedException();
        }

        public bool GetAlbums(List<int> albumIds, out List<Album> albums, out string errorString)
        {
            throw new NotImplementedException();
        }

        public bool GetImageURL(int albumId, string imageName, out string URL, out string errorString)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }


        public int NullAlbumId
        {
            get { throw new NotImplementedException(); }
        }
    }
}
