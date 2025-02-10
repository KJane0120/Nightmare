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
        public Dictionary<int, Item> ShopItems = new()
        {
            {1, new Item()
            {
                Id = 1,
                Name = "광부의 복수 곡괭이",
                Type = ItemType.Weapon,
                Atk = 10,
                Def = 0,
                Hp = 0,
                Avd = 0,
                Crt = 0,
                Desc = "보석 대신 적의 두개골을 깨부수는 강철 곡괭이"
            } },
            {2, new Item()
            {
                Id = 2,
                Name = "하이 호 가죽모자",
                Type = ItemType.Armor,
                Atk = 0,
                Def = 10,
                Hp = 0,
                Avd = 0,
                Crt = 0,
                Desc = "두들겨 맞아도 끄떡없는 마법의 모자"
            } },
            {3, new Item()
            {
                Id = 3,
                Name = "분노의 부지깽이",
                Type = ItemType.Weapon,
                Atk = 10,
                Def = 0,
                Hp = 0,
                Avd = 0,
                Crt = 0,
                Desc = "신데렐라를 못 잡은 새언니의 분노가 깃든 부지깽이"
            } },
            {4, new Item()
            {
                Id = 4,
                Name = "찢긴 무도회 드레스",
                Type = ItemType.Armor,
                Atk = 0,
                Def = 10,
                Hp = 0,
                Avd = 0,
                Crt = 0,
                Desc = "신데렐라의 눈물과 한으로 꿰멘 드레스"
            } },
            {5, new Item()
            {
                Id = 5,
                Name = "저주의 회중시계",
                Type = ItemType.Weapon,
                Atk = 10,
                Def = 0,
                Hp = 0,
                Avd = 0,
                Crt = 0,
                Desc = "시간을 되돌릴 순 없어도, 적의 숨은 멈출 수 있는 시계"
            } },
            {6, new Item()
            {
                Id = 6,
                Name = "핏빛 은쟁반",
                Type = ItemType.Armor,
                Atk = 0,
                Def = 10,
                Hp = 0,
                Avd = 0,
                Crt = 0,
                Desc = "수많은 배신과 독을 거쳐 살아남은 은쟁반"
            } },
            {7, new Item()
            {
                Id = 7,
                Name = "혼을 빼앗는 수정구",
                Type = ItemType.Weapon,
                Atk = 10,
                Def = 0,
                Hp = 0,
                Avd = 0,
                Crt = 0,
                Desc = "적을 유혹한 후 파멸시키는 마녀의 수정구"
            } },
            {8, new Item()
            {
                Id = 8,
                Name = "침묵의 소라목걸이",
                Type = ItemType.Armor,
                Atk = 0,
                Def = 10,
                Hp = 0,
                Avd = 0,
                Crt = 0,
                Desc = "깊고 깊은 어둠 속에서 주운 목걸이"
            } },
            //문장반지랑 그림자 턱시도는 공격력/방어력이 아닌 다른 스탯을 가지고 있음 일단 무기, 방어구로 작성해놓겠음
            {9, new Item()
            {
                Id = 9,
                Name = "야수의 문장반지",
                Type = ItemType.Weapon,
                Atk = 10,
                Def = 0,
                Hp = 0,
                Avd = 0,
                Crt = 0,
                Desc = "낀 순간 손톱이 날카로워진다"
            } },
            {10, new Item()
            {
                Id = 10,
                Name = "그림자 턱시도",
                Type = ItemType.Armor,
                Atk = 0,
                Def = 10,
                Hp = 0,
                Avd = 0,
                Crt = 0,
                Desc = "낀 순간 손톱이 날카로워진다"
            } }
        };

        //가지고 있는 아이템 리스트
        public Dictionary<int, Item> HaveItems = new() { };

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
    }

}
//장착된 아이템 리스트

//보스드랍아이템 리스트



