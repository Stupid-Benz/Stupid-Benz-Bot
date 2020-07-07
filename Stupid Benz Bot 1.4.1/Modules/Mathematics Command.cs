using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace Stupid_Benz_Bot.Modules
{
    public class Mathematics_Commands : ModuleBase<SocketCommandContext>
    {
        //Enter "=sin [degree]"
        [Command("sin")]
        [Alias("sine")]
        public Task SinAsync([Remainder] float degree)
        {
            string ans = Math.Sin(degree * Math.PI / 180).ToString();
            var embed = new EmbedBuilder { };
            embed.AddField($"Sine {degree}", $"= **{ans}**")
                .WithAuthor(Context.Client.CurrentUser)
                .WithCurrentTimestamp()
                .WithColor(Color.Blue);
            return ReplyAsync("", false, embed.Build());
        }

        //Enter "=cos [degree]"
        [Command("cos")]
        [Alias("cosine")]
        public Task CosAsync([Remainder] float degree)
        {
            string ans = Math.Cos(degree * Math.PI / 180).ToString();
            var embed = new EmbedBuilder { };
            embed.AddField($"Cosine {degree}", $"= **{ans}**")
                .WithAuthor(Context.Client.CurrentUser)
                .WithCurrentTimestamp()
                .WithColor(Color.Blue);
            return ReplyAsync("", false, embed.Build());
        }

        //Enter "=tan [degree]"
        [Command("tan")]
        [Alias("tangent")]
        public Task TanAsync([Remainder] float degree)
        {
            string ans = Math.Tan(degree * Math.PI / 180).ToString();
            var embed = new EmbedBuilder { };
            embed.AddField($"Tangent {degree}", $"= **{ans}**")
                .WithAuthor(Context.Client.CurrentUser)
                .WithCurrentTimestamp()
                .WithColor(Color.Blue);
            return ReplyAsync("", false, embed.Build());
        }

        //Enter "=surd [integer number]"
        [Command("surd")]
        public async Task Surd([Remainder] int num)
        {
            string ans = Math.Sqrt(num).ToString();
            var embed = new EmbedBuilder { };
            embed.AddField($"√{num}", $"= **{ans}**")
                .WithAuthor(Context.Client.CurrentUser)
                .WithCurrentTimestamp()
                .WithColor(Color.Blue);
            await ReplyAsync("", false, embed.Build());
        }

        //Enter "=ssurd [integer number]"
        [Command("ssurd")]
        [Alias("simplifysurd")]
        public async Task SimplifiedSurd([Remainder] int num)
        {
            var embed = new EmbedBuilder { };
            embed.AddField($"Simplify √{num}", $"= **{Sqrt2(num)}**")
                .WithAuthor(Context.Client.CurrentUser)
                .WithCurrentTimestamp()
                .WithColor(Color.Blue);
            await ReplyAsync("", false, embed.Build());
        }

        public static string Sqrt2(int n)
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

            return $"{m.ToString()}√{n.ToString()}";
        }

        [Command("sq")]
        [Alias("square")]
        public async Task Square([Remainder] float num)
        {
            string ans = (num * num).ToString();
            var embed = new EmbedBuilder { };
            embed.AddField($"{num}²", $"= **{ans}**")
                .WithAuthor(Context.Client.CurrentUser)
                .WithCurrentTimestamp()
                .WithColor(Color.Blue);
            await ReplyAsync("", false, embed.Build());
        }

        [Command("cu")]
        [Alias("cubic")]
        public async Task Cubic([Remainder] float num)
        {
            string ans = (num * num * num).ToString();
            var embed = new EmbedBuilder { };
            embed.AddField($"{num}³", $"= **{ans}**")
                .WithAuthor(Context.Client.CurrentUser)
                .WithCurrentTimestamp()
                .WithColor(Color.Blue);
            await ReplyAsync("", false, embed.Build());
        }



        [Command("quad")]
        [Alias("quadratic")]
        public async Task QuadraticEquation(int a, int b, int c)
        {
            string vertixx = (-b / (2 * a)).ToString();
            string vertixy = (c - b * b / (4 * a)).ToString();
            float delta = (b * b - 4 * a * c);
            string ans1 = ((-b + Math.Sqrt(delta)) / (2 * a)).ToString();
            string ans2 = ((-b - Math.Sqrt(delta)) / (2 * a)).ToString();
            if (ans1 == "NaN")
            {
                var embed = new EmbedBuilder { };
                embed.AddField($"X point of the Curve Vertix", $"= **{vertixx}**")
                    .AddField($"Y point of the Curve Vertix", $"= **{vertixy}**")
                    .AddField($"Delta", $"= **{delta}**")
                    .AddField($"X", "= **Math Error**")
                    .WithAuthor(Context.Client.CurrentUser)
                    .WithCurrentTimestamp()
                    .WithColor(Color.Blue);
                await ReplyAsync("", false, embed.Build());
            }
            else if (ans1 == ans2)
            {
                var embed = new EmbedBuilder { };
                embed.AddField($"X point of the Curve Vertix", $"= **{vertixx}**")
                    .AddField($"Y point of the Curve Vertix", $"= **{vertixy}**")
                    .AddField($"Delta", $"= **{delta}**")
                    .AddField($"X", $"= **{ans1}**")
                    .WithAuthor(Context.Client.CurrentUser)
                    .WithCurrentTimestamp()
                    .WithColor(Color.Blue);
                await ReplyAsync("", false, embed.Build());
            }
            else
            {
                var embed = new EmbedBuilder { };
                embed.AddField($"X point of the Curve Vertix", $"= **{vertixx}**")
                    .AddField($"Y point of the Curve Vertix", $"= **{vertixy}**")
                    .AddField($"Delta", $"= **{delta}**")
                    .AddField($"X₁", $"= **{ans1}**")
                    .AddField($"X₂", $"= **{ans2}**")
                    .WithAuthor(Context.Client.CurrentUser)
                    .WithCurrentTimestamp()
                    .WithColor(Color.Blue);
                await ReplyAsync("", false, embed.Build());
            }
        }

        [Command("fac")]
        [Alias("factor")]
        public async Task Factor(int a)
        {
            int b;
            string result = "";
            for (b = 1; b <= a; b++)
            {
                if (a % b == 0)
                {
                    result += ($"**{b}**, ");
                }
            }
            result = result.Remove(result.Length - 2);
            var embed = new EmbedBuilder { };
            embed.AddField($"{a}\'s Factors", $"{result}")
                .WithAuthor(Context.Client.CurrentUser)
                .WithCurrentTimestamp()
                .WithColor(Color.Blue);
            await ReplyAsync("", false, embed.Build());

        }

        [Command("pf")]
        [Alias("primefactorize", "primefactorization")]
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
                    result += ($"{b.ToString()} x {x.ToString()} x ");
                }
            }
            result = result.Remove(result.Length - 3);
            var embed = new EmbedBuilder { };
            embed.AddField($"{a}\'s Prime Factors", $"{result}")
                .WithAuthor(Context.Client.CurrentUser)
                .WithCurrentTimestamp()
                .WithColor(Color.Blue);
            await ReplyAsync("", false, embed.Build());
            await ReplyAsync(result);
        }
    }
}
