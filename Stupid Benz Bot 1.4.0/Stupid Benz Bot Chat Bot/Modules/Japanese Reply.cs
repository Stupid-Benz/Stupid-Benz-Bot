using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using Discord.Commands;
using Discord;
using Discord.WebSocket;
using Discord.Rest;
using System.Threading.Channels;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

namespace Stupid_Benz_Bot_Chat_Bot.Modules
{
    public class Japanese_Reply : ModuleBase<SocketCommandContext>
    {
        [Command("Konnichiwa")]
        [Alias("こんにちは", "konnichiwa")]
        public async Task Konnichiwa()
        {
            await ReplyAsync("こんにちは");
        }

        [Command("Hajimemashite")]
        [Alias("はじめまして", "hajimemashite")]
        public async Task Hajimemashite()
        {
            await ReplyAsync("はじめまして，私は御坂美琴です，どうぞよろしくお願いします"
                + Context.Message.Author.Mention);
        }

        [Command("Ohayogozayimasu")]
        [Alias("おはようごぢいます", "おはよう", "ohayogozayimasu", "Ohaayo", "ohayo")]
        public async Task Ohayogozayimasu()
        {
            await ReplyAsync("おはよう" + Context.Message.Author.Mention);
        }
    }
}
