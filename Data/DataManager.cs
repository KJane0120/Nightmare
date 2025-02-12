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

                }
                return _Instance;
            }
        }

        private static DataManager? _Instance = null;

        public static void Initialize()
        {
            JsonDataLoad();
            Instance.InitializeConsumableItems();
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

        //Dict 데이터 사용시 for문 오류, 아이템 판매 시 출력되는 아이템목록 리스트 생성
        public List<Item> HaveItems = new List<Item>();

        //퀘스트 데이터 리스트
        public List<Quest> QuestDatas = new();


        public int CurrentStageClear;

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
        public Dictionary<long, Player> PlayerDatas = new()
        {
            { 1,new Player() },
            { 2,new Player() },
            { 3,new Player() },
            { 4,new Player() },
            { 5,new Player() }
        };

        public void SetPlayerDatas()
        {
            PlayerDatas[1].Level = GameManager.Instance.Player.Level;
            PlayerDatas[1].Name = GameManager.Instance.Player.Name;
            PlayerDatas[1].Job = Job.Dwarf;
            PlayerDatas[1].Stat = new Stat(10, 5, 100, 100, 30, 30);
            PlayerDatas[1].Gold = GameManager.Instance.Player.Gold;
            PlayerDatas[1].Avd = GameManager.Instance.Player.Avd;
            PlayerDatas[1].Crt = GameManager.Instance.Player.Crt;
            PlayerDatas[1].CurrentExp = 0;
            PlayerDatas[1].QuestGroupId = 12345;

            PlayerDatas[2].Level = GameManager.Instance.Player.Level;
            PlayerDatas[2].Name = GameManager.Instance.Player.Name;
            PlayerDatas[2].Job = Job.NewSister;
            PlayerDatas[2].Stat = new Stat(15, 5, 70, 70, 30, 30);
            PlayerDatas[2].Gold = GameManager.Instance.Player.Gold;
            PlayerDatas[2].Avd = GameManager.Instance.Player.Avd;
            PlayerDatas[2].Crt = GameManager.Instance.Player.Crt;
            PlayerDatas[2].CurrentExp = 0;
            PlayerDatas[2].QuestGroupId = 12345;

            PlayerDatas[3].Level = GameManager.Instance.Player.Level;
            PlayerDatas[3].Name = GameManager.Instance.Player.Name;
            PlayerDatas[3].Job = Job.Saison;
            PlayerDatas[3].Stat = new Stat(12, 7, 100, 100, 20, 20);
            PlayerDatas[3].Gold = GameManager.Instance.Player.Gold;
            PlayerDatas[3].Avd = GameManager.Instance.Player.Avd;
            PlayerDatas[3].Crt = GameManager.Instance.Player.Crt;
            PlayerDatas[3].CurrentExp = 0;
            PlayerDatas[3].QuestGroupId = 12345;

            PlayerDatas[4].Level = GameManager.Instance.Player.Level;
            PlayerDatas[4].Name = GameManager.Instance.Player.Name;
            PlayerDatas[4].Job = Job.OctopusWitch;
            PlayerDatas[4].Stat = new Stat(7, 4, 50, 50, 50, 50);
            PlayerDatas[4].Gold = GameManager.Instance.Player.Gold;
            PlayerDatas[4].Avd = GameManager.Instance.Player.Avd;
            PlayerDatas[4].Crt = GameManager.Instance.Player.Crt;
            PlayerDatas[4].CurrentExp = 0;
            PlayerDatas[4].QuestGroupId = 12345;

            PlayerDatas[5].Level = GameManager.Instance.Player.Level;
            PlayerDatas[5].Name = GameManager.Instance.Player.Name;
            PlayerDatas[5].Job = Job.WildAnimal;
            PlayerDatas[5].Stat = new Stat(20, 10, 150, 150, 10, 10);
            PlayerDatas[5].Gold = GameManager.Instance.Player.Gold;
            PlayerDatas[5].Avd = GameManager.Instance.Player.Avd;
            PlayerDatas[5].Crt = GameManager.Instance.Player.Crt;
            PlayerDatas[5].CurrentExp = 0;
            PlayerDatas[5].QuestGroupId = 12345;
        }


        //소모성 아이템(전투 중 볼 수 있는 인벤토리) 리스트(포션 3종+스페셜 드랍아이템 5종)
        public List<Item> ConsumableItems = new();
        
        
        //보스 처치시 필요한 필수 아이템 데이터
        public Dictionary<long, KillBossItem> KillBossItemDatas = new();

        //기본 포션 3개씩 추가하는 함수
        public void InitializeConsumableItems()
        {
            foreach (var portion in PortionDatas.Where(p => p.PortionId == 18 || p.PortionId == 24))
            {
                if (ItemDatas.TryGetValue(portion.PortionId, out Item itemData))
                {
                    // PortionCount만큼 ConsumableItems 리스트에 추가
                    for (int i = 0; i < portion.PortionCount; i++)
                    {
                        ConsumableItems.Add(itemData);
                        HaveItems.Add(itemData);
                    }
                }
            }
        }

        //스테이지 클리어별 보상에서 드랍될 시 추가해주기(Reward class를 활용하기로 함)

        //장착된 아이템 리스트
        public List<Item> EquippedItems = new();

        public List<Portion> PortionDatas = new()
        {
            
            new Portion()
            {
                PortionId = 18,
                PortionCount = 3,
                PortionMaxCount = 3
            },
            new Portion()
            {
                PortionId = 24,
                PortionCount = 3,
                PortionMaxCount = 3
            },
            new Portion()
            {
                PortionId = 25,
                PortionCount = 0,
                PortionMaxCount = 4
            }
        };
    }
}



