using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuzzleU.BackEnd.DAL
{
    class JSONManagersFactory : ManagersFactory
    {
        public override IAlbumsDataManager CreateAlbumsManager()
        {
            return JSONAlbumsDataManager.Instance;
        }

        public override IImagesManager CreateImagesManager()
        {
            return JSONImagesManager.Instance;
        }

        public override IPuzzlePartsManager CreatePuzzlePartsManager()
        {
            return JSONPuzzlePartsManager.Instance;
        }

        public override IUsersDataManager CreateUsersDataManagerr()
        {
            return JSONUsersDataManager.Instance;
        }
    }
}
