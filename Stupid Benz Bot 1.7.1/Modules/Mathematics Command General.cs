using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace Stupid_Benz_Bot.Modules
{
    public class Mathematics_Command_General : ModuleBase<SocketCommandContext>
    {
        /*Commands*/

        [Command("Surd")]
        [Alias("Square-Root", "SquareRoot")]
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

        [Command("SSurd")]
        [Alias("SimplifySurd", "Simplify-Surd")]
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

        [Command("Sq")]
        [Alias("Square")]
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

        [Command("Cu")]
        [Alias("Cubic")]
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

        [Command("FFac")]
        [Alias("FindFactor", "Find-Factor")]
        public async Task FindFactor(double number)
        {
            try
            {
                List<double> factors = new List<double>();
                double max = Math.Sqrt(number);
                for (int factor = 1; factor <= max; ++factor)
                {
                    if (number % factor == 0)
                    {
                        factors.Add(factor);
                        if (factor != number / factor)
                        {
                            factors.Add(number / factor);
                        }
                    }
                }
                factors.Sort();
                try
                {
                    var embed = new EmbedBuilder { };
                    embed.AddField($"{number}\'s Factors", $"**{string.Join("**, **", factors)}**")
                        .WithAuthor(Context.Client.CurrentUser)
                        .WithCurrentTimestamp()
                        .WithColor(Color.Blue);
                    await ReplyAsync("", false, embed.Build());
                }
                catch (ArgumentException)
                {
                    await ReplyAsync($"```{string.Join(", ", factors)}```");
                }
            }
            catch (Exception e)
            {
                await ReplyAsync("```" + e.ToString() + "```");
            }
        }

        [Command("PF")]
        [Alias("PrimeFactorize", "PrimeFactorization", "Prime-Factorize", "Prime-Factorization")]
        public async Task PrimeFactorization(double num)
        {
            try
            {
                double a = num;
                int b;
                List<double> result = new List<double>();
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
                        if (b != 1)
                        {
                            result.Add(b);
                        }
                        if (x != 1)
                        {
                            result.Add(x);
                        }
                    }
                }
                result.Add(1);
                result.Sort();
                var embed = new EmbedBuilder { };
                embed.AddField($"{num}\'s Prime Factors", $"**{string.Join("** x **", result)}**")
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

        [Command("!")]
        [Alias("Factorial")]
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

        [Command("Identity")]
        [Alias("Identities")]
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

        [Command("π")]
        [Alias("PI")]
        public async Task Pi()
        {
            var embed = new EmbedBuilder
            {
                Title = "π (PI)",
                Description = $"={Math.PI}"
            };
            embed.WithColor(Color.Blue)
                .WithAuthor(Context.Client.CurrentUser)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }

        [Command("e")]
        public async Task Euler()
        {
            var embed = new EmbedBuilder
            {
                Title = "e (Euler Number)",
                Description = $"={Math.E}"
            };
            embed.WithColor(Color.Blue)
                .WithAuthor(Context.Client.CurrentUser)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }

        [Command("ln")]
        public async Task LN(double number)
        {
            try
            {
                if (Math.Log(number).ToString() != "NaN")
                {
                    var embed = new EmbedBuilder
                    {
                        Title = $"ln {number}",
                        Description = $"={Math.Log(number)}"
                    };
                    embed.WithColor(Color.Blue)
                        .WithAuthor(Context.Client.CurrentUser)
                        .WithCurrentTimestamp();
                    await ReplyAsync("", false, embed.Build());
                }
                else
                {
                    throw new ArithmeticException("Math Error");
                }
            }
            catch (Exception e)
            {
                await Context.Channel.SendMessageAsync($"```{e.ToString()}```");
            }
        }

        [Command("Log")]
        public async Task Log(double a, double newBase = 10)
        {
            try
            {
                if (Math.Log(a, newBase).ToString() != "NaN")
                {
                    var embed = new EmbedBuilder
                    {
                        Title = $"log{newBase} {a}",
                        Description = $"={Math.Log(a, newBase)}"
                    };
                    embed.WithColor(Color.Blue)
                        .WithAuthor(Context.Client.CurrentUser)
                        .WithCurrentTimestamp();
                    await ReplyAsync("", false, embed.Build());
                }
                else
                {
                    throw new ArithmeticException("Math Error");
                }
            }
            catch (Exception e)
            {
                await Context.Channel.SendMessageAsync($"```{e.ToString()}```");
            }
        }

        [Command("Summation")]
        [Alias("Sigma-Notation", "SigmaNotation", "SN")]
        public async Task Summation(int x, int end, string expression)
        {
            try
            {
                if (x > end)
                {
                    throw new ArithmeticException("Mathe Error");
                }
                string formula = expression;
                StringToFormula stf = new StringToFormula();
                double sum = 0;
                bool HaveX = false;
                foreach (char c in formula)
                {
                    if (c.ToString() == "x") { HaveX = true; }
                }
                if (HaveX)
                {
                    for (int i = x; i <= end; i++)
                    {
                        formula = formula.Replace("x", i.ToString());
                        sum += stf.Eval(formula);
                        Console.WriteLine(sum + " " + i);
                        formula = formula.Replace(i.ToString(), "x");
                    }
                }
                else
                {
                    sum = stf.Eval(formula) * (end - x + 1);
                }
                var embed = new EmbedBuilder
                {
                    Title = $"{x}∑{end} {expression}",
                    Description = $"={sum}"
                };
                embed.WithColor(Color.Blue)
                    .WithAuthor(Context.Client.CurrentUser)
                    .WithCurrentTimestamp();
                await ReplyAsync("", false, embed.Build());
            }
            catch (Exception e)
            {
                await Context.Channel.SendMessageAsync($"```{e.ToString()}```");
            }
        }

        [Command("Multiplication")]
        [Alias("PI-Notation", "PINotation", "PN")]
        public async Task Multiplication(int x, int end, string expression)
        {
            try
            {
                if (x > end)
                {
                    throw new ArithmeticException("Mathe Error");
                }
                string formula = expression;
                StringToFormula stf = new StringToFormula();
                double sum = 0;
                bool HaveX = false;
                foreach (char c in formula)
                {
                    if (c.ToString() == "x") { HaveX = true; }
                }
                if (HaveX)
                {
                    for (int i = x; i <= end; i++)
                    {
                        formula = formula.Replace("x", i.ToString());
                        sum *= stf.Eval(formula);
                        Console.WriteLine(sum + " " + i);
                        formula = formula.Replace(i.ToString(), "x");
                    }
                }
                else
                {
                    sum = Math.Pow(stf.Eval(formula), (end - x + 1));
                }
                var embed = new EmbedBuilder
                {
                    Title = $"{x}∏{end} {expression}",
                    Description = $"={sum}"
                };
                embed.WithColor(Color.Blue)
                    .WithAuthor(Context.Client.CurrentUser)
                    .WithCurrentTimestamp();
                await ReplyAsync("", false, embed.Build());
            }
            catch (Exception e)
            {
                await Context.Channel.SendMessageAsync($"```{e.ToString()}```");
            }
        }

        [Command("Calc")]
        [Alias("Calculator")]
        public async Task Calculator(string expression)
        {
            try
            {
                StringToFormula stf = new StringToFormula();
                
                var embed = new EmbedBuilder
                {
                    Title = $"{expression}",
                    Description = $"={stf.Eval(expression)}"
                };
                embed.WithColor(Color.Blue)
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

    public class StringToFormula
    {
        private string[] _operators = { "+", "-", "*", "/", "^" };
        private Func<double, double, double>[] _operations =
        {
            (a1, a2) => a1 + a2,
            (a1, a2) => a1 - a2,
            (a1, a2) => a1 * a2,
            (a1, a2) => a1 / a2,
            (a1, a2) => Math.Pow(a1, a2)
        };

        public double Eval(string expression)
        {
            List<string> tokens = getTokens(expression);
            Stack<double> operandStack = new Stack<double>();
            Stack<string> operatorStack = new Stack<string>();
            int tokenIndex = 0;

            while (tokenIndex < tokens.Count)
            {
                string token = tokens[tokenIndex];
                if (token == "(")
                {
                    string subExpr = getSubExpression(tokens, ref tokenIndex);
                    operandStack.Push(Eval(subExpr));
                    continue;
                }
                if (token == ")")
                {
                    throw new ArgumentException("Mis-matched parentheses in expression");
                }
                //If this is an operator  
                if (Array.IndexOf(_operators, token) >= 0)
                {
                    while (operatorStack.Count > 0 && Array.IndexOf(_operators, token) < Array.IndexOf(_operators, operatorStack.Peek()))
                    {
                        string op = operatorStack.Pop();
                        double arg2 = operandStack.Pop();
                        double arg1 = operandStack.Pop();
                        operandStack.Push(_operations[Array.IndexOf(_operators, op)](arg1, arg2));
                    }
                    operatorStack.Push(token);
                }
                else
                {
                    operandStack.Push(double.Parse(token));
                }
                tokenIndex += 1;
            }

            while (operatorStack.Count > 0)
            {
                string op = operatorStack.Pop();
                double arg2 = operandStack.Pop();
                double arg1 = operandStack.Pop();
                operandStack.Push(_operations[Array.IndexOf(_operators, op)](arg1, arg2));
            }
            return operandStack.Pop();
        }

        private string getSubExpression(List<string> tokens, ref int index)
        {
            StringBuilder subExpr = new StringBuilder();
            int parenlevels = 1;
            index += 1;
            while (index < tokens.Count && parenlevels > 0)
            {
                string token = tokens[index];
                if (tokens[index] == "(")
                {
                    parenlevels += 1;
                }

                if (tokens[index] == ")")
                {
                    parenlevels -= 1;
                }

                if (parenlevels > 0)
                {
                    subExpr.Append(token);
                }

                index += 1;
            }

            if ((parenlevels > 0))
            {
                throw new ArgumentException("Mis-matched parentheses in expression");
            }
            return subExpr.ToString();
        }

        private List<string> getTokens(string expression)
        {
            string operators = "()^*/+-";
            List<string> tokens = new List<string>();
            StringBuilder sb = new StringBuilder();

            foreach (char c in expression.Replace(" ", string.Empty))
            {
                if (operators.IndexOf(c) >= 0)
                {
                    if ((sb.Length > 0))
                    {
                        tokens.Add(sb.ToString());
                        sb.Length = 0;
                    }
                    tokens.Add(c.ToString());
                }
                else
                {
                    sb.Append(c);
                }
            }

            if ((sb.Length > 0))
            {
                tokens.Add(sb.ToString());
            }
            return tokens;
        }
    }
}
