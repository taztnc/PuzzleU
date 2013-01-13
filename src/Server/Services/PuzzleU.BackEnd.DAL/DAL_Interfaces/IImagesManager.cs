using System;
using PuzzleU.BackEnd.ComonTypes;
namespace PuzzleU.BackEnd.DAL
{
    public interface IImagesManager
    {
        bool DeleteImage(int imageId);
        bool SaveImage(int albumId, ImageFileData imageFileData, out string url);
        bool SaveImage(int albumId, System.Drawing.Bitmap bm, out string url);
    }
}
