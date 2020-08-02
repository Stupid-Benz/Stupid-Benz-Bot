using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace Stupid_Benz_Bot.Modules
{
    [Group("Help")]
    [Alias("?")]
    public class Help_Commands : ModuleBase<SocketCommandContext>
    {
        [Command]
        public async Task Help()
        {
            var embed = new EmbedBuilder
            {
                Title = "\u2753 Command List",
                Description = "```Help > Command```"
            };
            embed.AddField("1\u20E3 General", "Simple Command")
                .AddField("2\u20E3 Mathematics General", "Function of Mathematics")
                .AddField("3\u20E3 Mathematics Base", "Base Function")
                .AddField("4\u20E3 Mathematics Formula", "Works with Formula")
                .AddField("5\u20E3 Mathematics Trigonometry", "Trigonometry Function")
                .WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }

        [Command("General")]
        [Alias("1")]
        public async Task General()
        {
            var embed = new EmbedBuilder
            {
                Title = "General",
                Description = "```Help > Command > General```"
            };
            embed.AddField("1\u20E3 Ping", "Give the Ping Time")
                .AddField("2\u20E3 Avatar", "Give the Avatar")
                .AddField("3\u20E3 User-Info", "Give the User Information")
                .AddField("4\u20E3 Server-Info", "Give the Server Information")
                .AddField("5\u20E3 Search-Role", "Give the Role Information")
                .WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }

        [Command("Mathematics-General")]
        [Alias("MathGeneral", "MathematicsGeneral", "2")]
        public async Task MathematicsGeneral()
        {
            var embed = new EmbedBuilder
            {
                Title = "Mathematics General",
                Description = "```Help > Command > Mathematics General```"
            };
            embed.AddField("🇦 Surd", "Surd (Square Root) Function", true)
                .AddField("🇧 SSurd", "Simplify the Surd", true)
                .AddField("🇨 Square", "Square Function", true)
                .AddField("🇩 Cubic", "Cubic Function", true)
                .AddField("🇪 FFac", "Find Factor Function", true)
                .AddField("🇫 PF", "Prime Factorization Funciton", true)
                .AddField("🇬 Factorial", "Factorial Funciton", true)
                .AddField("🇭 nCr", "Combinations Function", true)
                .AddField("🇮 nPr", "Permutations Function", true)
                .AddField("🇯 Power", "Power Function", true)
                .AddField("🇰 Identity", "Give the Identities", true)
                .WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }

        [Command("Mathematics-Base")]
        [Alias("MathBase", "MatheamticsBase", "3")]
        public async Task MathematicsBase()
        {
            var embed = new EmbedBuilder
            {
                Title = "Mathematics Base",
                Description = "```Help > Command > Mathematics Base```"
            };
            embed.AddField("1\u20E3 Base-2", "Change Base 16 or Base 10 to Base 2")
                .AddField("2\u20E3 Base-16", "Change Base 10 or Base 2 to Base 16")
                .AddField("3\u20E3 Base-10", "Change Base 16 or Base 2 to Base 10")
                .WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }

        [Command("Mathematics-Formula")]
        [Alias("MathFormula", "MathematicsFormula", "4")]
        public async Task MathematicsFormula()
        {
            var embed = new EmbedBuilder
            {
                Title = "Mathematics Formula",
                Description = "```Help > Command > Mathematics Formula```"
            };
            embed.AddField("1\u20E3 Quad", "Quadratic Equation")
                .WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }

        [Command("Mathematics-Trigonometry")]
        [Alias("MathTrigonometry", "MathematicsTrigonometry", "MathTri", "5")]
        public async Task MathematicsTrigonometry()
        {
            var embed = new EmbedBuilder
            {
                Title = "Mathematics Trigonometry",
                Description = "```Help > Command > Mathematics Trigonometry```"
            };
            embed.AddField("1\u20E3 Sine", "Sine Function", true)
                .AddField("2\u20E3 Cosine", "Cosine Function", true)
                .AddField("3\u20E3 Tangent", "Tangent Function", true)
                .AddField("4\u20E3 Cosecant", "Cosecant Function", true)
                .AddField("5\u20E3 Secant", "Secant Function", true)
                .AddField("6\u20E3 Cotangent", "Cotangent Function", true)
                .WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }

        [Command("Ping")]
        [Alias("1-1")]
        public async Task Ping()
        {
            var embed = new EmbedBuilder
            {
                Title = "Ping",
                Description = "```Help > Command > General > Ping```"
            };
            embed.AddField("How to Use", "=Ping")
                .AddField("Usage", "Give the Ping Time")
                .AddField("Caution", "No Caution")
                .AddField("Alias", "No Alias")
                .WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }

        [Command("Avatar")]
        [Alias("Ava", "Pfp", "1-2")]
        public async Task Avatar()
        {
            var embed = new EmbedBuilder
            {
                Title = "Avatar",
                Description = "```Help > Command > General > Avatar```"
            };
            embed.AddField("How to Use", "=Avatar [Size of the avatar in pixel] [User Mention]")
                .AddField("Usage", "Give the Avatar")
                .AddField("Caution", "The size of the avatar need to be 128, 256, 512, 1024 (normal), 2048, 4096 (4k)")
                .AddField("Alias", "Ava, Pfp")
                .WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }

        [Command("User-Info")]
        [Alias("User", "UserInfo", "Profile", "1-3")]
        public async Task UserInfo()
        {
            var embed = new EmbedBuilder
            {
                Title = "User Info",
                Description = "```Help > Command > General > User Info```"
            };
            embed.AddField("How to Use", "=User-Info [User Mention]")
                .AddField("Usage", "Give the User Information")
                .AddField("Caution", "No Caution")
                .AddField("Alias", "User, UserInfo, Profile")
                .WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }
        
        [Command("Bot-Info")]
        [Alias("Bot", "BotInfo", "1-4")]
        public async Task BotInfo()
        {
            var embed = new EmbedBuilder
            {
                Title = "Bot Info",
                Description = "```Help > Command > General > Bot Info```"
            };
            embed.AddField("How to Use", "=Bot-Info")
                .AddField("Usage", "Give the Bot Information")
                .AddField("Caution", "No Caution")
                .AddField("Alias", "Bot, BotInfo")
                .WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }

        [Command("Server-Info")]
        [Alias("SrvInfo", "ServerInfo", "1-5")]
        public async Task ServerInfo()
        {
            var embed = new EmbedBuilder
            {
                Title = "Server Info",
                Description = "```Help > Command > General > Server Info```"
            };
            embed.AddField("How to Use", "=Server-Info")
                .AddField("Usage", "Give the Server Information")
                .AddField("Caution", "No Caution")
                .AddField("Alias", "SrvInfo, ServerInfo")
                .WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }

        [Command("Role-Info")]
        [Alias("Role", "RoleInfo", "1-6")]
        public async Task Role()
        {
            var embed = new EmbedBuilder
            {
                Title = "Role Info",
                Description = "```Help > Command > General > Role Info```"
            };
            embed.AddField("How to Use", "=Role-Info [Role Mention]")
                .AddField("Usage", "Give the Role Information")
                .AddField("Caution", "No Caution")
                .AddField("Alias", "Role, RoleInfo")
                .WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }

        [Command("Surd")]
        [Alias("Square-Root", "SquareRoot", "2-1")]
        public async Task Surd()
        {
            var embed = new EmbedBuilder
            {
                Title = "Surd",
                Description = "```Help > Command > Mathematics General > Surd```"
            };
            embed.AddField("How to Use", "=Surd [Number] [Times]")
                .AddField("Usage", "Surd (Square Root) Function")
                .AddField("Mathematics Introduction", "[Times]√[Number]")
                .AddField("Alias", "Square-Root, SquareRoot")
                .WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }

        [Command("SSurd")]
        [Alias("Simplify-Surd", "SimplifySurd", "2-2")]
        public async Task SimplifySurd()
        {
            var embed = new EmbedBuilder
            {
                Title = "SSurd",
                Description = "```Help > Command > Mathematics General > SSurd```"
            };
            embed.AddField("How to Use", "=SSurd [Number]")
                .AddField("Usage", "Simplify the Surd")
                .AddField("Mathematics Introduction", "√[Number] ==> [Times]√[Number]")
                .AddField("Alias", "SimplifySurd, Simplify-Surd")
                .WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }

        [Command("Sq")]
        [Alias("Square", "2-3")]
        public async Task Square()
        {
            var embed = new EmbedBuilder
            {
                Title = "Square",
                Description = "```Help > Command > Mathematics General > Square```"
            };
            embed.AddField("How to Use", "=Square [Number]")
                .AddField("Usage", "Square Function")
                .AddField("Mathematics Introduction", "[Number]²")
                .AddField("Alias", "Sq")
                .WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }

        [Command("Cu")]
        [Alias("Cubic", "2-4")]
        public async Task Cubic()
        {
            var embed = new EmbedBuilder
            {
                Title = "Cubic",
                Description = "```Help > Command > Mathematics General > Cubic```"
            };
            embed.AddField("How to Use", "=Cubic [Number]")
                .AddField("Usage", "Cubic Function")
                .AddField("Mathematics Introduction", "[Number]³")
                .AddField("Alias", "Cu")
                .WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }

        [Command("FFac")]
        [Alias("FindFactor", "Find-Factor", "2-5")]
        public async Task FindFactor()
        {
            var embed = new EmbedBuilder
            {
                Title = "Find Factor",
                Description = "```Help > Command > Mathematics General > Find Factor```"
            };
            embed.AddField("How to Use", "=FFac [Number]")
                .AddField("Usage", "Find Factor Function")
                .AddField("Mathematics Introduction", "Find All Factors of the number")
                .AddField("Alias", "FindFactor, Find-Factor")
                .WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }
        
        [Command("PF")]
        [Alias("PrimeFactorize", "PrimeFactorization", "Prime-Factorize", "Prime-Factorization", "2-6")]
        public async Task PrimeFactorization()
        {
            var embed = new EmbedBuilder
            {
                Title = "Prime Factorization",
                Description = "```Help > Command > Mathematics General > Prime Factorization```"
            };
            embed.AddField("How to Use", "=PF [Number]")
                .AddField("Usage", "Prime Factorization Function")
                .AddField("Mathematics Introduction", "Find Prime Numbers which form the number")
                .AddField("Alias", "PrimeFactorize, PrimeFactorization, Prime-Factorize, Prime-Factorization")
                .WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }

        [Command("!")]
        [Alias("Factorial", "2-7")]
        public async Task Factorial()
        {
            var embed = new EmbedBuilder
            {
                Title = "Factorial",
                Description = "```Help > Command > Mathematics General > Factorial```"
            };
            embed.AddField("How to Use", "=! [Number]")
                .AddField("Usage", "Factorial Function")
                .AddField("Mathematics Introduction", "[Number]! = [Number] * [Number - 1] * ... * 1")
                .AddField("Alias", "Factorial")
                .WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }

        [Command("nCr")]
        [Alias("Combinations", "2-8")]
        public async Task Combinations()
        {
            var embed = new EmbedBuilder
            {
                Title = "Combinations",
                Description = "```Help > Command > Mathematics General > Combinations```"
            };
            embed.AddField("How to Use", "=nCr [n] [r]")
                .AddField("Usage", "Combinations Function")
                .AddField("Mathematics Introduction", "Counting how many group of a selected numbers (The order is not important)\n**n** for total numbers\n**r** for the number of selected")
                .AddField("Alias", "Combinations")
                .WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }

        [Command("nPr")]
        [Alias("Permutations", "2-9")]
        public async Task Permutations()
        {
            var embed = new EmbedBuilder
            {
                Title = "Permutations",
                Description = "```Help > Command > Mathematics General > Permutations```"
            };
            embed.AddField("How to Use", "=nPr [n] [r]")
                .AddField("Usage", "Permutations Function")
                .AddField("Mathematics Introduction", "Counting how many order of a the pairs of certain number\n**n** for total numbers\n**r** for the number of selected")
                .AddField("Alias", "Permutations")
                .WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }

        [Command("^")]
        [Alias("Pow", "Power", "2-10")]
        public async Task Power()
        {
            var embed = new EmbedBuilder
            {
                Title = "Power",
                Description = "```Help > Command > Mathematics General > Power```"
            };
            embed.AddField("How to Use", "=^ [Numebr] [Power]")
                .AddField("Usage", "Power Function")
                .AddField("Mathematics Introduction", "[Number]^[Power]")
                .AddField("Alias", "Pow, Power")
                .WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }

        [Command("Identity")]
        [Alias("Identities", "2-11")]
        public async Task Identity()
        {
            var embed = new EmbedBuilder
            {
                Title = "Identity",
                Description = "```Help > Command > Mathematics General > Identity```"
            };
            embed.AddField("How to Use", "=Identity")
                .AddField("Usage", "Give you Identities")
                .AddField("Mathematics Introduction", "Give you Identities Only")
                .AddField("Alias", "Identities")
                .WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }

        [Command("Base-2")]
        [Alias("Base2", "3-1")]
        public async Task Base2()
        {
            var embed = new EmbedBuilder
            {
                Title = "Base 2",
                Description = "```Help > Command > Mathematics Base > Base 2```"
            };
            embed.AddField("How to Use", "=Base-2 [Number in the corresponding base] [Base (Default as Base 10)]")
                .AddField("Usage", "Change Base 16 or Base 10 to Base 2")
                .AddField("Mathematics Introduction", "Change Base 16 or Base 10 to Base 2")
                .AddField("Alias", "Base2")
                .WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }

        [Command("Base-16")]
        [Alias("Base16", "3-2")]
        public async Task Base16()
        {
            var embed = new EmbedBuilder
            {
                Title = "Base 16",
                Description = "```Help > Command > Mathematics Base > Base 16```"
            };
            embed.AddField("How to Use", "=Base-16 [Number in the corresponding base] [Base (Default as Base 10)]")
                .AddField("Usage", "Change Base 10 or Base 2 to Base 16")
                .AddField("Mathematics Introduction", "Change Base 10 or Base 2 to Base 16")
                .AddField("Alias", "Base16")
                .WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }

        [Command("Base-10")]
        [Alias("Base10", "3-3")]
        public async Task Base10()
        {
            var embed = new EmbedBuilder
            {
                Title = "Base 10",
                Description = "```Help > Command > Mathematics Base > Base 10```"
            };
            embed.AddField("How to Use", "=Base-10 [Number in the corresponding base] [Base (Default as Base 2)]")
                .AddField("Usage", "Change Base 16 or Base 2 to Base 10")
                .AddField("Mathematics Introduction", "Change Base 16 or Base 2 to Base 10")
                .AddField("Alias", "Base10")
                .WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }

        [Command("Quad")]
        [Alias("Quadratic", "4-1")]
        public async Task Quadratic()
        {
            var embed = new EmbedBuilder
            {
                Title = "Quadratic",
                Description = "```Help > Command > Mathematics Formula > Quadratic```"
            };
            embed.AddField("How to Use", "=Quad [a] [b] [c]")
                .AddField("Usage", "Quadratic Equation")
                .AddField("Mathematics Introduction", "[a]x² + [b]x + [c] by using the find root formula")
                .AddField("Alias", "Quadratic")
                .WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }

        [Command("Sin")]
        [Alias("Sine", "5-1")]
        public async Task Sine()
        {
            var embed = new EmbedBuilder
            {
                Title = "Sine",
                Description = "```Help > Command > Mathematics Trigonometry > Sine```"
            };
            embed.AddField("How to Use", "=Sin [Degree] [Mode (Default as Degree Mode)]")
                .AddField("Usage", "Sine Equation")
                .AddField("Caution", "Mode only have D (Degree) and R (Radian)")
                .AddField("Alias", "Sine")
                .WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }

        [Command("Cos")]
        [Alias("Cosine", "5-2")]
        public async Task Cosine()
        {
            var embed = new EmbedBuilder
            {
                Title = "Cosine",
                Description = "```Help > Command > Mathematics Trigonometry > Cosine```"
            };
            embed.AddField("How to Use", "=Cos [Degree] [Mode (Default as Degree Mode)]")
                .AddField("Usage", "Cosine Equation")
                .AddField("Caution", "Mode only have D (Degree) and R (Radian)")
                .AddField("Alias", "Cosine")
                .WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }

        [Command("Tan")]
        [Alias("Tangent", "5-3")]
        public async Task Tangent()
        {
            var embed = new EmbedBuilder
            {
                Title = "Tangent",
                Description = "```Help > Command > Mathematics Trigonometry > Tangent```"
            };
            embed.AddField("How to Use", "=Tan [Degree] [Mode (Default as Degree Mode)]")
                .AddField("Usage", "Tangent Equation")
                .AddField("Caution", "Mode only have D (Degree) and R (Radian)")
                .AddField("Alias", "Tangent")
                .WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }

        [Command("Csc")]
        [Alias("Cosecant", "5-4")]
        public async Task Cosecant()
        {
            var embed = new EmbedBuilder
            {
                Title = "Cosecant",
                Description = "```Help > Command > Mathematics Trigonometry > Cosecant```"
            };
            embed.AddField("How to Use", "=Csc [Degree] [Mode (Default as Degree Mode)]")
                .AddField("Usage", "Cosecant Equation")
                .AddField("Caution", "Mode only have D (Degree) and R (Radian)")
                .AddField("Alias", "Cosecant")
                .WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }

        [Command("Sec")]
        [Alias("Secant", "5-5")]
        public async Task Secant()
        {
            var embed = new EmbedBuilder
            {
                Title = "Secant",
                Description = "```Help > Command > Mathematics Trigonometry > Secant```"
            };
            embed.AddField("How to Use", "=Sec [Degree] [Mode (Default as Degree Mode)]")
                .AddField("Usage", "Secant Equation")
                .AddField("Caution", "Mode only have D (Degree) and R (Radian)")
                .AddField("Alias", "Secant")
                .WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }

        [Command("Cot")]
        [Alias("Cotangent", "5-6")]
        public async Task Cotangent()
        {
            var embed = new EmbedBuilder
            {
                Title = "Cotangent",
                Description = "```Help > Command > Mathematics Trigonometry > Cotangent```"
            };
            embed.AddField("How to Use", "=Cot [Degree] [Mode (Default as Degree Mode)]")
                .AddField("Usage", "Cotangent Equation")
                .AddField("Caution", "Mode only have D (Degree) and R (Radian)")
                .AddField("Alias", "Cotangent")
                .WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();
            await ReplyAsync("", false, embed.Build());
        }
    }
}
