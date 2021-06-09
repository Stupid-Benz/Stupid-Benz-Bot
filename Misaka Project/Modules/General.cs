using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Misaka_Project.Utilities;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Misaka_Project.Modules
{
    public class General : ModuleBase
    {
        private static Images _images;

        public General(Images images)
        {
            _images = images;
        }

        [Command("Ping")]
        public async Task Ping()
        {
            await ReplyAsync("Pong!");
        }

        [Command("User")]
        public async Task Info(SocketUser user = null)
        {
            if (user == null) user = Context.User as SocketUser;
            var builder = new EmbedBuilder()
                .AddField("User", $"{user.Id}#{user.Discriminator}", true)
                .AddField("Created at", user.CreatedAt.ToString("dd/MM/yyyy"), true)
                .AddField("Joined at", (user as SocketGuildUser).JoinedAt.Value.ToString("dd/MM/yyyy"), true)
                .AddField("Roles", string.Join(", ", (user as SocketGuildUser).Roles.Select(x => x.Mention)), true)
                .WithThumbnailUrl(user.GetAvatarUrl() ?? user.GetDefaultAvatarUrl())
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            var embed = builder.Build();
            await ReplyAsync("", false, embed);
        }

        [Command("Server")]
        public async Task Server()
        {
            var builder = new EmbedBuilder()
                .AddField("Created at", Context.Guild.CreatedAt.ToString("dd/MM/yyyy"), true)
                .AddField("Memebercount", (Context.Guild as SocketGuild).MemberCount, true)
                .AddField("Online users", (Context.Guild as SocketGuild).Users.Where(x => x.Status == UserStatus.Online).Count(), true)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .WithThumbnailUrl(Context.Guild.IconUrl)
                .WithTitle($"{Context.Guild.Name} Information");
            var embed = builder.Build();
            await ReplyAsync("", false, embed);
        }

        [Command("Image", RunMode = RunMode.Async)]
        public async Task Image(SocketGuildUser user)
        {
            var path = await _images.CreateImageAsync(user);
            await Context.Channel.SendFileAsync(path);
            File.Delete(path);
        }
    }
}
