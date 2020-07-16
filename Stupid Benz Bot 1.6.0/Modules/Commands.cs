using System;
using System.Threading.Tasks;
using Discord.Commands;
using Discord;
using Discord.WebSocket;

namespace Stupid_Benz_Bot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        public async Task Ping()
        {
            var embed = new EmbedBuilder
            {
                Title = "Pong!"
            };
            embed.AddField("Latency", $"The latency is **{PingTime()}** ms.")
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .WithAuthor(Context.Client.CurrentUser);
            await ReplyAsync("", false, embed.Build());
        }

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

        //Enter "=test"
        [Command("test")]
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

        [Command("user-info")]
        [Alias("user", "userinfo")]
        public async Task UserInfoAsync(SocketUser user = null)
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
            embed.AddField("Username", $"{user.Username}#{user.Discriminator}", true)
                .AddField("ID", user.Id, true)
                .AddField("Is Online", IsActive.ToString())
                .AddField("Activity", user.Activity.ToString(), true)
                .AddField("Status", user.Status.ToString(), true)
                .WithImageUrl(user.GetAvatarUrl(ImageFormat.Png, size: 1024))
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .WithAuthor(Context.Client.CurrentUser);
            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }

        [Command("avatar")]
        [Alias("ava")]
        public async Task Avatar(ushort size = 1024, SocketUser user = null)
        {
            try
            {
                if (user == null)
                {
                    user = Context.User;
                }
                string userAvatar = "";
                switch (size)
                {
                    case 128:
                        userAvatar = user.GetAvatarUrl(ImageFormat.Png, size);
                        break;
                    case 256:
                        userAvatar = user.GetAvatarUrl(ImageFormat.Png, size);
                        break;
                    case 512:
                        userAvatar = user.GetAvatarUrl(ImageFormat.Png, size);
                        break;
                    case 1024:
                        userAvatar = user.GetAvatarUrl(ImageFormat.Png, size);
                        break;
                    case 2048:
                        userAvatar = user.GetAvatarUrl(ImageFormat.Png, size);
                        break;
                    case 4096:
                        userAvatar = user.GetAvatarUrl(ImageFormat.Png, size);
                        break;
                    default:
                        throw new ArgumentException("Only have 128, 256, 512, 1024 (normal), 2048 (2k), 4096 (4k)");
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

        [Command("bot-info")]
        [Alias("botinfo")]
        public async Task BotInfo()
        {
            var bot = Context.Client.CurrentUser;
            var embed = new EmbedBuilder
            {
                Title = $"{bot.Username}'s Info"
            };
            embed.AddField("Name", bot.Username)
                .AddField("ID", bot.Id)
                .WithImageUrl(bot.GetAvatarUrl(ImageFormat.Png, size: 1024))
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .WithAuthor(Context.Client.CurrentUser);
            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }

        [Command("Server-info")]
        [Alias("srvinfo", "ServerInfo")]
        public async Task ServerInfo()
        {
            try
            {
                var Guild = Context.Guild;
                string roles = "";
                string membersname = "";
                string emojiname = "0";
                int membersonline = 0;
                int bot = 0;
                int IsAnimation = 0;
                foreach (SocketRole Role in Context.Guild.Roles)
                {
                    roles += Role.Name.ToString() + ", ";
                }
                foreach (SocketUser User in Context.Guild.Users)
                {
                    membersname += User.Username.ToString() + ", ";
                }
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
                    emojiname = "";
                    foreach (Emote emote in Context.Guild.Emotes)
                    {
                        emojiname += emote.Name.ToString() + ", ";
                    }
                    foreach (Emote emote in Context.Guild.Emotes)
                    {
                        if (emote.Animated)
                        {
                            IsAnimation++;
                        }
                    }
                    emojiname = emojiname.Remove(emojiname.Length - 2);
                }
                roles = roles.Remove(roles.Length - 2);
                membersname = membersname.Remove(membersname.Length - 2);
                var embed = new EmbedBuilder
                {
                    Title = $"{Guild.Name}'s Info"
                };
                embed.WithImageUrl(Guild.IconUrl)
                    .AddField("Server", $"```Name: {Guild.Name} | ID: {Guild.Id}```")
                    .AddField("Server Owner", $"```Owner Name: {Guild.Owner.ToString().Remove(Guild.Owner.ToString().Length - 5)} | ID: {Guild.OwnerId}```")
                    .AddField($"Server Members [{Guild.MemberCount}]", $"```{membersname}``````Online: {membersonline} | Offline: {Guild.MemberCount - membersonline}\nMembers: {Guild.MemberCount - bot} | Bots: {bot}```")
                    .AddField("Server Channels", $"```Categories: {Guild.CategoryChannels.Count} | Text Channel: {Guild.TextChannels.Count} | Voice Channel: {Guild.VoiceChannels.Count}```")
                    .AddField($"Server Emojis [{Guild.Emotes.Count}]", $"```{emojiname}``````Normal: {Guild.Emotes.Count - IsAnimation} | Animation: {IsAnimation}```")
                    .AddField($"Server Roles [{Guild.Roles.Count}]", $"```{roles}```")
                    .AddField("Server Created At", $"```{Guild.CreatedAt.ToString().Remove(Guild.CreatedAt.ToString().Length - 7)}```")
                    .WithColor(Color.Blue)
                    .WithCurrentTimestamp()
                    .WithAuthor(Context.Client.CurrentUser);
                await ReplyAsync("", false, embed.Build());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        [Command("reboot")]
        public async Task Reboot()
        {
            var Client = new DiscordSocketClient();
            await Client.StopAsync();
            await Client.StartAsync();
        }
    }
}
