using System.Xml.Linq;
using Nightmare.Data;
using static Nightmare.Data.Item;

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
                Desc = "보석 대신 적의 두개골을 깨부수는 강철 곡괭이",
                Cost = 300
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
                Desc = "두들겨 맞아도 끄떡없는 마법의 모자",
                Cost = 300
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
                Desc = "신데렐라를 못 잡은 새언니의 분노가 깃든 부지깽이",
                Cost = 300
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
                Desc = "신데렐라의 눈물과 한으로 꿰멘 드레스",
                Cost = 1300
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
                Desc = "시간을 되돌릴 순 없어도, 적의 숨은 멈출 수 있는 시계",
                Cost = 500
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
                Desc = "수많은 배신과 독을 거쳐 살아남은 은쟁반",
                Cost = 300
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
                Desc = "적을 유혹한 후 파멸시키는 마녀의 수정구",
                Cost = 800
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
                Desc = "깊고 깊은 어둠 속에서 주운 목걸이",
                Cost = 500
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
                Desc = "낀 순간 손톱이 날카로워진다",
                Cost = 900
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
                Desc = "적의 공격을 한발 앞서 피할 수 있게 해준다.",
                Cost = 1200
            } }
        };

        //가지고 있는 아이템 리스트
        public Dictionary<int, Item> HaveItems = new () {};

        //Dict 데이터 사용시 for문 오류, 아이템 판매 시 출력되는 아이템목록 리스트 생성
        public List<Item> HaveItemDatas = new List<Item> ();

    }

}
//장착된 아이템 리스트

//보스드랍아이템 리스트



