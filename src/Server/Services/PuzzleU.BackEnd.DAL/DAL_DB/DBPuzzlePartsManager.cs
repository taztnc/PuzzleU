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
            throw new NotImplementedException();
        }

        public bool Load()
        {
            throw new NotImplementedException();
        }

        public bool PuzzlePartsDataExists(ImageData imageData, int iDifficultyLevel)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, List<PuzzlePartData>> PuzzlePartsMap
        {
            get { throw new NotImplementedException(); }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
