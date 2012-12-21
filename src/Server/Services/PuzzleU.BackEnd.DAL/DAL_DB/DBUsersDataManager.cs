using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PuzzleU.BackEnd.ComonTypes;

namespace PuzzleU.BackEnd.DAL
{
    class DBUsersDataManager : IUsersDataManager
    {

        public bool AddUserAlbum(int userID, Album album, out string errorString)
        {
            throw new NotImplementedException();
        }

        public bool CreateUser(string sUserName, out int id, out string errorString)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(int id, out string errorString)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUserAlbum(int albumId, out string errorString)
        {
            throw new NotImplementedException();
        }

        public bool GetAlbumIDs(int userId, out List<int> albumIDs, out string errorString)
        {
            throw new NotImplementedException();
        }

        public bool GetUserID(string sUserName, out int id, out string errorString)
        {
            throw new NotImplementedException();
        }

        public bool GetUsers(out List<User> users, out string errorString)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }


        public int NullUserID
        {
            get { throw new NotImplementedException(); }
        }
    }
}
