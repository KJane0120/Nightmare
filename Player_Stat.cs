﻿using System.ComponentModel;
using Nightmare.Data;

namespace Nightmare
{
    public class Stat
    {
        Item itemStat = new Item() { Atk = 0, Def = 0 };
        public float BaseAtk;
        public int EquipAtk;
        public int BaseDef;
        public int EquipDef;
        public int Hp;
        public int MaxHp;
        public int Mp;
        public int MaxMp;

        public Stat()
        {
            EquipAtk = itemStat.Atk;
            EquipDef = itemStat.Def;
        }
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

        [Description("백설공주와 일곱 번째 난쟁이")]
        Dwarf = 1,

        [Description("신데렐라의 새 언니")]
        NewSister = 2,

        [Description("모두가 잠든 성의 하인")]
        Saison = 3,

        [Description("깊은 바다 속 문어 마녀")]
        OctopusWitch = 4,

        [Description("힘을 잃은 야수")]
        WildAnimal = 5

    };

    public class Avd //회피율
    {
        public int PlayerAvd;
        public int EquipAvd;

        public Avd()
        {
            EquipAvd = 0;
            PlayerAvd = 10;
        }
    }


    public class Crt //치명타율
    {
        public int PlayerCrt;
        public int EquipCrt;

        public Crt()
        {
            EquipCrt = 0;
            PlayerCrt = 15;
        }
    }

}
