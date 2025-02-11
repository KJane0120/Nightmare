﻿using Nightmare.Data;
using static Nightmare.Data.Item;
using Newtonsoft.Json;

namespace Nightmare
{
    internal class DataManager
    {
        public static DataManager Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DataManager();
                    Initialize();
                }
                return _Instance;
            }
        }

        private static DataManager? _Instance = null;

        public static void Initialize()
        {
            JsonDataLoad();
        }

        private static void JsonDataLoad()
        {
            string questfilePath = GetFilePath("QuestData");
            string bossfilePath = GetFilePath("BossData");
            string itemfilePath = GetFilePath("ItemData");

            if (!File.Exists(questfilePath))
            {
                Console.WriteLine("파일이 없습니다.");
                return;
            }

            string questJson = File.ReadAllText(questfilePath);
            var questData = JsonConvert.DeserializeObject<List<Quest>>(questJson);
            Instance.QuestDatas = questData;

            if (!File.Exists(bossfilePath))
            {
                Console.WriteLine("파일이 없습니다.");
                return;
            }

            string bossJson = File.ReadAllText(bossfilePath);
            var bossData = JsonConvert.DeserializeObject<Dictionary<long, Boss>>(bossJson);
            Instance.BossDatas = bossData;

            if (!File.Exists(itemfilePath))
            {
                Console.WriteLine("파일이 없습니다.");
                return;
            }

            string itemJson = File.ReadAllText(itemfilePath);
            var itemData = JsonConvert.DeserializeObject<Dictionary<long, Item>>(itemJson);
            Instance.ItemDatas = itemData;

        }

        private static string GetFilePath(string fileName)
        {
            var paths = AppDomain.CurrentDomain.BaseDirectory.Split('\\');
            var newPath = "";

            for (int i = 0; i < paths.Length - 4; i++)
            {
                newPath += paths[i] + "\\";
            }

            newPath += $"Data\\{fileName}.json";

            return newPath;
        }

        //아이템 리스트
        //상점 아이템 리스트  
        public Dictionary<int, Item> ShopItems = new();

        //가지고 있는 아이템 리스트
        public Dictionary<int, Item> HaveItems = new() { };

        //Dict 데이터 사용시 for문 오류, 아이템 판매 시 출력되는 아이템목록 리스트 생성
        public List<Item> HaveItemDatas = new List<Item>();

        //퀘스트 데이터 리스트
        public List<Quest> QuestDatas = new();

        //퀘스트 가져오기
        public List<Quest> GetPlayerQuestGroup()
        {
            long playerQuestGroupId = GameManager.Instance.Player.QuestGroupId;

            bool isDisplay(long questGroupId)
            {
                //TODO:보스 하나를 처치했을때 표시되는 퀘스트  
                return questGroupId == 0 || questGroupId == playerQuestGroupId;
            }

            return QuestDatas.Where(x => isDisplay(x.QuestGroupId)).ToList();
        }

        //아이템 데이터 리스트
        public Dictionary<long, Item> ItemDatas = new() { };

        //몬스터 데이터
        public Dictionary<long, Boss> BossDatas = new();

        //플레이어 데이터
        public Dictionary<long, Player> PlayerDatas = new();

        //소모성 아이템(전투 중 볼 수 있는 인벤토리) 리스트(포션+스페셜 아이템)
        public List<Item> ConsumableItems = new();
        //스테이지 클리어별 보상에서 드랍될 시 추가해주기(Reward class를 활용하기로 함)

    }

}
//장착된 아이템 리스트

//보스드랍아이템 리스트



