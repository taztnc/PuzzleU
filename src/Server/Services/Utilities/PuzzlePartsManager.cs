using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PuzzleUServices;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Utilities
{
    public class PuzzlePartsManager
    {
        #region Constants

        public const string PUZZLE_PARTS_FOLDER_PATH = "PuzzleParts";

        public string PUZZLES_FILE_PATH = Path.Combine(GlobalVars.BASE_PATH, "DataFiles\\puzzles.json");
        public string PUZZLES_FILE_PATH_TEMP = Path.Combine(GlobalVars.BASE_PATH, "DataFiles\\puzzles_temp.json");

        #endregion

        #region Private Fields

        public Dictionary<string, List<PuzzlePartData>> PuzzlePartsMap { get; private set; }

        #endregion

        #region Singelton

        

        private PuzzlePartsManager()
        {
            PuzzlePartsMap = new Dictionary<string, List<PuzzlePartData>>();
            
        }

        private static PuzzlePartsManager instance;
        public static PuzzlePartsManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PuzzlePartsManager();
                    if (!instance.Load()) instance = null;
                }

                return instance;
            }
        }

        #endregion

        private string CalcPuzzlePartsKey(string imageURL, int diffLevel)
        {
            return string.Format("{0}_{1}", imageURL, diffLevel.ToString());
        }

        public bool PuzzlePartsDataExists(PuzzleUServices.ImageData imageData, int iDifficultyLevel)
        {
            string puzzlePartsKey = CalcPuzzlePartsKey(imageData.URL, iDifficultyLevel);

            return PuzzlePartsMap.ContainsKey(puzzlePartsKey);
        }

        public bool GetPuzzlePartsData(ImageData imageData, int diffLevel, out List<PuzzlePartData> puzzlePartsData, out string errorString)
        {
            errorString = string.Empty;
            puzzlePartsData = null;

            string puzzlePartsKey = CalcPuzzlePartsKey(imageData.URL, diffLevel);

            if (PuzzlePartsMap.ContainsKey(puzzlePartsKey))
            {
                puzzlePartsData = PuzzlePartsMap[puzzlePartsKey];
                return true;
            }

            PuzzlePartsGenerator puzzlePartsGenerator = new PuzzlePartsGenerator();
            puzzlePartsGenerator.ImageData = imageData;
            puzzlePartsGenerator.DifficultyLevel = diffLevel;

            if (!puzzlePartsGenerator.Generate(out errorString))
                return false;

            if (!AddPuzzlePartsData(imageData, diffLevel, puzzlePartsGenerator.PuzzlePartsData, out errorString))
                return false;

            puzzlePartsData = puzzlePartsGenerator.PuzzlePartsData;

            return true;
        }

        private bool AddPuzzlePartsData(ImageData imageData, int diffLevel, List<PuzzlePartData> list, out string errorString)
        {
            errorString = string.Empty;
            string puzzlePartsKey = CalcPuzzlePartsKey(imageData.URL, diffLevel);

            if (PuzzlePartsMap.ContainsKey(puzzlePartsKey))
            {
                errorString = "Puzzle parts data already exists";
                return false;
            }

            PuzzlePartsMap.Add(puzzlePartsKey, list);

            return true;
        }

        public void Save()
        {
            try
            {
                if (File.Exists(PUZZLES_FILE_PATH_TEMP))
                    File.Delete(PUZZLES_FILE_PATH_TEMP);

                using (FileStream fileStream = new FileStream(PUZZLES_FILE_PATH_TEMP, FileMode.OpenOrCreate))
                {
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Dictionary<string, List<PuzzlePartData>>));
                    ser.WriteObject(fileStream, PuzzlePartsMap);
                }

                if (File.Exists(PUZZLES_FILE_PATH))
                    File.Delete(PUZZLES_FILE_PATH);

                File.Move(PUZZLES_FILE_PATH_TEMP, PUZZLES_FILE_PATH);
            }
            catch
            {
            }
        }

        public bool Load()
        {
            try
            {
                string curr = Directory.GetCurrentDirectory();

                if (!File.Exists(PUZZLES_FILE_PATH))
                    return false;

                PuzzlePartsMap.Clear();

                using (FileStream fileStream = new FileStream(PUZZLES_FILE_PATH, FileMode.Open))
                {
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Dictionary<string, List<PuzzlePartData>>));
                    PuzzlePartsMap = (Dictionary<string, List<PuzzlePartData>>)ser.ReadObject(fileStream);
                }                
            }
            catch
            {
                return false;
            }

            return true;
        } 
    }
}
