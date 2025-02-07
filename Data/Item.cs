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
        public bool IsPurchase { get; set; }
        public bool IsEquip { get; set; }

        public enum ItemType
        {
            None,
            [Description("무기")]
            Weapon,
            [Description("방어구")]
            Armor,
        }

        public string GetTypeString()
        {
            string str = (Type == ItemType.Weapon) ? $"공격력 +{Atk}" : $"방어력 +{Def}";
            return str;
        }

        public string GetPriceString()
        {
            string str = IsPurchase ? "구매 완료" : $"{Cost}";
            return str;
        }
        public string ShowShopItem()
        {
            string str = $"{Name} | {GetTypeString()} | {Desc} | {GetPriceString()}";
            return str;
        }
    }
    public class ShopItem : Item
    {
        
    }

    //public interface IEquip
    //{
    //    void Equip();
    //}

    //public interface IUnEquip
    //{
    //    void UnEquip();
    //}

    //public interface IDrop
    //{
    //    void Drop();
    //}

    //public interface IPickUp
    //{
    //    void PickUp();
    //}

}
