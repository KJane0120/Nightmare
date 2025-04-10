﻿using System.ComponentModel;

namespace Nightmare
{
    public class Stat
    {
        public float BaseAtk { get; set; }
        public float EquipAtk => equipAtk;
        public float BaseDef { get; set; }
        public float EquipDef => equipDef;
        public float Hp { get; set; }
        public float MaxHp { get; set; }
        public float Mp { get; set; }
        public float MaxMp { get; set; }

        private float equipAtk;

        private float equipDef;

        public void AddEquipAtk(float add)
        {
            equipAtk += add;
        }
        public void AddEquipDef(float add)
        {
            equipDef += add;
        }
        public void SubtEquipAtk(float subt)
        {
            equipAtk -= subt;
        }
        public void SubtEquipDef(float subt)
        {
            equipDef -= subt;
        }

        public Stat(float baseAtk, float baseDef, float hp, float maxHp, float mp, float maxMp)
        {
            BaseAtk = baseAtk;
            BaseDef = baseDef;
            Hp = hp;
            MaxHp = maxHp;
            Mp = mp;
            MaxMp = maxMp;
        }

        public Stat()
        {
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


    public enum Job
    {
        None = 0,

        [Description("백설공주와 일곱째 난쟁이")]
        Dwarf = 1,

        [Description("신데렐라의 새 언니")]
        NewSister = 2,

        [Description("모두가 잠든 성의 하인")]
        Saison = 3,

        [Description("깊은 바닷속 문어 마녀")]
        OctopusWitch = 4,

        [Description("힘을 잃은 야수")]
        WildAnimal = 5

    };

    public class Avd //회피율
    {
        public float PlayerAvd = 0.1f;
        public float EquipAvd;

        public void AddPlayerAvd(float add) // 회피율 증가
        {
            PlayerAvd += add;
        }
    }


    public class Crt //치명타율
    {
        public float PlayerCrt = 0.15f;
        public float EquipCrt;

        public void AddPlayerCrt(float add) // 치명타 증가
        {
            PlayerCrt += add;
        }
    }
}
