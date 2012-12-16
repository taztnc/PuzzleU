using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Runtime.Serialization;

namespace Utilities
{
    [DataContract]
    public class Album
    {
        public const string ALBUM_ELEMENT_TAG = "album";
        private const string ALBUM_ATTRIBUTE_NAME = "name";
        private const string ALBUM_ATTRIBUTE_ID = "id";
        private const string ALBUM_ATTRIBUTE_USER_ID = "userId";

        public const string IMAGES_DATA_ELEMENT_TAG = "imagesData";

        public static string GetAlbumKey(string albumName, int userId)
        {
            return albumName + "." + userId.ToString();
        }

        public Album(int id, string name, int userID)
        {
            ID = id;
            Name = name;
            UserId = userID;

            ImagesData = new Dictionary<string, AlbumImageData>();
        }        

        [DataMember]
        public int ID { get; private set; }

        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public int UserId { get; private set; }

        [DataMember]
        public Dictionary<string, AlbumImageData> ImagesData { get; private set; }        
    }    
}
