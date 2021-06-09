using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Misaka_Project.Utilities;
using Misaka_Project_Infrastructure;
using System;
using System.Threading.Tasks;

namespace Misaka_Project.Services
{
    public class CommandHandler
    {
        public static IServiceProvider _provider;
        public static DiscordSocketClient _discord;
        public static CommandService _commands;
        public static IConfigurationRoot _config;
        public static Servers _servers;
        public static Images _images;

        public CommandHandler(DiscordSocketClient discord, CommandService commands, IConfigurationRoot config, IServiceProvider provider, Servers servers, Images images)
        {
            _provider = provider;
            _discord = discord;
            _commands = commands;
            _config = config;
            _servers = servers;
            _images = images;

            _discord.Ready += OnReady;
            _discord.MessageReceived += OnMessageReceived;
            _discord.MessageUpdated += OnMessageUpdated;
        }

        private async Task OnMessageUpdated(Cacheable<IMessage, ulong> id, SocketMessage arg, ISocketMessageChannel channelId)
        {
            var msg = arg as SocketUserMessage;

            if (msg.Author.IsBot) return; ;
            var context = new SocketCommandContext(_discord, msg);

            int pos = 0;
            var prefix = await _servers.GetGuildPrefix((msg.Channel as SocketGuildChannel).Guild.Id) ?? "=";
            if (msg.HasStringPrefix(prefix, ref pos) || msg.HasMentionPrefix(_discord.CurrentUser, ref pos))
            {
                var result = await _commands.ExecuteAsync(context, pos, _provider);

                if (!result.IsSuccess)
                {
                    var reason = result.Error;

                    await context.Channel.SendMessageAsync($"The following error occured: \n    {reason}");
                    Console.WriteLine(reason);
                }
            }
        }

        private async Task OnMessageReceived(SocketMessage arg)
        {
            var msg = arg as SocketUserMessage;

            if (msg.Author.IsBot) return; ;
            var context = new SocketCommandContext(_discord, msg);

            int pos = 0;
            var prefix = await _servers.GetGuildPrefix((msg.Channel as SocketGuildChannel).Guild.Id) ?? "=";
            if (msg.HasStringPrefix(prefix, ref pos) || msg.HasMentionPrefix(_discord.CurrentUser, ref pos))
            {
                var result = await _commands.ExecuteAsync(context, pos, _provider);

                if (!result.IsSuccess)
                {
                    var reason = result.Error;

                    await context.Channel.SendMessageAsync($"The following error occured: \n    {reason}");
                    Console.WriteLine(reason);
                }
            }
        }

        private Task OnReady()
        {
            Console.WriteLine($"Connected as {_discord.CurrentUser.Username}#{_discord.CurrentUser.Discriminator}");
            return Task.CompletedTask;
        }
    }
}
