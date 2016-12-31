using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace TARSbot
{
    class Tars
    {
        private DiscordClient client;
        public static Dictionary<string, Func<CommandArgs, Task>> commands;
        public static string prefix;
        Timer timer;

        public Tars()
        {
            client = new DiscordClient();
            timer = new Timer(UpdateGameTimer, client, 3000, 14400000);
            commands = new Dictionary<string, Func<CommandArgs, Task>>();
            Commands.Init(commands);
            client.Log.Message += (s, e) => Console.WriteLine($"[{e.Severity}] {e.Source}: {e.Message}");
            client.MessageReceived += async (s, e) =>
            {
                if (e.Channel.IsPrivate)
                {
                    CommandArgs dm = new CommandArgs(e);
                    if (dm.Message.RawText.ToLower() == "tars help")
                        await e.Channel.SendMessage(Util.GetInfo());
                    else
                    {
                        ulong id = 0;
                        if (dm.Args.Count() >= 2 && dm.Message.RawText.ToLower().StartsWith("tars getprefix") && ulong.TryParse(dm.Args.ElementAt(1), out id))
                            await e.Channel.SendMessage("That server's prefix is: `" + DataBase.GetServerPrefix(id) + "`");
                    }
                    return;
                }

                Console.WriteLine("[{0}] [{1}] [{2}]: {3}", e.Server.Name, e.Channel.Name, e.User.Name, e.Message.Text);

                if (e.Message.IsAuthor)
                    return;

                if (e.Message.IsMentioningMe() && DataBase.IsUniqueUser(e.User.Id))
                {
                    await e.Channel.SendMessage(e.User.Mention + " " + Util.GetRandomHump());
                    return;
                }

                if (e.Message.RawText.ToLower().Contains("so i guess it's a") || e.Message.RawText.ToLower().Contains("so i suppose it's a"))
                {
                    await e.Channel.SendFile("images/ADate.jpg");
                    return;
                }

                if (e.Message.RawText.ToLower().Equals("ayy"))
                {
                    await e.Channel.SendMessage("lmao");
                    return;
                }

                if (e.Message.RawText.ToLower().StartsWith("present new changes"))
                {
                    await e.Channel.SendMessage("In your lame life nothing has changed.\nAnd it's even sadder when you realize " + e.User.Mention + " made me say it.");
                    return;
                }


                if (e.Message.RawText.ToLower().Equals("tars help"))
                {
                    string currentPrefix = DataBase.GetServerPrefix(e.Server.Id);
                    if (currentPrefix.ToLower() != "tars")
                    {
                        await e.Channel.SendMessage("TARS' prefix for this server is: `" + currentPrefix + "`\nUse `" + currentPrefix + " info`");
                        return;
                    }
                }

                prefix = DataBase.GetServerPrefix(e.Server.Id).Trim().ToLower();
                if (!e.Message.RawText.ToLower().StartsWith(prefix))
                    return;

                var trigger = string.Join("", e.Message.RawText.Substring(prefix.Length + 1).TakeWhile(c => c != ' '));
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
        private static void UpdateGameTimer(object o)
        {
            ((DiscordClient)o).SetGame("TARS help");
            Console.WriteLine("DEBUG: Updated game");
        }
    }
}