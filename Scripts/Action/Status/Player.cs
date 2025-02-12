﻿using static Nightmare.GameManager;

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
        public int CurrentExp { get; set; }
        public long QuestGroupId { get; set; }



        public void StatusDisplay()
        {
            Console.WriteLine($"Lv. {Level.PlayerLevel}");
            Console.WriteLine($"{Name} ( {UtilityManager.GetDescription(Job)} )");
            string str = Stat.EquipAtk == 0 ? $"공격력 : {Stat.BaseAtk}" : $"공격력 : {Stat.BaseAtk + Stat.EquipAtk} (+{Stat.EquipAtk})";
            Console.WriteLine(str);
            str = Stat.EquipDef == 0 ? $"방어력 : {Stat.BaseDef}" : $"방어력 : {Stat.BaseDef + Stat.EquipDef} (+{Stat.EquipDef})";
            Console.WriteLine(str);
            Console.WriteLine($"체력 : {Stat.Hp} / {Stat.MaxHp}");
            Console.WriteLine($"마력 : {Stat.Mp} / {Stat.MaxMp}");
            Console.WriteLine($"회피율: {Math.Round((Avd.EquipAvd + Avd.PlayerAvd) * 100),0} %");
            Console.WriteLine($"치명타율 : {Math.Round((Crt.PlayerCrt + Crt.EquipCrt) * 100),0} %");
            Console.WriteLine($"Gold : {Gold.PlayerGold} G");
        }

        //레벨업
        //public void LevelUp()
        //{
        //    int[] Exp = { 10, 12, 15, 30, 36, 40, 48, 54, 60 };


        //    if (Level.PlayerLevel < 10)
        //    {
        //        CurrentExp -= Exp[Level.PlayerLevel - 1];
        //        while (Exp[Level.PlayerLevel - 1] < CurrentExp)
        //        {
        //            if (Level.PlayerLevel == 4)
        //            {
        //                Level.PlayerLevel++;
        //                Stat.BaseAtk += 5;
        //                Stat.BaseDef += 3;
        //                Stat.Hp += 20;
        //                Stat.MaxHp += 20;
        //            }
        //            else if (Level.PlayerLevel == 8)
        //            {
        //                Level.PlayerLevel++;
        //                Stat.BaseAtk += 5;
        //                Stat.BaseDef += 3;
        //                Stat.Hp += 20;
        //                Stat.MaxHp += 20;
        //            }
        //            else if (Level.PlayerLevel == 9)
        //            {
        //                Level.PlayerLevel++;
        //                Stat.BaseAtk += 7;
        //                Stat.BaseDef += 3;
        //                Stat.Hp += 20;
        //                Stat.MaxHp += 20;
        //            }
        //            else
        //            {
        //                Level.PlayerLevel++;
        //                Stat.BaseAtk += 3;
        //                Stat.BaseDef += 1;
        //                Stat.Hp += 10;
        //                Stat.MaxHp += 10;
        //            }
        //            Console.WriteLine();
        //            Console.WriteLine($"Lv.{Level.PlayerLevel} -> Lv.{Level.PlayerLevel + 1}");
        //            Console.WriteLine();
        //        }
        //    }
        //}
        public void LevelUp()
        {
            int[] Exp = { 10, 12, 15, 30, 36, 40, 48, 54, 60 };

            while (Level.PlayerLevel < 10 && Level.PlayerLevel <= Exp.Length && Exp[Level.PlayerLevel - 1] <= CurrentExp)
            {
                int previousLevel = Level.PlayerLevel; // 레벨업 전 레벨 저장

                // 경험치 차감
                CurrentExp -= Exp[Level.PlayerLevel - 1];

                // 레벨업 로직
                if (Level.PlayerLevel == 4 || Level.PlayerLevel == 8)
                {
                    Level.PlayerLevel++;
                    Stat.BaseAtk += 5;
                    Stat.BaseDef += 3;
                    Stat.Hp += 20;
                    Stat.MaxHp += 20;
                }
                else if (Level.PlayerLevel == 9)
                {
                    Level.PlayerLevel++;
                    Stat.BaseAtk += 7;
                    Stat.BaseDef += 3;
                    Stat.Hp += 20;
                    Stat.MaxHp += 20;
                }
                else
                {
                    Level.PlayerLevel++;
                    Stat.BaseAtk += 3;
                    Stat.BaseDef += 1;
                    Stat.Hp += 10;
                    Stat.MaxHp += 10;
                }

                // 올바른 레벨업 메시지 출력
                Console.WriteLine();
                Console.WriteLine($"Lv.{previousLevel} -> Lv.{Level.PlayerLevel}");
                Console.WriteLine();
            }
        }




        public List<Skill> Playerskill = new List<Skill>();
    }
}

