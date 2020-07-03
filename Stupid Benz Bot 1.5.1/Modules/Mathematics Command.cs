using System;
using System.Threading.Tasks;
using Discord.Commands;

namespace Stupid_Benz_Bot.Modules
{
    public class Mathematics_Commands : ModuleBase<SocketCommandContext>
    {
        //Enter "=sin [degree]"
        [Command("sin")]
        public Task SinAsync([Remainder] float degree)
        {
            string ans = Math.Sin(degree * Math.PI / 180).ToString();
            return ReplyAsync(ans);
        }

        //Enter "=cos [degree]"
        [Command("cos")]
        public Task CosAsync([Remainder] float degree)
        {
            string ans = Math.Cos(degree * Math.PI / 180).ToString();
            return ReplyAsync(ans);
        }

        //Enter "=tan [degree]"
        [Command("tan")]
        public Task TanAsync([Remainder] float degree)
        {
            string ans = Math.Tan(degree * Math.PI / 180).ToString();
            return ReplyAsync(ans);
        }

        //Enter "=surd [integer number]"
        [Command("surd")]
        public async Task Surd([Remainder] int num)
        {
            string ans = Math.Sqrt(num).ToString();
            await ReplyAsync(ans + ", -" + ans);
        }

        //Enter "=ssurd [integer number]"
        [Command("ssurd")]
        public async Task SimplifiedSurd([Remainder] int num)
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
        public async Task Square([Remainder] float num)
        {
            string ans = (num * num).ToString();
            await ReplyAsync(ans);
        }

        [Command("cu")]
        public async Task Cubic([Remainder] float num)
        {
            string ans = (num * num * num).ToString();
            await ReplyAsync(ans);
        }



        [Command("quad")]
        public async Task QuadraticEquation(int a, int b, int c)
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

        [Command("spam")]
        public async Task Spamming(string sentence, int time)
        {
            if (time <= 10)
            {
                int i = 0;
                while(i < time)
                {
                    await ReplyAsync(sentence);
                    i++;
                }
            }
            else
            {
                await ReplyAsync("Sorry, Stupid Benz's computer **sux**!!!!");
            }

        }

        [Command("fac")]
        public async Task Factor(int a)
        {
            int b;
            string result = "";
            for (b = 1; b <= a; b++)
            {
                if (a % b == 0)
                {
                    result += (b + ", ");
                }
            }
            result = result.Remove(result.Length - 2);
            await ReplyAsync(result);

        }

        [Command("pf")]
        public async Task PrimeFactor(int a)
        {

            int b;
            string result = "";
            for (b = 2; a > 1; b++)
            {
                if (a % b == 0)
                {
                    int x = 0;
                    while (a % b == 0)
                    {
                        a /= b;
                        x++;
                    }
                    result += (b.ToString() + " x " + x.ToString() + ", ");
                }
            }
            result = result.Remove(result.Length - 2);
            await ReplyAsync(result);
        }
    }
}
