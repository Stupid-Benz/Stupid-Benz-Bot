using System;
using System.Threading.Tasks;
using Discord.Commands;
using Discord;
using Discord.WebSocket;
using System.Collections.Generic;

namespace Stupid_Benz_Bot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("Ping")]
        public async Task Ping()
        {
            var embed = new EmbedBuilder
            {
                Title = "Pong! 🏓",
                Description = $"Lantency is **{PingTime()}** ms"
            };
            embed.WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .WithAuthor(Context.Client.CurrentUser);
            var emoji = new Emoji("🏓");
            var msg = await ReplyAsync("", false, embed.Build());
            await msg.AddReactionAsync(emoji);
        }

        public int PingTime()
        {
            int createdAt = Context.Message.CreatedAt.Second * 1000 + Context.Message.CreatedAt.Millisecond;
            int dateNow = DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;
            return dateNow - createdAt;
        }

        [Command("Test")]
        public async Task Test()
        {
            Random rnd = new Random();
            string[] Ans =
            {
                "No Test! You Stupid ", "Once upon a time, there have **NO TEST** "
            };
            string reply = Ans[rnd.Next(Ans.Length)];
            await ReplyAsync(reply + Context.Message.Author.Mention);
        }

        [Command("User-Info")]
        [Alias("User", "UserInfo", "Profile")]
        public async Task UserInfoAsync(SocketUser user = null)
        {
            try
            {
                if (user == null)
                {
                    user = Context.User;
                }
                var embed = new EmbedBuilder
                {
                    Title = $"{user.Username}'s Info"
                };
                bool IsActive = false;
                if (user.ActiveClients.Count.ToString() == "1")
                {
                    IsActive = true;
                }
                string activity = "No Activity";
                if (user.Activity != null)
                {
                    activity = user.Activity.ToString();
                }
                embed.AddField("Username", $"{user.Username}#{user.Discriminator}", true)
                        .AddField("ID", user.Id, true)
                        .AddField("Is Online", IsActive.ToString())
                        .AddField("Activity", activity, true)
                        .AddField("Status", user.Status.ToString(), true)
                        .WithImageUrl(user.GetAvatarUrl(ImageFormat.Png, size: 1024))
                        .WithColor(Color.Blue)
                        .WithCurrentTimestamp()
                        .WithAuthor(Context.Client.CurrentUser);
                await Context.Channel.SendMessageAsync("", false, embed.Build());
            }
            catch (Exception e)
            {
                await Context.Channel.SendMessageAsync($"```{e.ToString()}```");
            }
        }

        [Command("Avatar")]
        [Alias("Ava", "Pfp")]
        public async Task Avatar(ushort size = 1024, SocketUser user = null)
        {
            try
            {
                if (user == null)
                {
                    user = Context.User;
                }
                string userAvatar = "";
                if (size == 128 || size == 256 || size == 512 || size == 1024 || size == 2048 || size == 4096)
                {
                    userAvatar = user.GetAvatarUrl(ImageFormat.Png, size);
                }
                else
                {
                    throw new ArgumentException("Only have 128, 256, 512, 1024 (normal), 2048, 4096 (4k)");
                }
                var embed = new EmbedBuilder
                {
                    Title = $"{user.Username}\'s Avatar",
                    Description = $"[PNG]({user.GetAvatarUrl(ImageFormat.Png, size)}) | [JPEG]({user.GetAvatarUrl(ImageFormat.Jpeg, size)}) | [WEBP]({user.GetAvatarUrl(ImageFormat.WebP, size)})",
                    ImageUrl = userAvatar
                };
                embed.WithCurrentTimestamp()
                    .WithColor(Color.Blue)
                    .WithAuthor(Context.Client.CurrentUser);
                await Context.Channel.SendMessageAsync("", false, embed.Build());
            }
            catch (Exception e)
            {
                await Context.Channel.SendMessageAsync($"```{e.ToString()}```");
            }
        }

        [Command("Bot-info")]
        [Alias("Botinfo", "Bot")]
        public async Task BotInfo()
        {
            var bot = Context.Client.CurrentUser;
            var embed = new EmbedBuilder
            {
                Title = $"{bot.Username}'s Info",
                ImageUrl = bot.GetAvatarUrl(ImageFormat.Png, size: 1024),
                Description = $"{bot.Username} is made by Stupid Benz with C#."
            };
            embed.AddField("Name", bot.Username)
                .AddField("ID", bot.Id)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .WithAuthor(Context.Client.CurrentUser);
            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }

        [Command("Server-info")]
        [Alias("SrvInfo", "ServerInfo")]
        public async Task ServerInfo()
        {
            try
            {
                var Guild = Context.Guild;
                int membersonline = 0;
                int bot = 0;
                int IsAnimation = 0;
                foreach (SocketUser User in Context.Guild.Users)
                {
                    if (User.ActiveClients.Count.ToString() == "1")
                    {
                        membersonline++;
                    }
                }
                foreach (SocketUser User in Context.Guild.Users)
                {
                    if (User.IsBot)
                    {
                        bot++;
                    }
                }
                if (Guild.Emotes.Count != 0)
                {
                    foreach (Emote emote in Context.Guild.Emotes)
                    {
                        if (emote.Animated)
                        {
                            IsAnimation++;
                        }
                    }
                }
                var embed = new EmbedBuilder
                {
                    Title = $"{Guild.Name}'s Info"
                };
                embed.WithImageUrl(Guild.IconUrl)
                    .AddField("Server", $"```Name: {Guild.Name} | ID: {Guild.Id}```")
                    .AddField("Server Owner", $"```Owner Name: {Guild.Owner.Username} | ID: {Guild.OwnerId}```")
                    .AddField($"Server Members [{Guild.MemberCount}]", $"```Online: {membersonline} | Offline: {Guild.MemberCount - membersonline}\nMembers: {Guild.MemberCount - bot} | Bots: {bot}```")
                    .AddField("Server Channels", $"```Categories: {Guild.CategoryChannels.Count} | Text Channel: {Guild.TextChannels.Count} | Voice Channel: {Guild.VoiceChannels.Count}```")
                    .AddField($"Server Emojis [{Guild.Emotes.Count}]", $"```Normal: {Guild.Emotes.Count - IsAnimation} | Animation: {IsAnimation}```")
                    .AddField($"Server Roles", $"{Guild.Roles.Count}")
                    .AddField("Server Created At", $"```{Guild.CreatedAt.ToString().Remove(Guild.CreatedAt.ToString().Length - 7)}```")
                    .WithColor(Color.Blue)
                    .WithCurrentTimestamp()
                    .WithAuthor(Context.Client.CurrentUser);
                await ReplyAsync("", false, embed.Build());
            }
            catch (Exception e)
            {
                await Context.Channel.SendMessageAsync($"```{e.ToString()}```");
            }
        }

        [Command("Role-Info")]
        [Alias("Role", "RoleInfo")]
        public async Task Role(SocketRole role)
        {
            try
            {
                int numbers = 0;
                List<string> members = new List<string>();
                foreach (SocketGuildUser user in Context.Guild.Users)
                {
                    foreach (SocketRole roles in user.Roles)
                    {
                        if (role.Id == roles.Id)
                        {
                            members.Add(user.Username.ToString());
                            numbers++;
                        }
                    }
                }
                var embed = new EmbedBuilder
                {
                    Title = $"{role.Name}"
                };
                embed.AddField("Members", numbers.ToString())
                    .AddField("Members Name", string.Join(", ", members))
                    .WithColor(Color.Blue)
                    .WithCurrentTimestamp()
                    .WithAuthor(Context.Client.CurrentUser);
                var message = await ReplyAsync("", false, embed.Build());
            }
            catch (Exception e)
            {
                await ReplyAsync($"```{e.ToString()}```");
            }
        }
    }
}
