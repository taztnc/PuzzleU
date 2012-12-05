using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace Utilities
{
    public class UsersDataManager
    {
        #region Constants

        public const int NULL_USER_ID = -1;
        public const string USERS_FILE_PATH = "DataFiles\\users.xml";
        public const string USERS_FILE_PATH_TEMP = "DataFiles\\users_temp.xml";

        private const string USERS_ELEMENT_TAG = "users"; // root    

        #endregion

        #region Private Fields

        private Dictionary<int, User> Users { get; set; } // User ID to user
        private Dictionary<string, int> UsersNameToIdMap { get; set; }
        private int MaxId { get; set; }
        private Dictionary<int, int> AlbumIdToUserId { get; set; }

        #endregion

        #region Singelton

        public void Save()
        {
            WriteToFile();
        }

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
                if (!File.Exists(USERS_FILE_PATH))
                    return false;

                Users.Clear();
                UsersNameToIdMap.Clear();

                XmlDocument doc = new XmlDocument();
                doc.Load(USERS_FILE_PATH);

                XmlNodeList userNodes = doc.DocumentElement.GetElementsByTagName(User.USER_ELEMENT_TAG);
                foreach (XmlElement userElement in userNodes)
                {
                    User newUser = new User(userElement);
                    Users.Add(newUser.ID, newUser);
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

        public bool WriteToFile()
        {
            try
            {
                if (File.Exists(USERS_FILE_PATH_TEMP))
                    File.Delete(USERS_FILE_PATH_TEMP);

                XmlDocument doc = new XmlDocument();
                XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "", "");

                doc.AppendChild(dec);                

                XmlElement usersElement = doc.CreateElement(USERS_ELEMENT_TAG);
                doc.AppendChild(usersElement);

                foreach (KeyValuePair<int, User> userEntry in Users)
                {
                    XmlElement userElement = userEntry.Value.CreateXmlElement(ref doc);                   
                    usersElement.AppendChild(userElement);
                }

                doc.Save(USERS_FILE_PATH_TEMP);

                if (File.Exists(USERS_FILE_PATH))
                    File.Delete(USERS_FILE_PATH);

                File.Move(USERS_FILE_PATH_TEMP, USERS_FILE_PATH);
            }
            catch
            {
                return false;
            }

            return true;
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
