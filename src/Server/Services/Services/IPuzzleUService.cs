using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Drawing;

namespace PuzzleUServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
    [ServiceContract]
    public interface IPuzzleUService
    {
        [OperationContract]
        bool CreateUser(string sUserName, out int id, out string errorString);
        [OperationContract]
        bool GetUserID(string sUserName, out int id, out string errorString);
        [OperationContract]
        bool DeleteUser(int id, out string errorString);
        [OperationContract]
        bool GetUsersData(out List<UserData> users, out string errorString);

        [OperationContract]
        bool CreateAlbum(int userId, string albumName, out int albumId, out string errorString); // Returns AlbumID
        [OperationContract]
        bool DeleteAlbum(int albumId, out string errorString);
        [OperationContract]
        bool GetAlbumID(int userId, string albumName, out int albumId, out string errorString); // Returns AlbumID
        [OperationContract]
        bool GetAlbumIDs(int userId, out List<int> albumIds, out string errorString); // Returns List<AlbumID>
        [OperationContract]
        bool GetAlbumsData(int userId, out List<AlbumData> albums, out string errorString);

        // kobig - Add a new AddImage operation contract that accepts a post stream and calls our very own AddImage
        // We will have to do the same for all operation contracts above
        // Note:
        //           1. We should start thinking about returning values
        //           2. We can do this after we finish writing the basic operation contracts
        //           3. The parsing should be clear on what we expect in the Posted/Get message


        [OperationContract]
        bool AddImage(int albumId, ImageFileData imageFileData, out string errorString);
        [OperationContract]
        bool DeleteImage(int albumId, string imageName, out string errorString);
        [OperationContract]
        bool GetAlbumImages(int iAlbumID, out List<string> images, out string errorString); // Returns List<Images name>


        [OperationContract]
        bool GetPuzzleData(int albumId, string imageName, int iDifficultyLevel, out PuzzleData puzzleData, out string errorString);

    }
}
