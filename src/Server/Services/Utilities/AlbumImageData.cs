using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Runtime.Serialization;

namespace Utilities
{
    [DataContract]
    public class AlbumImageData
    {
        public const string IMAGE_DATA_ELEMENT_TAG = "image";

        private const string IMAGE_DATA_ATTRIBUTE_NAME = "name";
        private const string IMAGE_DATA_ATTRIBUTE_URL = "url";
        private const string IMAGE_DATA_ATTRIBUTE_ALBUM_ID = "albumId";

        public AlbumImageData(string name, string url, int albumId)
        {
            Name = name;
            URL = url;
            AlbumId = albumId;
        }        

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string URL { get; set; }

        [DataMember]
        public int AlbumId { get; set; }        
    }
}
