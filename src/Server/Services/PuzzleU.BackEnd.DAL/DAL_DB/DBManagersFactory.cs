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
            throw new NotImplementedException();
        }

        public override IImagesManager CreateImagesManager()
        {
            throw new NotImplementedException();
        }

        public override IPuzzlePartsManager CreatePuzzlePartsManager()
        {
            throw new NotImplementedException();
        }

        public override IUsersDataManager CreateUsersDataManagerr()
        {
            throw new NotImplementedException();
        }
    }
}
