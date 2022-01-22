using Discord;
using Discord.Commands;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Misaka_Project.Commands
{
    public class Fun : ModuleBase
    {
        [Command("Meme")]
        [Alias("Reddit")]
        public async Task Meme(string subreddit = null)
        {
            subreddit ??= "memes";
            var client = new HttpClient();
            var result = await client.GetStringAsync($"https://reddit.com/r/{subreddit}/random.json?limit=1");
            if (!result.ToString().StartsWith("["))
            {
                JArray array = JArray.Parse(result);
                JObject error = JObject.Parse(array["message"].ToString());
                JObject errorCode = JObject.Parse(array["error"].ToString());
                await ReplyAsync($"No {subreddit} found!\nError Message: {error}\nError Code: {errorCode}");
                return;
            }
            JArray arr = JArray.Parse(result);
            JObject post = JObject.Parse(arr[0]["data"]["children"][0]["data"].ToString());

            var builder = new EmbedBuilder()
                .WithImageUrl(post["url"].ToString())
                .WithColor(Color.Blue)
                .WithTitle(post["title"].ToString())
                .WithUrl($"https://reddit.com{post["permalink"]}")
                .WithFooter($"🗨️ {post["num_comments"]} ⬆️ {post["ups"]}")
                .WithCurrentTimestamp();
            var embed = builder.Build();
            await ReplyAsync("", false, embed);
        }
    }
}
