using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using PuzzleU.BackEnd.ComonTypes;

namespace PuzzleU.BackEnd.DAL.DAL_DB
{
    public class PuzzleUDBContext : DbContext
    {
        private static readonly PuzzleUDBContext mInstance = new PuzzleUDBContext();
        public static PuzzleUDBContext Instance
        {
            get
            {              
                return mInstance;
            }
        }
        
#warning yossim, connection string should be in a config file
        protected PuzzleUDBContext() : base("Server=localhost;Database=PuzzleUDB;Trusted_Connection=true;") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<AlbumImageData> AlbumImages { get; set; }

    }
}
