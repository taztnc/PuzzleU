using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Runtime.Serialization;

namespace Utilities
{
    [DataContract]
    public class UserAlbum
    {
        public const string ALBUM_ELEMENT_TAG = "album";
        private const string ALBUM_ATTRIBUTE_ID = "id";

        public UserAlbum(int id)
        {
            ID = id;
        }        

        [DataMember]
        public int ID { get; private set; }        
    }
}
