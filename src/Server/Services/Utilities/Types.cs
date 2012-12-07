using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.IO;
using System.Runtime.Serialization.Json;


namespace PuzzleUServices
{
    [DataContract]
    public class ImageFileData
    {
        [DataMember]
        public string ImageName { get; set; }

        [DataMember]
        public byte[] ImageStream { get; set; }

        [DataMember]
        public string ImageFormat { get; set; }
    }


    [DataContract]
    public class UserData
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }
    }

    [DataContract]
    public class AlbumData
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }
    }

    [DataContract]
    public class PuzzleData
    {
        private ImageData mImageData;

        // Apply the DataMemberAttribute to the property.
        [DataMember]
        public ImageData ImageData
        {

            get { return mImageData; }
            set { mImageData = value; }
        }

        private List<PuzzlePartData> mPuzzlePartsData;
        [DataMember]
        public List<PuzzlePartData> PuzzlePartData
        {

            get { return mPuzzlePartsData; }
            set { mPuzzlePartsData = value; }
        }        
    }

    [DataContract]
    public class ImageData
    {
        private string mURI;
        [DataMember]
        public string URI
        {
            get { return mURI; }
            set { mURI = value; }
        }

        private int mWidth;
        [DataMember]
        public int Width
        {
            get { return mWidth; }
            set { mWidth = value; }
        }

        private int mHeight;
        [DataMember]
        public int Height
        {
            get { return mHeight; }
            set { mHeight = value; }
        }
    }

    [DataContract]
    public class PuzzlePartData
    {
        private ImageData mImageData;
        [DataMember]
        public ImageData ImageData
        {
            get { return mImageData; }
            set { mImageData = value; }
        }

        private int mCoordinateX;
        [DataMember]
        public int CoordinateX
        {
            get { return mCoordinateX; }
            set { mCoordinateX = value; }
        }

        private int mCoordinateY;
        [DataMember]
        public int CoordinateY
        {
            get { return mCoordinateY; }
            set { mCoordinateY = value; }
        }
    }
}
