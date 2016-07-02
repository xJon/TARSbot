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
            commands.Add("mememe", Mememe);
            commands.Add("getuserid", GetUserId);
            commands.Add("adduniqueuser", AddUniqueUser);
            commands.Add("isuniqueuser", IsUniqueUser);
            commands.Add("removeuniqueuser", RemoveUniqueUser);
            commands.Add("say", Say);
            commands.Add("info", Info);
        }

        public static async Task GetCurrentChannelId(CommandArgs e)
        {
            await e.Channel.SendMessage("This current channel Id is: `" + e.Channel.Id.ToString() + "`");
        }

        public static async Task Mememe(CommandArgs e)
        {
            await e.Channel.SendFile(Util.GetRandomMeme());
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
            await e.Channel.SendMessage("```∞ TARS ∞\nA bot made by Jon.\nAll the code can be found in GitHub: github.com/xJon/TARSbot \n\n    Bot Prefix is to say Tars at the start of your message\n     It doesn't matter if you use caps for the Prefix or the commands.\n\n    Info\nGives this message, with all the detail on the bot and its commands.\n\n    GetUserId @User\nGives the id of the mentioned user.\n\n    GetCurrentChannelId\nGives the id of the current channel.\n\n    Say\nMakes Tars say anything you want him to.\n\n    MemeMe\nMakes Tars to post a random dank meme.\n\n    AddUniqueUser/RemoveUniqueUser/IsUniqueUser\nAdds/removes a user from the list. Only unique users can add/remove others. IsUniqueUser returns a boolean.```");
        }
    }
}
