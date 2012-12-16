using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using PuzzleUServices;
using System.Runtime.Serialization.Json;

namespace Utilities
{
    public class UsersDataManager
    {
        #region Constants

        public const int NULL_USER_ID = -1;
        public string USERS_FILE_PATH = Path.Combine(GlobalVars.BASE_PATH, "DataFiles\\users.json");
        public string USERS_FILE_PATH_TEMP = Path.Combine(GlobalVars.BASE_PATH, "DataFiles\\users_temp.json");

        private const string USERS_ELEMENT_TAG = "users"; // root    

        #endregion

        #region Private Fields

        private Dictionary<int, User> Users { get; set; } // User ID to user
        private Dictionary<string, int> UsersNameToIdMap { get; set; }
        private int MaxId { get; set; }
        private Dictionary<int, int> AlbumIdToUserId { get; set; }

        #endregion

        #region Singelton        

        private UsersDataManager()
        {
            Users = new Dictionary<int, User>();
            UsersNameToIdMap = new Dictionary<string, int>();
            AlbumIdToUserId = new Dictionary<int, int>();
            MaxId = -1;
        }

        private static UsersDataManager instance;
        public static UsersDataManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UsersDataManager();
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

                    foreach (KeyValuePair<int, UserAlbum> albumPair in newUser.Albums)
                    {
                        AlbumIdToUserId.Add(albumPair.Key, newUser.ID);
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

            Users.Add(id, new User(id, sUserName));
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

            foreach (KeyValuePair<int, UserAlbum> albumPair in Users[id].Albums)
            {
                AlbumIdToUserId.Remove(albumPair.Key);
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
            albumIDs = user.GetAlbumsIds();
                     
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
            if (user.Albums.ContainsKey(albumId))
            {
                errorString = "Album already exists";
                return false;
            }

            UserAlbum album = new UserAlbum(albumId);
            user.Albums.Add(albumId, album);

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
            user.Albums.Remove(albumId);

            return true;
        }       

        #endregion
    }
}
