using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Linq;
using System.Threading.Tasks;

namespace Misaka_Project.Commands
{
    public class Moderation : ModuleBase
    {

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
    }
}
