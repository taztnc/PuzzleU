using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Runtime.Serialization;

namespace Utilities
{
    [DataContract]
    public class User
    {
        public const string USER_ELEMENT_TAG = "user";
        private const string USER_ATTRIBUTE_NAME = "name";
        private const string USER_ATTRIBUTE_ID = "id";
        
        public const string ALBUMS_ELEMENT_TAG = "albums";
        public const string ALBUM_ELEMENT_TAG = "album";

        public User (int id, string name)
        {
            ID = id;
            Name = name;
            Albums = new Dictionary<int, UserAlbum>();
        }        

        [DataMember]
        public int ID { get; private set; }

        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public Dictionary<int, UserAlbum>  Albums { get; private set; }

        public List<int> GetAlbumsIds()
        {
            List<int> ans = new List<int>();

            foreach (KeyValuePair<int, UserAlbum> pair in Albums)
            {
                ans.Add(pair.Key);
            }

            return ans;
        }               
    }
}
