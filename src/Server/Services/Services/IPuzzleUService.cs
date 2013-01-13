using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Drawing;
using System.ServiceModel.Web;
using System.IO;
using PuzzleU.BackEnd.ComonTypes;

#warning yossim : communications with the services should be based on a session token, we should add CreateSession and DestroySession operation that are based on a user.It also means that we have to add session management module(or service).
#warning yossim : What about security? 
#warning yossim : What about a password for users?!!?!

namespace PuzzleUServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
    [ServiceContract]
    public interface IPuzzleUService
    {
        // kobig - move this to the other interface ??
        //[OperationContract, WebInvoke(Method = "POST", UriTemplate = "Signup", BodyStyle = WebMessageBodyStyle.Bare)]
        //string Signup(Stream contents);


        //USER OPERATIONS -------------------------------------------------------------
        [OperationContract]
        bool CreateUser(string sUserName, out int id, out string errorString);
        [OperationContract]
        bool GetUserID(string sUserName, out int id, out string errorString);
        [OperationContract]
        bool DeleteUser(int id, out string errorString);
        [OperationContract]
        bool GetUsersData(out List<UserData> users, out string errorString);
        /// <summary>
        /// Get All information about the user in one call. in normal user flows We should really use this call instead of all other query calls,
        /// to reduce high-latency issues. This call doesn't return images data , it just returns the meta data for a specific user.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        bool GetUserData(int userId, out UserData userData, out String errorString);


        //ALBUM OPERATIONS -------------------------------------------------------------
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


        //IMAGE OPERATIONS -------------------------------------------------------------
        [OperationContract]
        bool AddImage(int albumId, ImageFileData imageFileData, out string errorString);
        [OperationContract]
        bool DeleteImage(int imageId, out string errorString);
        [OperationContract]
        bool GetAlbumImages(int iAlbumID, out List<int> images, out string errorString); // Returns List<Images name>


        //PUZZLE OPERATIONS -------------------------------------------------------------
        [OperationContract]
        bool GetPuzzleData(int imageId, int iDifficultyLevel, out PuzzleData puzzleData, out string errorString);

    }
}
