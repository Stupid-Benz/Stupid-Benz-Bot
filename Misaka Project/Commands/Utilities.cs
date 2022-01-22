using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Misaka_Project.Utilities;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Misaka_Project.Commands
{
    public class Utilities : ModuleBase
    {
        private static Images _images;

        public Utilities(Images images)
        {
            _images = images;
        }

        [Command("Ping")]
        public async Task Ping() => await ReplyAsync("Pong!");

        [Command("User")]
        public async Task Info(SocketUser user = null)
        {
            user = user ?? Context.User as SocketUser;
            var builder = new EmbedBuilder()
                .AddField("User", $"{user.Username}#{user.Discriminator}", true)
                .AddField("ID", user.Id, true)
                .AddField("Created at", user.CreatedAt.ToString("dd/MM/yyyy"), true)
                .AddField("Joined at", (user as SocketGuildUser).JoinedAt.Value.ToString("dd/MM/yyyy"), true)
                .AddField("Is Online", user.ActiveClients.Count == 1 ? "Active" : "Not Active", true)
                .AddField("Status", (user.Status == UserStatus.Online ? "🟢" : user.Status == UserStatus.Idle ? "🟡" : user.Status == UserStatus.DoNotDisturb ? "🔴" : "⚫") + " " + user.Status.ToString(), true)
                .AddField("Roles", string.Join(", ", 
                    (user as SocketGuildUser).Roles.Select(x => x.Mention)), true)
                .WithThumbnailUrl(user.GetAvatarUrl() ?? user.GetDefaultAvatarUrl())
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, builder.Build());
        }

        [Command("Server")]
        public async Task Server()
        {
            var builder = new EmbedBuilder()
                .AddField("Created at", Context.Guild.CreatedAt.ToString("dd/MM/yyyy"), true)
                .AddField("Memebercount", (Context.Guild as SocketGuild).MemberCount, true)
                .AddField("Online users", 
                    (Context.Guild as SocketGuild).Users.Where(x => x.Status == UserStatus.Online).Count(), true)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .WithThumbnailUrl(Context.Guild.IconUrl)
                .WithTitle($"{Context.Guild.Name} Information");
            await ReplyAsync("", false, builder.Build());
        }

        [Command("Avatar")]
        [Alias("Pfp", "Ava")]
        public async Task Avatar(SocketUser user = null, ushort size = 1024)
        {
            user = user ?? Context.User as SocketUser;
            ushort[] sizeLimit = { 128, 256, 512, 1024, 2048, 4096 };
            size = Convert.ToUInt16(sizeLimit.Contains(size) ? size : 1024);
            var builder = new EmbedBuilder()
                .WithDescription($"[PNG]({user.GetAvatarUrl(ImageFormat.Png, size)}) | [JPEG]({user.GetAvatarUrl(ImageFormat.Jpeg, size)}) | [WEBP]({user.GetAvatarUrl(ImageFormat.WebP, size)})")
                .WithTitle($"{user.Username}\'s Avatar")
                .WithImageUrl(user.GetAvatarUrl(ImageFormat.Png, size))
                .WithCurrentTimestamp()
                .WithColor(Color.Blue);
            await ReplyAsync("", false, builder.Build());
        }

        [Command("Role")]
        public async Task Role(SocketRole role)
        {
            var builder = new EmbedBuilder()
                .AddField("Members", string.Join(", ", role.Members.Select(x => x.Mention)), true)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .WithTitle(role.Name);
            await ReplyAsync("", false, builder.Build());
        }

        [Command("Image", RunMode = RunMode.Async)]
        public async Task Image(SocketGuildUser user, string pic_url = null)
        {
            var path = await _images.CreateImageAsync(user, 
                pic_url ?? "https://wallpaperaccess.com/full/3520264.jpg");
            await Context.Channel.SendFileAsync(path);
            File.Delete(path);
        }
    }
}
