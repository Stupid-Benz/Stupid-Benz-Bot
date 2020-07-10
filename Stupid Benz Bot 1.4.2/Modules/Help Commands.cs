using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace Stupid_Benz_Bot.Modules
{
    [Group("help")]
    public class Help_Commands : ModuleBase<SocketCommandContext>
    {

        [Command]
        public async Task Help()
        {
            var embed = new EmbedBuilder
            {
                Title = "Command List"
            };
            embed.WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .AddField("Ping", "Give Ping Time", true)
                .AddField("Avatar", "Give the Avatar", true)
                .AddField("UserInfo", "Give the user information", true)
                .AddField("Spam", "Spamming", true)
                .AddField("Sin", "Sine Function", true)
                .AddField("Cos", "Cosine Function", true)
                .AddField("Tan", "Tangent Function", true)
                .AddField("Surd", "Surd Function", true)
                .AddField("SSurd", "Simpify Surd Function", true)
                .AddField("Sq", "Square Function", true)
                .AddField("Cu", "Cubic Function", true)
                .AddField("Quad", "Quadratic Function", true)
                .AddField("Fac", "Find all Factor Function", true)
                .AddField("PF", "Prime Factorization Funtion", true);
            await ReplyAsync("", false, embed.Build());
        }

        [Command("ping")]
        public async Task HelpPing()
        {
            var embed = new EmbedBuilder
            {
                Title = "Ping"
            };
            embed.WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .AddField("How to use", "=ping")
                .AddField("Usage", "Give Ping Time");
            await ReplyAsync("", false, embed.Build());
        }

        [Command("spam")]
        public async Task HelpSpam()
        {
            var embed = new EmbedBuilder
            {
                Title = "Spam"
            };
            embed.WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .AddField("How to use", "=spam [Text] [Times]")
                .AddField("Usage", "Spamming")
                .AddField("Caution!", "Don\'t over 30");
            await ReplyAsync("", false, embed.Build());
        }

        [Command("avatar")]
        public async Task HelpAvatar()
        {
            var embed = new EmbedBuilder
            {
                Title = "Avatar"
            };
            embed.WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .AddField("How to use", "=avatar [Member Mention] [Size of the avatar in pixel]")
                .AddField("Usage", "Give the Avatar")
                .AddField("Caution!", "The size of the avatar need to be 128, 256, 512, 1024 (normal), 2048 (2k), 4096 (4k)")
                .AddField("Alias", "Ava");
            await ReplyAsync("", false, embed.Build());
        }

        [Command("userinfo")]
        public async Task HelpSay()
        {
            var embed = new EmbedBuilder
            {
                Title = "User Info"
            };
            embed.WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .AddField("How to use", "=userinfo [Member Mention]")
                .AddField("Usage", "Give the user information")
                .AddField("Alias", "User");
            await ReplyAsync("", false, embed.Build());
        }

        [Command("sin")]
        public async Task HelpSin()
        {
            var embed = new EmbedBuilder
            {
                Title = "Mathematics: Sin"
            };
            embed.WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .AddField("How to use", "=sin [Degree]")
                .AddField("Usage", "Sine Function")
                .AddField("Alias", "Sine");
            await ReplyAsync("", false, embed.Build());
        }

        [Command("cos")]
        public async Task HelpCos()
        {
            var embed = new EmbedBuilder
            {
                Title = "Mathematics: Cos"
            };
            embed.WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .AddField("How to use", "=cos [Degree]")
                .AddField("Usage", "Cosine Function")
                .AddField("Alias", "Cosine");
            await ReplyAsync("", false, embed.Build());
        }

        [Command("tan")]
        public async Task HelpTan()
        {
            var embed = new EmbedBuilder
            {
                Title = "Mathematics: Tan"
            };
            embed.WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .AddField("How to use", "=tan [Degree]")
                .AddField("Usage", "Tangent Function")
                .AddField("Alias", "Tangent");
            await ReplyAsync("", false, embed.Build());
        }

        [Command("surd")]
        public async Task HelpSurd()
        {
            var embed = new EmbedBuilder
            {
                Title = "Mathematics: Surd"
            };
            embed.WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .AddField("How to use", "=surd [Degree]")
                .AddField("Usage", "Surd Function");
            await ReplyAsync("", false, embed.Build());
        }

        [Command("ssurd")]
        public async Task HelpSSurd()
        {
            var embed = new EmbedBuilder
            {
                Title = "Mathematics: SSurd"
            };
            embed.WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .AddField("How to use", "=sin [Degree]")
                .AddField("Usage", "Simplify Surd Function")
                .AddField("Alias", "SimplifySurd");
            await ReplyAsync("", false, embed.Build());
        }

        [Command("sq")]
        public async Task HelpSq()
        {
            var embed = new EmbedBuilder
            {
                Title = "Mathematics: Sq"
            };
            embed.WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .AddField("How to use", "=sq [Degree]")
                .AddField("Usage", "Square Function")
                .AddField("Alias", "Square");
            await ReplyAsync("", false, embed.Build());
        }

        [Command("cu")]
        public async Task HelpCu()
        {
            var embed = new EmbedBuilder
            {
                Title = "Mathematics: Cu"
            };
            embed.WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .AddField("How to use", "=cu [Degree]")
                .AddField("Usage", "Cubic Function")
                .AddField("Alias", "Cubic");
            await ReplyAsync("", false, embed.Build());
        }

        [Command("quad")]
        public async Task HelpQuad()
        {
            var embed = new EmbedBuilder
            {
                Title = "Mathematics: Quad"
            };
            embed.WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .AddField("How to use", "=quad [Degree]")
                .AddField("Usage", "Quadratic Function")
                .AddField("Alias", "Quadratic");
            await ReplyAsync("", false, embed.Build());
        }

        [Command("fac")]
        public async Task HelpFac()
        {
            var embed = new EmbedBuilder
            {
                Title = "Mathematics: Fac"
            };
            embed.WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .AddField("How to use", "=fac [Degree]")
                .AddField("Usage", "Find all Factor Function")
                .AddField("Alias", "Factor");
            await ReplyAsync("", false, embed.Build());
        }

        [Command("pf")]
        public async Task HelpPf()
        {
            var embed = new EmbedBuilder
            {
                Title = "Mathematics: PF"
            };
            embed.WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .AddField("How to use", "=sin [Degree]")
                .AddField("Usage", "Prime Factorization Function")
                .AddField("Alias", "PrimeFactorize, PrimeFactorization");
            await ReplyAsync("", false, embed.Build());
        }
    }
}
