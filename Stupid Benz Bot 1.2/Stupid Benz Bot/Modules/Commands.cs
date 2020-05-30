using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using Discord.Commands;
using Discord;
using Discord.WebSocket;

namespace Stupid_Benz_Bot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        // Entering "=ping" to show Pong! @People The latency is PingTime ms.
        [Command("ping")]
        public async Task Ping()
        {
            await ReplyAsync("**Pong!** " + Context.Message.Author.Mention + "\n" +
                "The latency is " + "**" + PingTime() + "**" + " ms.");
        }

        public float PingTime()
        {
            string createTime = Context.Message.CreatedAt.Second.ToString()
                + "." + Context.Message.CreatedAt.Millisecond.ToString();
            string Now = DateTime.Now.Second.ToString()
                + "." + DateTime.Now.Millisecond.ToString();
            float cTime = float.Parse(createTime);
            float now = float.Parse(Now);
            float pingTime = Math.Abs((now - cTime) * 1000);
            return pingTime;
        }

        // Entering "=hi" to show Bye @People
        [Command("hi")]
        public async Task Hi()
        {
            await ReplyAsync("Hi " + Context.Message.Author.Mention + "\nWhat's problem??");
        }

        [Command("test")]
        public async Task Test()
        {
            await ReplyAsync(TaskAns());
        }

        public string TaskAns()
        {
            Random rnd = new Random();
            string[] Ans =
            {
                "No Test! You Stupid", "A~~, Who are calling me??"
            };
            string reply = Ans[rnd.Next(Ans.Length)];
            return reply;
        }

        [Command("say")]
        [Summary("Echoes a message.")]
        public Task SayAsync([Remainder][Summary("The text to echo")] string echo)
            => ReplyAsync(echo);

        [Command("sin")]
        [Summary("Enter degree")]
        public Task SinAsync([Remainder][Summary("Enter degree")] double degree)
        {
            double Ans = Math.Sin(degree * Math.PI / 180);
            string ans = Ans.ToString();
            return ReplyAsync(ans);
        }

        [Command("cos")]
        [Summary("Enter degree")]
        public Task CosAsync([Remainder][Summary("Enter degree")] double degree)
        {
            double Ans = Math.Cos(degree * Math.PI / 180);
            string ans = Ans.ToString();
            return ReplyAsync(ans);
        }

        [Command("tan")]
        [Summary("Enter degree")]
        public Task TanAsync([Remainder][Summary("Enter degree")] double degree)
        {
            double Ans = Math.Tan(degree * Math.PI / 180);
            string ans = Ans.ToString();
            return ReplyAsync(ans);
        }

        [Command("surd")]
        [Summary("Enter number")]
        public Task Surd([Remainder][Summary("Enter number")] int num)
        {
            string ans = Math.Sqrt(num).ToString();
            return ReplyAsync(ans);
        }

        [Command("ssurd")]
        [Summary("Enter number")]
        public async Task SimplifiedSurd([Remainder][Summary("Enter number")] int num)
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
    }
}
