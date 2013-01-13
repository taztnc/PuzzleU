using System;
using PuzzleU.BackEnd.ComonTypes;
namespace PuzzleU.BackEnd.DAL
{
    public interface IPuzzlePartsManager
    {
        bool GetPuzzlePartsData(PuzzleU.BackEnd.ComonTypes.ImageData imageData, int diffLevel, out System.Collections.Generic.List<PuzzlePartData> puzzlePartsData, out string errorString);
    }
}
