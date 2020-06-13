using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace Stupid_Benz_Bot.Modules
{
    public class Help_Commands : ModuleBase<SocketCommandContext>
    {
        [Command("help")]
        public async Task Help()
        {
            await ReplyAsync("```This Bot is made by Stupid Benz" +
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

        [Command("help ping")]
        public async Task HelpPing()
        {
            await ReplyAsync("```ping   Type '=ping'" +
                "\n       Tells you the ping from discord to the bot" +
                "\nType =help [command] for more info on a command.```");
        }

        [Command("help say")]
        public async Task HelpSay()
        {
            await ReplyAsync("```say    Type '=say [Message]'" +
                "\nType =help [command] for more info on a command.```");
        }

        [Command("help sin")]
        public async Task HelpSin()
        {
            await ReplyAsync("```sin    Type '=sin [Degree]'" +
                "\nType =help [command] for more info on a command.```");
        }

        [Command("help cos")]
        public async Task HelpCos()
        {
            await ReplyAsync("```sin    Type '=cos [Degree]'" +
                "\nType =help [command] for more info on a command.```");
        }

        [Command("help tan")]
        public async Task HelpTan()
        {
            await ReplyAsync("```sin    Type '=tan [Degree]'" +
                "\nType =help [command] for more info on a command.```");
        }

        [Command("help surd")]
        public async Task HelpSurd()
        {
            await ReplyAsync("```surd   Type '=surd [Number]'" +
                "\nType =help [command] for more info on a command.```");
        }

        [Command("help ssurd")]
        public async Task HelpSSurd()
        {
            await ReplyAsync("```ssurd  Type '=ssurd [Number]'" +
                "\nThe Answer of m, n) means m√n" +
                "\nType =help [command] for more info on a command.```");
        }

        [Command("help sq")]
        public async Task HelpSq()
        {
            await ReplyAsync("```sq     Type '=sq [Number]'" +
                "\nType =help [command] for more info on a command.```");
        }

        [Command("help cu")]
        public async Task HelpCu()
        {
            await ReplyAsync("```cu     Type '=cu [Number]'" +
                "\nType =help [command] for more info on a command.```");
        }

        [Command("help quad")]
        public async Task HelpQuad()
        {
            await ReplyAsync("```quad   Type '=quad [Number]'" +
                "\n       The reply is (x position of vertix, y position of vertix), delta, " +
                "first answer of x, second answer of x" +
                "\nType =help [command] for more info on a command.```");
        }

        [Command("help fac")]
        public async Task HelpFac()
        {
            await ReplyAsync("```fac    Type '=fac [Integer Number]'" +
                "\n       Please Don't larger than 500" +
                "\nType =help [command] for more info on a command.```");
        }

        [Command("help pf")]
        public async Task HelpPf()
        {
            await ReplyAsync("```pf     Type '=pf [Integer Number]'" +
                "\n       Please Don't larger than 500" +
                "\nType =help [command] for more info on a command.```");
        }

        [Command("help spam")]
        public async Task HelpSpam()
        {
            await ReplyAsync("```spam   Type '=spam [Text] [Times]'" +
                "\n       Please Don't larger than 10" +
                "\nType =help [command] for more info on a command.```");
        }

        [Command("help rank")]
        public async Task HelpRank()
        {
            await ReplyAsync("```rank   Type '=rank'" +
                "\nType =help [command] for more info on a command.");
        }
    }
}
