using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Stupid_Benz_Bot
{
    class Program
    {
        static void Main(string[] args)
            => new Program().RunBotAsync().GetAwaiter().GetResult();

        private DiscordSocketClient Client;
        private CommandService Commands;
        private IServiceProvider Services;
        private IConfiguration Config;

        public async Task RunBotAsync()
        {
            Client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Info
            });
            Commands = new CommandService();
            Config = BuildConfig();
            Services = new ServiceCollection()
                .AddSingleton(Client)
                .AddSingleton(Commands)
                .AddSingleton(Config)
                .BuildServiceProvider();

            Client.Log += Client_Log;

            Client.Ready += Client_Ready;

            await RegisterCommandAsync();

            await Client.LoginAsync(TokenType.Bot, Config["token"]);

            await Client.StartAsync();

            await Task.Delay(Timeout.Infinite);
        }

        private IConfiguration BuildConfig()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json")
                .Build();
        }

        private Task Client_Log(LogMessage log)
        {
            Console.WriteLine(log.ToString());

            return Task.CompletedTask;
        }

        private Task Client_Ready()
        {
            Console.WriteLine($"{DateTime.Now.ToString().Remove(0, 11)} Gateway     Login as {Client.CurrentUser.Username} - {Client.CurrentUser.Id}");

            return Task.CompletedTask;
        }

        public async Task RegisterCommandAsync()
        {
            Client.MessageReceived += HandleCommandAsync;

            Client.MessageUpdated += HandleUpdateAsync;

            Client.UserJoined += UserJoin;

            await Commands.AddModulesAsync(Assembly.GetEntryAssembly(), Services);
        }

        private async Task UserJoin(SocketGuildUser user)
        {
            if (user.Guild.Id.ToString() == Config["current-server-id"].ToString())
            {
                var channel = Client.GetChannel(Convert.ToUInt64(Config["announcements-id"])) as IMessageChannel;
                await channel.SendMessageAsync($"Hey {user.Mention}, Welcome to {user.Guild.Name}\n\nYou will be muted for 3 minutes so that you may have time to read the **rules** and explore the server.\n\nHave Fun!");
            }
        }

        private async Task HandleUpdateAsync(Cacheable<IMessage, ulong> before, SocketMessage after, ISocketMessageChannel messageChannel)
        {
            var msg = await before.GetOrDownloadAsync();
            var message = after as SocketUserMessage;
            var context = new SocketCommandContext(Client, message);
            if (message.Author.IsBot)
            {
                return;
            }

            int argPos = 0;

            if (message.HasStringPrefix(Config["prefix"], ref argPos) || message.HasMentionPrefix(Client.CurrentUser, ref argPos))
            {
                var result = await Commands.ExecuteAsync(context, argPos, Services);
                var channel = Client.GetChannel(Convert.ToUInt64(Config["console-id"])) as IMessageChannel;
                if (context.Guild.Id.ToString() == Config["current-server-id"].ToString())
                {
                    await channel.SendMessageAsync($"[{message.CreatedAt.DateTime.ToLocalTime()}] #{context.Channel} {message.Author.Username} has edited command: `{msg}` ==> `{message.Content}`");
                }
                if (!result.IsSuccess)
                {
                    await context.Channel.SendMessageAsync("```" + result.ErrorReason + "```");
                    await channel.SendMessageAsync("```" + result.ErrorReason + "```");
                    Console.WriteLine(result.ErrorReason);
                }
            }
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;
            var context = new SocketCommandContext(Client, message);
            if (message.Author.IsBot)
            {
                return;
            }

            int argPos = 0;

            if (message.HasStringPrefix(Config["prefix"], ref argPos) || message.HasMentionPrefix(Client.CurrentUser, ref argPos))
            {
                var result = await Commands.ExecuteAsync(context, argPos, Services);
                await message.DeleteAsync();
                var channel = Client.GetChannel(Convert.ToUInt64(Config["console-id"])) as IMessageChannel;
                if (context.Guild.Id.ToString() == Config["current-server-id"].ToString())
                {
                    await channel.SendMessageAsync($"[{message.CreatedAt.DateTime.ToLocalTime()}] {context.Channel} {message.Author.Username} has issued command: `{message.Content}`");
                }
                if (!result.IsSuccess)
                {
                    await context.Channel.SendMessageAsync("```" + result.ErrorReason + "```");
                    await channel.SendMessageAsync("```" + result.ErrorReason + "```");
                    Console.WriteLine(result.ErrorReason);
                }
            }
        }
    }
}
