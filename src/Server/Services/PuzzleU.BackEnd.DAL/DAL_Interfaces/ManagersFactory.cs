using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//yossim : uncomment for DB mode
//#define DAL_DB

namespace PuzzleU.BackEnd.DAL
{
    //this is a kind of abstract factory
    public abstract class ManagersFactory
    {
        public abstract IAlbumsDataManager CreateAlbumsManager();
        public abstract IImagesManager CreateImagesManager();
        public abstract IPuzzlePartsManager CreatePuzzlePartsManager();
        public abstract IUsersDataManager CreateUsersDataManagerr();

        public static ManagersFactory Create()
        {
#if DAL_DB
            return new DBManagersFactory();    
#else
            return new JSONManagersFactory();
#endif
        }
    }
}
