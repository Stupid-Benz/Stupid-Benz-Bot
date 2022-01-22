using Discord;
using Discord.Audio;
using Discord.Net.Providers.WS4Net;
using Discord.Audio.Streams;
using Discord.Commands;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Misaka_Project.Slash_Commands
{
    
    public class Voice : ModuleBase
    {

        [Command("join", RunMode = RunMode.Async)]
        public async Task JoinChannel(IVoiceChannel channel = null)
        {
            channel = channel ?? (Context.User as IGuildUser)?.VoiceChannel;
            if (channel == null) { await Context.Channel.SendMessageAsync("User must be in a voice channel, or a voice channel must be passed as an argument."); }

            await channel.ConnectAsync(true, false, true);
        }

        [Command("Leave", RunMode = RunMode.Async)]
        public async Task LeaveChannel()
        {
            await (Context.User as IGuildUser).VoiceChannel.DisconnectAsync();
        }

        [Command("Play", RunMode = RunMode.Async)]
        public async Task Play(string url = null)
        {
            IVoiceChannel channel = (Context.User as IGuildUser)?.VoiceChannel;
            IAudioClient audioClient = await channel.ConnectAsync(true, false, true);
            await SendAsync(audioClient, url);
        }

        private Process CreateStream(string path)
        {
            return Process.Start(new ProcessStartInfo
            {
                FileName = "ffmpeg",
                Arguments = $"-hide_banner -loglevel panic -i \"{path}\" -ac 2 -f s16le -ar 48000 pipe:1",
                UseShellExecute = false,
                RedirectStandardOutput = true,
            });
        }

        private async Task SendAsync(IAudioClient client, string path)
        {
            // Create FFmpeg using the previous example
            var ffmpeg = CreateStream(path);
            var output = ffmpeg.StandardOutput.BaseStream;
            var discord = client.CreatePCMStream(AudioApplication.Voice, 48000);
            {
                try { await output.CopyToAsync(discord); }
                finally { await discord.FlushAsync(); }
            }
        }
    }
}
