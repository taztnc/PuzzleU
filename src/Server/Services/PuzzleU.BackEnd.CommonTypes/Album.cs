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
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public Dictionary<string, AlbumImageData> ImagesData { get; set; }        
    }    
}
