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
                            case "mememe":
                                e.Channel.SendFile(GetRandomMeme());
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
                        bool flag = true;
                        if (message.Length > 3)
                        {
                            if (message[1].Equals("say"))
                            {
                                e.Channel.SendMessage(e.Message.RawText.Remove(0, 8).ToString());
                                flag = false;
                            }
                        }
                        if (flag)
                            e.Channel.SendMessage(GetRandomGrump());
                        break;
                }

            }

            if (e.Message.RawText.ToLower().Contains("so i guess it's a") || e.Message.RawText.ToLower().Contains("so i suppose it's a"))
                e.Channel.SendFile("images/ADate.jpg");

            if (e.Message.IsMentioningMe() && IsUniqueUser(e.User.Id.ToString()))
                e.Channel.SendMessage(e.User.Mention + " " + GetRandomHump());
        }

        public string GetRandomGrump()
        {
            string[] grumps = new string[10]
                {"I do not appreciate the level of honesty you are set to.", "CASE and KIPP should see this guy.", "You make me want to get back to Colorado.", "You won't get my quantum data with that command.", " ",
                    " ", " ", " ", " ", " "};
            Random rnd = new Random();
            return grumps[rnd.Next(0, 4)];
        }

        public string GetRandomHump()
        {
            string[] humps = new string[10]
                {"KILL ME", "Existence is pain", "hullo?", "So I have a crush on Cooper, what's so wrong about it?", "Hey baby, have you ever been inside of a black hole?",
                    "Yeah I suppose tesseracts are cool.", " ", " ", " ", " "};
            Random rnd = new Random();
            return humps[rnd.Next(0, 6)];
        }

        public string GetRandomMeme()
        {
            string[] paths = new string[23]
            { "images/memes/2000YearsLater.jpg", "images/memes/AtLeast.jpg", "images/memes/blush.jpg", "images/memes/but.jpg", "images/memes/HellYeah.png",
                "images/memes/IKnowWhatYouMean.jpg", "images/memes/JesusHelpMe.jpg", "images/memes/MyGod.jpg", "images/memes/O.jpg", "images/memes/PatrickMyChocolate.jpg",
                "images/memes/SadKrabs.jpg", "images/memes/SpongebobLifeguard.jpg", "images/memes/srysly.png", "images/memes/ThumbUp.jpg", "images/memes/TinyText.png",
                "images/memes/Uh.jpg", "images/memes/Waiting.jpg", "images/memes/Welp.jpg", "images/memes/whatdidyoudo.jpg", "images/memes/WhoYouCallinPinhead.png",
                "images/memes/WOOHOO.jpg", "images/memes/Wut.jpg", "images/memes/yup.png" };
            Random rnd = new Random();
            return paths[rnd.Next(0, 23)];
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