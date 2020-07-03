using System;
using System.Threading.Tasks;
using Discord.Commands;
using Discord;
using Discord.WebSocket;

namespace Stupid_Benz_Bot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        [Alias("Ping")]
        public async Task Ping()
        {
            await ReplyAsync("**Pong!** " + Context.Message.Author.Mention + "\n" +
                "The latency is " + "**" + PingTime() + "**" + " ms.");
        }

        public string PingTime()
        {
            string cSec = Context.Message.Timestamp.Second.ToString();
            string cMs = Context.Message.Timestamp.Millisecond.ToString();
            string nSec = DateTime.Now.Second.ToString();
            string nMs = DateTime.Now.Millisecond.ToString();
            float cTime = float.Parse(cSec) * 1000
                + float.Parse(cMs);
            float nTime = float.Parse(nSec) * 1000
                + float.Parse(nMs);
            string pingTime = (nTime - cTime).ToString();
            return pingTime;
        }

        //Enter "=test"
        [Command("test")]
        [Alias("Test")]
        public async Task Test()
        {
            Random rnd = new Random();
            string[] Ans =
            {
                "No Test! You Stupid ", "Once upon a time, there have **NO TEST** "
            };
            string reply = Ans[rnd.Next(Ans.Length)];
            await ReplyAsync(reply + Context.Message.Author.Mention);
        }

        //Enter "=say [message]"
        [Command("say")]
        [Alias("Say")]
        public async Task Say([Remainder] string echo)
        {
            await ReplyAsync(echo);
        }

        [Command("userinfo")]
        [Alias("user")]
        public async Task UserInfoAsync(SocketUser user = null)
        {
            if (user == null)
            {
                user = Context.User;
            }
            var userInfo = user ?? Context.Client.CurrentUser;
            await ReplyAsync($"{userInfo.Username}#{userInfo.Discriminator}");
        }

        [Command("avatar")]
        [Alias("ava")]
        public async Task Avatar(SocketUser user = null, ushort size = 1024)
        {
            if (user == null)
            {
                user = Context.User;
            }
            var userAvatar = user.GetAvatarUrl(ImageFormat.Auto, size);
            await ReplyAsync($"{user}\n{userAvatar}");
        }
    }
}
