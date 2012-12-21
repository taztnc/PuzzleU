using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Runtime.Serialization;

namespace PuzzleU.BackEnd.ComonTypes
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public virtual List<Album> Albums { get; set; }
             
    }
}
