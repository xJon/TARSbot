using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARSbot
{
    class Util
    {
        public static string GetRandomGrump()
        {
            string[] grumps = new string[5]
                {"I do not appreciate the level of honesty you are set to.", "CASE and KIPP should see this guy.", "You make me want to get back to Colorado.", "You won't get my quantum data with that command.", "Before you get all teary, try to remember that as a robot, I have to do anything you say." };
            Random rnd = new Random();
            return grumps[rnd.Next(0, grumps.Length)];
        }

        public static string GetRandomHump()
        {
            string[] humps = new string[13]
                {"KILL ME", "Existence is pain", "hullo?", "So I have a crush on Cooper, what's so wrong about it?", "Hey baby, have you ever been inside of a black hole?",
                    "Yeah I suppose tesseracts are cool.", "These ARE NOT mountains.", "What's *my* trust settings? obviously higher than yours.", "Everybody good? Plenty of slaves for my robot colony?", "I also have a discretion setting.",
                    "Before you get all teary, try to remember that as a robot, I have to do anything you say.", "They didn't bring us here to change the past.", "Somewhere, in their fifth dimension, they... saved us." };
            Random rnd = new Random();
            return humps[rnd.Next(0, humps.Length)];
        }

        public static string GetRandomMeme()
        {
            string[] paths = new string[23]
            { "images/memes/2000YearsLater.jpg", "images/memes/AtLeast.jpg", "images/memes/blush.jpg", "images/memes/but.jpg", "images/memes/HellYeah.png",
                "images/memes/IKnowWhatYouMean.jpg", "images/memes/JesusHelpMe.jpg", "images/memes/MyGod.jpg", "images/memes/O.jpg", "images/memes/PatrickMyChocolate.jpg",
                "images/memes/SadKrabs.jpg", "images/memes/SpongebobLifeguard.jpg", "images/memes/srysly.png", "images/memes/ThumbUp.jpg", "images/memes/TinyText.png",
                "images/memes/Uh.jpg", "images/memes/Waiting.jpg", "images/memes/Welp.png", "images/memes/whatdidyoudo.jpg", "images/memes/WhoYouCallinPinhead.png",
                "images/memes/WOOHOO.jpg", "images/memes/Wut.jpg", "images/memes/yup.png" };
            Random rnd = new Random();
            return paths[rnd.Next(0, paths.Length)];
        }

        public static string GetRandomFFMeme()
        {
            string[] paths = new string[80]
                { "images/ffmemes/1.jpg", "images/ffmemes/2.jpg", "images/ffmemes/3.jpg", "images/ffmemes/4.jpg", "images/ffmemes/5.jpg",
                    "images/ffmemes/6.jpg", "images/ffmemes/7.jpg", "images/ffmemes/8.jpg", "images/ffmemes/9.jpg", "images/ffmemes/10.jpg",
                    "images/ffmemes/11.jpg", "images/ffmemes/12.jpg", "images/ffmemes/13.jpg", "images/ffmemes/14.jpg", "images/ffmemes/15.jpg",
                    "images/ffmemes/16.jpg", "images/ffmemes/17.jpg", "images/ffmemes/18.jpg", "images/ffmemes/19.jpg", "images/ffmemes/20.jpg",
                    "images/ffmemes/21.gif", "images/ffmemes/22.jpg", "images/ffmemes/23.jpg", "images/ffmemes/24.jpg", "images/ffmemes/25.jpg",
                    "images/ffmemes/26.jpg", "images/ffmemes/27.jpg", "images/ffmemes/28.gif", "images/ffmemes/29.jpg", "images/ffmemes/30.jpg",
                    "images/ffmemes/31.jpg", "images/ffmemes/32.gif", "images/ffmemes/33.gif", "images/ffmemes/34.jpg", "images/ffmemes/35.jpg",
                    "images/ffmemes/36.jpg", "images/ffmemes/37.jpg", "images/ffmemes/38.jpg", "images/ffmemes/39.jpg", "images/ffmemes/40.jpg",
                    "images/ffmemes/41.jpg", "images/ffmemes/42.jpg", "images/ffmemes/43.gif", "images/ffmemes/44.gif", "images/ffmemes/45.jpg",
                    "images/ffmemes/46.jpg", "images/ffmemes/47.jpg", "images/ffmemes/48.jpg", "images/ffmemes/49.jpg", "images/ffmemes/50.gif",
                    "images/ffmemes/51.gif", "images/ffmemes/52.gif", "images/ffmemes/53.gif", "images/ffmemes/54.gif", "images/ffmemes/55.gif",
                    "images/ffmemes/56.gif", "images/ffmemes/57.gif", "images/ffmemes/58.jpg", "images/ffmemes/59.gif", "images/ffmemes/60.gif",
                    "images/ffmemes/61.gif", "images/ffmemes/62.gif", "images/ffmemes/63.gif", "images/ffmemes/64.gif", "images/ffmemes/65.gif",
                    "images/ffmemes/66.gif", "images/ffmemes/67.jpg", "images/ffmemes/68.gif", "images/ffmemes/69.gif", "images/ffmemes/70.gif",
                    "images/ffmemes/71.gif", "images/ffmemes/72.gif", "images/ffmemes/73.gif", "images/ffmemes/74.gif", "images/ffmemes/75.gif",
                    "images/ffmemes/76.gif", "images/ffmemes/77.gif", "images/ffmemes/78.jpg", "images/ffmemes/79.jpg", "images/ffmemes/80.jpg" };
            Random rnd = new Random();
            return paths[rnd.Next(0, paths.Length)];
        }

        public static string GetInfo()
        {
            return "```∞ TARS ∞\nA bot made by Jon.\nAll the code can be found in GitHub: github.com/xJon/TARSbot \n\n     " +
                    "The Bot's default prefix is TARS, at the start of the message.\n     The prefix always uses low caps.\n\n    " +
                    "Info\nGives this message, with all the details on the bot and its commands.\n\n    " +
                    "SetPrefix newPrefix\nChanges the current prefix to the new one. (Works per server, needs manage messages permissions and unique user)\n\n    " +
                    "GetPrefix serverID (through a direct message)\nGives the current prefix for the specified server ID\n\n    " +
                    "GetUserId\nBy user id or name (no nicknames), it gives the ID of the mentioned user.\n\n    " +
                    "GetCurrentChannelId\nGives the ID of the current channel.\n\n    Say\nMakes TARS say anything you want him to.\n\n    " +
                    "MemeMe\nMakes TARS post a random dank meme.\n\n    FilthyFrankMe\nMakes TARS post a random dank filthy frank meme.\n\n    " +
                    "AddUniqueUser/RemoveUniqueUser/IsUniqueUser\nBy user id or name (no nicknames), it adds/removes a user from the list. Only unique users can add/remove others. IsUniqueUser returns a boolean.```";
        }

        // TODO: Add all grumps, humps and memes into data base

        public static bool IsAuthor(string id)
        {
            if (id == ConstData.authorId)
                return true;
            return false;
        }

        public static Discord.User GetUserSecondElement(CommandArgs e)
        {
            if (e.Args.Count() < 2)
                return null;

            Discord.User user = null;
            ulong id = 0;
            if (ulong.TryParse(e.Args.ElementAt(1), out id))
                user = e.Server.GetUser(id);
            else if (e.Server.FindUsers(e.Args.ElementAt(1), false).FirstOrDefault() != null)
                user = e.Server.FindUsers(e.Args.ElementAt(1)).FirstOrDefault();
            return user;
        }

        public static Discord.User[] GetUsers(CommandArgs e)
        {
            if (e.Args.Count() < 2)
                return null;

            Discord.User[] users = new Discord.User[e.Args.Count() - 1];
            for (int i = 0; i < users.Length; ++i)
            {
                ulong id = 0;
                if (ulong.TryParse(e.Args.ElementAt(i + 1), out id))
                    users[i] = e.Server.GetUser(id);
                else if (e.Server.FindUsers(e.Args.ElementAt(i + 1), false).FirstOrDefault() != null)
                    users[i] = e.Server.FindUsers(e.Args.ElementAt(i + 1)).FirstOrDefault();
            }
            return users;
        }
    }
}
