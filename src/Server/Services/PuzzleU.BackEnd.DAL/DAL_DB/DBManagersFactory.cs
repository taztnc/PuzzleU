using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuzzleU.BackEnd.DAL
{
    class DBManagersFactory : ManagersFactory
    {

        public override IAlbumsDataManager CreateAlbumsManager()
        {
            return new DBAlbumsDataManager();
        }

        public override IImagesManager CreateImagesManager()
        {
            return new DBImagesManager();
        }

        public override IPuzzlePartsManager CreatePuzzlePartsManager()
        {
            return new DBPuzzlePartsManager();
        }

        public override IUsersDataManager CreateUsersDataManagerr()
        {
            return new DBUsersDataManager();
        }
    }
}
