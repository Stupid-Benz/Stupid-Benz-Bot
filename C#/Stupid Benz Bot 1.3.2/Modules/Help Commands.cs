using System.Threading.Tasks;
using Discord.Commands;

namespace Stupid_Benz_Bot.Modules
{
    [Group("help")]
    public class Help_Commands : ModuleBase<SocketCommandContext>
    {

        [Command]
        [Alias("Help")]
        public async Task Help()
        {
            await ReplyAsync("```This Bot is made by Stupid Benz" +
                "\n" +
                "\nUtilities:" +
                "\n   ping    Tells you the ping from discord to the bot" +
                "\n   avatar  Send the Avatar" +
                "\nFun:" +
                "\n   say     Send a message by This Bot" +
                "\n   spam    Spaming" +
                "\nMathematics:" +
                "\n   sin     Sine Function" +
                "\n   cos     Cosine Function" +
                "\n   tan     Tangent Function" +
                "\n   surd    Surd Function" +
                "\n   ssurd   Surd Function in Simpified form" +
                "\n   sq      Squre Function" +
                "\n   cu      Cubic Function" +
                "\n   quad    Quadratic Function" +
                "\n   fac     Find all Factor Function" +
                "\n   pf      Prime Factorization Funtion" +
                "\n" +
                "\nType =help [command] for more info on a command.```");
        }

        [Command("ping")]
        public async Task HelpPing()
        {
            await ReplyAsync("```ping   Type '=ping'" +
                "\n       Tells you the ping from discord to the bot" +
                "\nType =help [command] for more info on a command.```");
        }

        [Command("say")]
        public async Task HelpSay()
        {
            await ReplyAsync("```say    Type '=say [Message]'" +
                "\nType =help [command] for more info on a command.```");
        }

        [Command("sin")]
        public async Task HelpSin()
        {
            await ReplyAsync("```sin    Type '=sin [Degree]'" +
                "\nType =help [command] for more info on a command.```");
        }

        [Command("cos")]
        public async Task HelpCos()
        {
            await ReplyAsync("```sin    Type '=cos [Degree]'" +
                "\nType =help [command] for more info on a command.```");
        }

        [Command("tan")]
        public async Task HelpTan()
        {
            await ReplyAsync("```sin    Type '=tan [Degree]'" +
                "\nType =help [command] for more info on a command.```");
        }

        [Command("surd")]
        public async Task HelpSurd()
        {
            await ReplyAsync("```surd   Type '=surd [Number]'" +
                "\nType =help [command] for more info on a command.```");
        }

        [Command("ssurd")]
        public async Task HelpSSurd()
        {
            await ReplyAsync("```ssurd  Type '=ssurd [Number]'" +
                "\nThe Answer of (m, n) means m√n" +
                "\nType =help [command] for more info on a command.```");
        }

        [Command("sq")]
        public async Task HelpSq()
        {
            await ReplyAsync("```sq     Type '=sq [Number]'" +
                "\nType =help [command] for more info on a command.```");
        }

        [Command("cu")]
        public async Task HelpCu()
        {
            await ReplyAsync("```cu     Type '=cu [Number]'" +
                "\nType =help [command] for more info on a command.```");
        }

        [Command("quad")]
        public async Task HelpQuad()
        {
            await ReplyAsync("```quad   Type '=quad [Number]'" +
                "\n       The reply is (x position of vertix, y position of vertix), delta, " +
                "first answer of x, second answer of x" +
                "\nType =help [command] for more info on a command.```");
        }

        [Command("fac")]
        public async Task HelpFac()
        {
            await ReplyAsync("```fac    Type '=fac [Integer Number]'" +
                "\n       Please Don't larger than 500" +
                "\nType =help [command] for more info on a command.```");
        }

        [Command("pf")]
        public async Task HelpPf()
        {
            await ReplyAsync("```pf     Type '=pf [Integer Number]'" +
                "\n       Please Don't larger than 500" +
                "\nType =help [command] for more info on a command.```");
        }

        [Command("spam")]
        public async Task HelpSpam()
        {
            await ReplyAsync("```spam   Type '=spam [Text] [Times]'" +
                "\n       Please Don't larger than 10" +
                "\nType =help [command] for more info on a command.```");
        }

        [Command("avatar")]
        public async Task HelpAvatar()
        {
            await ReplyAsync("```avatar Type '=avatar [Member Mention] [Size of the avatar in pixel]'" +
                "\n       The size of the avatar need to be 128, 256, 512, 1024 (normal), 2048 (2k), 4096 (4k)" +
                "\nType =help [command] for more info on a command.```");
        }
    }
}
