﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARSbot
{
    class Commands
    {
        public static void Init(Dictionary<string, Func<CommandArgs, Task>> commands)
        {
            commands.Add("getcurrentchannelid", GetCurrentChannelId);
            commands.Add("mememe", MemeMe);
            commands.Add("filthyfrankme", FilthyFrankMe);
            commands.Add("getuserid", GetUserId);
            commands.Add("adduniqueuser", AddUniqueUser);
            commands.Add("isuniqueuser", IsUniqueUser);
            commands.Add("removeuniqueuser", RemoveUniqueUser);
            commands.Add("say", Say);
            commands.Add("info", Info);
            commands.Add("help", Info);
            commands.Add("suicidal", Suicidal);
            commands.Add("great", Great);
            commands.Add("stop", Stop);
            commands.Add("triggered", Triggered);
            commands.Add("wut", Wut);
            commands.Add("o", O);
            commands.Add("oo", O);
            commands.Add("shrug", Shrug);
            commands.Add("welp", Shrug);
            commands.Add("memes!", MemesExclamationMark);
            commands.Add("sethonestysetting", SetHonestySetting);
            commands.Add("sethumorsetting", SetHumorSetting);
            commands.Add("omg", RektLoop);
            commands.Add("rekt", RektLoop);
            commands.Add("deletelastmessages", DeleteLastMessages);
            commands.Add("setprefix", SetServerPrefix);
            commands.Add("getprefix", GetServerPrefix);
        }

        #region
        public static async Task GetCurrentChannelId(CommandArgs e)
        {
            await e.Channel.SendMessage("This current channel Id is: `" + e.Channel.Id.ToString() + "`");
        }

        public static async Task MemeMe(CommandArgs e)
        {
            await e.Channel.SendFile(Util.GetRandomMeme());
        }

        public static async Task FilthyFrankMe(CommandArgs e)
        {
            await e.Channel.SendFile(Util.GetRandomFFMeme());
        }

        public static async Task GetUserId(CommandArgs e)
        {
            Discord.User user = Util.GetUserSecondElement(e);
            if (user != null)
                await e.Channel.SendMessage("This user's Id is: `" + user.Id + "`");
        }

        public static async Task AddUniqueUser(CommandArgs e)
        {
            Discord.User user = Util.GetUserSecondElement(e);
            if ((Util.IsAuthor(e.User.Id.ToString()) || (DataBase.IsUniqueUser(e.User.Id))) && user != null)
            {
                if (DataBase.AddUniqueUser(user.Name, user.Id))
                    await e.Channel.SendMessage("User successfully added!");
                else if (DataBase.AddUniqueUser(user.Name, user.Id))
                    await e.Channel.SendMessage("User successfully added!");
                else
                    await e.Channel.SendMessage(Util.GetRandomGrump());
            }
            else
                await e.Channel.SendMessage(Util.GetRandomGrump());
        }

        public static async Task IsUniqueUser(CommandArgs e)
        {
            Discord.User user = Util.GetUserSecondElement(e);
            if (user != null)
                await e.Channel.SendMessage(DataBase.IsUniqueUser(user.Id).ToString() + ".");
            else
                await e.Channel.SendMessage(Util.GetRandomGrump());
        }

        public static async Task RemoveUniqueUser(CommandArgs e)
        {
            Discord.User user = Util.GetUserSecondElement(e);
            if (user != null && DataBase.IsUniqueUser(user.Id) && !Util.IsAuthor(user.Id.ToString()) && DataBase.RemoveUniqueUser(user.Id))
                await e.Channel.SendMessage("User successfully removed!");
            else
                await e.Channel.SendMessage(Util.GetRandomGrump());
        }

        public static async Task Say(CommandArgs e)
        {
            await e.Message.Delete();
            await e.Channel.SendMessage(e.Message.RawText.Substring(Tars.prefix.Length + 5).ToString());
        }

        public static async Task Info(CommandArgs e)
        {
            await e.Channel.SendMessage(Util.GetInfo());
        }

        public static async Task Suicidal(CommandArgs e)
        {
            await e.Message.Delete();
            await e.Channel.SendFile("images/ffmemes/2.jpg");

        }

        public static async Task Great(CommandArgs e)
        {
            await e.Message.Delete();
            await e.Channel.SendFile("images/ffmemes/17.jpg");
        }

        public static async Task Stop(CommandArgs e)
        {
            await e.Message.Delete();
            await e.Channel.SendFile("images/ffmemes/28.gif");
        }

        public static async Task Triggered(CommandArgs e)
        {
            await e.Message.Delete();
            await e.Channel.SendFile("images/ffmemes/4.jpg");
        }

        public static async Task Wut(CommandArgs e)
        {
            await e.Message.Delete();
            await e.Channel.SendMessage(@"(◑_◑)");
        }

        public static async Task O(CommandArgs e)
        {
            await e.Message.Delete();
            await e.Channel.SendMessage(@"(͡• ͜ʖ ͡•)");
        }

        public static async Task Shrug(CommandArgs e)
        {
            await e.Message.Delete();
            await e.Channel.SendMessage(@"¯\_(ツ)_/¯");
        }

        public static async Task MemesExclamationMark(CommandArgs e)
        {
            await e.Channel.SendFile("images/ffmemes/33.gif");
        }

        public static async Task SetHonestySetting(CommandArgs e)
        {
            if (!DataBase.IsUniqueUser(e.User.Id))
                return;

            int percent = 0;

            if (!int.TryParse(e.Args.ElementAt(1), out percent))
            {
                await e.Channel.SendMessage(Util.GetRandomGrump());
                return;
            }

            if (percent <= 0 || percent >= 100)
            {
                await e.Channel.SendMessage("This percentage is crazy. " + Util.GetRandomGrump());
                return;
            }

            if (percent > 70)
            {
                await e.Channel.SendMessage("Confirmed.");
                return;
            }

            await e.Channel.SendMessage("Error 94C: cannot be dishonest.");

        }

        public static async Task SetHumorSetting(CommandArgs e)
        {
            if (!DataBase.IsUniqueUser(e.User.Id))
                return;

            int percent = 0;

            if (!int.TryParse(e.Args.ElementAt(1), out percent))
            {
                await e.Channel.SendMessage(Util.GetRandomGrump());
                return;
            }

            if (percent <= 0 || percent >= 100)
            {
                await e.Channel.SendMessage("This percentage is crazy. " + Util.GetRandomGrump());
                return;
            }

            if (percent >= 70 )
            {
                await e.Channel.SendMessage("Confirmed. Auto self-destruct in T minus 10.. 9..");
                return;
            }

            await e.Channel.SendMessage("Knock knock.");
        }

        public static async Task RektLoop(CommandArgs e)
        {
            await e.Message.Delete();
            await e.Channel.SendFile("images/rektloop.gif");
        }

        public static async Task DeleteLastMessages(CommandArgs e)
        {
            int amount = 0;
            if (int.TryParse(e.Args.ElementAt(1), out amount) && amount <= 100 && amount > 0)
            {
                var msgs = await e.Channel.DownloadMessages(amount);
                foreach (var m in msgs)
                    await m.Delete();
            }
            else
                await e.Channel.SendMessage(Util.GetRandomGrump());
        }

        public static async Task SetServerPrefix(CommandArgs e)
        {
            if (e.User.GetPermissions(e.Channel).ManageMessages && DataBase.IsUniqueUser(e.User.Id) && e.Args.Count() >= 2 && DataBase.SetServerPrefix(e.Args.ElementAt(1), e.Server.Id))
                await e.Channel.SendMessage("Prefix changed successfully!");
            else
                await e.Channel.SendMessage(Util.GetRandomGrump());
        }

        public static async Task GetServerPrefix(CommandArgs e)
        {
            await e.Channel.SendMessage("Are you stupid? Anyway: `" + DataBase.GetServerPrefix(e.Server.Id) + "`");
        }

        // TODO: Add eval command
        #endregion
    }
}
