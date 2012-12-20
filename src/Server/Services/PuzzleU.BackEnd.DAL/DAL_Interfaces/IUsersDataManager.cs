using System;
namespace PuzzleU.BackEnd.DAL
{
    public interface IUsersDataManager
    {
        bool AddUserAlbum(int userID, int albumId, out string errorString);
        bool CreateUser(string sUserName, out int id, out string errorString);
        bool DeleteUser(int id, out string errorString);
        bool DeleteUserAlbum(int albumId, out string errorString);
        bool GetAlbumIDs(int userId, out System.Collections.Generic.List<int> albumIDs, out string errorString);
        bool GetUserID(string sUserName, out int id, out string errorString);
        bool GetUsers(out System.Collections.Generic.List<PuzzleU.BackEnd.ComonTypes.User> users, out string errorString);
        int NullUserID { get; }
        void Save();
    }
}
