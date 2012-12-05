using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Utilities
{
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

        public Album(XmlElement albumElement)
        {
            Name = albumElement.Attributes[ALBUM_ATTRIBUTE_NAME].Value;
            ID = int.Parse(albumElement.Attributes[ALBUM_ATTRIBUTE_ID].Value);
            UserId = int.Parse(albumElement.Attributes[ALBUM_ATTRIBUTE_USER_ID].Value);

            // Images
            XmlNodeList imagesDataNodes = albumElement.GetElementsByTagName(IMAGES_DATA_ELEMENT_TAG);
            XmlElement imagesDataElement = (XmlElement)imagesDataNodes[0];
            XmlNodeList imageDataNodes = imagesDataElement.GetElementsByTagName(AlbumImageData.IMAGE_DATA_ELEMENT_TAG);

            ImagesData = new Dictionary<string, AlbumImageData>();
            foreach (XmlElement imageElement in imageDataNodes)
            {
                AlbumImageData newImageData = new AlbumImageData(imageElement);
                ImagesData.Add(newImageData.Name, newImageData);
            }
        }

        public int ID { get; private set; }
        public string Name { get; private set; }
        public int UserId { get; private set; }
        public Dictionary<string, AlbumImageData> ImagesData { get; private set; }

        public XmlElement CreateXmlElement(ref XmlDocument doc)
        {
            XmlElement albumElement = doc.CreateElement(ALBUM_ELEMENT_TAG);

            // Attributes
            XmlAttribute nameAttribute = doc.CreateAttribute(ALBUM_ATTRIBUTE_NAME);
            nameAttribute.Value = Name;

            XmlAttribute idAttribute = doc.CreateAttribute(ALBUM_ATTRIBUTE_ID);
            idAttribute.Value = ID.ToString();

            XmlAttribute userIdAttribute = doc.CreateAttribute(ALBUM_ATTRIBUTE_USER_ID);
            userIdAttribute.Value = UserId.ToString();

            albumElement.Attributes.Append(nameAttribute);
            albumElement.Attributes.Append(idAttribute);
            albumElement.Attributes.Append(userIdAttribute);

            // Images
            XmlElement imagesDataElement = doc.CreateElement(IMAGES_DATA_ELEMENT_TAG);
            albumElement.AppendChild(imagesDataElement);

            foreach (KeyValuePair<string, AlbumImageData> imageDataEntry in ImagesData)
            {
                XmlElement imageDataElement = imageDataEntry.Value.CreateXmlElement(ref doc);
                imagesDataElement.AppendChild(imageDataElement);
            }

            return albumElement;
        }
    }    
}
