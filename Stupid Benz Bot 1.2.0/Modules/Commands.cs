using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using Discord.Commands;
using Discord;
using Discord.WebSocket;
using Discord.Rest;
using System.Threading.Channels;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace Stupid_Benz_Bot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
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

        //Enter "=hi"
        [Command("hi")]
        public async Task Hi()
        {
            await ReplyAsync("Hi " + Context.Message.Author.Mention + "\nWhat's problem??");
        }

        //Enter "=test"
        [Command("test")]
        public async Task Test()
        {
            await ReplyAsync(TestAns());
        }

        //Test Reply
        public string TestAns()
        {
            Random rnd = new Random();
            string[] Ans =
            {
                "No Test! You Stupid", "A~~, Who are calling me??"
            };
            string reply = Ans[rnd.Next(Ans.Length)];
            return reply;
        }

        //Enter "=say [message]"
        [Command("say")]
        public async Task Say([Remainder] string echo)
        {
            await ReplyAsync(echo);
        }

        [Command("rank")]
        public async Task Rank()
        {
            await ReplyAsync("Link is https://repl.it/@StupidBenz/xpsystem?lite=icon_title_nologo#user.json." +
                "\nThis is an file in json format, Stupid Benz will update it to a html format soon. Please wait for it!");
        }
    }
}
