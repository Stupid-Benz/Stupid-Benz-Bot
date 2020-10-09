using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace Stupid_Benz_Bot.Modules
{
    public class Mathematics_Command_Formula : ModuleBase<SocketCommandContext>
    {
        [Command("quad")]
        [Alias("quadratic")]
        public async Task QuadraticEquation(int a, int b, int c)
        {
            try
            {
                string vertixx = (-b / (2 * a)).ToString();
                string vertixy = (c - b * b / (4 * a)).ToString();
                double delta = (b * b - 4 * a * c);
                string ans1 = ((-b + Math.Sqrt(delta)) / (2 * a)).ToString();
                string ans2 = ((-b - Math.Sqrt(delta)) / (2 * a)).ToString();
                if (ans1 == "NaN")
                {
                    var embed = new EmbedBuilder
                    {
                        Title = $"{a}x² + {b}x + {c}"
                    };
                    embed.AddField($"X point of the Curve Vertix", $"= **{vertixx}**")
                        .AddField($"Y point of the Curve Vertix", $"= **{vertixy}**")
                        .AddField($"Delta Δ", $"= **{delta}**")
                        .AddField($"X", "= **Math Error**")
                        .WithAuthor(Context.Client.CurrentUser)
                        .WithCurrentTimestamp()
                        .WithColor(Color.Blue);
                    await ReplyAsync("", false, embed.Build());
                    throw new ArithmeticException("Math Error");
                }
                else if (ans1 == ans2)
                {
                    var embed = new EmbedBuilder
                    {
                        Title = $"{a}x² + {b}x + {c}"
                    };
                    embed.AddField($"X point of the Curve Vertix", $"= **{vertixx}**")
                        .AddField($"Y point of the Curve Vertix", $"= **{vertixy}**")
                        .AddField($"Delta Δ", $"= **{delta}**")
                        .AddField($"X", $"= **{ans1}**")
                        .WithAuthor(Context.Client.CurrentUser)
                        .WithCurrentTimestamp()
                        .WithColor(Color.Blue);
                    await ReplyAsync("", false, embed.Build());
                }
                else
                {
                    var embed = new EmbedBuilder
                    {
                        Title = $"{a}x² + {b}x + {c}"
                    };
                    embed.AddField($"X point of the Curve Vertix", $"= **{vertixx}**")
                        .AddField($"Y point of the Curve Vertix", $"= **{vertixy}**")
                        .AddField($"Delta Δ", $"= **{delta}**")
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
    }
}
