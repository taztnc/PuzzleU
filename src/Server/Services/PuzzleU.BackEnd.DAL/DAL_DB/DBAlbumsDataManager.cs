using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PuzzleU.BackEnd.ComonTypes;
using PuzzleU.BackEnd.DAL.DAL_DB;

namespace PuzzleU.BackEnd.DAL
{
    class DBAlbumsDataManager : IAlbumsDataManager
    {
        PuzzleUDBContext context = PuzzleUDBContext.Instance;

        public bool CreateAlbum(int userId, string albumName, out int id, out string errorString)
        {
            try
            {
#warning should prevent duplicate albums with the same name
                Album album = new Album() { UserId = userId, Name = albumName };
                context.Albums.Add(album);
                context.SaveChanges();
                id = album.AlbumId;
                errorString = "";
                return true;
            }
            catch (Exception e)
            {
                errorString = "Error while trying to create album ," + e.Message;
                id = NullAlbumId;
                return false;
            }
        }

        public bool DeleteAlbum(int id, out string errorString)
        {
            try
            {
                Album album = context.Albums.Find(id);
                if(album == null)
                {
                    errorString = String.Format("No album with id = '{0}' found", id);
                    return false;
                }
                context.Albums.Remove(album);
                context.SaveChanges();
                errorString = "";
                return true;
            }
            catch (Exception e)
            {
                errorString = "Error while trying to delete album ," + e.Message;
                id = NullAlbumId;
                return false;
            }
        }


        public bool GetAlbumID(int userId, string albumName, out int id, out string errorString)
        {
            try
            {
                var query = from item in context.Albums
                            where item.UserId == userId && item.Name == albumName
                            select item;
                if (!query.Any())
                {
                    errorString = "Album doesn't exist";
                    id = NullAlbumId;
                    return false;
                }
                id = query.First().AlbumId;
                errorString = "";
                return true;
            }
            catch (Exception e)
            {
                errorString = "Could not get Album Id," +e;
                id = NullAlbumId;
                return false;
            }
        }

        public bool GetAlbumImages(int albumId, out List<int> images, out string errorString)
        {
            try
            {
                var q = from a in context.AlbumImages
                        where a.AlbumId == albumId
                        select a.AlbumImageDataId;
                images = q.ToList();
                errorString = "";
                return true;
            }
            catch (Exception e)
            {
                errorString = "could not get album images," + e.Message;
                images = new List<int>();
                return false;
            }
        }

        public bool GetAlbums(List<int> albumIds, out List<Album> albums, out string errorString)
        {
            try
            {
                var query = from item in context.Albums
                            where albumIds.Contains(item.AlbumId)
                            select item;
               albums = query.ToList();
               errorString = "";
               return true;
            }
            catch (Exception e)
            {
                albums = new List<Album>();
                errorString = "Could not get albums , " + e.Message;
                return false;
            }
        }

        public bool GetImageURL(int imageId, out string URL, out string errorString)
        {
            try
            {
                var query = from item in context.AlbumImages
                            where item.AlbumImageDataId == imageId
                            select item.URL;

                URL = query.ToList()[0];
                errorString = "";
                return true;
            }
            catch (Exception e)
            {
                URL = "";
                errorString = "Could not get Iamge URL," + e.Message;
                return true;
            }
        }


        public int NullAlbumId
        {
            get { return -1; }
        }


    }
}
