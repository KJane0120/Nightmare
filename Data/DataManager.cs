using System.Xml.Linq;
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
                }
                return _Instance;
            }
        }

        private static DataManager? _Instance = null;

        //아이템 리스트
        //상점 아이템 리스트  
        public Dictionary<int, Item> ShopItems = new();
        

        //가지고 있는 아이템 리스트
        public Dictionary<int, Item> HaveItems = new() { };

        //Dict 데이터 사용시 for문 오류, 아이템 판매 시 출력되는 아이템목록 리스트 생성
        public List<Item> HaveItemDatas = new List<Item>();

        //퀘스트 데이터 리스트
        public List<Quest> QuestDatas = new List<Quest>();

        //플레이어 전용 퀘스트 가져오기
        public List<Quest> GetPlayerQuestGroup(long questGroupId)
        {
            return QuestDatas.Where(x => x.QuestGroupId == questGroupId).ToList();
        }

        //아이템 데이터 리스트
        public Dictionary<long, Item> ItemDatas = new() { };

        //몬스터 데이터
        public Dictionary<long, Boss> BossDatas = new ();

        //플레이어 데이터
        public Dictionary<long, Player> PlayerDatas = new();
    }

}
//장착된 아이템 리스트

//보스드랍아이템 리스트



