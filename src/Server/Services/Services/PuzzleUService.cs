using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Threading;
using PuzzleU.BackEnd.DAL;
using PuzzleU.BackEnd.ComonTypes;

//Gamba

namespace PuzzleUServices
{
    // kobig - This is not the way to go - we currently keep a singelton service and keep the data in memory
    //         The proper way to work is keeping a database and use a per-call instantiation 

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class PuzzleUService : IPuzzleUService, IPuzzleUWebService
    {
        ManagersFactory managersFactory = ManagersFactory.Create();
        // User Name
        public bool CreateUser(string sUserName, out int id, out string errorString)
        {
            errorString = string.Empty;

            IUsersDataManager usersDataMan = managersFactory.CreateUsersDataManagerr() ;
            id = usersDataMan.NullUserID;
            if (usersDataMan == null)
            {
                errorString = "Failed retrieving UsersDataManager"; 
                return false;
            }

            return usersDataMan.CreateUser(sUserName, out id, out errorString);
        }

        public bool GetUserID(string sUserName, out int id, out string errorString)
        {
            errorString = string.Empty;

            IUsersDataManager usersDataMan = managersFactory.CreateUsersDataManagerr();
            id = usersDataMan.NullUserID;
            if (usersDataMan == null)
            {
                errorString = "Failed retrieving UsersDataManager";
                return false;
            }

            return usersDataMan.GetUserID(sUserName, out id, out errorString);
        }

        public bool DeleteUser(int id, out string errorString)
        {
            errorString = string.Empty;

            IUsersDataManager usersDataMan = managersFactory.CreateUsersDataManagerr();
            if (usersDataMan == null)
            {
                errorString = "Failed retrieving UsersDataManager";
                return false;
            }

            return usersDataMan.DeleteUser(id, out errorString);
        }

        public bool GetAlbumsData(int userId, out List<AlbumData> albumsData, out string errorString)
        {
            albumsData = null;
            errorString = string.Empty;

            IUsersDataManager usersDataMan = managersFactory.CreateUsersDataManagerr();
            if (usersDataMan == null)
            {
                errorString = "Failed retrieving UsersDataManager";
                return false;
            }

            List<int> albumIds = null;
            if (!usersDataMan.GetAlbumIDs(userId, out albumIds, out errorString))
                return false;

            IAlbumsDataManager albumsDataMan = managersFactory.CreateAlbumsManager();
            if (albumsDataMan == null)
            {
                errorString = "Failed retrieving AlbumsDataManager";
                return false;
            }

            List<Album> albums = null;
            if (!albumsDataMan.GetAlbums(albumIds, out albums, out errorString))
                return false;

            albumsData = new List<AlbumData>();
            foreach (Album album in albums)
            {
                AlbumData albumData = new AlbumData();
                albumData.ID = album.ID;
                albumData.Name = album.Name;

                albumsData.Add(albumData);
            }            

            return true;
        }

        public bool GetUsersData(out List<UserData> usersData, out string errorString)
        {
            usersData = null;
            errorString = string.Empty;

            IUsersDataManager usersDataMan = managersFactory.CreateUsersDataManagerr();
            if (usersDataMan == null)
            {
                errorString = "Failed retrieving UsersDataManager";
                return false;
            }

            List<User> users = null;
            if (!usersDataMan.GetUsers(out users, out errorString))
                return false;

            usersData = new List<UserData>();
            foreach (User user in users)
            {
                UserData userData = new UserData();
                userData.ID = user.ID;
                userData.Name = user.Name;
                usersData.Add(userData);
            }

            return true;
        }

        // Album
        public bool CreateAlbum(int userID, string albumName, out int albumId, out string errorString)
        {
            errorString = string.Empty;

            IAlbumsDataManager albumsDataMan = managersFactory.CreateAlbumsManager();
            albumId = albumsDataMan.NullAlbumId;
            if (albumsDataMan == null)
            {
                errorString = "Failed retrieving AlbumsDataManager";
                return false;
            }

            if (!albumsDataMan.CreateAlbum(userID, albumName, out albumId, out errorString))
                return false;

            IUsersDataManager usersDataMan = managersFactory.CreateUsersDataManagerr();
            if (usersDataMan == null)
            {
                errorString = "Failed retrieving UsersDataManager";
                return false;
            }

            List<Album> albums = null;
            if (!albumsDataMan.GetAlbums(new List<int>() { albumId },out albums, out errorString) || 
                albums == null || albums.Count != 1 || albums[0] == null)
            {
                errorString = "Faied adding album to user";
                return false;
            }

            return usersDataMan.AddUserAlbum(userID, albums[0], out errorString);
        }

        public bool DeleteAlbum(int albumId, out string errorString)
        {
            errorString = string.Empty;

            IAlbumsDataManager albumsDataMan = managersFactory.CreateAlbumsManager();
            if (albumsDataMan == null)
            {
                errorString = "Failed retrieving AlbumsDataManager";
                return false;
            }

            if (!albumsDataMan.DeleteAlbum(albumId, out errorString))
                return false;

            IUsersDataManager usersDataMan = managersFactory.CreateUsersDataManagerr();
            if (usersDataMan == null)
            {
                errorString = "Failed retrieving UsersDataManager";
                return false;
            }

            return usersDataMan.DeleteUserAlbum(albumId, out errorString);
        }

        public bool GetAlbumID(int userId, string albumName, out int albumId, out string errorString)
        {
            
            errorString = string.Empty;

            IAlbumsDataManager albumsDataMan = managersFactory.CreateAlbumsManager();
            albumId = albumsDataMan.NullAlbumId;

            if (albumsDataMan == null)
            {
                errorString = "Failed retrieving AlbumsDataManager";
                return false;
            }

            return albumsDataMan.GetAlbumID(userId, albumName, out albumId, out errorString);
        }

        public bool GetAlbumIDs(int userID, out List<int> albumIDs, out string errorString)
        {
            albumIDs = null;
            errorString = string.Empty;

            IUsersDataManager usersDataMan = managersFactory.CreateUsersDataManagerr();
            if (usersDataMan == null)
            {
                errorString = "Failed retrieving UsersDataManager";
                return false;
            }

            return usersDataMan.GetAlbumIDs(userID, out albumIDs, out errorString);
        }        

        public bool AddImage(int albumId, ImageFileData imageFileData, out string errorString)
        {
            IAlbumsDataManager albumsDataMan = managersFactory.CreateAlbumsManager();
            if (albumsDataMan == null)
            {
                errorString = "Failed retrieving AlbumsDataManager";
                return false;
            }

            if (albumsDataMan.AlbumImageExists(albumId, imageFileData.ImageName))
            {
                errorString = "Image already exists in album";
                return false;
            }

            IImagesManager imagesMan = managersFactory.CreateImagesManager();
            if (imagesMan == null)
            {
                errorString = "Failed retrieving ImagesManager";
                return false;
            }

            string url;
            if (!imagesMan.SaveImage(albumId, imageFileData, out url))
            {
                errorString = "Failed saving image";
                return false;
            }

            if (!albumsDataMan.AddAlbumImage(albumId, imageFileData.ImageName, url, out errorString))
                return false;

            return true;
        }

        public bool DeleteImage(int albumId, string imageName, out string errorString)
        {
            IAlbumsDataManager albumsDataMan = managersFactory.CreateAlbumsManager();
            if (albumsDataMan == null)
            {
                errorString = "Failed retrieving AlbumsDataManager";
                return false;
            }

            if (!albumsDataMan.AlbumImageExists(albumId, imageName))
            {
                errorString = "Image does not exists in album";
                return false;
            }

            IImagesManager imagesMan = managersFactory.CreateImagesManager();
            if (imagesMan == null)
            {
                errorString = "Failed retrieving ImagesManager";
                return false;
            }

            if (!imagesMan.DeleteImage(albumId, imageName))
            {
                errorString = "Failed deleting image";
                return false;
            }

            if (!albumsDataMan.DeleteAlbumImage(albumId, imageName, out errorString))
                return false;

            return true;
        }

        public bool GetAlbumImages(int iAlbumID, out List<string> images, out string errorString)
        {
            images = null;
            
            IAlbumsDataManager albumsDataMan = managersFactory.CreateAlbumsManager();
            if (albumsDataMan == null)
            {
                errorString = "Failed retrieving AlbumsDataManager";
                return false;
            }

            if (!albumsDataMan.GetAlbumImages(iAlbumID, out images, out errorString))
                return false;

            return true;
        }

        public bool GetPuzzleData(int albumId, string imageName, int iDifficultyLevel, out PuzzleData puzzleData, out string errorString)
        {
            puzzleData = null;
            errorString = string.Empty;

            puzzleData = new PuzzleData();

            ImageData imageData = null;
            if (!GetImageData(albumId, imageName, out imageData, out errorString))
                return false;

            puzzleData.ImageData = imageData;

            List<PuzzlePartData> puzzlePartsData = null;
            if (!GetPuzzlePartsData(albumId, imageName, iDifficultyLevel, out puzzlePartsData, out errorString))
                return false;

            puzzleData.PuzzlePartData = puzzlePartsData;

            return true;
        }

        private bool GetPuzzlePartsData(int albumId, string imageName, int iDifficultyLevel, out List<PuzzlePartData> puzzlePartsData, out string errorString)
        {
            puzzlePartsData = new List<PuzzlePartData>();
            errorString = string.Empty;

            ImageData imageData = null;
            if (!GetImageData(albumId, imageName, out imageData, out errorString))
                return false;

            IPuzzlePartsManager puzzlePartsMan = managersFactory.CreatePuzzlePartsManager();
            if (puzzlePartsMan == null)
            {
                errorString = "Failed retrieving PuzzlePartsManager";
                return false;
            }

            if (!puzzlePartsMan.GetPuzzlePartsData(imageData, iDifficultyLevel, out puzzlePartsData, out errorString))
                return false;

            return true;
        }

        private bool GetImageData(int albumId, string imageName, out ImageData imageData, out string errorString)
        {
            imageData = new ImageData();

            // Get image URL
            IAlbumsDataManager albumsDataMan = managersFactory.CreateAlbumsManager();
            if (albumsDataMan == null)
            {
                errorString = "Failed retrieving AlbumsDataManager";
                return false;
            }

            string URL = string.Empty;
            if (!albumsDataMan.GetImageURL(albumId, imageName, out URL, out errorString))
                return false;

            imageData.URL = URL;

            // Get image size
            Image image = Image.FromFile(URL);

            imageData.Height = image.Height;
            imageData.Width = image.Width;

            return true;
        }

        public void Save()
        {
            managersFactory.CreateUsersDataManagerr().Save();
            managersFactory.CreateAlbumsManager().Save();
            managersFactory.CreatePuzzlePartsManager().Save();
        }

        #region WebInvokes


        private byte[] ToByteArray(Stream stream)
        {
            byte[] buffer = new byte[32768];
            using (MemoryStream ms = new MemoryStream())
            {
                while (true)
                {
                    int read = stream.Read(buffer, 0, buffer.Length);
                    if (read <= 0)
                        return ms.ToArray();
                    ms.Write(buffer, 0, read);
                }
            }
        }

        public string Singup(Stream streamContent)
        {
            byte[] data = ToByteArray(streamContent);
            string strContent = Encoding.UTF8.GetString(data);

            return "from server";
        }


        #endregion
    }
}
