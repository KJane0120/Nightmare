using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nightmare.Data
{
    public class Item
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ItemType Type { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Hp { get; set; }
        public int Avd { get; set; }
        public int Crt { get; set; }
        public string? Desc { get; set; }

        public int Cost { get; set; }
        public bool IsPurchase { get; set; } = false;
        public bool IsEquip { get; set; } = false;

        public bool IsSold { get; set; } = false;

        public enum ItemType
        {
            None,
            [Description("무기")]
            Weapon,
            [Description("방어구")]
            Armor,
        }
        //무기인지 방어구인지에 따라 공격력이나 방어력을 출력
        public string GetTypeString()
        {
            string str = (Type == ItemType.Weapon) ? $"공격력 +{Atk}" : $"방어력 +{Def}";
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
    }
}
