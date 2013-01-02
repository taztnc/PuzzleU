using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PuzzleU.BackEnd.ComonTypes;
using PuzzleU.BackEnd.DAL.DAL_DB;
using System.Collections;

namespace PuzzleU.BackEnd.DAL
{


    class DBUsersDataManager : IUsersDataManager
    {
        PuzzleUDBContext dbContext = PuzzleUDBContext.Instance;

        public bool CreateUser(string sUserName, out int id, out string errorString)
        {
            id = NullUserID;
            errorString = "";

            try
            {
                User userToCreate = new User() { Name = sUserName };

                if (dbContext.Users.Any(x => x.Name == sUserName))
                {
                    errorString = "uesr already exists";
                    return false;
                }

                dbContext.Users.Add(userToCreate);
                dbContext.SaveChanges();

                var query = from b in dbContext.Users
                            where b.Name == sUserName
                            select b;

                var createdUser = query.First();
                if (createdUser == null)
                {
                    errorString = "error while trying to add a user";
                    return false;
                }

                id = createdUser.UserId;
                return true;
            }
            catch (Exception e)
            {
                errorString = e.Message;
                return false;
            }            
        }

        public bool DeleteUser(int id, out string errorString)
        {
            errorString = "";

            try
            {
                var query = from b in dbContext.Users
                            where b.UserId == id
                            select b;

                var user = query.First();
                if (user == null)
                {
                    errorString = "User wasn't found";
                    return false;
                }

                dbContext.Users.Remove(user);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                errorString = e.Message;
                return false;
            }   
        }

        public bool GetAlbumIDs(int userId, out List<int> albumIDs, out string errorString)
        {
            errorString = "";
            albumIDs = new List<int>();
            try
            {
                var userQuery = from b in dbContext.Users
                            where b.UserId == userId
                            select b;
                if(!userQuery.Any())
                {
                    errorString = "User doesn't exist";
                    return false;
                }

                User user  = userQuery.First();

                if (user.Albums == null)
                {
                    albumIDs = new List<int>();
                }
                else
                {
                    var albumIDsQuery = from album in user.Albums
                                        select album.AlbumId;
                    albumIDs = albumIDsQuery.ToList();
                }
                return true;
            }
            catch (Exception e)
            {
                errorString = e.Message;
                return false;
            }  
        }

        public bool GetUserID(string sUserName, out int id, out string errorString)
        {
            errorString = "";
            id = NullUserID;
            try
            {
                var query = from b in dbContext.Users
                            where b.Name == sUserName
                            select b;                
                id = query.First().UserId;
                return true;
            }
            catch (Exception e)
            {
                errorString = e.Message;
                return false;
            }   
        }

        public bool GetUsers(out List<User> users, out string errorString)
        {
            errorString = "";
            users = new List<User>();
            try
            {
                var query = from b in dbContext.Users
                            select b;

                users = query.ToList();
                return true;
            }
            catch(Exception e)
            {
                errorString = e.Message;
                return false;
            }   
        }


        public bool AddUserAlbum(int userID, Album album, out string errorString)
        {
            throw new NotImplementedException();
        }

        public int NullUserID
        {
            get
            {
                return -1;
            }
        }


        public User GetUser(int userId)
        {
            return dbContext.Users.Find(userId);
        }
    }
}
