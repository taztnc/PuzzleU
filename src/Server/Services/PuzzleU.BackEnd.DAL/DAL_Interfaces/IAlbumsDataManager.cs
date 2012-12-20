using System;
using PuzzleU.BackEnd.ComonTypes;
namespace PuzzleU.BackEnd.DAL
{
    public interface IAlbumsDataManager
    {
        bool AddAlbumImage(int albumId, string imageName, string url, out string errorString);
        bool AlbumImageExists(int albumId, string imageName);
        bool CreateAlbum(int userId, string albumName, out int id, out string errorString);
        bool DeleteAlbum(int id, out string errorString);
        bool DeleteAlbumImage(int albumId, string imageName, out string errorString);
        bool GetAlbumID(int userId, string albumName, out int id, out string errorString);
        bool GetAlbumImages(int albumId, out System.Collections.Generic.List<string> images, out string errorString);
        bool GetAlbums(System.Collections.Generic.List<int> albumIds, out System.Collections.Generic.List<Album> albums, out string errorString);
        bool GetImageURL(int albumId, string imageName, out string URL, out string errorString);
        void Save();
        int NullAlbumId { get; }
    }
}
