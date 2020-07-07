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
            var embed = new EmbedBuilder
            {
                Title = "Pong!"
            };
            embed.AddField("Latency", $"The latency is **{PingTime()}** ms.")
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .WithAuthor(Context.Client.CurrentUser);
            await Context.Channel.SendMessageAsync("", false, embed.Build());
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
            await Context.Channel.SendMessageAsync(echo);
        }

        [Command("userinfo")]
        [Alias("user")]
        public async Task UserInfoAsync(SocketUser user = null)
        {
            if (user == null)
            {
                user = Context.User;
            }
            var embed = new EmbedBuilder
            {
                Title = $"{user.Username}'s Info"
            };
            embed.AddField("Name", user.Username)
                .AddField("ID", user.Id)
                .WithImageUrl(user.GetAvatarUrl(ImageFormat.Png, size: 1024))
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .WithAuthor(Context.Client.CurrentUser);
            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }

        [Command("avatar")]
        [Alias("ava")]
        public async Task Avatar(SocketUser user = null, ushort size = 1024)
        {
            if (user == null)
            {
                user = Context.User;
            }
            var userAvatar = user.GetAvatarUrl(ImageFormat.Png, size);
            var embed = new EmbedBuilder();
            embed.WithImageUrl(userAvatar)
                .WithCurrentTimestamp()
                .WithColor(Color.Blue)
                .WithAuthor(Context.Client.CurrentUser)
                .WithTitle(user.Username + "\'s Avatar");
            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }



        [Command("spam")]
        public async Task Spamming(string sentence, int time)
        {
            if (time <= 20)
            {
                int i = 0;
                while (i < time)
                {
                    await ReplyAsync(sentence);
                    i++;
                }
                await ReplyAsync("Finished!");
            }
            else
            {
                await ReplyAsync("Sorry, Stupid Benz's computer **SUX**!!!!");
            }

        }
    }
}
