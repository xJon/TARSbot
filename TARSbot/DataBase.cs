using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARSbot
{
    class DataBase
    {
        public static bool AddUniqueUser(string name, string id)
        {
            using (LiteDatabase db = new LiteDatabase(ConstData.path))
            {
                var uniqueUsers = db.GetCollection<UniqueUser>("uniqueUsers");
                var uniqueUser = new UniqueUser { userName = name, userId = id };
                uniqueUsers.Insert(uniqueUser);
                return true;
            }
        }

        public static bool RemoveUniqueUser(string name)
        {
            using (LiteDatabase db = new LiteDatabase(ConstData.path))
            {
                var uniqueUsers = db.GetCollection<UniqueUser>("uniqueUsers");
                uniqueUsers.Delete(Query.EQ("userName", name));
                return true;
            }
        }

        public static bool IsUniqueUser(string id)
        {
            using (LiteDatabase db = new LiteDatabase(ConstData.path))
            {
                var uniqueUsers = db.GetCollection<UniqueUser>("uniqueUsers");
                var resultUser = uniqueUsers.FindOne(Query.EQ("userId", id));
                return resultUser != null ? true : false;
            }
        }
    }

    public class UniqueUser
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string userId { get; set; }
    }
}
