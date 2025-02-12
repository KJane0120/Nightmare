using System.ComponentModel;

namespace Nightmare
{
    public enum ItemType
    {
        None = 0,
        [Description("무기")]
        Weapon = 1,
        [Description("방어구")]
        Armor = 2,
        [Description("액세서리")]
        Accessory = 3,
        [Description("하트조각")]
        HeartPiece = 4,
        [Description("체력 회복 포션")]
        HPPotion = 5,
        [Description("마나 회복 포션")]
        MPPotion = 6,
        [Description("스페셜 아이템")]
        Special = 7,
    }
    public class Item
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ItemType Type { get; set; }

        //Hp, Mp, Atk, Def, Avd, Crt를 하나의 변수로 묶어 아이템타입이 ~면 ~증가. 
        public float Value { get; set; }
        public string? Desc { get; set; }
        public int Cost { get; set; }
        public bool IsPurchase { get; set; } = false;
        public bool IsEquip { get; set; } = false;

        public bool IsSold { get; set; } = false;

        //무기인지 방어구인지에 따라 공격력이나 방어력을 출력
        public string GetTypeString()
        {
            string str = "";
            switch (Type)
            {
                case ItemType.Weapon:
                    str = $"공격력 +{Value}";
                    break;
                case ItemType.Armor:
                    str = $"방어력 +{Value}";
                    break;
                case ItemType.Accessory:
                    str = $"치명타율 +{Value} | 회피율 +{Value}";
                    break;
                case ItemType.HeartPiece:
                    str = "";
                    break;
                case ItemType.HPPotion:
                    str = $"HP +{Value}";
                    break;
                case ItemType.MPPotion:
                    str = $"MP +{Value}";
                    break;
                case ItemType.Special:
                    str = $"HP +{Value} | MP +{Value}";
                    break;


            }
            return str;


        }
        //구매 여부에 따른 출력
        public string GetPriceString()
        {
            string str = IsPurchase ? "구매 완료" : $"{Cost}";
            return str;
        }
        //상점아이템 정보 출력 양식
        public string ShowShopItem()
        {
            string str = $"{Name} | {GetTypeString()} | {Desc} | {GetPriceString()}";
            return str;
        }
        //아이템판매 시 정보 출력 양식
        public string ShowSellItem()
        {
            string str = $"{Name} | {GetTypeString()} | {Desc} ";
            str += IsSold ? " | 판매완료" : $" | {Cost * 0.85f} G";
            return str;
        }
        public string SelectItem()
        {
            string str = IsEquip ? "[E]" : "";
            str += $"{Name} | {GetTypeString()} | {Desc}";
            return str;
        }

        public override string ToString()
        {
            String s = $"{Name}";
            return s;
        }

        public virtual void UseItem(Item item)
        {
            // override를 통해 구현 예정
        }

    }
}
