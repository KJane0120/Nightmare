using Nightmare.Data;
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
            string fileName = "Data\\QuestData.json";

            if (!File.Exists(GetFilePath(fileName)))
            {
                Console.WriteLine("파일이 없습니다.");
                return;
            }
            else
            {
                //임시로 몬스터 데이터 불러오기 
                //TODO: 합쳐서 불러오기
                string json = File.ReadAllText(fileName);
                string json2 = File.ReadAllText("Data\\BossData.json");
                var data = JsonConvert.DeserializeObject<List<Quest>>(json);
                var data2 = JsonConvert.DeserializeObject<Dictionary<long,Boss>>(json2);

                Instance.BossDatas = data2;
                Instance.QuestDatas = data;
            }
        }

        private static string GetFilePath(string fileName)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            return path;
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
        //스테이지 클리어별 보상에서 드랍될 시 추가해주기
        
    }

}
//장착된 아이템 리스트

//보스드랍아이템 리스트



