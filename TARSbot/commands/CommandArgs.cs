using Discord;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TARSbot
{
    class CommandArgs
    {
        public Message Message { get; private set; }
        public Channel Channel { get; private set; }
        public Server Server { get; private set; }
        public User User { get; private set; }

        public IEnumerable<string> Args { get; private set; }

        public CommandArgs(MessageEventArgs e)
        {
            Message = e.Message;
            Channel = e.Channel;
            Server = e.Server;
            User = e.User;

            Args = e.Message.RawText.Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries).Skip(1);
        }
    }
}
