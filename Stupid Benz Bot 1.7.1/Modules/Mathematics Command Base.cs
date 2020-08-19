using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace Stupid_Benz_Bot.Modules
{
    public class Mathematics_Command_Base : ModuleBase<SocketCommandContext>
    {
        [Command("Base-16")]
        [Alias("Base16")]
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

        [Command("Base-2")]
        [Alias("Base2")]
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

        [Command("Base-10")]
        [Alias("Base10")]
        public async Task Base10(string number, string mode = "2")
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
    }
}
