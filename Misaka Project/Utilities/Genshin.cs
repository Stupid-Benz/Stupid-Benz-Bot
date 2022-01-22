using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misaka_Project.Utilities
{
    public class GenshinTalent
    {
        public static Dictionary<string, string> TalentJapanese = new Dictionary<string, string>
            {
                { "Freedom", "自由" },
                { "Resistance", "抗争" },
                { "Ballad", "詩文" },
                { "Prosperity", "繁栄" },
                { "Diligence", "勤労" },
                { "Gold", "黄金" },
                { "Transience", "浮世" },
                { "Elegance" , "風雅" },
                { "Light", "天光" }
            };
        public static Dictionary<string, List<string>> TalentPeople = new Dictionary<string, List<string>>
            {
                { "Freedom", new List<string> { "Aloy", "Klee", "Tartaglia", "Amber", "Barbara", "Diona", "Sucrose" } },
                { "Resistance", new List<string> { "Diluc", "Eula", "Jean", "Mona", "Bennett", "Noelle", "Razor" } },
                { "Ballad", new List<string> { "Albedo", "Venti", "Fischl", "Kaeya", "Lisa", "Rosaria" } },
                { "Prosperity", new List<string> { "Keqing", "Qiqi", "Shenhe", "Xiao", "Ningguang"} },
                { "Diligence", new List<string> { "Ganyu", "Hu_Tao", "Kaedehara_Kazuha", "Chongyun", "Xiangling", "Yun_Jin" } },
                { "Gold", new List<string> { "Zhongli", "Beidou", "Xingqiu", "Xinyan", "Yanfei" } },
                { "Transience", new List<string> { "Sangonomiya_Kokomi", "Yoimiya", "Thoma" } },
                { "Elegance" , new List<string> { "Arataki_Itto", "Kamisato_Ayaka", "Kujou_Sara" } },
                { "Light", new List<string> { "Raiden_Shogun", "Sayu", "Gorou" } }
            };
        public static Dictionary<string, string> PeopleJapaneseName = new Dictionary<string, string>
            {
                { "Aloy", "アーロイ" },
                { "Arataki_Itto", "荒瀧一斗" },
                { "Albedo", "アルベド"},
                { "Amber", "アンバー" },
                { "Venti", "ウェンティ" },
                { "Yun_Jin", "雲菫" },
                { "Eula", "エウルア" },
                { "Yanfei", "煙緋" },
                { "Kaeya", "ガイア" },
                { "Kaedehara_Kazuha", "楓原万葉" },
                { "Kamisato_Ayaka", "神里綾華" },
                { "Ganyu", "甘雨" },
                { "Ningguang", "凝光" },
                { "Kujou_Sara", "九条裟羅" },
                { "Klee", "クレー" },
                { "Keqing", "刻晴" },
                { "Gorou", "ゴロー" },
                { "Sayu", "早柚" },
                { "Sangonomiya_Kokomi", "珊瑚宮心海" },
                { "Xiangling", "香菱" },
                { "Xiao", "魈" },
                { "Zhongli", "鍾離" },
                { "Jean", "ジン" },
                { "Xinyan", "辛炎" },
                { "Shenhe", "申鶴" },
                { "Sucrose", "スクロース" },
                { "Tartaglia", "タルタリヤ" },
                { "Chongyun", "重雲" },
                { "Diona", "ディオナ" },
                { "Diluc", "ディルック" },
                { "Thoma", "トーマ" },
                { "Qiqi", "七七" },
                { "Noelle", "ノエル" },
                { "Barbara", "バーバラ" },
                { "Fischl", "フィッシュル" },
                { "Hu_Tao", "胡桃" },
                { "Bennett", "ベネット" },
                { "Beidou", "北斗" },
                { "Mona", "モナ" },
                { "Xingqiu", "行秋" },
                { "Yoimiya", "宵宮" },
                { "Raiden_Shogun", "雷電将軍" },
                { "Lisa", "リサ" },
                { "Razor", "レザー" },
                { "Rosaria", "ロサリア" }
            };


        public static string Talent(DayOfWeek day)
        {
            List<string> Sunday = new List<string> { "Freedom", "Resistance", "Ballad", "Prosperity", "Diligence", "Gold", "Transience", "Elegance", "Light" };
            List<string> MondayAndThursday = new List<string> { "Freedom", "Prosperity", "Transience" };
            List<string> TuesdayAndFriday = new List<string> { "Resistance", "Diligence", "Elegance" };
            List<string> WednesdayAndSaturday = new List<string> { "Ballad", "Gold", "Light" };

            switch (day)
            {
                case DayOfWeek.Sunday:
                    return CreateTalentImageAsync(Sunday);
                case DayOfWeek.Monday or DayOfWeek.Thursday:
                    return CreateTalentImageAsync(MondayAndThursday);
                case DayOfWeek.Tuesday or DayOfWeek.Friday:
                    return CreateTalentImageAsync(TuesdayAndFriday);
                case DayOfWeek.Wednesday or DayOfWeek.Saturday:
                    return CreateTalentImageAsync(WednesdayAndSaturday);
                default:
                    return null;
            }
        }

        public static string CreateTalentImageAsync(List<string> talentDay)
        {
            List<string> talentJapaneseNames = new List<string>();
            List<string> talentUrl = new List<string>();

            foreach (var talent in talentDay)
            {
                talentJapaneseNames.Add(TalentJapanese[talent]);
                talentUrl.Add($"Talent\\Item_Philosophies_of_{talent}.png");
            }

            List<Image> talentImage = new List<Image>();

            foreach (var url in talentUrl)
            {
                Image presentImage = ClipImageToCircle(Image.FromFile(url));
                talentImage.Add(presentImage);
            }

            Image background = Image.FromFile("Background\\genshin-impact-03.jpg");

            var banner = CopyRegionIntoImage(talentImage, background);
            banner = DrawTextToImage(banner, String.Join(", ", talentJapaneseNames));

            string path = $"{Guid.NewGuid()}.png";
            banner.Save(path);
            return path;
        }

        private static Image ClipImageToCircle(Image Image)
        {
            Image destination = new Bitmap(Image.Width, Image.Height, Image.PixelFormat);
            var radius = Image.Width / 2;
            var x = Image.Width / 2;
            var y = Image.Height / 2;

            using Graphics g = Graphics.FromImage(destination);
            var r = new Rectangle(x - radius, y - radius, radius * 2, radius * 2);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (Brush brush = new SolidBrush(Color.Transparent))
            {
                g.FillRectangle(brush, 0, 0, destination.Width, destination.Height);
            }

            var path = new GraphicsPath();
            path.AddEllipse(r);
            g.SetClip(path);
            g.DrawImage(Image, 0, 0);

            return destination;
        }

        private static Image CopyRegionIntoImage(List<Image> source, Image destination)
        {
            using var grD = Graphics.FromImage(destination);
            if (source.Count == 3)
            {
                var x = (destination.Width / 4) - 512;
                var y = (destination.Height / 2) - 512;
                foreach (var image in source)
                {
                    grD.DrawImage(image, x, y, 1024, 1024);
                    x += (destination.Width / 4);
                }
                return destination;
            }
            else
            {
                var x = (destination.Width / 4) - 256;
                var y = (destination.Height / 4) - 256;
                int i = 0;
                foreach (var image in source)
                {
                    grD.DrawImage(image, x, y, 512, 512);
                    x += destination.Width / 4;
                    i++;
                    if (i == 3 || i ==6) 
                    {
                        y += destination.Height / 4;
                        x = (destination.Width / 4) - 256;
                    }
                }
                return destination;
            }
        }

        private static Image DrawTextToImage(Image Image, string header)
        {
            var DFKai = new Font("DFKai-SB", 96, FontStyle.Bold);

            var brushWhite = new SolidBrush(Color.White);
            var brushBlack = new SolidBrush(Color.Black);

            var headerX = Image.Width / 2;
            var headerY = Image.Height - 256;

            var drawFormat = new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            };

            using var GrD = Graphics.FromImage(Image);
            var sizeOfFont = GrD.MeasureString(header, DFKai).ToSize();
            var rect = new Rectangle(new Point(headerX - sizeOfFont.Width / 2, headerY - sizeOfFont.Height / 2), sizeOfFont);
            GrD.FillRectangle(brushWhite, rect);
            GrD.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            GrD.DrawString(header, DFKai, brushBlack, headerX, headerY, drawFormat);

            return Image;
        }
    }

    //public class Genshin
}
