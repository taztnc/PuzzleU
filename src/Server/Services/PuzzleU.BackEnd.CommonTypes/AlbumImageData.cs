using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Runtime.Serialization;

namespace PuzzleU.BackEnd.ComonTypes
{
    [DataContract]
    public class AlbumImageData
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string URL { get; set; }

        [DataMember]
        public int AlbumId { get; set; }        
    }
}
