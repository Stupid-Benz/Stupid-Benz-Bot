using System;
using System.Collections.Generic;
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
        public async Task Sine(float degree, string mode = "d")
        {
            try
            {
                mode = mode.ToLower();
                switch (mode)
                {
                    case "r":
                        try
                        {
                            string ans = Math.Sin(degree).ToString();
                            var embed = new EmbedBuilder { };
                            embed.AddField($"Sine {degree}", $"= **{ans}**")
                                .WithAuthor(Context.Client.CurrentUser)
                                .WithCurrentTimestamp()
                                .WithColor(Color.Blue);
                            await ReplyAsync("", false, embed.Build());
                        }
                        catch (Exception e)
                        {
                            await ReplyAsync("```" + e.ToString() + "```");
                        }
                        break;
                    case "d":
                        try
                        {
                            string ans = Math.Sin(degree * Math.PI / 180).ToString();
                            var embed = new EmbedBuilder { };
                            embed.AddField($"Sine {degree}", $"= **{ans}**")
                                .WithAuthor(Context.Client.CurrentUser)
                                .WithCurrentTimestamp()
                                .WithColor(Color.Blue);
                            await ReplyAsync("", false, embed.Build());
                        }
                        catch (Exception e)
                        {
                            await ReplyAsync("```" + e.ToString() + "```");
                        }
                        break;
                    default:
                        throw new ArgumentException("System.ArgumentException: Only have r(radian) and d(degree) mode");
                }
            }
            catch (Exception e)
            {
                await Context.Channel.SendMessageAsync($"```{e.ToString()}```");
            }
        }

        //Enter "=cos [degree]"
        [Command("cos")]
        [Alias("cosine")]
        public async Task Cosine(float degree, string mode = "d")
        {
            try
            {
                mode = mode.ToLower();
                switch (mode)
                {
                    case "r":
                        try
                        {
                            string ans = Math.Cos(degree).ToString();
                            var embed = new EmbedBuilder { };
                            embed.AddField($"Cosine {degree}", $"= **{ans}**")
                                .WithAuthor(Context.Client.CurrentUser)
                                .WithCurrentTimestamp()
                                .WithColor(Color.Blue);
                            await ReplyAsync("", false, embed.Build());
                        }
                        catch (Exception e)
                        {
                            await ReplyAsync("```" + e.ToString() + "```");
                        }
                        break;
                    case "d":
                        try
                        {
                            string ans = Math.Cos(degree * Math.PI / 180).ToString();
                            var embed = new EmbedBuilder { };
                            embed.AddField($"Cosine {degree}", $"= **{ans}**")
                                .WithAuthor(Context.Client.CurrentUser)
                                .WithCurrentTimestamp()
                                .WithColor(Color.Blue);
                            await ReplyAsync("", false, embed.Build());
                        }
                        catch (Exception e)
                        {
                            await ReplyAsync("```" + e.ToString() + "```");
                        }
                        break;
                    default:
                        throw new ArgumentException("System.ArgumentException: Only have r(radian) and d(degree) mode");
                }
            }
            catch (Exception e)
            {
                await Context.Channel.SendMessageAsync($"```{e.ToString()}```");
            }
        }

        //Enter "=tan [degree]"
        [Command("tan")]
        [Alias("tangent")]
        public async Task TanAsync(float degree, string mode = "d")
        {
            try
            {
                mode = mode.ToLower();
                switch (mode)
                {
                    case "r":
                        try
                        {
                            string ans = Math.Tan(degree * Math.PI / 180).ToString();
                            var embed = new EmbedBuilder { };
                            embed.AddField($"Tangent {degree}", $"= **{ans}**")
                                .WithAuthor(Context.Client.CurrentUser)
                                .WithCurrentTimestamp()
                                .WithColor(Color.Blue);
                            await ReplyAsync("", false, embed.Build());
                        }
                        catch (Exception e)
                        {
                            await ReplyAsync("```" + e.ToString() + "```");
                        }
                        break;
                    case "d":
                        try
                        {
                            string ans = Math.Tan(degree * Math.PI / 180).ToString();
                            var embed = new EmbedBuilder { };
                            embed.AddField($"Tangent {degree}", $"= **{ans}**")
                                .WithAuthor(Context.Client.CurrentUser)
                                .WithCurrentTimestamp()
                                .WithColor(Color.Blue);
                            await ReplyAsync("", false, embed.Build());
                        }
                        catch (Exception e)
                        {
                            await ReplyAsync("```" + e.ToString() + "```");
                        }
                        break;
                    default:
                        throw new ArgumentException("Only have r(radian) and d(degree) mode");
                }
            }
            catch (Exception e)
            {
                await Context.Channel.SendMessageAsync($"```{e.ToString()}```");
            }
        }

        //Enter "=surd [integer number]"
        [Command("surd")]
        public async Task Surd(int num, int times = 1)
        {
            try
            {
                double ans = Math.Sqrt(num);
                var embed = new EmbedBuilder { };
                if (times == 1)
                {
                    embed.AddField($"√{num}", $"= **{ans}**")
                        .WithAuthor(Context.Client.CurrentUser)
                        .WithCurrentTimestamp()
                        .WithColor(Color.Blue);
                }
                else
                {

                    embed.AddField($"{times}√{num}", $"= **{ans * times}**")
                        .WithAuthor(Context.Client.CurrentUser)
                        .WithCurrentTimestamp()
                        .WithColor(Color.Blue);
                }
                await ReplyAsync("", false, embed.Build());
            }
            catch (Exception e)
            {
                await Context.Channel.SendMessageAsync($"```{e.ToString()}```");
            }
        }

        //Enter "=ssurd [integer number]"
        [Command("ssurd")]
        [Alias("simplifysurd")]
        public async Task SimplifiedSurd([Remainder] int num)
        {
            try
            {
                var embed = new EmbedBuilder { };
                embed.AddField($"Simplify √{num}", $"= **{Sqrt2(num)}**")
                    .WithAuthor(Context.Client.CurrentUser)
                    .WithCurrentTimestamp()
                    .WithColor(Color.Blue);
                await ReplyAsync("", false, embed.Build());
            }
            catch (Exception e)
            {
                await Context.Channel.SendMessageAsync($"```{e.ToString()}```");
            }
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
            try
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
                    throw new ArithmeticException("Math Error");
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
            catch (Exception e)
            {
                await ReplyAsync("```" + e.ToString() + "```");
            }
        }

        [Command("fac")]
        [Alias("factor")]
        public async Task Factor(double number)
        {
            try
            {
                string factors = "";
                double max = Math.Sqrt(number);
                for (int factor = 1; factor <= max; ++factor)
                {
                    if (number % factor == 0)
                    {
                        factors += $"**{factor.ToString()}**, ";
                        if (factor != number / factor)
                        {
                            factors += $"**{(number / factor).ToString()}**, ";
                        }
                    }
                }
                factors = factors.Remove(factors.Length - 2);
                var embed = new EmbedBuilder { };
                embed.AddField($"{number}\'s Factors", $"{factors}")
                    .WithAuthor(Context.Client.CurrentUser)
                    .WithCurrentTimestamp()
                    .WithColor(Color.Blue);
                await ReplyAsync("", false, embed.Build());
            }
            catch (Exception e)
            {
                await ReplyAsync("```" + e.ToString() + "```");
            }
        }

        [Command("pf")]
        [Alias("primefactorize", "primefactorization")]
        public async Task PrimeFactor(double num)
        {
            try
            {
                double a = num;
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
                        result += ($"**{b.ToString()}** x **{x.ToString()}** x ");
                    }
                }
                result = result.Remove(result.Length - 3);
                var embed = new EmbedBuilder { };
                embed.AddField($"{num}\'s Prime Factors", $"{result}")
                    .WithAuthor(Context.Client.CurrentUser)
                    .WithCurrentTimestamp()
                    .WithColor(Color.Blue);
                await ReplyAsync("", false, embed.Build());
            }
            catch (Exception e)
            {
                await ReplyAsync("```" + e.ToString() + "```");
            }
        }

        [Command("identity")]
        public async Task Identity()
        {
            var embed = new EmbedBuilder
            {
                Title = "Identity"
            };
            embed.AddField("First Identity", "(a + b)² ≡ a² + 2ab + b²")
                .AddField("Sencond Identity", "(a + b)³ ≡ a³ + b³ + 3ab(a + b) ≡  a³ + 3a²b + 3ab² + b³")
                .AddField("Third Identity", "a² - b² ≡ (a + b)(a - b)")
                .AddField("Fourth Identity", "(a - b)² ≡ a² - 2ab + b²")
                .AddField("Fifth Identity", "(a - b)³ ≡ a³ - b³ - 3ab(a - b) ≡ a³ - 3a²b + 3ab² - b³")
                .AddField("Sixth Identity", "a³ - b³ ≡ (a - b)(a + b)² ≡ (a - b)(a² + 2ab + b²)")
                .AddField("Seventh Identity", "a³ + b³ ≡ (a + b)(a - b)² ≡ (a + b)(a² + 2ab - b²)")
                .WithColor(Color.Blue)
                .WithAuthor(Context.Client.CurrentUser)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }

        [Command("!")]
        [Alias("factorial")]
        public async Task Factorial(int num)
        {
            try
            {
                if (num < 0)
                {
                    throw new ArithmeticException("Math Error");
                }
                else
                {
                    string ans = Fac(num).ToString().ToLower();
                    var embed = new EmbedBuilder { };
                    embed.AddField($"{num}!", $"=**{ans}**")
                        .WithColor(Color.Blue)
                        .WithAuthor(Context.Client.CurrentUser)
                        .WithCurrentTimestamp();
                    await ReplyAsync("", false, embed.Build());
                }
            }
            catch (Exception e)
            {
                await Context.Channel.SendMessageAsync($"```{e.ToString()}```");
            }
        }

        [Command("nCr")]
        [Alias("Combinations")]
        public async Task nCr(int n, int r)
        {
            try
            {
                string ans = (Fac(n) / (Fac(r) * Fac(n - r))).ToString();
                if (n < r || ans == "NaN")
                {
                    throw new ArithmeticException("Math Error");
                }
                else
                {
                    var embed = new EmbedBuilder { };
                    embed.AddField($"C({n}, {r})", $"=**{ans}**")
                        .WithColor(Color.Blue)
                        .WithAuthor(Context.Client.CurrentUser)
                        .WithCurrentTimestamp();
                    await ReplyAsync("", false, embed.Build());
                }
            }
            catch (Exception e)
            {
                await Context.Channel.SendMessageAsync($"```{e.ToString()}```");
            }
        }

        [Command("nPr")]
        [Alias("Permutations")]
        public async Task nPr(int n, int r)
        {
            try
            {
                string ans = (Fac(n) / Fac(n - r)).ToString();
                if (n < r || ans == "NaN")
                {
                    throw new ArithmeticException("Math Error");
                }
                else
                {
                    var embed = new EmbedBuilder { };
                    embed.AddField($"P({n}, {r})", $"=**{ans}**")
                        .WithColor(Color.Blue)
                        .WithAuthor(Context.Client.CurrentUser)
                        .WithCurrentTimestamp();
                    await ReplyAsync("", false, embed.Build());
                }
            }
            catch (Exception e)
            {
                await Context.Channel.SendMessageAsync($"```{e.ToString()}```");
            }
        }

        [Command("base16")]
        [Alias("16")]
        public async Task Base16(string basenum, string mode = "10")
        {
            try
            {
                switch (mode)
                {
                    case "10":
                        try
                        {
                            int number = Convert.ToInt32(basenum);
                            string ans = Convert.ToString(number, 16).ToUpper();
                            if (ans != "∞")
                            {
                                var embed = new EmbedBuilder { };
                                embed.AddField($"{basenum}₁₀ to Base 16", $"=**{ans}₁₆**")
                                    .WithColor(Color.Blue)
                                    .WithAuthor(Context.Client.CurrentUser)
                                    .WithCurrentTimestamp();
                                await ReplyAsync("", false, embed.Build());
                            }
                            else
                            {
                                var embed = new EmbedBuilder { };
                                embed.AddField($"{basenum}₁₀ to Base 16", $"=**∞**")
                                    .WithColor(Color.Blue)
                                    .WithAuthor(Context.Client.CurrentUser)
                                    .WithCurrentTimestamp();
                                await ReplyAsync("", false, embed.Build());
                            }
                        }
                        catch (Exception e)
                        {
                            await Context.Channel.SendMessageAsync($"```{e.ToString()}```");
                        }
                        break;
                    case "2":
                        try
                        {
                            int number = Convert.ToInt32(basenum, 2);
                            string ans = Convert.ToString(number, 16).ToUpper();
                            if (ans != "∞")
                            {
                                var embed = new EmbedBuilder { };
                                embed.AddField($"{basenum}₁₀ to Base 16", $"=**{ans}₁₆**")
                                    .WithColor(Color.Blue)
                                    .WithAuthor(Context.Client.CurrentUser)
                                    .WithCurrentTimestamp();
                                await ReplyAsync("", false, embed.Build());
                            }
                            else
                            {
                                var embed = new EmbedBuilder { };
                                embed.AddField($"{basenum}₁₀ to Base 16", $"=**∞**")
                                    .WithColor(Color.Blue)
                                    .WithAuthor(Context.Client.CurrentUser)
                                    .WithCurrentTimestamp();
                                await ReplyAsync("", false, embed.Build());
                            }
                        }
                        catch (Exception e)
                        {
                            await Context.Channel.SendMessageAsync($"```{e.ToString()}```");
                        }
                        break;
                    default:
                        throw new ArgumentException("Only have 2(base 2) and 10(base 10) mode");
                }
            }
            catch (Exception e)
            {
                await Context.Channel.SendMessageAsync($"```{e.ToString()}```");
            }
        }

        [Command("base2")]
        [Alias("2")]
        public async Task Base2(string basenum, string mode = "10")
        {
            try
            {
                switch (mode)
                {
                    case "10":
                        try
                        {
                            int number = Convert.ToInt32(basenum);
                            string ans = Convert.ToString(number, 2).ToString();
                            if (ans.ToString() != "∞")
                            {
                                var embed = new EmbedBuilder { };
                                embed.AddField($"{number}₁₀ to Base 2", $"=**{ans}₂**")
                                    .WithColor(Color.Blue)
                                    .WithAuthor(Context.Client.CurrentUser)
                                    .WithCurrentTimestamp();
                                await ReplyAsync("", false, embed.Build());
                            }
                            else
                            {
                                var embed = new EmbedBuilder { };
                                embed.AddField($"{number}₁₀ to Base 2", $"=**∞**")
                                    .WithColor(Color.Blue)
                                    .WithAuthor(Context.Client.CurrentUser)
                                    .WithCurrentTimestamp();
                                await ReplyAsync("", false, embed.Build());
                            }
                        }
                        catch (Exception e)
                        {
                            await ReplyAsync("```" + e.ToString() + "```");
                        }
                        break;
                    case "16":
                        try
                        {
                            int number = Convert.ToInt32(basenum.ToUpper(), 16);
                            string ans = Convert.ToString(number, 2).ToString();
                            if (ans != "∞")
                            {
                                var embed = new EmbedBuilder { };
                                embed.AddField($"{basenum.ToUpper()}₁₆ to Base 2", $"=**{ans}₂**")
                                    .WithColor(Color.Blue)
                                    .WithAuthor(Context.Client.CurrentUser)
                                    .WithCurrentTimestamp();
                                await ReplyAsync("", false, embed.Build());
                            }
                            else
                            {
                                var embed = new EmbedBuilder { };
                                embed.AddField($"{basenum.ToUpper()}₁₆ to Base 2", $"=**∞**")
                                    .WithColor(Color.Blue)
                                    .WithAuthor(Context.Client.CurrentUser)
                                    .WithCurrentTimestamp();
                                await ReplyAsync("", false, embed.Build());
                            }
                        }
                        catch (Exception e)
                        {
                            await ReplyAsync("```" + e.ToString() + "```");
                        }
                        break;
                    default:
                        throw new ArgumentException("Only have 10(base 10) and 16(base 16) mode");
                }
            }
            catch (Exception e)
            {
                await Context.Channel.SendMessageAsync($"```{e.ToString()}```");
            }
        }

        [Command("base10")]
        [Alias("10")]
        public async Task Base10(string mode, string number)
        {
            try
            {
                switch (mode)
                {
                    case "2":
                        try
                        {
                            string ans = Convert.ToInt64(number, 2).ToString();
                            if (ans != "∞")
                            {
                                var embed = new EmbedBuilder { };
                                embed.AddField($"{number}₂ to Base 10", $"=**{ans}₁₀**")
                                    .WithColor(Color.Blue)
                                    .WithAuthor(Context.Client.CurrentUser)
                                    .WithCurrentTimestamp();
                                await ReplyAsync("", false, embed.Build());
                            }
                            else
                            {
                                var embed = new EmbedBuilder { };
                                embed.AddField($"{number}₂ to Base 10", $"=**∞**")
                                    .WithColor(Color.Blue)
                                    .WithAuthor(Context.Client.CurrentUser)
                                    .WithCurrentTimestamp();
                                await ReplyAsync("", false, embed.Build());
                            }
                        }
                        catch (Exception e)
                        {
                            await ReplyAsync("```" + e.ToString() + "```");
                        }
                        break;
                    case "16":
                        try
                        {
                            string ans = Convert.ToInt64(number.ToUpper(), 16).ToString();
                            if (ans != "∞")
                            {
                                var embed = new EmbedBuilder { };
                                embed.AddField($"{number.ToUpper()}₁₆ to Base 10", $"=**{ans}₁₀**")
                                    .WithColor(Color.Blue)
                                    .WithAuthor(Context.Client.CurrentUser)
                                    .WithCurrentTimestamp();
                                await ReplyAsync("", false, embed.Build());
                            }
                            else
                            {
                                var embed = new EmbedBuilder { };
                                embed.AddField($"{number.ToUpper()}₁₆ to Base 10", $"=**∞**")
                                    .WithColor(Color.Blue)
                                    .WithAuthor(Context.Client.CurrentUser)
                                    .WithCurrentTimestamp();
                                await ReplyAsync("", false, embed.Build());
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                        break;
                    default:
                        throw new ArgumentException("System.ArgumentException: Only have 2 and 16 mode");
                }
            }
            catch (Exception e)
            {
                await Context.Channel.SendMessageAsync($"```{e.ToString()}```");
            }
        }

        [Command("^")]
        [Alias("Power", "Pow")]
        public async Task Power(int num, int toPower)
        {
            try
            {
                var embed = new EmbedBuilder { };
                embed.AddField($"{num}^{toPower}", $"=**{Math.Pow(num, toPower)}**")
                    .WithColor(Color.Blue)
                    .WithAuthor(Context.Client.CurrentUser)
                    .WithCurrentTimestamp();
                await ReplyAsync("", false, embed.Build());
            }
            catch (Exception e)
            {
                await Context.Channel.SendMessageAsync($"```{e.ToString()}```");
            }
        }


        /*Functions*/
        public static double Fac(int n)
        {
            double fact = 1.0;
            if (n > 1)
            {
                for (int i = 2; i <= n; i++)
                {
                    fact *= i;
                }
            }
            return fact;
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
    }
}
