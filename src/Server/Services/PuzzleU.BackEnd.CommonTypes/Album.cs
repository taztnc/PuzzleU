using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Runtime.Serialization;

namespace PuzzleU.BackEnd.ComonTypes
{
    [DataContract]
    public class Album
    {
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
