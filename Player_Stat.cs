using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nightmare
{
    public class Stat
    {
        public int Atk = 10;
        public int EquipAtk = 0;
        public int Def = 5;
        public int EquipDef = 0;
        public int Hp = 100;
        public int MaxHp = 100;
        public int Mp = 50;
        public int MaxMp = 50;
    }


    public class Level
    {
        public int PlayerLevel;

        public Level()
        {
            PlayerLevel = 1;
        }
    }

    public class Gold
    {
        public int PlayerGold;
        public Gold()
        {
            PlayerGold = 1500;
        }
    }


    public enum Job
    {
        None = 0,

        [Description("일곱번째 난쟁이")]
        Dwarf = 1,

        [Description("새언니")]
        NewSister = 2,

        [Description("시종")]
        Saison = 3,

        [Description("문어 마녀")]
        OctopusWitch = 4,

        [Description("인간버전 야수")]
        WildAnimal = 5

    };


}
