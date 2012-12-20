using System;
using PuzzleU.BackEnd.ComonTypes;
namespace PuzzleU.BackEnd.DAL
{
    public interface IImagesManager
    {
        bool DeleteImage(int albumId, string imageName);
        bool SaveImage(int albumId, ImageFileData imageFileData, out string url);
        bool SaveImage(int albumId, string imageName, System.Drawing.Bitmap bm, out string url);
    }
}
