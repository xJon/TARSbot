using LiteDB;

namespace TARSbot
{
    class DataBase
    {
        public static bool AddUniqueUser(string name, ulong id)
        {
            using (var db = new LiteDatabase(ConstData.path))
            {
                var uniqueUsers = db.GetCollection<UniqueUser>("uniqueUsers");
                var uniqueUser = new UniqueUser { userName = name, userID = id };
                uniqueUsers.Insert(uniqueUser);
                return true;
            }
        }

        public static bool RemoveUniqueUser(ulong id)
        {
            using (var db = new LiteDatabase(ConstData.path))
            {
                var uniqueUsers = db.GetCollection<UniqueUser>("uniqueUsers");
                uniqueUsers.Delete(Query.EQ("userID", id));
                return true;
            }
        }

        public static bool IsUniqueUser(ulong id)
        {
            using (var db = new LiteDatabase(ConstData.path))
            {
                var uniqueUsers = db.GetCollection<UniqueUser>("uniqueUsers");
                var resultUser = uniqueUsers.FindOne(Query.EQ("userID", id));
                return resultUser != null ? true : false;
            }
        }

        public static bool SetServerPrefix(string newPrefix, ulong serverID)
        {
            if (newPrefix.Length < 3)
                return false;
            using (var db = new LiteDatabase(ConstData.path))
            {
                var servers = db.GetCollection<ServerSetting>("servers");
                if (GetServerPrefix(serverID) == "TARS")
                {
                    var customServerSetting = new ServerSetting { customPrefix = newPrefix, serverID = serverID };
                    servers.Insert(customServerSetting);
                }
                else
                {
                    var customServerSetting = servers.FindOne(Query.EQ("serverID", serverID));
                    customServerSetting.customPrefix = newPrefix;
                    servers.Update(customServerSetting);
                }
            }
            return true;
        }

        public static string GetServerPrefix(ulong serverID)
        {
            using (var db = new LiteDatabase(ConstData.path))
            {
                var servers = db.GetCollection<ServerSetting>("servers");
                var customServerSetting = servers.FindOne(Query.EQ("serverID", serverID));
                return (customServerSetting != null && customServerSetting.customPrefix != null) ? customServerSetting.customPrefix : "TARS";
            }
        }
    }

    public class UniqueUser
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public ulong userID { get; set; }
    }

    public class ServerSetting
    {
        public int Id { get; set; }
        public string customPrefix { get; set; }
        public ulong serverID { get; set; }
    }
}
