using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace PuzzleU.BackEnd.ComonTypes
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public virtual List<AlbumImageData> ImagesData { get; set; }        
    }    
}
