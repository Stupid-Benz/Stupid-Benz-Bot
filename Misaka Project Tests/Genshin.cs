using System;
using System.Collections.Generic;
using Xunit;

namespace Misaka_Project_Tests
{
    public class Genshin
    {
        [Fact]
        public void Test1()
        {
            var TalentPeople = new Dictionary<string, List<string>>
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

            var PeopleJapaneseName = new Dictionary<string, string>
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

            List<List<string>> peopleNames = new List<List<string>>();
            peopleNames.Add(TalentPeople["Freedom"]);

            Console.WriteLine(peopleNames[0]);
        }
    }
}