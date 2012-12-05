using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Utilities
{
    public class UserAlbum
    {
        public const string ALBUM_ELEMENT_TAG = "album";
        private const string ALBUM_ATTRIBUTE_ID = "id";

        public UserAlbum(int id)
        {
            ID = id;
        }

        public UserAlbum(XmlElement albumElement)
        {
            ID = int.Parse(albumElement.Attributes[ALBUM_ATTRIBUTE_ID].Value);
        }

        public int ID { get; private set; }

        public XmlElement CreateXmlElement(ref XmlDocument doc)
        {
            XmlElement albumElement = doc.CreateElement(ALBUM_ELEMENT_TAG);

            // Attributes
            XmlAttribute idAttribute = doc.CreateAttribute(ALBUM_ATTRIBUTE_ID);
            idAttribute.Value = ID.ToString();

            albumElement.Attributes.Append(idAttribute);

            return albumElement;
        }
    }
}
