using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace Stupid_Benz_Bot.Modules
{
    public class Mathematics_Commands_Trigonometry : ModuleBase<SocketCommandContext>
    {
        [Command("Sin")]
        [Alias("Sine")]
        public async Task Sine(double degree, string mode = "d")
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

        [Command("Cos")]
        [Alias("Cosine")]
        public async Task Cosine(double degree, string mode = "d")
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

        [Command("Tan")]
        [Alias("Tangent")]
        public async Task Tangent(double degree, string mode = "d")
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

        [Command("Csc")]
        [Alias("Cosecant")]
        public async Task Cosecant(double degree, string mode = "d")
        {
            try
            {
                mode = mode.ToLower();
                switch (mode)
                {
                    case "r":
                        try
                        {
                            string ans = (1 / Math.Sin(degree)).ToString();
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
                            string ans = (1 / Math.Sin(degree * Math.PI / 180)).ToString();
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

        [Command("Sec")]
        [Alias("Secant")]
        public async Task Secant(double degree, string mode = "d")
        {
            try
            {
                mode = mode.ToLower();
                switch (mode)
                {
                    case "r":
                        try
                        {
                            string ans = (1 / Math.Cos(degree)).ToString();
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
                            string ans = (1 / Math.Cos(degree * Math.PI / 180)).ToString();
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

        [Command("Cot")]
        [Alias("Cotangent")]
        public async Task Cotangent(double degree, string mode = "d")
        {
            try
            {
                mode = mode.ToLower();
                switch (mode)
                {
                    case "r":
                        try
                        {
                            string ans = (1 / Math.Tan(degree * Math.PI / 180)).ToString();
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
                            string ans = (1 / Math.Tan(degree * Math.PI / 180)).ToString();
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
    }
}
