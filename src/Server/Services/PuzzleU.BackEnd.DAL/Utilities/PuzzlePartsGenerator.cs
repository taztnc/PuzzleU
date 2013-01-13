using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using PuzzleU.BackEnd.ComonTypes;

namespace PuzzleU.BackEnd.DAL
{
    public class PuzzlePartsGenerator
    {
        private class Rect
        {
            public int MinX { get; set; }
            public int MinY { get; set; }

            public int MaxX { get; set; }
            public int MaxY { get; set; }


            public int Width 
            {
                get
                {
                    return MaxX - MinX;
                }
            }

            public int Height 
            {
                get
                {
                    return MaxY - MinY;
                }
                
            }

            internal bool InRangeOnX(int start, int end)
            {
                return ((MinX <= end && MinX >= start) ||
                        (MaxX <= end && MaxX >= start));
            }
        }

        private class Interval
        {
            public int Start { get; set; }
            public int End { get; set; }

            public int Length
            {
                get { return End-Start; }
            }
        }

        public ImageData ImageData { get; set; }
        public int DifficultyLevel { get; set; }
        public List<PuzzlePartData> PuzzlePartsData { get; private set; }
        public int AlbumId { get; set; }       

        internal bool Generate(out string errorString)
        {
            PuzzlePartsData = new List<PuzzlePartData>();
            errorString = string.Empty;

            int numPuzzleParts = 4;
            switch (DifficultyLevel)
            {
                case 1:
                    numPuzzleParts = 4;
                    break;
                case 2:
                    numPuzzleParts = 9;
                    break;
                case 3:
                    numPuzzleParts = 16;
                    break;
            };       

            Rect mainRect = new Rect();
            mainRect.MinX = mainRect.MinY = 0;
            mainRect.MaxX = ImageData.Width;
            mainRect.MaxY = ImageData.Height;

            // We will split the image to numPuzzleParts imageParts
            // Each ImagePart will contain a PuzzlePart
            // We want each part to take about half of the part it is in:

            int dimension = (int) Math.Sqrt(numPuzzleParts);

            int imagePartWidth = (int) ((1 / (double)dimension) * mainRect.Width);
            int imagePartHeight = (int)((1 / (double)dimension) * mainRect.Height);

            int puzzlePartWidth = (int)(imagePartWidth / (double)Math.Sqrt(2));
            int puzzlePartHeight = (int)(imagePartHeight / (double)Math.Sqrt(2));
          
            // for each part:
            //                1. Calculate relative random x between 0 and (imagePartWidth-puzzlePartWidth)
            //                2. Calculate relative random y between 0 and (imagePartHeight-puzzlePartHeight)

            List<Rect> partsRects = new List<Rect>();
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    int randomX = CalcRandom(0, imagePartWidth - puzzlePartWidth);
                    int randomY = CalcRandom(0, imagePartHeight - puzzlePartHeight);

                    int actualX = randomX + (i * puzzlePartWidth);
                    int actualY = randomY + (j * puzzlePartHeight);

                    Rect rect = new Rect();


                    Rect newPartRect = new Rect();
                    newPartRect.MinX = actualX;
                    newPartRect.MaxX = actualX + puzzlePartWidth;
                    newPartRect.MinY = actualY;
                    newPartRect.MaxY = actualY + puzzlePartHeight;

                    partsRects.Add(newPartRect);
                }
            }

            GeneratePartsFromRects(partsRects);

            return true;
        }


        private void GeneratePartsFromRects(List<Rect> partsRects)
        {
            foreach (Rect puzzlePartRect in partsRects)
            {
                PuzzlePartData newPuzzlePartData = new PuzzlePartData();
                newPuzzlePartData.CoordinateX = puzzlePartRect.MinX;
                newPuzzlePartData.CoordinateY = puzzlePartRect.MinY;

                ImageData newImageData = new ImageData();
                newImageData.Width = puzzlePartRect.MaxX - puzzlePartRect.MinX;
                newImageData.Height = puzzlePartRect.MaxY - puzzlePartRect.MinY;

                string URL = CreatePartImage(puzzlePartRect);

                newImageData.URL = URL;

                newPuzzlePartData.ImageData = newImageData;

                PuzzlePartsData.Add(newPuzzlePartData);
            }
        }

        private string CreatePartImage(Rect puzzlePartRect)
        {           
            // Load main image
            ImageFileData data = new ImageFileData();
            
            Bitmap imageBM = new Bitmap(Bitmap.FromFile(ImageData.URL));

            Bitmap puzzlePartBM = new Bitmap(puzzlePartRect.Width, puzzlePartRect.Height);

            for (int i=0; i < puzzlePartRect.Width; i++)
            {
                for (int j=0; j < puzzlePartRect.Height; j++)
                {
                    puzzlePartBM.SetPixel(i, j, imageBM.GetPixel(puzzlePartRect.MinX + i, puzzlePartRect.MinY + j));
                }
            }

            ManagersFactory factory = ManagersFactory.Create();
            IImagesManager imagesManager = factory.CreateImagesManager();
            string URL;
            imagesManager.SaveImage(AlbumId, puzzlePartBM, out URL);

            return URL;
        }

        private class RectYComarer : IComparer<Rect>
        {
            public int Compare(Rect x, Rect y)
            {
                if (x.MinY < y.MinY)
                    return -1;
                else if (x.MinY > y.MinY)
                    return 1;
                else
                    return 0;
            }
        }

        private void SortRectsByY(List<Rect> limitingRects)
        {
            limitingRects.Sort(new RectYComarer());
        }

        private int CalcRandom(int start, int end)
        {
            Random rand = new Random();
            return rand.Next(start, end);            
        } 
    }
}
