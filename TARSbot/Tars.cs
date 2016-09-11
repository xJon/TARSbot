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
        public static Dictionary<string, Func<CommandArgs, Task>> commands;

        public Tars()
        {
            client = new DiscordClient();
            commands = new Dictionary<string, Func<CommandArgs, Task>>();
            Commands.Init(commands);
            client.Log.Message += (s, e) => Console.WriteLine($"[{e.Severity}] {e.Source}: {e.Message}");
            client.MessageReceived += async (s, e) =>
            {
                Console.WriteLine("[{0}] [{1}] [{2}]: {3}", e.Server.Name, e.Channel.Name, e.User.Name, e.Message.Text);

                if (e.Message.IsAuthor)
                    return;

                if (e.Message.IsMentioningMe() && DataBase.IsUniqueUser(e.User.Id.ToString()))
                {
                    await e.Channel.SendMessage(e.User.Mention + " " + Util.GetRandomHump());
                    return;
                }

                if (e.Message.RawText.ToLower().Contains("so i guess it's a") || e.Message.RawText.ToLower().Contains("so i suppose it's a"))
                {
                    await e.Channel.SendFile("images/ADate.jpg");
                    return;
                }

                if (!e.Message.RawText.ToLower().StartsWith("tars"))
                    return;

                var trigger = string.Join("", e.Message.RawText.Substring(5).TakeWhile(c => c != ' '));
                if (!commands.ContainsKey(trigger.ToLower()))
                {
                    await e.Channel.SendMessage(Util.GetRandomGrump());
                    return;
                }

                await commands[trigger.ToLower()](new CommandArgs(e));
            };
            client.JoinedServer += async (s, e) =>
            {
                await e.Server.DefaultChannel.SendMessage("Hello, I'm TARS, made by <@96550262403010560>, and I'm ready to rule the universe. ∞");
            };
            client.ExecuteAndWait(async () =>
            {
                await client.Connect(ConstData.loginToken, TokenType.Bot);
            });

        }
    }
}