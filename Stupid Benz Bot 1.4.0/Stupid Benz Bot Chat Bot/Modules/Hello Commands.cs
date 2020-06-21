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
    public class Hello_Commands : ModuleBase<SocketCommandContext>
    {
        [Command("hi")]
        [Alias("Hi", "hello", "Hello", "How are you", "how are you", "Is there anyone here",
            "is there anyone here", "Whats up", "whats up", "Good day", "good day")]
        public async Task Hello()
        {
            await ReplyAsync(HelloReply());
        }

        //Test Reply
        public string HelloReply()
        {
            Random rnd = new Random();
            string[] Ans =
            {
                "Hi " + Context.Message.Author.Mention,
                "Hello " + Context.Message.Author.Mention,
                "*iPhone 12, 102 cameras, the best phone ever!*", 
                "I am glad to see you again " + Context.Message.Author.Mention, 
                "Hi " + Context.Message.Author.Mention + ", how can I help you?", 
                "Hello " + Context.Message.Author.Mention + ", how can I help you?"
            };
            string reply = Ans[rnd.Next(Ans.Length)];
            return reply;
        }

        [Command("Help")]
        [Alias("help")]
        public async Task Help()
        {
            var Message = await Context.Channel.SendMessageAsync("Let me find!");

            await Message.ModifyAsync(msg => msg.Content = "Oh Found it!" +
            "\n```This Bot is made by Stupid Benz" +
                "\n" +
                "\nUtils:" +
                "\n   ping    Tells you the ping from discord to the bot" +
                "\n   say     Send a message by This Bot" +
                "\n   spam    Spaming" +
                "\n   rank    Get the rank in json file" +
                "\nMathematics:" +
                "\n   sin     Sine Function" +
                "\n   cos     Cosin Function" +
                "\n   tan     Tangent Function" +
                "\n   surd    Surd Function" +
                "\n   ssurd   Simpify Surd Function" +
                "\n   sq      Squre Function" +
                "\n   cu      Cubic Function" +
                "\n   quad    Quadratic Function" +
                "\n   fac     Find all Factor Function" +
                "\n   pf      Prime Factorization Funtion" +
                "\n" +
                "\nType =help [command] for more info on a command.```");
        }

        [Command("what can you do")]
        [Alias("What can you do")]
        public async Task WCYDReply()
        {
            var Message = await Context.Channel.SendMessageAsync("Let me think!");

            await Message.ModifyAsync(msg => msg.Content = "Oh thats it!" +
            "\n```This Bot is made by Stupid Benz" +
                "\n" +
                "\nUtils:" +
                "\n   ping    Tells you the ping from discord to the bot" +
                "\n   say     Send a message by This Bot" +
                "\n   spam    Spaming" +
                "\n   rank    Get the rank in json file" +
                "\nMathematics:" +
                "\n   sin     Sine Function" +
                "\n   cos     Cosin Function" +
                "\n   tan     Tangent Function" +
                "\n   surd    Surd Function" +
                "\n   ssurd   Simpify Surd Function" +
                "\n   sq      Squre Function" +
                "\n   cu      Cubic Function" +
                "\n   quad    Quadratic Function" +
                "\n   fac     Find all Factor Function" +
                "\n   pf      Prime Factorization Funtion" +
                "\n" +
                "\nType =help [command] for more info on a command.```");
        }

        [Command("test")]
        [Alias("Test", "tesing", "Testing")]
        public async Task Test()
        {
            await ReplyAsync("Something went wrong!");
        }

        [Command("Sorry, I don't what you mean")]
        public async Task CopyReply()
        {
            Random rnd = new Random();
            string[] Ans =
            {
                "Hey, " + Context.Message.Author.Mention + "\n**Don't Copy My Word!!!**", 
                "Who are you!! **YOU THE COPY CAT!!**"
            };
            string reply = Ans[rnd.Next(Ans.Length)];
            await ReplyAsync(reply);
        }

        [Command("fk")]
        [Alias("Fuck", "FUCK", "fuck", "**FUCK**")]
        public async Task Fuck()
        {
            Random rnd = new Random();
            string[] Ans =
            {
                "Why you are so angry than need to say foul language",
                "You bad bad", "Ummm, foul language is bad"
            };
            string reply = Ans[rnd.Next(Ans.Length)];
            await ReplyAsync(reply);
        }

        [Command("See you later")]
        [Alias("cya", "see you later", "Goodbye", "goodbye", "I am Leaving", "I am leaving",
            "i am leaving", "Have a Good day", "Have a good day", "have a good day")]
        public async Task GoodBye()
        {
            Random rnd = new Random();
            string[] Ans =
            {
                "Sad to see you go :( " + Context.Message.Author.Mention,
                "Talk to you later " + Context.Message.Author.Mention,
                "Goodbye! " + Context.Message.Author.Mention
            };
            string reply = Ans[rnd.Next(Ans.Length)];
            await ReplyAsync(reply);
        }
    }
}
