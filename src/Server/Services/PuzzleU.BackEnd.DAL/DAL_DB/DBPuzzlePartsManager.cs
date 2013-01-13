using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PuzzleU.BackEnd.ComonTypes;

namespace PuzzleU.BackEnd.DAL
{
    class DBPuzzlePartsManager : IPuzzlePartsManager
    {

        public bool GetPuzzlePartsData(ImageData imageData, int diffLevel, out List<PuzzlePartData> puzzlePartsData, out string errorString)
        {
            PuzzlePartsGenerator generator = new PuzzlePartsGenerator()
            {
                DifficultyLevel = diffLevel,
                ImageData = imageData
            };

            if (!generator.Generate(out errorString))
            {
                puzzlePartsData = new List<PuzzlePartData>();
                return false;
            }

            errorString = "";
            puzzlePartsData = generator.PuzzlePartsData;
            return true;
        }
    }
}
