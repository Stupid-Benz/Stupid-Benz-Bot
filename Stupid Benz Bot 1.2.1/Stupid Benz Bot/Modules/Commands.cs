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

namespace Stupid_Benz_Bot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        //Enter "=ping"
        [Command("ping")]
        public async Task Ping()
        {
            
            await ReplyAsync("**Pong!** " + Context.Message.Author.Mention + "\n" +
                "The latency is " + "**" + "Cant Use This Function, " +
                "Please wait until @Stupid Benz back first" + "**" + " ms.");
        }
        

        //Counting Ping Time
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
        [Summary("Echoes a message.")]
        public async Task Say([Remainder][Summary("The text to echo")] string echo)
        {
            await ReplyAsync(echo);
        }

        //Enter "=sin [degree]"
        [Command("sin")]
        [Summary("Enter degree")]
        public Task SinAsync([Remainder][Summary("Enter degree")] float degree)
        {
            string ans = Math.Sin(degree * Math.PI / 180).ToString();
            return ReplyAsync(ans);
        }

        //Enter "=cos [degree]"
        [Command("cos")]
        [Summary("Enter degree")]
        public Task CosAsync([Remainder][Summary("Enter degree")] float degree)
        {
            string ans = Math.Cos(degree * Math.PI / 180).ToString();
            return ReplyAsync(ans);
        }

        //Enter "=tan [degree]"
        [Command("tan")]
        [Summary("Enter degree")]
        public Task TanAsync([Remainder][Summary("Enter degree")] float degree)
        {
            string ans = Math.Tan(degree * Math.PI / 180).ToString();
            return ReplyAsync(ans);
        }

        //Enter "=surd [integer number]"
        [Command("surd")]
        [Summary("Enter number")]
        public async Task Surd([Remainder][Summary("Enter a number")] int num)
        {
            string ans = Math.Sqrt(num).ToString();
            await ReplyAsync(ans + ", -" + ans);
        }

        //Enter "=ssurd [integer number]"
        [Command("ssurd")]
        [Summary("Enter a number")]
        public async Task SimplifiedSurd([Remainder][Summary("Enter a number")] int num)
        {
            await ReplyAsync(Sqrt2(num).ToString());
        }

        public static (int, int) Sqrt2(int n)
        {
            int m = 1, d = 2;

            int dSquared;
            while ((dSquared = d * d) <= n)
            {
                while ((n % dSquared) == 0)
                {
                    n /= dSquared;
                    m *= d;
                }
                d++;
            }

            return (m, n);
        }

        [Command("sq")]
        [Summary("Enter a number")]
        public async Task Square([Remainder][Summary("Enter a number")] float num)
        {
            string ans = (num * num).ToString();
            await ReplyAsync(ans);
        }

        [Command("cu")]
        [Summary("Enter a number")]
        public async Task Cubic([Remainder][Summary("Enter a number")] float num)
        {
            string ans = (num * num * num).ToString();
            await ReplyAsync(ans);
        }



        [Command("quad")]
        public async Task QuadraticReply(int a, int b, int c)
        {
            string vertixx = (-b / (2 * a)).ToString();
            string vertixy = (c - b * b / (4 * a)).ToString();
            float delta = (b * b - 4 * a * c);
            string ans1 = ((-b + Math.Sqrt(delta)) / (2 * a)).ToString();
            string ans2 = ((-b - Math.Sqrt(delta)) / (2 * a)).ToString();
            if (ans1 == "NaN")
            {
                await ReplyAsync("(" + vertixx + ", " + vertixy
                    + "), " + delta.ToString()
                    + ", Math Error");
            }
            else if (ans1 == ans2)
            {
                await ReplyAsync("(" + vertixx + ", " + vertixy
                    + "), " + delta.ToString()
                    + ", " + ans1);
            }
            else
            {
                await ReplyAsync("(" + vertixx + ", " + vertixy
                    + "), " + delta.ToString()
                    + ", " + ans1 + " or " + ans2);
            }
        }
    }
}
