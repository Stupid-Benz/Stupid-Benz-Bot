using Discord.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Stupid_Benz_Bot.Modules
{
    [Group("Play")]
    public class Game_Command : ModuleBase<SocketCommandContext>
    {
        [Command]
        public Task Play()
            => ReplyAsync("Play What?");

        [Command("Slot")]
        public async Task Slot()
        {
            var rand = new Random();
            string[] Slot = new string[] { "🍒", "🍌", "🍍", "🍎", "🍓", "🍑", "7️⃣" };
            int[] List = { rand.Next(Slot.Length), rand.Next(Slot.Length), rand.Next(Slot.Length) };
            int[] FList = { List[0] - 1, List[1] - 1, List[2] - 1 };
            int[] TList = { List[0] + 1, List[1] + 1, List[2] + 1 };
            int count = 0;
            foreach (int listnum in List)
            {
                if (listnum == 0)
                {
                    FList[count] = 6;
                }
                else if (listnum == 6)
                {
                    TList[count] = 0;
                }
                count++;
            }
            var msg = await ReplyAsync($"{Slot[FList[0]]} |" + "\n"
                + $"{Slot[List[0]]} |" + " ⬅️" + "\n"
                + $"{Slot[TList[0]]} |"
                );
            Thread.Sleep(500);
            await msg.ModifyAsync(m => 
            {
                m.Content = $"{Slot[FList[0]]} | {Slot[FList[1]]} |" + "\n"
                + $"{Slot[List[0]]} | {Slot[List[1]]} |" + " ⬅️" + "\n"
                + $"{Slot[TList[0]]} | {Slot[TList[1]]} |";
            }
            );
            Thread.Sleep(500);
            await msg.ModifyAsync(m => 
            {
                m.Content = $"{Slot[FList[0]]} | {Slot[FList[1]]} | {Slot[FList[2]]}" + "\n"
                + $"{Slot[List[0]]} | {Slot[List[1]]} | {Slot[List[2]]}" + " ⬅️" + "\n"
                + $"{Slot[TList[0]]} | {Slot[TList[1]]} | {Slot[TList[2]]}";
            }
            );
            Thread.Sleep(500);
            if (List[0] == List[1] && List[0] == List[2])
            {
                await msg.ModifyAsync(m =>
                {
                    m.Content = "You win";
                }
                );
            }
            else
            {
                await msg.ModifyAsync(m =>
                {
                    m.Content = "You lose";
                }
                );
            }
        }
    }
}
