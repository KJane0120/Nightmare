using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nightmare
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
        { }
        public int MonsterAttackToPlayer()
        {
            int EndDamage;

            EndDamage = MonsterAttack + (Level * 1);

            return EndDamage;

        }
        public String MonsterDIe(ref int DeathCount)
        {
            StringBuilder sb = new StringBuilder();


            if (MonsterHealth <= 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                sb.Append("Lv.").Append(Level).Append(" ").Append(Name).Append("Dead");
                Console.ResetColor();
                if (IsLive) // 이미 사망 처리된 몬스터라면 DeathCount 증가 방지
                {
                    IsLive = false;
                    DeathCount++; 
                }
                return sb.ToString();
            }
            else
            {
                return ToString();
            }
        }


        public Monster Monstersummon(int wei)
        {
            //몬스터들의 능력치들을 결정해줄 랜덤
            Random MonsterRandom = new Random();
            //잡몹들 이름
            String[] Name = { "난쟁이 형제들", "물고기", "언니 인어들", "성을 막는 가시덩쿨", "살아 움직이는 집기들", "호박마차" };
            Monster mons = new Monster(MonsterRandom.Next(25 +(wei *5), 35 + (wei * 5)), MonsterRandom.Next(5 + (wei * 5), 10 + (wei * 5)), 
                MonsterRandom.Next(5 + (wei * 5), 10 + (wei * 5)), Name[MonsterRandom.Next(0, 6)], MonsterRandom.Next(250 + (wei * 50), 750 + (wei * 50)));

            return mons;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Lv.").Append(Level).Append(" ").Append(Name).Append("Hp:").Append(MonsterHealth).Append("\n").Append("공격력").
                Append(MonsterAttack).Append("방어력").Append(MonsterDefense).Append("\n");
            return sb.ToString();
        }

        public void AttackedFromPlayer(Monster monster) //Player를 받게할 예정
        {

            if(monster.MonsterDefense >= 10)
            {
                monster.MonsterHealth -= 1;
                if(monster.MonsterHealth < 0)
                {
                    Console.WriteLine($"Lv.{monster.Level} {monster.Name}을 맟췄습니다. [데미지]");
                    Console.WriteLine($"Hp: {monster.MonsterHealth + 1} -> Dead");
                }
                else
                {
                      Console.WriteLine($"Lv.{monster.Level} {monster.Name}을 맟췄습니다. [데미지]");
                      Console.WriteLine($"Hp: {monster.MonsterHealth +1} -> {monster.MonsterHealth}"); //여기도
                }
            }
            else
            {
                monster.MonsterHealth -= 10 - monster.MonsterDefense;
                if (monster.MonsterHealth < 0)
                {
                    Console.WriteLine($"Lv.{monster.Level} {monster.Name}을 맟췄습니다. [데미지]");
                    Console.WriteLine($"Hp: {monster.MonsterHealth + 10 - monster.MonsterDefense} -> Dead");
                }
                else
                {
                    Console.WriteLine($"Lv.{monster.Level} {monster.Name}을 맟췄습니다. [데미지]");
                    Console.WriteLine($"Hp: {monster.MonsterHealth + 10 - monster.MonsterDefense} -> {monster.MonsterHealth}"); //여기도
                }
            }

            //if (IsLive)
            //{

            //    Console.WriteLine($"Lv.{monster.Level} {monster.Name}을 맟췄습니다. [데미지]");
            //    Console.WriteLine($"Hp: {monster.MonsterHealth} -> {monster.MonsterHealth}"); //여기도
            //}
            //else
            //{
            //    Console.WriteLine($"Lv.{monster.Level} {monster.Name}을 맟췄습니다. [데미지]");
            //    Console.WriteLine($"Hp: {monster.MonsterHealth} -> Dead");
            //}




        }
    }
}
