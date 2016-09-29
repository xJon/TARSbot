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
            using (var db = new LiteDatabase(ConstData.path))
            {
                var uniqueUsers = db.GetCollection<UniqueUser>("uniqueUsers");
                var uniqueUser = new UniqueUser { userName = name, userId = id };
                uniqueUsers.Insert(uniqueUser);
                return true;
            }
        }

        public static bool RemoveUniqueUser(string name)
        {
            using (var db = new LiteDatabase(ConstData.path))
            {
                var uniqueUsers = db.GetCollection<UniqueUser>("uniqueUsers");
                uniqueUsers.Delete(Query.EQ("userName", name));
                return true;
            }
        }

        public static bool IsUniqueUser(string id)
        {
            using (var db = new LiteDatabase(ConstData.path))
            {
                var uniqueUsers = db.GetCollection<UniqueUser>("uniqueUsers");
                var resultUser = uniqueUsers.FindOne(Query.EQ("userId", id));
                return resultUser != null ? true : false;
            }
        }

        public static bool SetTarsPrefix(string newPrefix)
        {
            if (newPrefix.Length < 3)
                return false;
            using (var db = new LiteDatabase(ConstData.path))
            {
                var customPrefix = db.GetCollection<Prefix>("prefix");
                var prefix = new Prefix { customPrefix = newPrefix, Id = 1 };
                if (GetTarsPrefix() == "TARS")
                    customPrefix.Insert(prefix);
                else
                    customPrefix.Update(prefix);
            }
            return true;
        }

        public static string GetTarsPrefix()
        {
            using (var db = new LiteDatabase(ConstData.path))
            {
                var customPrefix = db.GetCollection<Prefix>("prefix");
                var currentPrefix = customPrefix.FindById(1);
                return (currentPrefix != null && currentPrefix.customPrefix != null) ? currentPrefix.customPrefix : "TARS";
            }
        }
    }

    public class UniqueUser
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string userId { get; set; }
    }

    public class Prefix
    {
        public int Id { get; set; }
        public string customPrefix { get; set; }
    }
}
