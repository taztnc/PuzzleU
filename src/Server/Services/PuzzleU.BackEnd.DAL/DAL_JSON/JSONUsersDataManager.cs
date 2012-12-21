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
    class JSONUsersDataManager : PuzzleU.BackEnd.DAL.IUsersDataManager
    {
        #region Constants

        private const int NULL_USER_ID = -1;
        public int NullUserID
        {
            get
            {
                return NULL_USER_ID;
            }
        }

        public string USERS_FILE_PATH = "users.json";
        public string USERS_FILE_PATH_TEMP = "users_temp.json";

        private const string USERS_ELEMENT_TAG = "users"; // root    

        #endregion

        #region Private Fields

        private Dictionary<int, User> Users { get; set; } // User ID to user
        private Dictionary<string, int> UsersNameToIdMap { get; set; }
        private int MaxId { get; set; }
        private Dictionary<int, int> AlbumIdToUserId { get; set; }

        #endregion

        #region Singelton        

        private JSONUsersDataManager()
        {
            Users = new Dictionary<int, User>();
            UsersNameToIdMap = new Dictionary<string, int>();
            AlbumIdToUserId = new Dictionary<int, int>();
            MaxId = -1;
        }

        private static JSONUsersDataManager instance;
        public static JSONUsersDataManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JSONUsersDataManager();
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
                string currDir = Directory.GetCurrentDirectory();

                if (!File.Exists(USERS_FILE_PATH))
                    return false;

                Users.Clear();
                UsersNameToIdMap.Clear();


                using (FileStream fileStream = new FileStream(USERS_FILE_PATH, FileMode.Open))
                {
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Dictionary<int, User>));
                    Users = (Dictionary<int, User>)ser.ReadObject(fileStream);
                }

                foreach (KeyValuePair<int, User> userPair in Users)
                {
                    User newUser = userPair.Value;
                    UsersNameToIdMap.Add(newUser.Name, newUser.ID);

                    foreach (Album album in newUser.Albums)
                    {
                        AlbumIdToUserId.Add(album.ID, newUser.ID);
                    }

                    if (newUser.ID > MaxId)
                        MaxId = newUser.ID;
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
                if (File.Exists(USERS_FILE_PATH_TEMP))
                    File.Delete(USERS_FILE_PATH_TEMP);

                using (FileStream fileStream = new FileStream(USERS_FILE_PATH_TEMP, FileMode.OpenOrCreate))
                {
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Dictionary<int, User>));
                    ser.WriteObject(fileStream, Users);
                }

                if (File.Exists(USERS_FILE_PATH))
                    File.Delete(USERS_FILE_PATH);

                File.Move(USERS_FILE_PATH_TEMP, USERS_FILE_PATH);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }

        private bool UserExists(string sUserName)
        {
            return UsersNameToIdMap.ContainsKey(sUserName);
        }

        private bool UserExists(int iUserID)
        {
            return Users.ContainsKey(iUserID);
        }

        private int GenerateID()
        {
            MaxId++;
            return MaxId;
        }

        #endregion

        #region Public Methods

        public bool CreateUser(string sUserName, out int id, out string errorString)
        {
            id = NULL_USER_ID;
            errorString = string.Empty;

            if (UserExists(sUserName))
            {
                errorString = "User already exists";
                return false;
            }
            
            id = GenerateID();

            Users.Add(id, new User()
            {
                ID = id,
                Name = sUserName,
                Albums = new List<Album>()
            });
            UsersNameToIdMap.Add(sUserName, id);

            return true;
        }

        public bool GetUserID(string sUserName, out int id, out string errorString)
        {
            id = NULL_USER_ID;
            errorString = string.Empty;

            if (!UserExists(sUserName))
            {
                errorString = "User does not exists";
                return false;
            }          

            id = UsersNameToIdMap[sUserName];

            return true;
        }

        public bool DeleteUser(int id, out string errorString)
        {
            errorString = string.Empty;

            if (!UserExists(id))
            {
                errorString = "User does not exists";
                return false;
            }

            string name = Users[id].Name;
            UsersNameToIdMap.Remove(name);

            foreach (Album album in Users[id].Albums)
            {
                AlbumIdToUserId.Remove(album.ID);
            }

            Users.Remove(id);

            return true;
        }

        public bool GetAlbumIDs(int userId, out List<int> albumIDs, out string errorString)
        {
            albumIDs = null;
            errorString = string.Empty;

            if (!UserExists(userId))
            {
                errorString = "User does not exists";
                return false;
            }

            User user = Users[userId];

            albumIDs = new List<int>();

            foreach (Album album in user.Albums)
            {
                albumIDs.Add(album.ID);
            }
                     
            return true;
        }

        public bool GetUsers(out List<User> users, out string errorString)
        {
            users = new List<User>();
            errorString = string.Empty;

            foreach (KeyValuePair<int, User> pair in Users)
            {
                users.Add(pair.Value);
            }

            return true;
        }

        public bool AddUserAlbum(int userID, int albumId, out string errorString)
        {
            errorString = string.Empty;

            if (!Users.ContainsKey(userID))
            {
                errorString = "User does not exist";
                return false;
            }

            User user = Users[userID];
            Album searchResult = user.Albums.Find(new Predicate<Album>(album => { return album.ID == albumId; }));
            if (searchResult != null)
            {
                errorString = "Album already exists";
                return false;
            }
            user.Albums.Add(searchResult);

            AlbumIdToUserId.Add(albumId, userID);

            return true;
        }

        public bool DeleteUserAlbum(int albumId, out string errorString)
        {
            errorString = string.Empty;

            if (!AlbumIdToUserId.ContainsKey(albumId))
            {
                errorString = "Album does not exist";
                return false;
            }

            int userId = AlbumIdToUserId[albumId];
            AlbumIdToUserId.Remove(albumId);

            User user = Users[userId];
            user.Albums.RemoveAll(new Predicate<Album>(album => { return album.ID == albumId; })); ;

            return true;
        }       

        #endregion
    }
}
