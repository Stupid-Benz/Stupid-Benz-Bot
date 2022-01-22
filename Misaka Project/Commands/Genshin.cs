using Discord;
using Discord.Commands;
using Misaka_Project.Utilities;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Misaka_Project.Commands
{
    public class Genshin : ModuleBase<SocketCommandContext>
    {

        [Command("Talent", RunMode = RunMode.Async)]
        public async Task Talent(int dayOfWeek = 0)
        {
            DayOfWeek[] dayOfWeeks = { DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday };
            DayOfWeek day = DateTime.Today.DayOfWeek;
            if (dayOfWeek != 0) { day = dayOfWeeks[dayOfWeek]; }
            var path = GenshinTalent.Talent(day);
            await Context.Channel.SendFileAsync(path);
            File.Delete(path);
        }
    }
}
