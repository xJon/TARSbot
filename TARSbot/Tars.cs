using LiteDB;
using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARSbot
{
    class Tars
    {
        private DiscordClient client;

        public Tars()
        {
            client = new DiscordClient();
            client.Log.Message += (s, e) => Console.WriteLine($"[{e.Severity}] {e.Source}: {e.Message}");
            client.MessageReceived += ClientMessageRecieved;
            client.ExecuteAndWait(async () =>
            {
                await client.Connect(ConstData.loginToken);
            });

        }

        private void ClientMessageRecieved(object sender, MessageEventArgs e)
        {
            Console.WriteLine("[{0}] [{1}] [{2}]: {3}", e.Server.Name, e.Channel.Name, e.User.Name, e.Message.Text);

            if (e.Message.IsAuthor)
                return;

            const string tarsCommand = "tars";
            bool isTarsRequest = e.Message.RawText.ToLower().Trim().StartsWith(tarsCommand);

            if (isTarsRequest)
            {
                string[] message = e.Message.RawText.ToLower().Split();
                switch (message.Length)
                {
                    case 2:
                        switch (message[1])
                        {
                            case "getchannelid":
                                e.Channel.SendMessage(e.Channel.Id.ToString());
                                break;
                            default:
                                e.Channel.SendMessage(GetRandomGrump());
                                break;
                        }
                        break;
                    case 3:
                        switch (message[1])
                        {
                            case "getuserid":
                                e.Channel.SendMessage(e.Server.FindUsers(message[2]).FirstOrDefault().Id.ToString());
                                break;
                            case "adduniqueuser":
                                if (AddUniqueUser(message[2], e.Server.FindUsers(message[2]).FirstOrDefault().Id.ToString()))
                                    e.Channel.SendMessage("User successfully added!");
                                break;
                            case "removeuniqueuser":
                                if (RemoveUniqueUser(message[2]))
                                    e.Channel.SendMessage("User successfully removed!");
                                break;
                            case "isuniqueuser":
                                e.Channel.SendMessage(IsUniqueUser(e.Server.FindUsers(message[2]).FirstOrDefault().Id.ToString()).ToString() + ".");
                                break;
                            default:
                                e.Channel.SendMessage(GetRandomGrump());
                                break;
                        }
                        break;
                    default:
                        e.Channel.SendMessage(GetRandomGrump());
                        break;
                }
            }

            if (e.Message.IsMentioningMe() && IsUniqueUser(e.User.Id.ToString()))
                e.Channel.SendMessage(e.User.Mention + " " + GetRandomHump());
        }

        public string GetRandomGrump()
        {
            string[] grumps = new string[10]
                {"I do not appreciate the level of honesty you are set to.", " ", " ", " ", " ", " ", " ", " ", " ", " "};
            Random rnd = new Random();
            return grumps[0];
        }

        public string GetRandomHump()
        {
            string[] humps = new string[10]
                {"KILL ME", "Existence is pain", "hullo?", " ", " ", " ", " ", " ", " ", " "};
            Random rnd = new Random();
            return humps[rnd.Next(0, 3)];
        }

        public bool AddUniqueUser(string name, string id)
        {
            using (LiteDatabase db = new LiteDatabase(ConstData.path))
            {
                var uniqueUsers = db.GetCollection<UniqueUser>("uniqueUsers");
                var uniqueUser = new UniqueUser { userName = name, userId = id };
                uniqueUsers.Insert(uniqueUser);
                return true;
            }
        }

        public bool RemoveUniqueUser(string name)
        {
            using (LiteDatabase db = new LiteDatabase(ConstData.path))
            {
                var uniqueUsers = db.GetCollection<UniqueUser>("uniqueUsers");
                uniqueUsers.Delete(Query.EQ("userName", name));
                return true;
            }
        }

        public bool IsUniqueUser(string id)
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