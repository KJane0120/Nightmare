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

        public enum ItemType
        {
            None,
            [Description("무기")]
            Weapon,
            [Description("방어구")]
            Armor,
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
