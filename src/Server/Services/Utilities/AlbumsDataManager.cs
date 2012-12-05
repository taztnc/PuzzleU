using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace Utilities
{
    public class AlbumsDataManager
    {
        #region Constants

        public const int NULL_ALBUM_ID = -1;
        public const string ALBUMS_FILE_PATH = "DataFiles\\albums.xml";
        public const string ALBUMS_FILE_PATH_TEMP = "DataFiles\\albums_temp.xml";

        private const string ALBUMS_ELEMENT_TAG = "albums"; // root

        #endregion

        #region Private Fields

        private Dictionary<int, Album> Albums { get; set; } // Album ID to album
        private Dictionary<string, int> AlbumsNameToIdMap { get; set; }
        private int MaxId { get; set; }

        #endregion

        #region Singelton

        public void Save()
        {
            WriteToFile();
        }

        private AlbumsDataManager()
        {
            Albums = new Dictionary<int, Album>();
            AlbumsNameToIdMap = new Dictionary<string, int>();
            MaxId = -1;
        }

        private static AlbumsDataManager instance;
        public static AlbumsDataManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AlbumsDataManager();
                    if (!instance.ReadFromFile()) instance = null;
                }

                return instance;
            }
        }

        #endregion

        #region Private Methods

        private bool ReadFromFile()
        {
            try
            {
                if (!File.Exists(ALBUMS_FILE_PATH))
                    return false;

                Albums.Clear();
                AlbumsNameToIdMap.Clear();

                XmlDocument doc = new XmlDocument();
                doc.Load(ALBUMS_FILE_PATH);

                XmlNodeList albumNodes = doc.DocumentElement.GetElementsByTagName(User.ALBUM_ELEMENT_TAG);
                foreach (XmlElement albumElement in albumNodes)
                {
                    Album newAlbum = new Album(albumElement);
                    Albums.Add(newAlbum.ID, newAlbum);
                    AlbumsNameToIdMap.Add(Album.GetAlbumKey(newAlbum.Name, newAlbum.UserId), newAlbum.ID);

                    if (newAlbum.ID > MaxId)
                        MaxId = newAlbum.ID;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool WriteToFile()
        {
            try
            {
                if (File.Exists(ALBUMS_FILE_PATH_TEMP))
                    File.Delete(ALBUMS_FILE_PATH_TEMP);

                XmlDocument doc = new XmlDocument();
                XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "", "");

                doc.AppendChild(dec);

                XmlElement albumsElement = doc.CreateElement(ALBUMS_ELEMENT_TAG);
                doc.AppendChild(albumsElement);

                foreach (KeyValuePair<int, Album> albumEntry in Albums)
                {
                    XmlElement albumElement = albumEntry.Value.CreateXmlElement(ref doc);
                    albumsElement.AppendChild(albumElement);
                }

                doc.Save(ALBUMS_FILE_PATH_TEMP);

                if (File.Exists(ALBUMS_FILE_PATH))
                    File.Delete(ALBUMS_FILE_PATH);

                File.Move(ALBUMS_FILE_PATH_TEMP, ALBUMS_FILE_PATH);
            }
            catch
            {
                return false;
            }

            return true;
        }

        private bool AlbumExists(string albumName, int userId)
        {
            return AlbumsNameToIdMap.ContainsKey(Album.GetAlbumKey(albumName, userId));
        }

        private bool AlbumExists(int albumId)
        {
            return Albums.ContainsKey(albumId);
        }

        private int GenerateID()
        {
            MaxId++;
            return MaxId;
        }

        #endregion

        #region Public Methods
        
        public bool CreateAlbum(int userId, string albumName, out int id, out string errorString)
        {
            id = NULL_ALBUM_ID;
            errorString = string.Empty;

            if (AlbumExists(albumName, userId))
            {
                errorString = "Album already exists";
                return false;
            }

            id = GenerateID();

            Albums.Add(id, new Album(id, albumName, userId));

            AlbumsNameToIdMap.Add(Album.GetAlbumKey(albumName, userId), id);

            return true;
        }

        public bool GetAlbumID(int userId, string albumName, out int id, out string errorString)
        {
            id = NULL_ALBUM_ID;
            errorString = string.Empty;

            if (!AlbumExists(albumName, userId))
            {
                errorString = "Album does not exists";
                return false;
            }

            id = AlbumsNameToIdMap[Album.GetAlbumKey(albumName, userId)];

            return true;
        }

        public bool DeleteAlbum(int id, out string errorString)
        {
            errorString = string.Empty;

            if (!AlbumExists(id))
            {
                errorString = "User does not exists";
                return false;
            }

            string name = Albums[id].Name;
            
            AlbumsNameToIdMap.Remove( Album.GetAlbumKey(Albums[id].Name, Albums[id].UserId));
            Albums.Remove(id);

            return true;
        }

        public bool GetAlbums(List<int> albumIds, out List<Album> albums, out string errorString)
        {
            albums = new List<Album>();
            errorString = string.Empty;

            foreach (int albumId in albumIds)
            {
                if (!Albums.ContainsKey(albumId))
                    continue;

                albums.Add(Albums[albumId]);
            }

            return true;
        }

        public bool AlbumImageExists(int albumId, string imageName)
        {
            if (!Albums.ContainsKey(albumId))
                return false;

            return Albums[albumId].ImagesData.ContainsKey(imageName);
        }

        public bool AddAlbumImage(int albumId, string imageName, string url, out string errorString)
        {
            errorString = string.Empty;


            if (!Albums.ContainsKey(albumId))
            {
                errorString = "Album does not exist";
                return false;
            }

            
            Album album = Albums[albumId];
            if (album.ImagesData.ContainsKey(imageName))
            {
                errorString = "Image already exists";
                return false;
            }

            AlbumImageData imageData = new AlbumImageData(imageName, url, albumId);

            album.ImagesData.Add(imageName, imageData);
            
            return true;
        }


        #endregion
    }
}
