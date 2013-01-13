using System;
using PuzzleU.BackEnd.ComonTypes;
namespace PuzzleU.BackEnd.DAL
{
    public interface IAlbumsDataManager
    {
        bool CreateAlbum(int userId, string albumName, out int id, out string errorString);
        bool DeleteAlbum(int id, out string errorString);
        bool GetAlbumID(int userId, string albumName, out int id, out string errorString);
        bool GetAlbumImages(int albumId, out System.Collections.Generic.List<int> images, out string errorString);
        bool GetAlbums(System.Collections.Generic.List<int> albumIds, out System.Collections.Generic.List<Album> albums, out string errorString);
        bool GetImageURL(int imageId, out string URL, out string errorString);
        int NullAlbumId { get; }
    }
}
