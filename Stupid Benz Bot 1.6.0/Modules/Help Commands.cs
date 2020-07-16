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
                .AddField("Server-Info", "Give this Server inforamtion", true)
                .AddField("Sin", "Sine Function", true)
                .AddField("Cos", "Cosine Function", true)
                .AddField("Tan", "Tangent Function", true)
                .AddField("Surd", "Surd Function", true)
                .AddField("SSurd", "Simpify Surd Function", true)
                .AddField("Sq", "Square Function", true)
                .AddField("Cu", "Cubic Function", true)
                .AddField("Quad", "Quadratic Function", true)
                .AddField("Fac", "Find all Factor Function", true)
                .AddField("PF", "Prime Factorization Funtion", true)
                .AddField("Identity", "Send Identities Function", true)
                .AddField("!", "Factorial Function", true)
                .AddField("nCr", "Combinations Funciton", true)
                .AddField("nPr", "Permutations Function", true)
                .AddField("base16", "Change Base 10 to Base 16 Function", true)
                .AddField("base2", "Change Base 10 to Base 2 Function", true)
                .AddField("base10", "Change Base 2 or 16 to Base 10 Function", true)
                .AddField("^", "To the Power Function", true);
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
        [Alias("ava")]
        public async Task HelpAvatar()
        {
            var embed = new EmbedBuilder
            {
                Title = "Avatar"
            };
            embed.WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .AddField("How to use", "=avatar [Size of the avatar in pixel] [Member Mention]")
                .AddField("Usage", "Give the Avatar")
                .AddField("Caution!", "The size of the avatar need to be 128, 256, 512, 1024 (normal), 2048 (2k), 4096 (4k)")
                .AddField("Alias", "Ava");
            await ReplyAsync("", false, embed.Build());
        }

        [Command("user-info")]
        [Alias("user", "userinfo")]
        public async Task HelpSay()
        {
            var embed = new EmbedBuilder
            {
                Title = "User Info"
            };
            embed.WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .AddField("How to use", "=User-Info [Member Mention]")
                .AddField("Usage", "Give the user information")
                .AddField("Alias", "User, UserInfo");
            await ReplyAsync("", false, embed.Build());
        }

        [Command("Server-info")]
        [Alias("SrvInfo")]
        public async Task ServerInfo()
        {
            var embed = new EmbedBuilder
            {
                Title = "Server Info"
            };
            embed.WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .AddField("How to use", "=Server-Info")
                .AddField("Usage", "Give this Server information")
                .AddField("Alias", "srvinfo, serverinfo");
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
                .AddField("How to use", "=Sin [Degree] [Mode]")
                .AddField("Usage", "Sine Function")
                .AddField("Caution!", "Mode is r, which for 'radian', and d, which for 'degree', these two mode")
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
                .AddField("How to use", "=Cos [Degree] [Mode]")
                .AddField("Usage", "Cosine Function")
                .AddField("Caution!", "Mode is r, which for 'radian', and d, which for 'degree', these two mode")
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
                .AddField("How to use", "=Tan [Degree] [Mode]")
                .AddField("Usage", "Tangent Function")
                .AddField("Caution!", "Mode is r, which for 'radian', and d, which for 'degree', these two mode")
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
                .AddField("How to use", "=Surd [Number]")
                .AddField("Usage", "Surd Function");
            await ReplyAsync("", false, embed.Build());
        }

        [Command("ssurd")]
        [Alias("SimplifySurd")]
        public async Task HelpSSurd()
        {
            var embed = new EmbedBuilder
            {
                Title = "Mathematics: SSurd"
            };
            embed.WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .AddField("How to use", "=SSurd [Number]")
                .AddField("Usage", "Simplify Surd Function")
                .AddField("Alias", "SimplifySurd");
            await ReplyAsync("", false, embed.Build());
        }

        [Command("sq")]
        [Alias("Square")]
        public async Task HelpSq()
        {
            var embed = new EmbedBuilder
            {
                Title = "Mathematics: Sq"
            };
            embed.WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .AddField("How to use", "=Sq [Number]")
                .AddField("Usage", "Square Function")
                .AddField("Alias", "Square");
            await ReplyAsync("", false, embed.Build());
        }

        [Command("cu")]
        [Alias("Cubic")]
        public async Task HelpCu()
        {
            var embed = new EmbedBuilder
            {
                Title = "Mathematics: Cu"
            };
            embed.WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .AddField("How to use", "=Cu [Number]")
                .AddField("Usage", "Cubic Function")
                .AddField("Alias", "Cubic");
            await ReplyAsync("", false, embed.Build());
        }

        [Command("quad")]
        [Alias("Quadratic")]
        public async Task HelpQuad()
        {
            var embed = new EmbedBuilder
            {
                Title = "Mathematics: Quad"
            };
            embed.WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .AddField("How to use", "=Quad [a] [b] [c]")
                .AddField("Usage", "Quadratic Function")
                .AddField("Caution!", "a b c which stands for ax²+bx+c")
                .AddField("Alias", "Quadratic");
            await ReplyAsync("", false, embed.Build());
        }

        [Command("fac")]
        [Alias("Factor")]
        public async Task HelpFac()
        {
            var embed = new EmbedBuilder
            {
                Title = "Mathematics: Fac"
            };
            embed.WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .AddField("How to use", "=Fac [Number]")
                .AddField("Usage", "Find all Factor Function")
                .AddField("Alias", "Factor");
            await ReplyAsync("", false, embed.Build());
        }

        [Command("pf")]
        [Alias("PrimeFactorize", "PrimeFactorization")]
        public async Task HelpPf()
        {
            var embed = new EmbedBuilder
            {
                Title = "Mathematics: PF"
            };
            embed.WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .AddField("How to use", "=PF [Number]")
                .AddField("Usage", "Prime Factorization Function")
                .AddField("Alias", "PrimeFactorize, PrimeFactorization");
            await ReplyAsync("", false, embed.Build());
        }

        [Command("identity")]
        public async Task HelpIdentity()
        {
            var embed = new EmbedBuilder
            {
                Title = "Mathematics: Identity"
            };
            embed.WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .AddField("How to use", "=Identity")
                .AddField("Usage", "Send Identities Function");
            await ReplyAsync("", false, embed.Build());
        }

        [Command("!")]
        [Alias("Factorial")]
        public async Task HelpFactorial()
        {
            var embed = new EmbedBuilder
            {
                Title = "Mathematics: !"
            };
            embed.WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .AddField("How to use", "=! [Number]")
                .AddField("Usage", "Factorial Function")
                .AddField("Alias", "Factorial");
            await ReplyAsync("", false, embed.Build());
        }

        [Command("nCr")]
        [Alias("Combinations")]
        public async Task HelpnCr()
        {
            var embed = new EmbedBuilder
            {
                Title = "Mathematics: nCr"
            };
            embed.WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .AddField("How to use", "=nCr [n] [r]")
                .AddField("Usage", "Combinations Function")
                .AddField("Alias", "Combinations");
            await ReplyAsync("", false, embed.Build());
        }

        [Command("nPr")]
        [Alias("Permutations")]
        public async Task HelpnPr()
        {
            var embed = new EmbedBuilder
            {
                Title = "Mathematics: nPr"
            };
            embed.WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .AddField("How to use", "=nPr [n] [r]")
                .AddField("Usage", "Permutations Function")
                .AddField("Alias", "Permutations");
            await ReplyAsync("", false, embed.Build());
        }

        [Command("base16")]
        [Alias("16")]
        public async Task HelpBase16()
        {
            var embed = new EmbedBuilder
            {
                Title = "Mathematics: Base 16"
            };
            embed.WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .AddField("How to use", "=Base16 [Base 10 Number]")
                .AddField("Usage", "Change Base 10 to Base 16 Function")
                .AddField("Alias", "16");
            await ReplyAsync("", false, embed.Build());
        }

        [Command("base2")]
        [Alias("2")]
        public async Task HelpBase2()
        {
            var embed = new EmbedBuilder
            {
                Title = "Mathematics: Base 2"
            };
            embed.WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .AddField("How to use", "=Base2 [Base 10 Number]")
                .AddField("Usage", "Change Base 10 to Base 2 Function")
                .AddField("Alias", "2");
            await ReplyAsync("", false, embed.Build());
        }

        [Command("base10")]
        [Alias("10")]
        public async Task HelpBase10()
        {
            var embed = new EmbedBuilder
            {
                Title = "Mathematics: Base 10"
            };
            embed.WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .AddField("How to use", "=Base10 [Mode] [Base 2 or 16 Number]")
                .AddField("Usage", "Change Base 2 or 16 to Base 10 Function")
                .AddField("Caution!", "Mode is 2, which for 'Base 2', and 16, which for 'Base 16', these two mode")
                .AddField("Alias", "10");
            await ReplyAsync("", false, embed.Build());
        }

        [Command("^")]
        [Alias("Pow", "Power")]
        public async Task HelpPow()
        {
            var embed = new EmbedBuilder
            {
                Title = "Mathematics: Base 10"
            };
            embed.WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .AddField("How to use", "=^ [Number to Power] [Power Number]")
                .AddField("Usage", "To Power Function")
                .AddField("Alias", "Pow, Power");
            await ReplyAsync("", false, embed.Build());
        }
    }
}
