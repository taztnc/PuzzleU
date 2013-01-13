using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Runtime.Serialization;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace PuzzleU.BackEnd.ComonTypes
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public virtual  List<Album>  Albums { get;  set; }         
    }
}
