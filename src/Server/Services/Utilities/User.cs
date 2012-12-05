using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Utilities
{
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

        public User(XmlElement userElement)
        {
            Name = userElement.Attributes[USER_ATTRIBUTE_NAME].Value;
            ID = int.Parse(userElement.Attributes[USER_ATTRIBUTE_ID].Value);

            XmlNodeList albumsNodes = userElement.GetElementsByTagName(ALBUMS_ELEMENT_TAG);
            XmlElement albumsElement = (XmlElement)albumsNodes[0];
            XmlNodeList albumNodes = albumsElement.GetElementsByTagName(ALBUM_ELEMENT_TAG);

            Albums = new Dictionary<int, UserAlbum>();
            foreach (XmlElement albumElement in albumNodes)
            {
                UserAlbum newAlbum = new UserAlbum(albumElement);
                Albums.Add(newAlbum.ID, newAlbum);
            }
        }

        public int ID { get; private set; }
        public string Name { get; private set; }
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
        
        public XmlElement CreateXmlElement(ref XmlDocument doc)
        {
            XmlElement userElement = doc.CreateElement(USER_ELEMENT_TAG);

            // Attributes
            XmlAttribute nameAttribute = doc.CreateAttribute(USER_ATTRIBUTE_NAME);
            nameAttribute.Value = Name;

            XmlAttribute idAttribute = doc.CreateAttribute(USER_ATTRIBUTE_ID);
            idAttribute.Value = ID.ToString();

            userElement.Attributes.Append(nameAttribute);
            userElement.Attributes.Append(idAttribute);

            // Albums
            XmlElement albumsElement = doc.CreateElement(ALBUMS_ELEMENT_TAG);
            userElement.AppendChild(albumsElement);

            foreach (KeyValuePair<int, UserAlbum> albumData in Albums)
            {
                XmlElement albumElement = albumData.Value.CreateXmlElement(ref doc);
                albumsElement.AppendChild(albumElement);
            }

            return userElement;
        }
    }
}
