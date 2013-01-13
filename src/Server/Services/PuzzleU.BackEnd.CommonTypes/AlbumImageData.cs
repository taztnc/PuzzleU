using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace PuzzleU.BackEnd.ComonTypes
{
    public class AlbumImageData
    {
        public int AlbumImageDataId { get; set; }
        public string URL { get; set; }
        public int AlbumId { get; set; }        
    }
}
