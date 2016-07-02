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
            string[] grumps = new string[10]
                {"I do not appreciate the level of honesty you are set to.", "CASE and KIPP should see this guy.", "You make me want to get back to Colorado.", "You won't get my quantum data with that command.", " ",
                    " ", " ", " ", " ", " "};
            Random rnd = new Random();
            return grumps[rnd.Next(0, 4)];
        }

        public static string GetRandomHump()
        {
            string[] humps = new string[10]
                {"KILL ME", "Existence is pain", "hullo?", "So I have a crush on Cooper, what's so wrong about it?", "Hey baby, have you ever been inside of a black hole?",
                    "Yeah I suppose tesseracts are cool.", " ", " ", " ", " "};
            Random rnd = new Random();
            return humps[rnd.Next(0, 6)];
        }

        public static string GetRandomMeme()
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
    }
}
