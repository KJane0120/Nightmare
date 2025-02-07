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
        string Name { get; set; }
        ItemType Type { get; set; }
        int Attack { get; set; }
        int Defense { get; set; }
        int Health { get; set; }
        int Avoidance { get; set; }
        int Critical { get; set; }
        string Description { get; set; }

        public enum ItemType
        {
            //None,
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
