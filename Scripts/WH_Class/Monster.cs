using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nightmare.Scripts.WH_Class
{
    internal class Monster
    {
        public int Level { get; set; }
        public string Name { get; set; }
        public int MonsterHealth { get; set; }
        public int MonsterAttack { get; set; }
        public int MonsterDefense { get; set; }
        public bool IsLive { get; set; } //체력이 0이면 Fales

        public int MonsterMoney { get; set; }

        public Monster(int Health, int Attack, int Defense, String name, int MonsterMoney)
        {

            MonsterHealth = Health;
            MonsterAttack = Attack;
            MonsterDefense = Defense;
            this.MonsterMoney = MonsterMoney;
            Name = name;
            IsLive = true;

        }
        public Monster()
        {

        }
        public int MonsterAttackToPlayer()
        {
            int EndDamage;

            EndDamage = MonsterAttack + (Level * 1);

            return EndDamage;

        }
        public String MonsterDIe(int DeathCount)
        {
            StringBuilder sb = new StringBuilder();


            if (MonsterHealth < 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                sb.Append("Lv.").Append(Level).Append(" ").Append(Name).Append("  Dead");
                Console.ResetColor();
                IsLive = false;
                DeathCount++;
                return sb.ToString();
            }
            else
            {
                return ToString();
            }
        }


        public Monster Monstersummon()
        {
            //몬스터들의 능력치들을 결정해줄 랜덤
            Random MonsterRandom = new Random();
            //잡몹들 이름
            String[] Name = { "난쟁이 형제들", "물고기", "언니 인어들", "성을 막는 가시덩쿨", "살아 움직이는 집기들", "호박마차" };
            Monster mons = new Monster(MonsterRandom.Next(30, 50), MonsterRandom.Next(5, 10), MonsterRandom.Next(5, 10), Name[MonsterRandom.Next(0, 6)], MonsterRandom.Next(250, 750));

            return mons;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Lv.").Append(Level).Append(" ").Append(Name).Append("\t").Append("Hp:").Append(MonsterHealth);
            return sb.ToString();
        }

        public void AttackedFromPlayer() //Player를 받게할 예정
        {
            if (IsLive)
            {
                if (MonsterHealth > 0) //플레이어의 공격력으로 빼줘야함
                {
                    Console.WriteLine($"Lv.{Level} {Name}을 맟췄습니다. [데미지]");
                    Console.WriteLine($"Hp: {MonsterHealth} -> {MonsterHealth}"); //여기도
                }
                else
                {
                    Console.WriteLine($"Lv.{Level} {Name}을 맟췄습니다. [데미지]");
                    Console.WriteLine($"Hp: {MonsterHealth} -> Dead");
                }

            }


        }
    }
}
