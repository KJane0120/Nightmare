using Newtonsoft.Json;
using System.Data;
using static Nightmare.GameManager;

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
                }
                return _Instance;
            }
        }

        private static DataManager? _Instance = null;

        private static bool isInitialized = false;

        private SaveGameData? saveGameData;

        private readonly string SAVEDATA_FILENAME = "SaveData";

        private readonly string SAVEDATA_FOLIDERNAME = "SaveData";

        public Player Player { get; set; } = new();
        public int CurrentEqisodeNumber { get; set; } = 0;

        public Dictionary<long, Player> CanSelectPlayers = new();

        //Dict 데이터 사용시 for문 오류, 아이템 판매 시 출력되는 아이템목록 리스트 생성
        public List<Item> HaveItems = new List<Item>();

        //퀘스트 데이터 리스트
        public List<Quest> QuestDatas = new();

        //아이템 데이터 리스트
        public Dictionary<long, Item> ItemDatas = new() { };

        //몬스터 데이터
        [JsonIgnore]
        public Dictionary<long, Boss> BossDatas = new();

        //플레이어 데이터
        [JsonIgnore]
        public Dictionary<long, Player> PlayerDatas = new()
        {
            { 1,new Player() },
            { 2,new Player() },
            { 3,new Player() },
            { 4,new Player() },
            { 5,new Player() }
        };

        //소모성 아이템(전투 중 볼 수 있는 인벤토리) 리스트(포션 3종+스페셜 드랍아이템 5종)
        [JsonIgnore]
        public List<Potion> HealthConsumableItems = new();
        [JsonIgnore]
        public List<Potion> ManaConsumableItems = new();
        [JsonIgnore]
        public List<Potion> LoveConsumableItems = new();
        [JsonIgnore]
        public List<Item> BossConsumableItems = new();
        //보스 처치시 필요한 필수 아이템 데이터
        [JsonIgnore]
        public Dictionary<long, KillBossItem> KillBossItemDatas = new();

        public List<Item> EquippedItems = new();

        [JsonIgnore]
        public List<Potion> PortionDatas = new()
        {
            new Potion()
            {
                PotionId = 18,
                PotionCount = 0,
                PotionMaxCount = 3
            },
            new Potion()
            {
                PotionId = 24,
                PotionCount = 0,
                PotionMaxCount = 3
            },
            new Potion()
            {
                PotionId = 25,
                PotionCount = 0,
                PotionMaxCount = 4
            }
        };

        public static void Initialize()
        {
            if (isInitialized)
            {
                return;
            }
            isInitialized = true;
            JsonDataLoad();
            Instance.SetPlayerDatas();
        }

        private static void JsonDataLoad()
        {
            string questfilePath = GetFilePath("QuestData", "Data\\Quest");
            string bossfilePath = GetFilePath("BossData", "Data");
            string itemfilePath = GetFilePath("ItemData", "Data\\Item");

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

        private static string GetFilePath(string fileName, string folderName)
        {
            var paths = AppDomain.CurrentDomain.BaseDirectory.Split('\\');
            var newPath = "";

            for (int i = 0; i < paths.Length - 4; i++)
            {
                newPath += paths[i] + "\\";
            }

            newPath += $"{folderName}\\{fileName}.json";

            return newPath;
        }

        public void SaveGameData()
        {
            if (saveGameData == null)
            {
                saveGameData = new SaveGameData();
            }

            string GameData = JsonConvert.SerializeObject(Instance);
            File.WriteAllText(GetFilePath(SAVEDATA_FOLIDERNAME, SAVEDATA_FILENAME), GameData);
        }

        public void LoadGameData()
        {
            if (!IsExistSaveData())
            {
                Initialize();
                return;
            }
            else
            {
                string GameData = File.ReadAllText(GetFilePath(SAVEDATA_FOLIDERNAME, SAVEDATA_FILENAME));
                var dataManager = JsonConvert.DeserializeObject<DataManager>(GameData);

                Instance.Player = dataManager.Player;
                Instance.CurrentEqisodeNumber = dataManager.CurrentEqisodeNumber;
                Instance.CanSelectPlayers = dataManager.CanSelectPlayers;
                Instance.HaveItems = dataManager.HaveItems;
                Instance.ItemDatas = dataManager.ItemDatas;
                Instance.EquippedItems = dataManager.EquippedItems;
                Instance.QuestDatas = dataManager.QuestDatas;
            }
        }

        public bool IsExistSaveData()
        {
            return File.Exists(GetFilePath(SAVEDATA_FOLIDERNAME, SAVEDATA_FILENAME));
        }

        //퀘스트 가져오기
        public List<Quest> GetPlayerQuestGroup()
        {
            long playerQuestGroupId = GameManager.Instance.Player.QuestGroupId;

            bool isDisplay(long questGroupId)
            {
                //TODO:보스 하나를 처치했을때 표시되는 퀘스트  
                return questGroupId == 0 || questGroupId == playerQuestGroupId;
            }

            return QuestDatas.Where(x => isDisplay(x.QuestGroupId) || GameManager.Instance.GameClearCount > 0 && x.QuestGroupId == 6).ToList();
        }
        public void SetPlayerDatas()
        {
            PlayerDatas[1].Job = Job.Dwarf;
            PlayerDatas[1].Stat = new Stat(10, 5, 100, 100, 30, 30);
            PlayerDatas[1].QuestGroupId = 1;

            PlayerDatas[2].Job = Job.NewSister;
            PlayerDatas[2].Stat = new Stat(15, 5, 70, 70, 30, 30);
            PlayerDatas[2].QuestGroupId = 2;

            PlayerDatas[3].Job = Job.Saison;
            PlayerDatas[3].Stat = new Stat(12, 7, 100, 100, 20, 20);
            PlayerDatas[3].QuestGroupId = 3;

            PlayerDatas[4].Job = Job.OctopusWitch;
            PlayerDatas[4].Stat = new Stat(7, 4, 50, 50, 50, 50);
            PlayerDatas[4].QuestGroupId = 4;

            PlayerDatas[5].Job = Job.WildAnimal;
            PlayerDatas[5].Stat = new Stat(20, 10, 150, 150, 10, 10);
            PlayerDatas[5].QuestGroupId = 5;

            UpdateCanSelectPlayers();
        }

        public void UpdateCanSelectPlayers()
        {
            CanSelectPlayers.Clear();
            int i = 0;
            foreach (var player in Instance.PlayerDatas.Values)
            {
                CanSelectPlayers.Add(i + 1, player);
                i++;
            }
        }

        public List<Item> EquippedItems = new();

        public List<Potion> PortionDatas = new()
        {

            new Potion()
            {
                PotionId = 18,
                PotionCount = 0,
                PotionMaxCount = 3
            },
            new Potion()
            {
                PotionId = 24,
                PotionCount = 0,
                PotionMaxCount = 3,
            },
            new Potion()
            {
                PotionId = 25,
                PotionCount = 0,
                PotionMaxCount = 4,
            }
        };

        public void ResetData()
        {
            // 가지고 있는 아이템 중에 하트조각과 스페셜 아이템 이외에 아이템은 삭제
            HaveItems.RemoveAll(x => x.Type == ItemType.HeartPiece && x.Type == ItemType.Special);

            // 장착된 아이템 삭제
            EquippedItems.Clear();

            //플레이한 직업 삭제
            PlayerDatas.Remove((int)GameManager.Instance.Player.Job);
            UpdateCanSelectPlayers();
        }
    }
}



