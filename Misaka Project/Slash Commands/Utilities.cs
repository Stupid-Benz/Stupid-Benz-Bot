using Discord.Interactions;
using Misaka_Project.Services;
using System.Threading.Tasks;

namespace Misaka_Project.Slash_Commands
{
    public class Utilities : InteractionModuleBase<SocketInteractionContext>
    {
        public InteractionService Commands { get; set; }

        private CommandHandler _handler;

        public Utilities(CommandHandler handler)
        {
            _handler = handler;
        }

        [SlashCommand("ping", "Recieve a pong")]
        public async Task Ping()
        {
            await RespondAsync("pong");
        }

        [SlashCommand("echo", "Repeat the input")]
        public async Task Echo(string echo, [Summary(description: "mention the user")] bool mention = false)
        {
            await RespondAsync(echo + (mention ? Context.User.Mention : string.Empty));
        }
    }
}