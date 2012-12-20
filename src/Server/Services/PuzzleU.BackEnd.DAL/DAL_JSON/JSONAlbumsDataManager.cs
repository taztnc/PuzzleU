using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Runtime.Serialization.Json;
using PuzzleU.BackEnd.ComonTypes;

namespace PuzzleU.BackEnd.DAL
{
    class JSONAlbumsDataManager : PuzzleU.BackEnd.DAL.IAlbumsDataManager
    {
        #region Constants

        private const int NULL_ALBUM_ID = -1;
        public string ALBUMS_FILE_PATH = "albums.json";
        public string ALBUMS_FILE_PATH_TEMP = "albums_temp.json";

        private const string ALBUMS_ELEMENT_TAG = "albums"; // root

        #endregion

        #region Private Fields

        private Dictionary<int, Album> Albums { get; set; } // Album ID to album
        private Dictionary<string, int> AlbumsNameToIdMap { get; set; }
        private int MaxId { get; set; }

        #endregion

        #region Singelton        

        private JSONAlbumsDataManager()
        {
            Albums = new Dictionary<int, Album>();
            AlbumsNameToIdMap = new Dictionary<string, int>();
            MaxId = -1;
        }

        private static JSONAlbumsDataManager instance;
        public static JSONAlbumsDataManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JSONAlbumsDataManager();
                    if (!instance.Load()) instance = null;
                }

                return instance;
            }
        }

        #endregion

        #region Private Methods

        private bool Load()
        {
            try
            {
                string curr = Directory.GetCurrentDirectory();

                if (!File.Exists(ALBUMS_FILE_PATH))
                    return false;

                Albums.Clear();
                AlbumsNameToIdMap.Clear();

                using (FileStream fileStream = new FileStream(ALBUMS_FILE_PATH, FileMode.Open))
                {
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Dictionary<int, Album>));
                    Albums = (Dictionary<int, Album>)ser.ReadObject(fileStream);
                }

                foreach (KeyValuePair<int, Album> albumPair in Albums)
                {
                    Album newAlbum = albumPair.Value;
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

        public void Save()
        {
            try
            {
                if (File.Exists(ALBUMS_FILE_PATH_TEMP))
                    File.Delete(ALBUMS_FILE_PATH_TEMP);

                using (FileStream fileStream = new FileStream(ALBUMS_FILE_PATH_TEMP, FileMode.OpenOrCreate))
                {
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Dictionary<int, Album>));
                    ser.WriteObject(fileStream, Albums);
                }

                if (File.Exists(ALBUMS_FILE_PATH))
                    File.Delete(ALBUMS_FILE_PATH);

                File.Move(ALBUMS_FILE_PATH_TEMP, ALBUMS_FILE_PATH);
            }
            catch
            {
            }
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

        public bool DeleteAlbumImage(int albumId, string imageName, out string errorString)
        {
            errorString = string.Empty;

            if (!Albums.ContainsKey(albumId))
            {
                errorString = "Album does not exist";
                return false;
            }

            Album album = Albums[albumId];
            if (!album.ImagesData.ContainsKey(imageName))
            {
                errorString = "Image does not exist";
                return false;
            }

            album.ImagesData.Remove(imageName);

            return true;
        }

        public bool GetAlbumImages(int albumId, out List<string> images, out string errorString)
        {
            images = null;
            errorString = string.Empty;

            if (!Albums.ContainsKey(albumId))
            {
                errorString = "Album does not exist";
                return false;
            }

            Album album = Albums[albumId];
            images = new List<string>();
            foreach (string imageName in album.ImagesData.Keys)
            {
                images.Add(imageName);
            }

            return true;
        }

        public bool GetImageURL(int albumId, string imageName, out string URL, out string errorString)
        {
            URL = string.Empty;
            errorString = string.Empty;

            if (!Albums.ContainsKey(albumId))
            {
                errorString = "Album does not exist";
                return false;
            }

            Album album = Albums[albumId];
            if (!album.ImagesData.ContainsKey(imageName))
            {
                errorString = "Image does not exist in album";
                return false;
            }

            // kobig - Give the images the URL in the website http://localhost:8000/Images/<image>
            AlbumImageData imageData = album.ImagesData[imageName];
            URL = imageData.URL;

            return true;
        }

        public int NullAlbumId
        {
            get
            {
                return NULL_ALBUM_ID;
            }
        }
    }
}
