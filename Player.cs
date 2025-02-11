using static Nightmare.GameManager;

namespace Nightmare
{
    public class Player
    {
        public Level Level { get; set; }
        public string Name { get; set; } = string.Empty;
        public Job Job { get; set; }
        public Stat Stat { get; set; }
        public Gold Gold { get; set; }
        public Avd Avd { get; set; }
        public Crt Crt { get; set; }

        public long QuestGroupId { get; set; }

        //레벨업 구현 시
        private int _Level = 1;

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
            Console.WriteLine($"회피율 : {(Avd.PlayerAvd + Avd.EquipAvd)} %");
            Console.WriteLine($"치명타율 : {(Crt.PlayerCrt + Crt.EquipCrt)} %");
            Console.WriteLine($"Gold : {Gold.PlayerGold} G");
        }

        //레벨업
        public void LevelUp()
        {
            _Level++;
            Stat.Atk += 0.5f;
            Stat.Def += 1;
        }

        public List<Skill> Playerskill = new List<Skill>();
    }
}

