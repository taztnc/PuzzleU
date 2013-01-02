using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            return new DBManagersFactory();    
        }
    }
}
