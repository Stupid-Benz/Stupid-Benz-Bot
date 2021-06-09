using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Misaka_Project_Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace Misaka_Project.Modules
{
    public class Moderation : ModuleBase
    {
        private static Servers _servers;

        public Moderation(Servers servers)
        {
            _servers = servers;
        }

        [Command("Purge")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        [RequireBotPermission(GuildPermission.ManageMessages)]
        public async Task Purge(int amount)
        {
            var messages = await Context.Channel.GetMessagesAsync(amount + 1).FlattenAsync();
            await (Context.Channel as SocketTextChannel).DeleteMessagesAsync(messages);

            var message = await ReplyAsync($"{messages.Count()} messages are deleted successfully!");
            await Task.Delay(2000);
            await message.DeleteAsync();
        }

        [Command("Prefix")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task Prefix(string prefix = null)
        {
            if (prefix == null)
            {
                var guildPrefix = await _servers.GetGuildPrefix(Context.Guild.Id) ?? "=";
                await ReplyAsync($"The currect prefix of this bot is `{guildPrefix}`.");
                return;
            }

            if(prefix.Length > 8)
            {
                await ReplyAsync("The length of the prefix is too long!");
                return;
            }

            await _servers.ModifyGuildPrefix(Context.Guild.Id, prefix);
            await ReplyAsync($"The prefix has been adjusted to `{prefix}` successfully!");
        }
    }
}
