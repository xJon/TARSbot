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
                "images/memes/Uh.jpg", "images/memes/Waiting.jpg", "images/memes/Welp.png", "images/memes/whatdidyoudo.jpg", "images/memes/WhoYouCallinPinhead.png",
                "images/memes/WOOHOO.jpg", "images/memes/Wut.jpg", "images/memes/yup.png" };
            Random rnd = new Random();
            return paths[rnd.Next(0, 23)];
        }

        public static string GetRandomFFMeme()
        {
            string[] paths = new string[31]
                { "images/ffmemes/1.jpg", "images/ffmemes/2.jpg", "images/ffmemes/3.jpg", "images/ffmemes/4.jpg", "images/ffmemes/5.jpg",
                    "images/ffmemes/6.jpg", "images/ffmemes/7.jpg", "images/ffmemes/8.jpg", "images/ffmemes/9.jpg", "images/ffmemes/10.jpg",
                    "images/ffmemes/11.jpg", "images/ffmemes/12.jpg", "images/ffmemes/13.jpg", "images/ffmemes/14.jpg", "images/ffmemes/15.jpg",
                    "images/ffmemes/16.jpg", "images/ffmemes/17.jpg", "images/ffmemes/18.jpg", "images/ffmemes/19.jpg", "images/ffmemes/20.jpg",
                    "images/ffmemes/21.gif", "images/ffmemes/22.jpg", "images/ffmemes/23.jpg", "images/ffmemes/24.jpg", "images/ffmemes/25.jpg",
                    "images/ffmemes/26.jpg", "images/ffmemes/27.jpg", "images/ffmemes/28.gif", "images/ffmemes/29.jpg", "images/ffmemes/30.jpg", "images/ffmemes/31.jpg", };
            Random rnd = new Random();
            return paths[rnd.Next(0, 31)];
        }
    }
}
