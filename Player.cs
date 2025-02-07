using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Nightmare
{
    public class Player
    {
        public Level Level { get; set; }
        public string Name { get; set; } = string.Empty;
        public Job Job { get; set; }
        public Stat Stat { get; set; }
        public Gold Gold { get; set; }
                            

        public void StatusDisplay()
        {
            Console.WriteLine($"Lv. {Level.PlayerLevel}");
            Console.WriteLine($"{Name} ( {UtilityManager.GetDescription(Job)} )");
            string str = Stat.EquipAtk == 0 ? $"공격력 : {Stat.Atk}" : $"공격력 : {Stat.Atk + Stat.EquipAtk} (+{Stat.EquipAtk})";
            Console.WriteLine(str);
            str = Stat.EquipDef == 0 ? $"방어력 : {Stat.Def}" : $"방어력 : {Stat.Def + Stat.EquipDef} (+{Stat.EquipDef})";
            Console.WriteLine(str);
            Console.WriteLine($"체력 : {Stat.Hp} / {Stat.MaxHp}");
            Console.WriteLine($"마력 : {Stat.Mp} / {Stat.MaxMp}");
            Console.WriteLine($"Gold : {Gold.PlayerGold} G");
        }


    }
}

