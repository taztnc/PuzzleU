﻿using System;
using PuzzleU.BackEnd.ComonTypes;

namespace PuzzleU.BackEnd.DAL
{
    public interface IUsersDataManager
    {
        bool AddUserAlbum(int userID, Album album, out string errorString);
        bool CreateUser(string sUserName, out int id, out string errorString);
        bool DeleteUser(int id, out string errorString);
        bool GetAlbumIDs(int userId, out System.Collections.Generic.List<int> albumIDs, out string errorString);
        bool GetUserID(string sUserName, out int id, out string errorString);
        bool GetUsers(out System.Collections.Generic.List<PuzzleU.BackEnd.ComonTypes.User> users, out string errorString);
        int NullUserID { get; }
        User GetUser(int userId);
    }
}
