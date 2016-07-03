using System;
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
            commands.Add("suicidal", Suicidal);
            commands.Add("great", Great);
            commands.Add("stop", Stop);
            commands.Add("triggered", Triggered);
            commands.Add("wut", Wut);
            commands.Add("o", O);
            commands.Add("oo", O);
            commands.Add("shrug", Shrug);
            commands.Add("welp", Shrug);
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
            await e.Channel.SendMessage("This user's Id is: `" + e.Server.FindUsers(e.Args.ElementAt(1)).FirstOrDefault().Id.ToString() + "`");
        }

        public static async Task AddUniqueUser(CommandArgs e)
        {
             if (DataBase.IsUniqueUser(e.User.Id.ToString()) && DataBase.AddUniqueUser(e.Args.ElementAt(1), e.Server.FindUsers(e.Args.ElementAt(1)).FirstOrDefault().Id.ToString()))
                await e.Channel.SendMessage("User successfully added!");
        }

        public static async Task IsUniqueUser(CommandArgs e)
        {
            await e.Channel.SendMessage(DataBase.IsUniqueUser(e.Server.FindUsers(e.Args.ElementAt(1)).FirstOrDefault().Id.ToString()).ToString() + ".");
        }

        public static async Task RemoveUniqueUser(CommandArgs e)
        {
            if (DataBase.IsUniqueUser(e.User.Id.ToString()) && DataBase.RemoveUniqueUser(e.Args.ElementAt(1)))
                await e.Channel.SendMessage("User successfully removed!");
        }

        public static async Task Say(CommandArgs e)
        {
            await e.Channel.SendMessage(e.Message.RawText.Remove(0, 8).ToString());
        }

        public static async Task Info(CommandArgs e)
        {
            await e.Channel.SendMessage("```∞ TARS ∞\nA bot made by Jon.\nAll the code can be found in GitHub: github.com/xJon/TARSbot \n\n    Bot Prefix is to say Tars at the start of your message\n     It doesn't matter if you use caps for the Prefix or the commands.\n\n    Info\nGives this message, with all the detail on the bot and its commands.\n\n    GetUserId @User\nGives the id of the mentioned user.\n\n    GetCurrentChannelId\nGives the id of the current channel.\n\n    Say\nMakes Tars say anything you want him to.\n\n    MemeMe\nMakes Tars  post a random dank meme.\n\n    FilthyFrankMe\nMakes Tars post a random dank filthy frank meme.\n\n    AddUniqueUser/RemoveUniqueUser/IsUniqueUser\nAdds/removes a user from the list. Only unique users can add/remove others. IsUniqueUser returns a boolean.```");
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
        #endregion
    }
}
