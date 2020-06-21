using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace Stupid_Benz_Bot
{
    class Program
    {
        static void Main(string[] args) => new Program().RunBotAsync().GetAwaiter().GetResult();

        private DiscordSocketClient Client;
        private CommandService Commands;
        private IServiceProvider Services;

        public async Task RunBotAsync()
        {
            Client = new DiscordSocketClient();
            Commands = new CommandService();

            Services = new ServiceCollection()
                .AddSingleton(Client)
                .AddSingleton(Commands)
                .BuildServiceProvider();

            string token = "NjkxMTExMjc5MzgwNjYwMjU0.Xu4S1A.KeQw02GA9FB37nlcjxZXlB_chD0";

            Client.Log += Client_Log;

            await RegisterCommandAsync();

            await Client.LoginAsync(TokenType.Bot , token);

            await Client.StartAsync();

            await Task.Delay(-1);
        }
        private Task Client_Log(LogMessage arg)
        {
            Console.WriteLine(arg);

            return Task.CompletedTask;
        }

        public async Task RegisterCommandAsync()
        {
            Client.MessageReceived += HandleCommandAsync;

            await Commands.AddModulesAsync(Assembly.GetEntryAssembly(), Services);
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
            
            if (message.HasStringPrefix("=", ref argPos))
            {
                var result = await Commands.ExecuteAsync(context, argPos, Services);
                if (!result.IsSuccess)
                {
                    if (result.ErrorReason == "Unknown command.")
                    {
                        Console.WriteLine(result.ErrorReason);
                    }
                    else
                    {
                        await context.Channel.SendMessageAsync(result.ErrorReason);
                        Console.WriteLine(result.ErrorReason);
                    }
                }
            }
        }
    }
}
