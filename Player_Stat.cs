using System.ComponentModel;

namespace Nightmare
{
    public class Stat
    {
        public float Atk = 10;
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
